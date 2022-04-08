using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Adapters;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Entities.Common.TPDM;
using Newtonsoft.Json;

// Aggregate: AccreditationStatusDescriptor

namespace EdFi.Ods.Entities.NHibernate.AccreditationStatusDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.AccreditationStatusDescriptor table of the AccreditationStatusDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class AccreditationStatusDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IAccreditationStatusDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IAccreditationStatusDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int AccreditationStatusDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("AccreditationStatusDescriptorId", AccreditationStatusDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IAccreditationStatusDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IAccreditationStatusDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IAccreditationStatusDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IAccreditationStatusDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IAccreditationStatusDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IAccreditationStatusDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IAccreditationStatusDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IAccreditationStatusDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IAccreditationStatusDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: AidTypeDescriptor

namespace EdFi.Ods.Entities.NHibernate.AidTypeDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.AidTypeDescriptor table of the AidTypeDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IAidTypeDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IAidTypeDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int AidTypeDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("AidTypeDescriptorId", AidTypeDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IAidTypeDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IAidTypeDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IAidTypeDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IAidTypeDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IAidTypeDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IAidTypeDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IAidTypeDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IAidTypeDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IAidTypeDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: Candidate

namespace EdFi.Ods.Entities.NHibernate.CandidateAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="Candidate"/> entity.
    /// </summary>
    public class CandidateReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string CandidateIdentifier { get; set; }
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
            keyValues.Add("CandidateIdentifier", CandidateIdentifier);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.Candidate table of the Candidate aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class Candidate : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.ICandidate, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public Candidate()
        {
            CandidateAddresses = new HashSet<CandidateAddress>();
            CandidateDisabilities = new HashSet<CandidateDisability>();
            CandidateElectronicMails = new HashSet<CandidateElectronicMail>();
            CandidateLanguages = new HashSet<CandidateLanguage>();
            CandidateOtherNames = new HashSet<CandidateOtherName>();
            CandidatePersonalIdentificationDocuments = new HashSet<CandidatePersonalIdentificationDocument>();
            CandidateRaces = new HashSet<CandidateRace>();
            CandidateTelephones = new HashSet<CandidateTelephone>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(32), NoDangerousText, NoWhitespace]
        public virtual string CandidateIdentifier  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [StringLength(30), NoDangerousText]
        public virtual string BirthCity  { get; set; }
        public virtual int? BirthCountryDescriptorId 
        {
            get
            {
                if (_birthCountryDescriptorId == default(int?))
                    _birthCountryDescriptorId = string.IsNullOrWhiteSpace(_birthCountryDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("CountryDescriptor", _birthCountryDescriptor);

                return _birthCountryDescriptorId;
            } 
            set
            {
                _birthCountryDescriptorId = value;
                _birthCountryDescriptor = null;
            }
        }

        private int? _birthCountryDescriptorId;
        private string _birthCountryDescriptor;

        public virtual string BirthCountryDescriptor
        {
            get
            {
                if (_birthCountryDescriptor == null)
                    _birthCountryDescriptor = _birthCountryDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("CountryDescriptor", _birthCountryDescriptorId.Value);
                    
                return _birthCountryDescriptor;
            }
            set
            {
                _birthCountryDescriptor = value;
                _birthCountryDescriptorId = default(int?);
            }
        }
        [RequiredWithNonDefault, SqlServerDateTimeRange]
        public virtual DateTime BirthDate 
        {
            get { return _birthDate; }
            //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
            set { _birthDate = new DateTime(value.Year, value.Month, value.Day); }
        }

        private DateTime _birthDate;
        
        [StringLength(150), NoDangerousText]
        public virtual string BirthInternationalProvince  { get; set; }
        public virtual int? BirthSexDescriptorId 
        {
            get
            {
                if (_birthSexDescriptorId == default(int?))
                    _birthSexDescriptorId = string.IsNullOrWhiteSpace(_birthSexDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("SexDescriptor", _birthSexDescriptor);

                return _birthSexDescriptorId;
            } 
            set
            {
                _birthSexDescriptorId = value;
                _birthSexDescriptor = null;
            }
        }

        private int? _birthSexDescriptorId;
        private string _birthSexDescriptor;

        public virtual string BirthSexDescriptor
        {
            get
            {
                if (_birthSexDescriptor == null)
                    _birthSexDescriptor = _birthSexDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("SexDescriptor", _birthSexDescriptorId.Value);
                    
                return _birthSexDescriptor;
            }
            set
            {
                _birthSexDescriptor = value;
                _birthSexDescriptorId = default(int?);
            }
        }
        public virtual int? BirthStateAbbreviationDescriptorId 
        {
            get
            {
                if (_birthStateAbbreviationDescriptorId == default(int?))
                    _birthStateAbbreviationDescriptorId = string.IsNullOrWhiteSpace(_birthStateAbbreviationDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("StateAbbreviationDescriptor", _birthStateAbbreviationDescriptor);

                return _birthStateAbbreviationDescriptorId;
            } 
            set
            {
                _birthStateAbbreviationDescriptorId = value;
                _birthStateAbbreviationDescriptor = null;
            }
        }

        private int? _birthStateAbbreviationDescriptorId;
        private string _birthStateAbbreviationDescriptor;

        public virtual string BirthStateAbbreviationDescriptor
        {
            get
            {
                if (_birthStateAbbreviationDescriptor == null)
                    _birthStateAbbreviationDescriptor = _birthStateAbbreviationDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("StateAbbreviationDescriptor", _birthStateAbbreviationDescriptorId.Value);
                    
                return _birthStateAbbreviationDescriptor;
            }
            set
            {
                _birthStateAbbreviationDescriptor = value;
                _birthStateAbbreviationDescriptorId = default(int?);
            }
        }
        [SqlServerDateTimeRange]
        public virtual DateTime? DateEnteredUS 
        {
            get { return _dateEnteredUS; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _dateEnteredUS = null;
                } else
                {
                    var given = (DateTime) value;
                    _dateEnteredUS = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _dateEnteredUS;
        
        [StringLength(30), NoDangerousText]
        public virtual string DisplacementStatus  { get; set; }
        public virtual bool? EconomicDisadvantaged  { get; set; }
        public virtual int? EnglishLanguageExamDescriptorId 
        {
            get
            {
                if (_englishLanguageExamDescriptorId == default(int?))
                    _englishLanguageExamDescriptorId = string.IsNullOrWhiteSpace(_englishLanguageExamDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("EnglishLanguageExamDescriptor", _englishLanguageExamDescriptor);

                return _englishLanguageExamDescriptorId;
            } 
            set
            {
                _englishLanguageExamDescriptorId = value;
                _englishLanguageExamDescriptor = null;
            }
        }

        private int? _englishLanguageExamDescriptorId;
        private string _englishLanguageExamDescriptor;

        public virtual string EnglishLanguageExamDescriptor
        {
            get
            {
                if (_englishLanguageExamDescriptor == null)
                    _englishLanguageExamDescriptor = _englishLanguageExamDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("EnglishLanguageExamDescriptor", _englishLanguageExamDescriptorId.Value);
                    
                return _englishLanguageExamDescriptor;
            }
            set
            {
                _englishLanguageExamDescriptor = value;
                _englishLanguageExamDescriptorId = default(int?);
            }
        }
        public virtual bool? FirstGenerationStudent  { get; set; }
        [RequiredWithNonDefault, StringLength(75), NoDangerousText]
        public virtual string FirstName  { get; set; }
        public virtual int? GenderDescriptorId 
        {
            get
            {
                if (_genderDescriptorId == default(int?))
                    _genderDescriptorId = string.IsNullOrWhiteSpace(_genderDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("GenderDescriptor", _genderDescriptor);

                return _genderDescriptorId;
            } 
            set
            {
                _genderDescriptorId = value;
                _genderDescriptor = null;
            }
        }

        private int? _genderDescriptorId;
        private string _genderDescriptor;

        public virtual string GenderDescriptor
        {
            get
            {
                if (_genderDescriptor == null)
                    _genderDescriptor = _genderDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("GenderDescriptor", _genderDescriptorId.Value);
                    
                return _genderDescriptor;
            }
            set
            {
                _genderDescriptor = value;
                _genderDescriptorId = default(int?);
            }
        }
        [StringLength(10), NoDangerousText]
        public virtual string GenerationCodeSuffix  { get; set; }
        public virtual bool? HispanicLatinoEthnicity  { get; set; }
        [RequiredWithNonDefault, StringLength(75), NoDangerousText]
        public virtual string LastSurname  { get; set; }
        public virtual int? LimitedEnglishProficiencyDescriptorId 
        {
            get
            {
                if (_limitedEnglishProficiencyDescriptorId == default(int?))
                    _limitedEnglishProficiencyDescriptorId = string.IsNullOrWhiteSpace(_limitedEnglishProficiencyDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("LimitedEnglishProficiencyDescriptor", _limitedEnglishProficiencyDescriptor);

                return _limitedEnglishProficiencyDescriptorId;
            } 
            set
            {
                _limitedEnglishProficiencyDescriptorId = value;
                _limitedEnglishProficiencyDescriptor = null;
            }
        }

        private int? _limitedEnglishProficiencyDescriptorId;
        private string _limitedEnglishProficiencyDescriptor;

        public virtual string LimitedEnglishProficiencyDescriptor
        {
            get
            {
                if (_limitedEnglishProficiencyDescriptor == null)
                    _limitedEnglishProficiencyDescriptor = _limitedEnglishProficiencyDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("LimitedEnglishProficiencyDescriptor", _limitedEnglishProficiencyDescriptorId.Value);
                    
                return _limitedEnglishProficiencyDescriptor;
            }
            set
            {
                _limitedEnglishProficiencyDescriptor = value;
                _limitedEnglishProficiencyDescriptorId = default(int?);
            }
        }
        [StringLength(75), NoDangerousText]
        public virtual string MaidenName  { get; set; }
        [StringLength(75), NoDangerousText]
        public virtual string MiddleName  { get; set; }
        public virtual bool? MultipleBirthStatus  { get; set; }
        [StringLength(30), NoDangerousText]
        public virtual string PersonalTitlePrefix  { get; set; }
        [StringLength(32), NoDangerousText]
        public virtual string PersonId  { get; set; }
        [RequiredWithNonDefault]
        public virtual int SexDescriptorId 
        {
            get
            {
                if (_sexDescriptorId == default(int))
                    _sexDescriptorId = DescriptorsCache.GetCache().GetId("SexDescriptor", _sexDescriptor);

                return _sexDescriptorId;
            } 
            set
            {
                _sexDescriptorId = value;
                _sexDescriptor = null;
            }
        }

        private int _sexDescriptorId;
        private string _sexDescriptor;

        public virtual string SexDescriptor
        {
            get
            {
                if (_sexDescriptor == null)
                    _sexDescriptor = DescriptorsCache.GetCache().GetValue("SexDescriptor", _sexDescriptorId);
                    
                return _sexDescriptor;
            }
            set
            {
                _sexDescriptor = value;
                _sexDescriptorId = default(int);
            }
        }
        public virtual int? SourceSystemDescriptorId 
        {
            get
            {
                if (_sourceSystemDescriptorId == default(int?))
                    _sourceSystemDescriptorId = string.IsNullOrWhiteSpace(_sourceSystemDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("SourceSystemDescriptor", _sourceSystemDescriptor);

                return _sourceSystemDescriptorId;
            } 
            set
            {
                _sourceSystemDescriptorId = value;
                _sourceSystemDescriptor = null;
            }
        }

        private int? _sourceSystemDescriptorId;
        private string _sourceSystemDescriptor;

        public virtual string SourceSystemDescriptor
        {
            get
            {
                if (_sourceSystemDescriptor == null)
                    _sourceSystemDescriptor = _sourceSystemDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("SourceSystemDescriptor", _sourceSystemDescriptorId.Value);
                    
                return _sourceSystemDescriptor;
            }
            set
            {
                _sourceSystemDescriptor = value;
                _sourceSystemDescriptorId = default(int?);
            }
        }
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
        public virtual NHibernate.PersonAggregate.EdFi.PersonReferenceData PersonReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Person discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.ICandidate.PersonDiscriminator
        {
            get { return PersonReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Person resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.ICandidate.PersonResourceId
        {
            get { return PersonReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateAddress> _candidateAddresses;
        private ICollection<Entities.Common.TPDM.ICandidateAddress> _candidateAddressesCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateAddress> CandidateAddresses
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateAddresses)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateAddresses;
            }
            set
            {
                _candidateAddresses = value;
                _candidateAddressesCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidateAddress, Entities.NHibernate.CandidateAggregate.TPDM.CandidateAddress>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidateAddress> Entities.Common.TPDM.ICandidate.CandidateAddresses
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateAddresses)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateAddressesCovariant;
            }
            set
            {
                CandidateAddresses = new HashSet<Entities.NHibernate.CandidateAggregate.TPDM.CandidateAddress>(value.Cast<Entities.NHibernate.CandidateAggregate.TPDM.CandidateAddress>());
            }
        }


        private ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateDisability> _candidateDisabilities;
        private ICollection<Entities.Common.TPDM.ICandidateDisability> _candidateDisabilitiesCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateDisability> CandidateDisabilities
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateDisabilities)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateDisabilities;
            }
            set
            {
                _candidateDisabilities = value;
                _candidateDisabilitiesCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidateDisability, Entities.NHibernate.CandidateAggregate.TPDM.CandidateDisability>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidateDisability> Entities.Common.TPDM.ICandidate.CandidateDisabilities
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateDisabilities)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateDisabilitiesCovariant;
            }
            set
            {
                CandidateDisabilities = new HashSet<Entities.NHibernate.CandidateAggregate.TPDM.CandidateDisability>(value.Cast<Entities.NHibernate.CandidateAggregate.TPDM.CandidateDisability>());
            }
        }


        private ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateElectronicMail> _candidateElectronicMails;
        private ICollection<Entities.Common.TPDM.ICandidateElectronicMail> _candidateElectronicMailsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateElectronicMail> CandidateElectronicMails
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateElectronicMails)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateElectronicMails;
            }
            set
            {
                _candidateElectronicMails = value;
                _candidateElectronicMailsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidateElectronicMail, Entities.NHibernate.CandidateAggregate.TPDM.CandidateElectronicMail>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidateElectronicMail> Entities.Common.TPDM.ICandidate.CandidateElectronicMails
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateElectronicMails)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateElectronicMailsCovariant;
            }
            set
            {
                CandidateElectronicMails = new HashSet<Entities.NHibernate.CandidateAggregate.TPDM.CandidateElectronicMail>(value.Cast<Entities.NHibernate.CandidateAggregate.TPDM.CandidateElectronicMail>());
            }
        }


        private ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateLanguage> _candidateLanguages;
        private ICollection<Entities.Common.TPDM.ICandidateLanguage> _candidateLanguagesCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateLanguage> CandidateLanguages
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateLanguages)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateLanguages;
            }
            set
            {
                _candidateLanguages = value;
                _candidateLanguagesCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidateLanguage, Entities.NHibernate.CandidateAggregate.TPDM.CandidateLanguage>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidateLanguage> Entities.Common.TPDM.ICandidate.CandidateLanguages
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateLanguages)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateLanguagesCovariant;
            }
            set
            {
                CandidateLanguages = new HashSet<Entities.NHibernate.CandidateAggregate.TPDM.CandidateLanguage>(value.Cast<Entities.NHibernate.CandidateAggregate.TPDM.CandidateLanguage>());
            }
        }


        private ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateOtherName> _candidateOtherNames;
        private ICollection<Entities.Common.TPDM.ICandidateOtherName> _candidateOtherNamesCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateOtherName> CandidateOtherNames
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateOtherNames)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateOtherNames;
            }
            set
            {
                _candidateOtherNames = value;
                _candidateOtherNamesCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidateOtherName, Entities.NHibernate.CandidateAggregate.TPDM.CandidateOtherName>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidateOtherName> Entities.Common.TPDM.ICandidate.CandidateOtherNames
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateOtherNames)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateOtherNamesCovariant;
            }
            set
            {
                CandidateOtherNames = new HashSet<Entities.NHibernate.CandidateAggregate.TPDM.CandidateOtherName>(value.Cast<Entities.NHibernate.CandidateAggregate.TPDM.CandidateOtherName>());
            }
        }


        private ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidatePersonalIdentificationDocument> _candidatePersonalIdentificationDocuments;
        private ICollection<Entities.Common.TPDM.ICandidatePersonalIdentificationDocument> _candidatePersonalIdentificationDocumentsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidatePersonalIdentificationDocument> CandidatePersonalIdentificationDocuments
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidatePersonalIdentificationDocuments)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidatePersonalIdentificationDocuments;
            }
            set
            {
                _candidatePersonalIdentificationDocuments = value;
                _candidatePersonalIdentificationDocumentsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidatePersonalIdentificationDocument, Entities.NHibernate.CandidateAggregate.TPDM.CandidatePersonalIdentificationDocument>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidatePersonalIdentificationDocument> Entities.Common.TPDM.ICandidate.CandidatePersonalIdentificationDocuments
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidatePersonalIdentificationDocuments)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidatePersonalIdentificationDocumentsCovariant;
            }
            set
            {
                CandidatePersonalIdentificationDocuments = new HashSet<Entities.NHibernate.CandidateAggregate.TPDM.CandidatePersonalIdentificationDocument>(value.Cast<Entities.NHibernate.CandidateAggregate.TPDM.CandidatePersonalIdentificationDocument>());
            }
        }


        private ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateRace> _candidateRaces;
        private ICollection<Entities.Common.TPDM.ICandidateRace> _candidateRacesCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateRace> CandidateRaces
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateRaces)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateRaces;
            }
            set
            {
                _candidateRaces = value;
                _candidateRacesCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidateRace, Entities.NHibernate.CandidateAggregate.TPDM.CandidateRace>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidateRace> Entities.Common.TPDM.ICandidate.CandidateRaces
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateRaces)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateRacesCovariant;
            }
            set
            {
                CandidateRaces = new HashSet<Entities.NHibernate.CandidateAggregate.TPDM.CandidateRace>(value.Cast<Entities.NHibernate.CandidateAggregate.TPDM.CandidateRace>());
            }
        }


        private ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateTelephone> _candidateTelephones;
        private ICollection<Entities.Common.TPDM.ICandidateTelephone> _candidateTelephonesCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateTelephone> CandidateTelephones
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateTelephones)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateTelephones;
            }
            set
            {
                _candidateTelephones = value;
                _candidateTelephonesCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidateTelephone, Entities.NHibernate.CandidateAggregate.TPDM.CandidateTelephone>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidateTelephone> Entities.Common.TPDM.ICandidate.CandidateTelephones
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateTelephones)
                    if (item.Candidate == null)
                        item.Candidate = this;
                // -------------------------------------------------------------

                return _candidateTelephonesCovariant;
            }
            set
            {
                CandidateTelephones = new HashSet<Entities.NHibernate.CandidateAggregate.TPDM.CandidateTelephone>(value.Cast<Entities.NHibernate.CandidateAggregate.TPDM.CandidateTelephone>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "BirthCountryDescriptor", new LookupColumnDetails { PropertyName = "BirthCountryDescriptorId", LookupTypeName = "CountryDescriptor"} },
                { "BirthSexDescriptor", new LookupColumnDetails { PropertyName = "BirthSexDescriptorId", LookupTypeName = "SexDescriptor"} },
                { "BirthStateAbbreviationDescriptor", new LookupColumnDetails { PropertyName = "BirthStateAbbreviationDescriptorId", LookupTypeName = "StateAbbreviationDescriptor"} },
                { "EnglishLanguageExamDescriptor", new LookupColumnDetails { PropertyName = "EnglishLanguageExamDescriptorId", LookupTypeName = "EnglishLanguageExamDescriptor"} },
                { "GenderDescriptor", new LookupColumnDetails { PropertyName = "GenderDescriptorId", LookupTypeName = "GenderDescriptor"} },
                { "LimitedEnglishProficiencyDescriptor", new LookupColumnDetails { PropertyName = "LimitedEnglishProficiencyDescriptorId", LookupTypeName = "LimitedEnglishProficiencyDescriptor"} },
                { "SexDescriptor", new LookupColumnDetails { PropertyName = "SexDescriptorId", LookupTypeName = "SexDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
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
            keyValues.Add("CandidateIdentifier", CandidateIdentifier);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidate)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidate) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isBirthCitySupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsBirthCitySupported
        {
            get { return _isBirthCitySupported; }
            set { _isBirthCitySupported = value; }
        }

        private bool _isBirthCountryDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsBirthCountryDescriptorSupported
        {
            get { return _isBirthCountryDescriptorSupported; }
            set { _isBirthCountryDescriptorSupported = value; }
        }

        private bool _isBirthDateSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsBirthDateSupported
        {
            get { return _isBirthDateSupported; }
            set { _isBirthDateSupported = value; }
        }

        private bool _isBirthInternationalProvinceSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsBirthInternationalProvinceSupported
        {
            get { return _isBirthInternationalProvinceSupported; }
            set { _isBirthInternationalProvinceSupported = value; }
        }

        private bool _isBirthSexDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsBirthSexDescriptorSupported
        {
            get { return _isBirthSexDescriptorSupported; }
            set { _isBirthSexDescriptorSupported = value; }
        }

        private bool _isBirthStateAbbreviationDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsBirthStateAbbreviationDescriptorSupported
        {
            get { return _isBirthStateAbbreviationDescriptorSupported; }
            set { _isBirthStateAbbreviationDescriptorSupported = value; }
        }

        private bool _isCandidateAddressesSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateAddressesSupported
        {
            get { return _isCandidateAddressesSupported; }
            set { _isCandidateAddressesSupported = value; }
        }

        private bool _isCandidateDisabilitiesSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateDisabilitiesSupported
        {
            get { return _isCandidateDisabilitiesSupported; }
            set { _isCandidateDisabilitiesSupported = value; }
        }

        private bool _isCandidateElectronicMailsSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateElectronicMailsSupported
        {
            get { return _isCandidateElectronicMailsSupported; }
            set { _isCandidateElectronicMailsSupported = value; }
        }

        private bool _isCandidateLanguagesSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateLanguagesSupported
        {
            get { return _isCandidateLanguagesSupported; }
            set { _isCandidateLanguagesSupported = value; }
        }

        private bool _isCandidateOtherNamesSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateOtherNamesSupported
        {
            get { return _isCandidateOtherNamesSupported; }
            set { _isCandidateOtherNamesSupported = value; }
        }

        private bool _isCandidatePersonalIdentificationDocumentsSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidatePersonalIdentificationDocumentsSupported
        {
            get { return _isCandidatePersonalIdentificationDocumentsSupported; }
            set { _isCandidatePersonalIdentificationDocumentsSupported = value; }
        }

        private bool _isCandidateRacesSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateRacesSupported
        {
            get { return _isCandidateRacesSupported; }
            set { _isCandidateRacesSupported = value; }
        }

        private bool _isCandidateTelephonesSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateTelephonesSupported
        {
            get { return _isCandidateTelephonesSupported; }
            set { _isCandidateTelephonesSupported = value; }
        }

        private bool _isDateEnteredUSSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsDateEnteredUSSupported
        {
            get { return _isDateEnteredUSSupported; }
            set { _isDateEnteredUSSupported = value; }
        }

        private bool _isDisplacementStatusSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsDisplacementStatusSupported
        {
            get { return _isDisplacementStatusSupported; }
            set { _isDisplacementStatusSupported = value; }
        }

        private bool _isEconomicDisadvantagedSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsEconomicDisadvantagedSupported
        {
            get { return _isEconomicDisadvantagedSupported; }
            set { _isEconomicDisadvantagedSupported = value; }
        }

        private bool _isEnglishLanguageExamDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsEnglishLanguageExamDescriptorSupported
        {
            get { return _isEnglishLanguageExamDescriptorSupported; }
            set { _isEnglishLanguageExamDescriptorSupported = value; }
        }

        private bool _isFirstGenerationStudentSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsFirstGenerationStudentSupported
        {
            get { return _isFirstGenerationStudentSupported; }
            set { _isFirstGenerationStudentSupported = value; }
        }

        private bool _isFirstNameSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsFirstNameSupported
        {
            get { return _isFirstNameSupported; }
            set { _isFirstNameSupported = value; }
        }

        private bool _isGenderDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsGenderDescriptorSupported
        {
            get { return _isGenderDescriptorSupported; }
            set { _isGenderDescriptorSupported = value; }
        }

        private bool _isGenerationCodeSuffixSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsGenerationCodeSuffixSupported
        {
            get { return _isGenerationCodeSuffixSupported; }
            set { _isGenerationCodeSuffixSupported = value; }
        }

        private bool _isHispanicLatinoEthnicitySupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsHispanicLatinoEthnicitySupported
        {
            get { return _isHispanicLatinoEthnicitySupported; }
            set { _isHispanicLatinoEthnicitySupported = value; }
        }

        private bool _isLastSurnameSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsLastSurnameSupported
        {
            get { return _isLastSurnameSupported; }
            set { _isLastSurnameSupported = value; }
        }

        private bool _isLimitedEnglishProficiencyDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsLimitedEnglishProficiencyDescriptorSupported
        {
            get { return _isLimitedEnglishProficiencyDescriptorSupported; }
            set { _isLimitedEnglishProficiencyDescriptorSupported = value; }
        }

        private bool _isMaidenNameSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsMaidenNameSupported
        {
            get { return _isMaidenNameSupported; }
            set { _isMaidenNameSupported = value; }
        }

        private bool _isMiddleNameSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsMiddleNameSupported
        {
            get { return _isMiddleNameSupported; }
            set { _isMiddleNameSupported = value; }
        }

        private bool _isMultipleBirthStatusSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsMultipleBirthStatusSupported
        {
            get { return _isMultipleBirthStatusSupported; }
            set { _isMultipleBirthStatusSupported = value; }
        }

        private bool _isPersonalTitlePrefixSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsPersonalTitlePrefixSupported
        {
            get { return _isPersonalTitlePrefixSupported; }
            set { _isPersonalTitlePrefixSupported = value; }
        }

        private bool _isPersonIdSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsPersonIdSupported
        {
            get { return _isPersonIdSupported; }
            set { _isPersonIdSupported = value; }
        }

        private bool _isSexDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsSexDescriptorSupported
        {
            get { return _isSexDescriptorSupported; }
            set { _isSexDescriptorSupported = value; }
        }

        private bool _isSourceSystemDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsSourceSystemDescriptorSupported
        {
            get { return _isSourceSystemDescriptorSupported; }
            set { _isSourceSystemDescriptorSupported = value; }
        }

        private Func<Entities.Common.TPDM.ICandidateAddress, bool> _isCandidateAddressIncluded;
        Func<Entities.Common.TPDM.ICandidateAddress, bool> Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateAddressIncluded
        {
            get { return _isCandidateAddressIncluded; }
            set { _isCandidateAddressIncluded = value; }
        }

        private Func<Entities.Common.TPDM.ICandidateDisability, bool> _isCandidateDisabilityIncluded;
        Func<Entities.Common.TPDM.ICandidateDisability, bool> Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateDisabilityIncluded
        {
            get { return _isCandidateDisabilityIncluded; }
            set { _isCandidateDisabilityIncluded = value; }
        }

        private Func<Entities.Common.TPDM.ICandidateElectronicMail, bool> _isCandidateElectronicMailIncluded;
        Func<Entities.Common.TPDM.ICandidateElectronicMail, bool> Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateElectronicMailIncluded
        {
            get { return _isCandidateElectronicMailIncluded; }
            set { _isCandidateElectronicMailIncluded = value; }
        }

        private Func<Entities.Common.TPDM.ICandidateLanguage, bool> _isCandidateLanguageIncluded;
        Func<Entities.Common.TPDM.ICandidateLanguage, bool> Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateLanguageIncluded
        {
            get { return _isCandidateLanguageIncluded; }
            set { _isCandidateLanguageIncluded = value; }
        }

        private Func<Entities.Common.TPDM.ICandidateOtherName, bool> _isCandidateOtherNameIncluded;
        Func<Entities.Common.TPDM.ICandidateOtherName, bool> Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateOtherNameIncluded
        {
            get { return _isCandidateOtherNameIncluded; }
            set { _isCandidateOtherNameIncluded = value; }
        }

        private Func<Entities.Common.TPDM.ICandidatePersonalIdentificationDocument, bool> _isCandidatePersonalIdentificationDocumentIncluded;
        Func<Entities.Common.TPDM.ICandidatePersonalIdentificationDocument, bool> Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidatePersonalIdentificationDocumentIncluded
        {
            get { return _isCandidatePersonalIdentificationDocumentIncluded; }
            set { _isCandidatePersonalIdentificationDocumentIncluded = value; }
        }

        private Func<Entities.Common.TPDM.ICandidateRace, bool> _isCandidateRaceIncluded;
        Func<Entities.Common.TPDM.ICandidateRace, bool> Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateRaceIncluded
        {
            get { return _isCandidateRaceIncluded; }
            set { _isCandidateRaceIncluded = value; }
        }

        private Func<Entities.Common.TPDM.ICandidateTelephone, bool> _isCandidateTelephoneIncluded;
        Func<Entities.Common.TPDM.ICandidateTelephone, bool> Entities.Common.TPDM.ICandidateSynchronizationSourceSupport.IsCandidateTelephoneIncluded
        {
            get { return _isCandidateTelephoneIncluded; }
            set { _isCandidateTelephoneIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateAddress table of the Candidate aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateAddress : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidateAddress, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateAddressSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateAddress()
        {
            CandidateAddressPeriods = new HashSet<CandidateAddressPeriod>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Candidate Candidate { get; set; }

        Entities.Common.TPDM.ICandidate ICandidateAddress.Candidate
        {
            get { return Candidate; }
            set { Candidate = (Candidate) value; }
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
        [DomainSignature, RequiredWithNonDefault, StringLength(30), NoDangerousText, NoWhitespace]
        public virtual string City  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(17), NoDangerousText, NoWhitespace]
        public virtual string PostalCode  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
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
        [DomainSignature, RequiredWithNonDefault, StringLength(150), NoDangerousText, NoWhitespace]
        public virtual string StreetNumberName  { get; set; }
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
        [StringLength(20), NoDangerousText]
        public virtual string BuildingSiteNumber  { get; set; }
        [StringLength(30), NoDangerousText]
        public virtual string CongressionalDistrict  { get; set; }
        [StringLength(5), NoDangerousText]
        public virtual string CountyFIPSCode  { get; set; }
        public virtual bool? DoNotPublishIndicator  { get; set; }
        [StringLength(20), NoDangerousText]
        public virtual string Latitude  { get; set; }
        public virtual int? LocaleDescriptorId 
        {
            get
            {
                if (_localeDescriptorId == default(int?))
                    _localeDescriptorId = string.IsNullOrWhiteSpace(_localeDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("LocaleDescriptor", _localeDescriptor);

                return _localeDescriptorId;
            } 
            set
            {
                _localeDescriptorId = value;
                _localeDescriptor = null;
            }
        }

        private int? _localeDescriptorId;
        private string _localeDescriptor;

        public virtual string LocaleDescriptor
        {
            get
            {
                if (_localeDescriptor == null)
                    _localeDescriptor = _localeDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("LocaleDescriptor", _localeDescriptorId.Value);
                    
                return _localeDescriptor;
            }
            set
            {
                _localeDescriptor = value;
                _localeDescriptorId = default(int?);
            }
        }
        [StringLength(20), NoDangerousText]
        public virtual string Longitude  { get; set; }
        [StringLength(30), NoDangerousText]
        public virtual string NameOfCounty  { get; set; }
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

        private ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateAddressPeriod> _candidateAddressPeriods;
        private ICollection<Entities.Common.TPDM.ICandidateAddressPeriod> _candidateAddressPeriodsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateAddressPeriod> CandidateAddressPeriods
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateAddressPeriods)
                    if (item.CandidateAddress == null)
                        item.CandidateAddress = this;
                // -------------------------------------------------------------

                return _candidateAddressPeriods;
            }
            set
            {
                _candidateAddressPeriods = value;
                _candidateAddressPeriodsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidateAddressPeriod, Entities.NHibernate.CandidateAggregate.TPDM.CandidateAddressPeriod>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidateAddressPeriod> Entities.Common.TPDM.ICandidateAddress.CandidateAddressPeriods
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateAddressPeriods)
                    if (item.CandidateAddress == null)
                        item.CandidateAddress = this;
                // -------------------------------------------------------------

                return _candidateAddressPeriodsCovariant;
            }
            set
            {
                CandidateAddressPeriods = new HashSet<Entities.NHibernate.CandidateAggregate.TPDM.CandidateAddressPeriod>(value.Cast<Entities.NHibernate.CandidateAggregate.TPDM.CandidateAddressPeriod>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "AddressTypeDescriptor", new LookupColumnDetails { PropertyName = "AddressTypeDescriptorId", LookupTypeName = "AddressTypeDescriptor"} },
                { "LocaleDescriptor", new LookupColumnDetails { PropertyName = "LocaleDescriptorId", LookupTypeName = "LocaleDescriptor"} },
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
            var keyValues = (Candidate as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("AddressTypeDescriptorId", AddressTypeDescriptorId);
            keyValues.Add("City", City);
            keyValues.Add("PostalCode", PostalCode);
            keyValues.Add("StateAbbreviationDescriptorId", StateAbbreviationDescriptorId);
            keyValues.Add("StreetNumberName", StreetNumberName);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateAddress)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateAddress) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Candidate = (Candidate) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isApartmentRoomSuiteNumberSupported = true;
        bool Entities.Common.TPDM.ICandidateAddressSynchronizationSourceSupport.IsApartmentRoomSuiteNumberSupported
        {
            get { return _isApartmentRoomSuiteNumberSupported; }
            set { _isApartmentRoomSuiteNumberSupported = value; }
        }

        private bool _isBuildingSiteNumberSupported = true;
        bool Entities.Common.TPDM.ICandidateAddressSynchronizationSourceSupport.IsBuildingSiteNumberSupported
        {
            get { return _isBuildingSiteNumberSupported; }
            set { _isBuildingSiteNumberSupported = value; }
        }

        private bool _isCandidateAddressPeriodsSupported = true;
        bool Entities.Common.TPDM.ICandidateAddressSynchronizationSourceSupport.IsCandidateAddressPeriodsSupported
        {
            get { return _isCandidateAddressPeriodsSupported; }
            set { _isCandidateAddressPeriodsSupported = value; }
        }

        private bool _isCongressionalDistrictSupported = true;
        bool Entities.Common.TPDM.ICandidateAddressSynchronizationSourceSupport.IsCongressionalDistrictSupported
        {
            get { return _isCongressionalDistrictSupported; }
            set { _isCongressionalDistrictSupported = value; }
        }

        private bool _isCountyFIPSCodeSupported = true;
        bool Entities.Common.TPDM.ICandidateAddressSynchronizationSourceSupport.IsCountyFIPSCodeSupported
        {
            get { return _isCountyFIPSCodeSupported; }
            set { _isCountyFIPSCodeSupported = value; }
        }

        private bool _isDoNotPublishIndicatorSupported = true;
        bool Entities.Common.TPDM.ICandidateAddressSynchronizationSourceSupport.IsDoNotPublishIndicatorSupported
        {
            get { return _isDoNotPublishIndicatorSupported; }
            set { _isDoNotPublishIndicatorSupported = value; }
        }

        private bool _isLatitudeSupported = true;
        bool Entities.Common.TPDM.ICandidateAddressSynchronizationSourceSupport.IsLatitudeSupported
        {
            get { return _isLatitudeSupported; }
            set { _isLatitudeSupported = value; }
        }

        private bool _isLocaleDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateAddressSynchronizationSourceSupport.IsLocaleDescriptorSupported
        {
            get { return _isLocaleDescriptorSupported; }
            set { _isLocaleDescriptorSupported = value; }
        }

        private bool _isLongitudeSupported = true;
        bool Entities.Common.TPDM.ICandidateAddressSynchronizationSourceSupport.IsLongitudeSupported
        {
            get { return _isLongitudeSupported; }
            set { _isLongitudeSupported = value; }
        }

        private bool _isNameOfCountySupported = true;
        bool Entities.Common.TPDM.ICandidateAddressSynchronizationSourceSupport.IsNameOfCountySupported
        {
            get { return _isNameOfCountySupported; }
            set { _isNameOfCountySupported = value; }
        }

        private Func<Entities.Common.TPDM.ICandidateAddressPeriod, bool> _isCandidateAddressPeriodIncluded;
        Func<Entities.Common.TPDM.ICandidateAddressPeriod, bool> Entities.Common.TPDM.ICandidateAddressSynchronizationSourceSupport.IsCandidateAddressPeriodIncluded
        {
            get { return _isCandidateAddressPeriodIncluded; }
            set { _isCandidateAddressPeriodIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateAddressPeriod table of the Candidate aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateAddressPeriod : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidateAddressPeriod, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateAddressPeriodSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateAddressPeriod()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual CandidateAddress CandidateAddress { get; set; }

        Entities.Common.TPDM.ICandidateAddress ICandidateAddressPeriod.CandidateAddress
        {
            get { return CandidateAddress; }
            set { CandidateAddress = (CandidateAddress) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual DateTime BeginDate 
        {
            get { return _beginDate; }
            //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
            set { _beginDate = new DateTime(value.Year, value.Month, value.Day); }
        }

        private DateTime _beginDate;
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            var keyValues = (CandidateAddress as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("BeginDate", BeginDate);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateAddressPeriod)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateAddressPeriod) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            CandidateAddress = (CandidateAddress) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isEndDateSupported = true;
        bool Entities.Common.TPDM.ICandidateAddressPeriodSynchronizationSourceSupport.IsEndDateSupported
        {
            get { return _isEndDateSupported; }
            set { _isEndDateSupported = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateDisability table of the Candidate aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateDisability : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidateDisability, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateDisabilitySynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateDisability()
        {
            CandidateDisabilityDesignations = new HashSet<CandidateDisabilityDesignation>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Candidate Candidate { get; set; }

        Entities.Common.TPDM.ICandidate ICandidateDisability.Candidate
        {
            get { return Candidate; }
            set { Candidate = (Candidate) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int DisabilityDescriptorId 
        {
            get
            {
                if (_disabilityDescriptorId == default(int))
                    _disabilityDescriptorId = DescriptorsCache.GetCache().GetId("DisabilityDescriptor", _disabilityDescriptor);

                return _disabilityDescriptorId;
            } 
            set
            {
                _disabilityDescriptorId = value;
                _disabilityDescriptor = null;
            }
        }

        private int _disabilityDescriptorId;
        private string _disabilityDescriptor;

        public virtual string DisabilityDescriptor
        {
            get
            {
                if (_disabilityDescriptor == null)
                    _disabilityDescriptor = DescriptorsCache.GetCache().GetValue("DisabilityDescriptor", _disabilityDescriptorId);
                    
                return _disabilityDescriptor;
            }
            set
            {
                _disabilityDescriptor = value;
                _disabilityDescriptorId = default(int);
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
        public virtual int? DisabilityDeterminationSourceTypeDescriptorId 
        {
            get
            {
                if (_disabilityDeterminationSourceTypeDescriptorId == default(int?))
                    _disabilityDeterminationSourceTypeDescriptorId = string.IsNullOrWhiteSpace(_disabilityDeterminationSourceTypeDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("DisabilityDeterminationSourceTypeDescriptor", _disabilityDeterminationSourceTypeDescriptor);

                return _disabilityDeterminationSourceTypeDescriptorId;
            } 
            set
            {
                _disabilityDeterminationSourceTypeDescriptorId = value;
                _disabilityDeterminationSourceTypeDescriptor = null;
            }
        }

        private int? _disabilityDeterminationSourceTypeDescriptorId;
        private string _disabilityDeterminationSourceTypeDescriptor;

        public virtual string DisabilityDeterminationSourceTypeDescriptor
        {
            get
            {
                if (_disabilityDeterminationSourceTypeDescriptor == null)
                    _disabilityDeterminationSourceTypeDescriptor = _disabilityDeterminationSourceTypeDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("DisabilityDeterminationSourceTypeDescriptor", _disabilityDeterminationSourceTypeDescriptorId.Value);
                    
                return _disabilityDeterminationSourceTypeDescriptor;
            }
            set
            {
                _disabilityDeterminationSourceTypeDescriptor = value;
                _disabilityDeterminationSourceTypeDescriptorId = default(int?);
            }
        }
        [StringLength(80), NoDangerousText]
        public virtual string DisabilityDiagnosis  { get; set; }
        public virtual int? OrderOfDisability  { get; set; }
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

        private ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateDisabilityDesignation> _candidateDisabilityDesignations;
        private ICollection<Entities.Common.TPDM.ICandidateDisabilityDesignation> _candidateDisabilityDesignationsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateDisabilityDesignation> CandidateDisabilityDesignations
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateDisabilityDesignations)
                    if (item.CandidateDisability == null)
                        item.CandidateDisability = this;
                // -------------------------------------------------------------

                return _candidateDisabilityDesignations;
            }
            set
            {
                _candidateDisabilityDesignations = value;
                _candidateDisabilityDesignationsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidateDisabilityDesignation, Entities.NHibernate.CandidateAggregate.TPDM.CandidateDisabilityDesignation>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidateDisabilityDesignation> Entities.Common.TPDM.ICandidateDisability.CandidateDisabilityDesignations
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateDisabilityDesignations)
                    if (item.CandidateDisability == null)
                        item.CandidateDisability = this;
                // -------------------------------------------------------------

                return _candidateDisabilityDesignationsCovariant;
            }
            set
            {
                CandidateDisabilityDesignations = new HashSet<Entities.NHibernate.CandidateAggregate.TPDM.CandidateDisabilityDesignation>(value.Cast<Entities.NHibernate.CandidateAggregate.TPDM.CandidateDisabilityDesignation>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "DisabilityDescriptor", new LookupColumnDetails { PropertyName = "DisabilityDescriptorId", LookupTypeName = "DisabilityDescriptor"} },
                { "DisabilityDeterminationSourceTypeDescriptor", new LookupColumnDetails { PropertyName = "DisabilityDeterminationSourceTypeDescriptorId", LookupTypeName = "DisabilityDeterminationSourceTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Candidate as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("DisabilityDescriptorId", DisabilityDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateDisability)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateDisability) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Candidate = (Candidate) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCandidateDisabilityDesignationsSupported = true;
        bool Entities.Common.TPDM.ICandidateDisabilitySynchronizationSourceSupport.IsCandidateDisabilityDesignationsSupported
        {
            get { return _isCandidateDisabilityDesignationsSupported; }
            set { _isCandidateDisabilityDesignationsSupported = value; }
        }

        private bool _isDisabilityDeterminationSourceTypeDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateDisabilitySynchronizationSourceSupport.IsDisabilityDeterminationSourceTypeDescriptorSupported
        {
            get { return _isDisabilityDeterminationSourceTypeDescriptorSupported; }
            set { _isDisabilityDeterminationSourceTypeDescriptorSupported = value; }
        }

        private bool _isDisabilityDiagnosisSupported = true;
        bool Entities.Common.TPDM.ICandidateDisabilitySynchronizationSourceSupport.IsDisabilityDiagnosisSupported
        {
            get { return _isDisabilityDiagnosisSupported; }
            set { _isDisabilityDiagnosisSupported = value; }
        }

        private bool _isOrderOfDisabilitySupported = true;
        bool Entities.Common.TPDM.ICandidateDisabilitySynchronizationSourceSupport.IsOrderOfDisabilitySupported
        {
            get { return _isOrderOfDisabilitySupported; }
            set { _isOrderOfDisabilitySupported = value; }
        }

        private Func<Entities.Common.TPDM.ICandidateDisabilityDesignation, bool> _isCandidateDisabilityDesignationIncluded;
        Func<Entities.Common.TPDM.ICandidateDisabilityDesignation, bool> Entities.Common.TPDM.ICandidateDisabilitySynchronizationSourceSupport.IsCandidateDisabilityDesignationIncluded
        {
            get { return _isCandidateDisabilityDesignationIncluded; }
            set { _isCandidateDisabilityDesignationIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateDisabilityDesignation table of the Candidate aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateDisabilityDesignation : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidateDisabilityDesignation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateDisabilityDesignationSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateDisabilityDesignation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual CandidateDisability CandidateDisability { get; set; }

        Entities.Common.TPDM.ICandidateDisability ICandidateDisabilityDesignation.CandidateDisability
        {
            get { return CandidateDisability; }
            set { CandidateDisability = (CandidateDisability) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int DisabilityDesignationDescriptorId 
        {
            get
            {
                if (_disabilityDesignationDescriptorId == default(int))
                    _disabilityDesignationDescriptorId = DescriptorsCache.GetCache().GetId("DisabilityDesignationDescriptor", _disabilityDesignationDescriptor);

                return _disabilityDesignationDescriptorId;
            } 
            set
            {
                _disabilityDesignationDescriptorId = value;
                _disabilityDesignationDescriptor = null;
            }
        }

        private int _disabilityDesignationDescriptorId;
        private string _disabilityDesignationDescriptor;

        public virtual string DisabilityDesignationDescriptor
        {
            get
            {
                if (_disabilityDesignationDescriptor == null)
                    _disabilityDesignationDescriptor = DescriptorsCache.GetCache().GetValue("DisabilityDesignationDescriptor", _disabilityDesignationDescriptorId);
                    
                return _disabilityDesignationDescriptor;
            }
            set
            {
                _disabilityDesignationDescriptor = value;
                _disabilityDesignationDescriptorId = default(int);
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
                { "DisabilityDescriptor", new LookupColumnDetails { PropertyName = "DisabilityDescriptorId", LookupTypeName = "DisabilityDescriptor"} },
                { "DisabilityDesignationDescriptor", new LookupColumnDetails { PropertyName = "DisabilityDesignationDescriptorId", LookupTypeName = "DisabilityDesignationDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (CandidateDisability as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("DisabilityDesignationDescriptorId", DisabilityDesignationDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateDisabilityDesignation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateDisabilityDesignation) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            CandidateDisability = (CandidateDisability) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateElectronicMail table of the Candidate aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateElectronicMail : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidateElectronicMail, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateElectronicMailSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateElectronicMail()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Candidate Candidate { get; set; }

        Entities.Common.TPDM.ICandidate ICandidateElectronicMail.Candidate
        {
            get { return Candidate; }
            set { Candidate = (Candidate) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(128), NoDangerousText, NoWhitespace]
        public virtual string ElectronicMailAddress  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int ElectronicMailTypeDescriptorId 
        {
            get
            {
                if (_electronicMailTypeDescriptorId == default(int))
                    _electronicMailTypeDescriptorId = DescriptorsCache.GetCache().GetId("ElectronicMailTypeDescriptor", _electronicMailTypeDescriptor);

                return _electronicMailTypeDescriptorId;
            } 
            set
            {
                _electronicMailTypeDescriptorId = value;
                _electronicMailTypeDescriptor = null;
            }
        }

        private int _electronicMailTypeDescriptorId;
        private string _electronicMailTypeDescriptor;

        public virtual string ElectronicMailTypeDescriptor
        {
            get
            {
                if (_electronicMailTypeDescriptor == null)
                    _electronicMailTypeDescriptor = DescriptorsCache.GetCache().GetValue("ElectronicMailTypeDescriptor", _electronicMailTypeDescriptorId);
                    
                return _electronicMailTypeDescriptor;
            }
            set
            {
                _electronicMailTypeDescriptor = value;
                _electronicMailTypeDescriptorId = default(int);
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
        public virtual bool? DoNotPublishIndicator  { get; set; }
        public virtual bool? PrimaryEmailAddressIndicator  { get; set; }
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
                { "ElectronicMailTypeDescriptor", new LookupColumnDetails { PropertyName = "ElectronicMailTypeDescriptorId", LookupTypeName = "ElectronicMailTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Candidate as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("ElectronicMailAddress", ElectronicMailAddress);
            keyValues.Add("ElectronicMailTypeDescriptorId", ElectronicMailTypeDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateElectronicMail)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateElectronicMail) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Candidate = (Candidate) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isDoNotPublishIndicatorSupported = true;
        bool Entities.Common.TPDM.ICandidateElectronicMailSynchronizationSourceSupport.IsDoNotPublishIndicatorSupported
        {
            get { return _isDoNotPublishIndicatorSupported; }
            set { _isDoNotPublishIndicatorSupported = value; }
        }

        private bool _isPrimaryEmailAddressIndicatorSupported = true;
        bool Entities.Common.TPDM.ICandidateElectronicMailSynchronizationSourceSupport.IsPrimaryEmailAddressIndicatorSupported
        {
            get { return _isPrimaryEmailAddressIndicatorSupported; }
            set { _isPrimaryEmailAddressIndicatorSupported = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateLanguage table of the Candidate aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateLanguage : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidateLanguage, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateLanguageSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateLanguage()
        {
            CandidateLanguageUses = new HashSet<CandidateLanguageUse>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Candidate Candidate { get; set; }

        Entities.Common.TPDM.ICandidate ICandidateLanguage.Candidate
        {
            get { return Candidate; }
            set { Candidate = (Candidate) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int LanguageDescriptorId 
        {
            get
            {
                if (_languageDescriptorId == default(int))
                    _languageDescriptorId = DescriptorsCache.GetCache().GetId("LanguageDescriptor", _languageDescriptor);

                return _languageDescriptorId;
            } 
            set
            {
                _languageDescriptorId = value;
                _languageDescriptor = null;
            }
        }

        private int _languageDescriptorId;
        private string _languageDescriptor;

        public virtual string LanguageDescriptor
        {
            get
            {
                if (_languageDescriptor == null)
                    _languageDescriptor = DescriptorsCache.GetCache().GetValue("LanguageDescriptor", _languageDescriptorId);
                    
                return _languageDescriptor;
            }
            set
            {
                _languageDescriptor = value;
                _languageDescriptorId = default(int);
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

        private ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateLanguageUse> _candidateLanguageUses;
        private ICollection<Entities.Common.TPDM.ICandidateLanguageUse> _candidateLanguageUsesCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateAggregate.TPDM.CandidateLanguageUse> CandidateLanguageUses
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateLanguageUses)
                    if (item.CandidateLanguage == null)
                        item.CandidateLanguage = this;
                // -------------------------------------------------------------

                return _candidateLanguageUses;
            }
            set
            {
                _candidateLanguageUses = value;
                _candidateLanguageUsesCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidateLanguageUse, Entities.NHibernate.CandidateAggregate.TPDM.CandidateLanguageUse>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidateLanguageUse> Entities.Common.TPDM.ICandidateLanguage.CandidateLanguageUses
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateLanguageUses)
                    if (item.CandidateLanguage == null)
                        item.CandidateLanguage = this;
                // -------------------------------------------------------------

                return _candidateLanguageUsesCovariant;
            }
            set
            {
                CandidateLanguageUses = new HashSet<Entities.NHibernate.CandidateAggregate.TPDM.CandidateLanguageUse>(value.Cast<Entities.NHibernate.CandidateAggregate.TPDM.CandidateLanguageUse>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "LanguageDescriptor", new LookupColumnDetails { PropertyName = "LanguageDescriptorId", LookupTypeName = "LanguageDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Candidate as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("LanguageDescriptorId", LanguageDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateLanguage)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateLanguage) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Candidate = (Candidate) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCandidateLanguageUsesSupported = true;
        bool Entities.Common.TPDM.ICandidateLanguageSynchronizationSourceSupport.IsCandidateLanguageUsesSupported
        {
            get { return _isCandidateLanguageUsesSupported; }
            set { _isCandidateLanguageUsesSupported = value; }
        }

        private Func<Entities.Common.TPDM.ICandidateLanguageUse, bool> _isCandidateLanguageUseIncluded;
        Func<Entities.Common.TPDM.ICandidateLanguageUse, bool> Entities.Common.TPDM.ICandidateLanguageSynchronizationSourceSupport.IsCandidateLanguageUseIncluded
        {
            get { return _isCandidateLanguageUseIncluded; }
            set { _isCandidateLanguageUseIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateLanguageUse table of the Candidate aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateLanguageUse : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidateLanguageUse, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateLanguageUseSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateLanguageUse()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual CandidateLanguage CandidateLanguage { get; set; }

        Entities.Common.TPDM.ICandidateLanguage ICandidateLanguageUse.CandidateLanguage
        {
            get { return CandidateLanguage; }
            set { CandidateLanguage = (CandidateLanguage) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int LanguageUseDescriptorId 
        {
            get
            {
                if (_languageUseDescriptorId == default(int))
                    _languageUseDescriptorId = DescriptorsCache.GetCache().GetId("LanguageUseDescriptor", _languageUseDescriptor);

                return _languageUseDescriptorId;
            } 
            set
            {
                _languageUseDescriptorId = value;
                _languageUseDescriptor = null;
            }
        }

        private int _languageUseDescriptorId;
        private string _languageUseDescriptor;

        public virtual string LanguageUseDescriptor
        {
            get
            {
                if (_languageUseDescriptor == null)
                    _languageUseDescriptor = DescriptorsCache.GetCache().GetValue("LanguageUseDescriptor", _languageUseDescriptorId);
                    
                return _languageUseDescriptor;
            }
            set
            {
                _languageUseDescriptor = value;
                _languageUseDescriptorId = default(int);
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
                { "LanguageDescriptor", new LookupColumnDetails { PropertyName = "LanguageDescriptorId", LookupTypeName = "LanguageDescriptor"} },
                { "LanguageUseDescriptor", new LookupColumnDetails { PropertyName = "LanguageUseDescriptorId", LookupTypeName = "LanguageUseDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (CandidateLanguage as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("LanguageUseDescriptorId", LanguageUseDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateLanguageUse)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateLanguageUse) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            CandidateLanguage = (CandidateLanguage) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateOtherName table of the Candidate aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateOtherName : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidateOtherName, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateOtherNameSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateOtherName()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Candidate Candidate { get; set; }

        Entities.Common.TPDM.ICandidate ICandidateOtherName.Candidate
        {
            get { return Candidate; }
            set { Candidate = (Candidate) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int OtherNameTypeDescriptorId 
        {
            get
            {
                if (_otherNameTypeDescriptorId == default(int))
                    _otherNameTypeDescriptorId = DescriptorsCache.GetCache().GetId("OtherNameTypeDescriptor", _otherNameTypeDescriptor);

                return _otherNameTypeDescriptorId;
            } 
            set
            {
                _otherNameTypeDescriptorId = value;
                _otherNameTypeDescriptor = null;
            }
        }

        private int _otherNameTypeDescriptorId;
        private string _otherNameTypeDescriptor;

        public virtual string OtherNameTypeDescriptor
        {
            get
            {
                if (_otherNameTypeDescriptor == null)
                    _otherNameTypeDescriptor = DescriptorsCache.GetCache().GetValue("OtherNameTypeDescriptor", _otherNameTypeDescriptorId);
                    
                return _otherNameTypeDescriptor;
            }
            set
            {
                _otherNameTypeDescriptor = value;
                _otherNameTypeDescriptorId = default(int);
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
        [RequiredWithNonDefault, StringLength(75), NoDangerousText]
        public virtual string FirstName  { get; set; }
        [StringLength(10), NoDangerousText]
        public virtual string GenerationCodeSuffix  { get; set; }
        [RequiredWithNonDefault, StringLength(75), NoDangerousText]
        public virtual string LastSurname  { get; set; }
        [StringLength(75), NoDangerousText]
        public virtual string MiddleName  { get; set; }
        [StringLength(30), NoDangerousText]
        public virtual string PersonalTitlePrefix  { get; set; }
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
                { "OtherNameTypeDescriptor", new LookupColumnDetails { PropertyName = "OtherNameTypeDescriptorId", LookupTypeName = "OtherNameTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Candidate as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("OtherNameTypeDescriptorId", OtherNameTypeDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateOtherName)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateOtherName) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Candidate = (Candidate) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isFirstNameSupported = true;
        bool Entities.Common.TPDM.ICandidateOtherNameSynchronizationSourceSupport.IsFirstNameSupported
        {
            get { return _isFirstNameSupported; }
            set { _isFirstNameSupported = value; }
        }

        private bool _isGenerationCodeSuffixSupported = true;
        bool Entities.Common.TPDM.ICandidateOtherNameSynchronizationSourceSupport.IsGenerationCodeSuffixSupported
        {
            get { return _isGenerationCodeSuffixSupported; }
            set { _isGenerationCodeSuffixSupported = value; }
        }

        private bool _isLastSurnameSupported = true;
        bool Entities.Common.TPDM.ICandidateOtherNameSynchronizationSourceSupport.IsLastSurnameSupported
        {
            get { return _isLastSurnameSupported; }
            set { _isLastSurnameSupported = value; }
        }

        private bool _isMiddleNameSupported = true;
        bool Entities.Common.TPDM.ICandidateOtherNameSynchronizationSourceSupport.IsMiddleNameSupported
        {
            get { return _isMiddleNameSupported; }
            set { _isMiddleNameSupported = value; }
        }

        private bool _isPersonalTitlePrefixSupported = true;
        bool Entities.Common.TPDM.ICandidateOtherNameSynchronizationSourceSupport.IsPersonalTitlePrefixSupported
        {
            get { return _isPersonalTitlePrefixSupported; }
            set { _isPersonalTitlePrefixSupported = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidatePersonalIdentificationDocument table of the Candidate aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidatePersonalIdentificationDocument : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidatePersonalIdentificationDocument, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidatePersonalIdentificationDocumentSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidatePersonalIdentificationDocument()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Candidate Candidate { get; set; }

        Entities.Common.TPDM.ICandidate ICandidatePersonalIdentificationDocument.Candidate
        {
            get { return Candidate; }
            set { Candidate = (Candidate) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int IdentificationDocumentUseDescriptorId 
        {
            get
            {
                if (_identificationDocumentUseDescriptorId == default(int))
                    _identificationDocumentUseDescriptorId = DescriptorsCache.GetCache().GetId("IdentificationDocumentUseDescriptor", _identificationDocumentUseDescriptor);

                return _identificationDocumentUseDescriptorId;
            } 
            set
            {
                _identificationDocumentUseDescriptorId = value;
                _identificationDocumentUseDescriptor = null;
            }
        }

        private int _identificationDocumentUseDescriptorId;
        private string _identificationDocumentUseDescriptor;

        public virtual string IdentificationDocumentUseDescriptor
        {
            get
            {
                if (_identificationDocumentUseDescriptor == null)
                    _identificationDocumentUseDescriptor = DescriptorsCache.GetCache().GetValue("IdentificationDocumentUseDescriptor", _identificationDocumentUseDescriptorId);
                    
                return _identificationDocumentUseDescriptor;
            }
            set
            {
                _identificationDocumentUseDescriptor = value;
                _identificationDocumentUseDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int PersonalInformationVerificationDescriptorId 
        {
            get
            {
                if (_personalInformationVerificationDescriptorId == default(int))
                    _personalInformationVerificationDescriptorId = DescriptorsCache.GetCache().GetId("PersonalInformationVerificationDescriptor", _personalInformationVerificationDescriptor);

                return _personalInformationVerificationDescriptorId;
            } 
            set
            {
                _personalInformationVerificationDescriptorId = value;
                _personalInformationVerificationDescriptor = null;
            }
        }

        private int _personalInformationVerificationDescriptorId;
        private string _personalInformationVerificationDescriptor;

        public virtual string PersonalInformationVerificationDescriptor
        {
            get
            {
                if (_personalInformationVerificationDescriptor == null)
                    _personalInformationVerificationDescriptor = DescriptorsCache.GetCache().GetValue("PersonalInformationVerificationDescriptor", _personalInformationVerificationDescriptorId);
                    
                return _personalInformationVerificationDescriptor;
            }
            set
            {
                _personalInformationVerificationDescriptor = value;
                _personalInformationVerificationDescriptorId = default(int);
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
        [SqlServerDateTimeRange]
        public virtual DateTime? DocumentExpirationDate 
        {
            get { return _documentExpirationDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _documentExpirationDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _documentExpirationDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _documentExpirationDate;
        
        [StringLength(60), NoDangerousText]
        public virtual string DocumentTitle  { get; set; }
        public virtual int? IssuerCountryDescriptorId 
        {
            get
            {
                if (_issuerCountryDescriptorId == default(int?))
                    _issuerCountryDescriptorId = string.IsNullOrWhiteSpace(_issuerCountryDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("CountryDescriptor", _issuerCountryDescriptor);

                return _issuerCountryDescriptorId;
            } 
            set
            {
                _issuerCountryDescriptorId = value;
                _issuerCountryDescriptor = null;
            }
        }

        private int? _issuerCountryDescriptorId;
        private string _issuerCountryDescriptor;

        public virtual string IssuerCountryDescriptor
        {
            get
            {
                if (_issuerCountryDescriptor == null)
                    _issuerCountryDescriptor = _issuerCountryDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("CountryDescriptor", _issuerCountryDescriptorId.Value);
                    
                return _issuerCountryDescriptor;
            }
            set
            {
                _issuerCountryDescriptor = value;
                _issuerCountryDescriptorId = default(int?);
            }
        }
        [StringLength(60), NoDangerousText]
        public virtual string IssuerDocumentIdentificationCode  { get; set; }
        [StringLength(150), NoDangerousText]
        public virtual string IssuerName  { get; set; }
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
                { "IdentificationDocumentUseDescriptor", new LookupColumnDetails { PropertyName = "IdentificationDocumentUseDescriptorId", LookupTypeName = "IdentificationDocumentUseDescriptor"} },
                { "IssuerCountryDescriptor", new LookupColumnDetails { PropertyName = "IssuerCountryDescriptorId", LookupTypeName = "CountryDescriptor"} },
                { "PersonalInformationVerificationDescriptor", new LookupColumnDetails { PropertyName = "PersonalInformationVerificationDescriptorId", LookupTypeName = "PersonalInformationVerificationDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Candidate as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("IdentificationDocumentUseDescriptorId", IdentificationDocumentUseDescriptorId);
            keyValues.Add("PersonalInformationVerificationDescriptorId", PersonalInformationVerificationDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidatePersonalIdentificationDocument)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidatePersonalIdentificationDocument) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Candidate = (Candidate) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isDocumentExpirationDateSupported = true;
        bool Entities.Common.TPDM.ICandidatePersonalIdentificationDocumentSynchronizationSourceSupport.IsDocumentExpirationDateSupported
        {
            get { return _isDocumentExpirationDateSupported; }
            set { _isDocumentExpirationDateSupported = value; }
        }

        private bool _isDocumentTitleSupported = true;
        bool Entities.Common.TPDM.ICandidatePersonalIdentificationDocumentSynchronizationSourceSupport.IsDocumentTitleSupported
        {
            get { return _isDocumentTitleSupported; }
            set { _isDocumentTitleSupported = value; }
        }

        private bool _isIssuerCountryDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidatePersonalIdentificationDocumentSynchronizationSourceSupport.IsIssuerCountryDescriptorSupported
        {
            get { return _isIssuerCountryDescriptorSupported; }
            set { _isIssuerCountryDescriptorSupported = value; }
        }

        private bool _isIssuerDocumentIdentificationCodeSupported = true;
        bool Entities.Common.TPDM.ICandidatePersonalIdentificationDocumentSynchronizationSourceSupport.IsIssuerDocumentIdentificationCodeSupported
        {
            get { return _isIssuerDocumentIdentificationCodeSupported; }
            set { _isIssuerDocumentIdentificationCodeSupported = value; }
        }

        private bool _isIssuerNameSupported = true;
        bool Entities.Common.TPDM.ICandidatePersonalIdentificationDocumentSynchronizationSourceSupport.IsIssuerNameSupported
        {
            get { return _isIssuerNameSupported; }
            set { _isIssuerNameSupported = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateRace table of the Candidate aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateRace : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidateRace, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateRaceSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateRace()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Candidate Candidate { get; set; }

        Entities.Common.TPDM.ICandidate ICandidateRace.Candidate
        {
            get { return Candidate; }
            set { Candidate = (Candidate) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int RaceDescriptorId 
        {
            get
            {
                if (_raceDescriptorId == default(int))
                    _raceDescriptorId = DescriptorsCache.GetCache().GetId("RaceDescriptor", _raceDescriptor);

                return _raceDescriptorId;
            } 
            set
            {
                _raceDescriptorId = value;
                _raceDescriptor = null;
            }
        }

        private int _raceDescriptorId;
        private string _raceDescriptor;

        public virtual string RaceDescriptor
        {
            get
            {
                if (_raceDescriptor == null)
                    _raceDescriptor = DescriptorsCache.GetCache().GetValue("RaceDescriptor", _raceDescriptorId);
                    
                return _raceDescriptor;
            }
            set
            {
                _raceDescriptor = value;
                _raceDescriptorId = default(int);
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
                { "RaceDescriptor", new LookupColumnDetails { PropertyName = "RaceDescriptorId", LookupTypeName = "RaceDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Candidate as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("RaceDescriptorId", RaceDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateRace)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateRace) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Candidate = (Candidate) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateTelephone table of the Candidate aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateTelephone : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidateTelephone, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateTelephoneSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateTelephone()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Candidate Candidate { get; set; }

        Entities.Common.TPDM.ICandidate ICandidateTelephone.Candidate
        {
            get { return Candidate; }
            set { Candidate = (Candidate) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(24), NoDangerousText, NoWhitespace]
        public virtual string TelephoneNumber  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int TelephoneNumberTypeDescriptorId 
        {
            get
            {
                if (_telephoneNumberTypeDescriptorId == default(int))
                    _telephoneNumberTypeDescriptorId = DescriptorsCache.GetCache().GetId("TelephoneNumberTypeDescriptor", _telephoneNumberTypeDescriptor);

                return _telephoneNumberTypeDescriptorId;
            } 
            set
            {
                _telephoneNumberTypeDescriptorId = value;
                _telephoneNumberTypeDescriptor = null;
            }
        }

        private int _telephoneNumberTypeDescriptorId;
        private string _telephoneNumberTypeDescriptor;

        public virtual string TelephoneNumberTypeDescriptor
        {
            get
            {
                if (_telephoneNumberTypeDescriptor == null)
                    _telephoneNumberTypeDescriptor = DescriptorsCache.GetCache().GetValue("TelephoneNumberTypeDescriptor", _telephoneNumberTypeDescriptorId);
                    
                return _telephoneNumberTypeDescriptor;
            }
            set
            {
                _telephoneNumberTypeDescriptor = value;
                _telephoneNumberTypeDescriptorId = default(int);
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
        public virtual bool? DoNotPublishIndicator  { get; set; }
        public virtual int? OrderOfPriority  { get; set; }
        public virtual bool? TextMessageCapabilityIndicator  { get; set; }
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
                { "TelephoneNumberTypeDescriptor", new LookupColumnDetails { PropertyName = "TelephoneNumberTypeDescriptorId", LookupTypeName = "TelephoneNumberTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Candidate as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("TelephoneNumber", TelephoneNumber);
            keyValues.Add("TelephoneNumberTypeDescriptorId", TelephoneNumberTypeDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateTelephone)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateTelephone) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Candidate = (Candidate) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isDoNotPublishIndicatorSupported = true;
        bool Entities.Common.TPDM.ICandidateTelephoneSynchronizationSourceSupport.IsDoNotPublishIndicatorSupported
        {
            get { return _isDoNotPublishIndicatorSupported; }
            set { _isDoNotPublishIndicatorSupported = value; }
        }

        private bool _isOrderOfPrioritySupported = true;
        bool Entities.Common.TPDM.ICandidateTelephoneSynchronizationSourceSupport.IsOrderOfPrioritySupported
        {
            get { return _isOrderOfPrioritySupported; }
            set { _isOrderOfPrioritySupported = value; }
        }

        private bool _isTextMessageCapabilityIndicatorSupported = true;
        bool Entities.Common.TPDM.ICandidateTelephoneSynchronizationSourceSupport.IsTextMessageCapabilityIndicatorSupported
        {
            get { return _isTextMessageCapabilityIndicatorSupported; }
            set { _isTextMessageCapabilityIndicatorSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: CandidateEducatorPreparationProgramAssociation

namespace EdFi.Ods.Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="CandidateEducatorPreparationProgramAssociation"/> entity.
    /// </summary>
    public class CandidateEducatorPreparationProgramAssociationReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual DateTime BeginDate { get; set; }
        public virtual string CandidateIdentifier { get; set; }
        public virtual int EducationOrganizationId { get; set; }
        public virtual string ProgramName { get; set; }
        public virtual int ProgramTypeDescriptorId { get; set; }
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
            keyValues.Add("BeginDate", BeginDate);
            keyValues.Add("CandidateIdentifier", CandidateIdentifier);
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("ProgramName", ProgramName);
            keyValues.Add("ProgramTypeDescriptorId", ProgramTypeDescriptorId);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateEducatorPreparationProgramAssociation table of the CandidateEducatorPreparationProgramAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateEducatorPreparationProgramAssociation : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateEducatorPreparationProgramAssociation()
        {
            CandidateEducatorPreparationProgramAssociationCohortYears = new HashSet<CandidateEducatorPreparationProgramAssociationCohortYear>();
            CandidateEducatorPreparationProgramAssociationDegreeSpecializations = new HashSet<CandidateEducatorPreparationProgramAssociationDegreeSpecialization>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual DateTime BeginDate 
        {
            get { return _beginDate; }
            //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
            set { _beginDate = new DateTime(value.Year, value.Month, value.Day); }
        }

        private DateTime _beginDate;
        
        [DomainSignature, RequiredWithNonDefault, StringLength(32), NoDangerousText, NoWhitespace]
        public virtual string CandidateIdentifier  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(255), NoDangerousText, NoWhitespace]
        public virtual string ProgramName  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int ProgramTypeDescriptorId 
        {
            get
            {
                if (_programTypeDescriptorId == default(int))
                    _programTypeDescriptorId = DescriptorsCache.GetCache().GetId("ProgramTypeDescriptor", _programTypeDescriptor);

                return _programTypeDescriptorId;
            } 
            set
            {
                _programTypeDescriptorId = value;
                _programTypeDescriptor = null;
            }
        }

        private int _programTypeDescriptorId;
        private string _programTypeDescriptor;

        public virtual string ProgramTypeDescriptor
        {
            get
            {
                if (_programTypeDescriptor == null)
                    _programTypeDescriptor = DescriptorsCache.GetCache().GetValue("ProgramTypeDescriptor", _programTypeDescriptorId);
                    
                return _programTypeDescriptor;
            }
            set
            {
                _programTypeDescriptor = value;
                _programTypeDescriptorId = default(int);
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
        
        public virtual int? EPPProgramPathwayDescriptorId 
        {
            get
            {
                if (_eppProgramPathwayDescriptorId == default(int?))
                    _eppProgramPathwayDescriptorId = string.IsNullOrWhiteSpace(_eppProgramPathwayDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("EPPProgramPathwayDescriptor", _eppProgramPathwayDescriptor);

                return _eppProgramPathwayDescriptorId;
            } 
            set
            {
                _eppProgramPathwayDescriptorId = value;
                _eppProgramPathwayDescriptor = null;
            }
        }

        private int? _eppProgramPathwayDescriptorId;
        private string _eppProgramPathwayDescriptor;

        public virtual string EPPProgramPathwayDescriptor
        {
            get
            {
                if (_eppProgramPathwayDescriptor == null)
                    _eppProgramPathwayDescriptor = _eppProgramPathwayDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("EPPProgramPathwayDescriptor", _eppProgramPathwayDescriptorId.Value);
                    
                return _eppProgramPathwayDescriptor;
            }
            set
            {
                _eppProgramPathwayDescriptor = value;
                _eppProgramPathwayDescriptorId = default(int?);
            }
        }
        public virtual int? ReasonExitedDescriptorId 
        {
            get
            {
                if (_reasonExitedDescriptorId == default(int?))
                    _reasonExitedDescriptorId = string.IsNullOrWhiteSpace(_reasonExitedDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("ReasonExitedDescriptor", _reasonExitedDescriptor);

                return _reasonExitedDescriptorId;
            } 
            set
            {
                _reasonExitedDescriptorId = value;
                _reasonExitedDescriptor = null;
            }
        }

        private int? _reasonExitedDescriptorId;
        private string _reasonExitedDescriptor;

        public virtual string ReasonExitedDescriptor
        {
            get
            {
                if (_reasonExitedDescriptor == null)
                    _reasonExitedDescriptor = _reasonExitedDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("ReasonExitedDescriptor", _reasonExitedDescriptorId.Value);
                    
                return _reasonExitedDescriptor;
            }
            set
            {
                _reasonExitedDescriptor = value;
                _reasonExitedDescriptorId = default(int?);
            }
        }
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
        public virtual NHibernate.CandidateAggregate.TPDM.CandidateReferenceData CandidateReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Candidate discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation.CandidateDiscriminator
        {
            get { return CandidateReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Candidate resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation.CandidateResourceId
        {
            get { return CandidateReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.EducatorPreparationProgramAggregate.TPDM.EducatorPreparationProgramReferenceData EducatorPreparationProgramReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the EducatorPreparationProgram discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation.EducatorPreparationProgramDiscriminator
        {
            get { return EducatorPreparationProgramReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the EducatorPreparationProgram resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation.EducatorPreparationProgramResourceId
        {
            get { return EducatorPreparationProgramReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM.CandidateEducatorPreparationProgramAssociationCohortYear> _candidateEducatorPreparationProgramAssociationCohortYears;
        private ICollection<Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationCohortYear> _candidateEducatorPreparationProgramAssociationCohortYearsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM.CandidateEducatorPreparationProgramAssociationCohortYear> CandidateEducatorPreparationProgramAssociationCohortYears
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateEducatorPreparationProgramAssociationCohortYears)
                    if (item.CandidateEducatorPreparationProgramAssociation == null)
                        item.CandidateEducatorPreparationProgramAssociation = this;
                // -------------------------------------------------------------

                return _candidateEducatorPreparationProgramAssociationCohortYears;
            }
            set
            {
                _candidateEducatorPreparationProgramAssociationCohortYears = value;
                _candidateEducatorPreparationProgramAssociationCohortYearsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationCohortYear, Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM.CandidateEducatorPreparationProgramAssociationCohortYear>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationCohortYear> Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation.CandidateEducatorPreparationProgramAssociationCohortYears
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateEducatorPreparationProgramAssociationCohortYears)
                    if (item.CandidateEducatorPreparationProgramAssociation == null)
                        item.CandidateEducatorPreparationProgramAssociation = this;
                // -------------------------------------------------------------

                return _candidateEducatorPreparationProgramAssociationCohortYearsCovariant;
            }
            set
            {
                CandidateEducatorPreparationProgramAssociationCohortYears = new HashSet<Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM.CandidateEducatorPreparationProgramAssociationCohortYear>(value.Cast<Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM.CandidateEducatorPreparationProgramAssociationCohortYear>());
            }
        }


        private ICollection<Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM.CandidateEducatorPreparationProgramAssociationDegreeSpecialization> _candidateEducatorPreparationProgramAssociationDegreeSpecializations;
        private ICollection<Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationDegreeSpecialization> _candidateEducatorPreparationProgramAssociationDegreeSpecializationsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM.CandidateEducatorPreparationProgramAssociationDegreeSpecialization> CandidateEducatorPreparationProgramAssociationDegreeSpecializations
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateEducatorPreparationProgramAssociationDegreeSpecializations)
                    if (item.CandidateEducatorPreparationProgramAssociation == null)
                        item.CandidateEducatorPreparationProgramAssociation = this;
                // -------------------------------------------------------------

                return _candidateEducatorPreparationProgramAssociationDegreeSpecializations;
            }
            set
            {
                _candidateEducatorPreparationProgramAssociationDegreeSpecializations = value;
                _candidateEducatorPreparationProgramAssociationDegreeSpecializationsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationDegreeSpecialization, Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM.CandidateEducatorPreparationProgramAssociationDegreeSpecialization>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationDegreeSpecialization> Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation.CandidateEducatorPreparationProgramAssociationDegreeSpecializations
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _candidateEducatorPreparationProgramAssociationDegreeSpecializations)
                    if (item.CandidateEducatorPreparationProgramAssociation == null)
                        item.CandidateEducatorPreparationProgramAssociation = this;
                // -------------------------------------------------------------

                return _candidateEducatorPreparationProgramAssociationDegreeSpecializationsCovariant;
            }
            set
            {
                CandidateEducatorPreparationProgramAssociationDegreeSpecializations = new HashSet<Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM.CandidateEducatorPreparationProgramAssociationDegreeSpecialization>(value.Cast<Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM.CandidateEducatorPreparationProgramAssociationDegreeSpecialization>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "EPPProgramPathwayDescriptor", new LookupColumnDetails { PropertyName = "EPPProgramPathwayDescriptorId", LookupTypeName = "EPPProgramPathwayDescriptor"} },
                { "ProgramTypeDescriptor", new LookupColumnDetails { PropertyName = "ProgramTypeDescriptorId", LookupTypeName = "ProgramTypeDescriptor"} },
                { "ReasonExitedDescriptor", new LookupColumnDetails { PropertyName = "ReasonExitedDescriptorId", LookupTypeName = "ReasonExitedDescriptor"} },
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
            keyValues.Add("BeginDate", BeginDate);
            keyValues.Add("CandidateIdentifier", CandidateIdentifier);
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("ProgramName", ProgramName);
            keyValues.Add("ProgramTypeDescriptorId", ProgramTypeDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCandidateEducatorPreparationProgramAssociationCohortYearsSupported = true;
        bool Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationSynchronizationSourceSupport.IsCandidateEducatorPreparationProgramAssociationCohortYearsSupported
        {
            get { return _isCandidateEducatorPreparationProgramAssociationCohortYearsSupported; }
            set { _isCandidateEducatorPreparationProgramAssociationCohortYearsSupported = value; }
        }

        private bool _isCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported = true;
        bool Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationSynchronizationSourceSupport.IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported
        {
            get { return _isCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported; }
            set { _isCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported = value; }
        }

        private bool _isEndDateSupported = true;
        bool Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationSynchronizationSourceSupport.IsEndDateSupported
        {
            get { return _isEndDateSupported; }
            set { _isEndDateSupported = value; }
        }

        private bool _isEPPProgramPathwayDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationSynchronizationSourceSupport.IsEPPProgramPathwayDescriptorSupported
        {
            get { return _isEPPProgramPathwayDescriptorSupported; }
            set { _isEPPProgramPathwayDescriptorSupported = value; }
        }

        private bool _isReasonExitedDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationSynchronizationSourceSupport.IsReasonExitedDescriptorSupported
        {
            get { return _isReasonExitedDescriptorSupported; }
            set { _isReasonExitedDescriptorSupported = value; }
        }

        private Func<Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationCohortYear, bool> _isCandidateEducatorPreparationProgramAssociationCohortYearIncluded;
        Func<Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationCohortYear, bool> Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationSynchronizationSourceSupport.IsCandidateEducatorPreparationProgramAssociationCohortYearIncluded
        {
            get { return _isCandidateEducatorPreparationProgramAssociationCohortYearIncluded; }
            set { _isCandidateEducatorPreparationProgramAssociationCohortYearIncluded = value; }
        }

        private Func<Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationDegreeSpecialization, bool> _isCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded;
        Func<Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationDegreeSpecialization, bool> Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationSynchronizationSourceSupport.IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded
        {
            get { return _isCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded; }
            set { _isCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateEducatorPreparationProgramAssociationCohortYear table of the CandidateEducatorPreparationProgramAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateEducatorPreparationProgramAssociationCohortYear : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationCohortYear, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationCohortYearSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateEducatorPreparationProgramAssociationCohortYear()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual CandidateEducatorPreparationProgramAssociation CandidateEducatorPreparationProgramAssociation { get; set; }

        Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation ICandidateEducatorPreparationProgramAssociationCohortYear.CandidateEducatorPreparationProgramAssociation
        {
            get { return CandidateEducatorPreparationProgramAssociation; }
            set { CandidateEducatorPreparationProgramAssociation = (CandidateEducatorPreparationProgramAssociation) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int CohortYearTypeDescriptorId 
        {
            get
            {
                if (_cohortYearTypeDescriptorId == default(int))
                    _cohortYearTypeDescriptorId = DescriptorsCache.GetCache().GetId("CohortYearTypeDescriptor", _cohortYearTypeDescriptor);

                return _cohortYearTypeDescriptorId;
            } 
            set
            {
                _cohortYearTypeDescriptorId = value;
                _cohortYearTypeDescriptor = null;
            }
        }

        private int _cohortYearTypeDescriptorId;
        private string _cohortYearTypeDescriptor;

        public virtual string CohortYearTypeDescriptor
        {
            get
            {
                if (_cohortYearTypeDescriptor == null)
                    _cohortYearTypeDescriptor = DescriptorsCache.GetCache().GetValue("CohortYearTypeDescriptor", _cohortYearTypeDescriptorId);
                    
                return _cohortYearTypeDescriptor;
            }
            set
            {
                _cohortYearTypeDescriptor = value;
                _cohortYearTypeDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual short SchoolYear  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int?))
                    _termDescriptorId = string.IsNullOrWhiteSpace(_termDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("TermDescriptor", _termDescriptor);

                return _termDescriptorId;
            } 
            set
            {
                _termDescriptorId = value;
                _termDescriptor = null;
            }
        }

        private int? _termDescriptorId;
        private string _termDescriptor;

        public virtual string TermDescriptor
        {
            get
            {
                if (_termDescriptor == null)
                    _termDescriptor = _termDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("TermDescriptor", _termDescriptorId.Value);
                    
                return _termDescriptor;
            }
            set
            {
                _termDescriptor = value;
                _termDescriptorId = default(int?);
            }
        }
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
        public virtual NHibernate.SchoolYearTypeAggregate.EdFi.SchoolYearTypeReferenceData SchoolYearTypeReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the SchoolYearType resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationCohortYear.SchoolYearTypeResourceId
        {
            get { return SchoolYearTypeReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "CohortYearTypeDescriptor", new LookupColumnDetails { PropertyName = "CohortYearTypeDescriptorId", LookupTypeName = "CohortYearTypeDescriptor"} },
                { "ProgramTypeDescriptor", new LookupColumnDetails { PropertyName = "ProgramTypeDescriptorId", LookupTypeName = "ProgramTypeDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (CandidateEducatorPreparationProgramAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("CohortYearTypeDescriptorId", CohortYearTypeDescriptorId);
            keyValues.Add("SchoolYear", SchoolYear);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationCohortYear)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationCohortYear) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            CandidateEducatorPreparationProgramAssociation = (CandidateEducatorPreparationProgramAssociation) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isTermDescriptorSupported = true;
        bool Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationCohortYearSynchronizationSourceSupport.IsTermDescriptorSupported
        {
            get { return _isTermDescriptorSupported; }
            set { _isTermDescriptorSupported = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CandidateEducatorPreparationProgramAssociationDegreeSpecialization table of the CandidateEducatorPreparationProgramAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CandidateEducatorPreparationProgramAssociationDegreeSpecialization : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationDegreeSpecialization, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationDegreeSpecializationSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CandidateEducatorPreparationProgramAssociationDegreeSpecialization()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual CandidateEducatorPreparationProgramAssociation CandidateEducatorPreparationProgramAssociation { get; set; }

        Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation ICandidateEducatorPreparationProgramAssociationDegreeSpecialization.CandidateEducatorPreparationProgramAssociation
        {
            get { return CandidateEducatorPreparationProgramAssociation; }
            set { CandidateEducatorPreparationProgramAssociation = (CandidateEducatorPreparationProgramAssociation) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(255), NoDangerousText, NoWhitespace]
        public virtual string MajorSpecialization  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
        
        [StringLength(255), NoDangerousText]
        public virtual string MinorSpecialization  { get; set; }
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
                { "ProgramTypeDescriptor", new LookupColumnDetails { PropertyName = "ProgramTypeDescriptorId", LookupTypeName = "ProgramTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (CandidateEducatorPreparationProgramAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("MajorSpecialization", MajorSpecialization);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationDegreeSpecialization)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationDegreeSpecialization) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            CandidateEducatorPreparationProgramAssociation = (CandidateEducatorPreparationProgramAssociation) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isEndDateSupported = true;
        bool Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationDegreeSpecializationSynchronizationSourceSupport.IsEndDateSupported
        {
            get { return _isEndDateSupported; }
            set { _isEndDateSupported = value; }
        }

        private bool _isMinorSpecializationSupported = true;
        bool Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociationDegreeSpecializationSynchronizationSourceSupport.IsMinorSpecializationSupported
        {
            get { return _isMinorSpecializationSupported; }
            set { _isMinorSpecializationSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: CertificationRouteDescriptor

namespace EdFi.Ods.Entities.NHibernate.CertificationRouteDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CertificationRouteDescriptor table of the CertificationRouteDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CertificationRouteDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.ICertificationRouteDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICertificationRouteDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int CertificationRouteDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("CertificationRouteDescriptorId", CertificationRouteDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICertificationRouteDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICertificationRouteDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.ICertificationRouteDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.ICertificationRouteDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.ICertificationRouteDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.ICertificationRouteDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.ICertificationRouteDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.ICertificationRouteDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.ICertificationRouteDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: CoteachingStyleObservedDescriptor

namespace EdFi.Ods.Entities.NHibernate.CoteachingStyleObservedDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CoteachingStyleObservedDescriptor table of the CoteachingStyleObservedDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.ICoteachingStyleObservedDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICoteachingStyleObservedDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int CoteachingStyleObservedDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("CoteachingStyleObservedDescriptorId", CoteachingStyleObservedDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICoteachingStyleObservedDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICoteachingStyleObservedDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.ICoteachingStyleObservedDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.ICoteachingStyleObservedDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.ICoteachingStyleObservedDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.ICoteachingStyleObservedDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.ICoteachingStyleObservedDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.ICoteachingStyleObservedDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.ICoteachingStyleObservedDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: Credential

namespace EdFi.Ods.Entities.NHibernate.CredentialAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CredentialStudentAcademicRecord table of the Credential aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CredentialStudentAcademicRecord : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICredentialStudentAcademicRecord, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICredentialStudentAcademicRecordSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CredentialStudentAcademicRecord()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Credential Credential { get; set; }

        Entities.Common.TPDM.ICredentialExtension ICredentialStudentAcademicRecord.CredentialExtension
        {
            get { return (ICredentialExtension) Credential.Extensions["TPDM"]; }
            set { Credential.Extensions["TPDM"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual short SchoolYear  { get; set; }
        [Display(Name="StudentUniqueId")]
        [DomainSignature, RequiredWithNonDefault("Student")]
        public virtual int StudentUSI 
        {
            get
            {
                if (_studentUSI == default(int))
                    _studentUSI = PersonUniqueIdToUsiCache.GetCache().GetUsi("Student", _studentUniqueId);

                return _studentUSI;
            } 
            set
            {
                _studentUSI = value;
            }
        }

        private int _studentUSI;
        private string _studentUniqueId;

        [RequiredWithNonDefault]
        public virtual string StudentUniqueId
        {
            get
            {
                if (_studentUniqueId == null)
                    _studentUniqueId = PersonUniqueIdToUsiCache.GetCache().GetUniqueId("Student", _studentUSI);
                    
                return _studentUniqueId;
            }
            set
            {
                if (_studentUniqueId != value)
                        _studentUSI = default(int);

                _studentUniqueId = value;
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int))
                    _termDescriptorId = DescriptorsCache.GetCache().GetId("TermDescriptor", _termDescriptor);

                return _termDescriptorId;
            } 
            set
            {
                _termDescriptorId = value;
                _termDescriptor = null;
            }
        }

        private int _termDescriptorId;
        private string _termDescriptor;

        public virtual string TermDescriptor
        {
            get
            {
                if (_termDescriptor == null)
                    _termDescriptor = DescriptorsCache.GetCache().GetValue("TermDescriptor", _termDescriptorId);
                    
                return _termDescriptor;
            }
            set
            {
                _termDescriptor = value;
                _termDescriptorId = default(int);
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
        public virtual NHibernate.StudentAcademicRecordAggregate.EdFi.StudentAcademicRecordReferenceData StudentAcademicRecordReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the StudentAcademicRecord discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.ICredentialStudentAcademicRecord.StudentAcademicRecordDiscriminator
        {
            get { return StudentAcademicRecordReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the StudentAcademicRecord resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.ICredentialStudentAcademicRecord.StudentAcademicRecordResourceId
        {
            get { return StudentAcademicRecordReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "StateOfIssueStateAbbreviationDescriptor", new LookupColumnDetails { PropertyName = "StateOfIssueStateAbbreviationDescriptorId", LookupTypeName = "StateAbbreviationDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Credential as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("StudentUSI", StudentUSI);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICredentialStudentAcademicRecord)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICredentialStudentAcademicRecord) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Credential = (EdFi.Credential) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CredentialExtension table of the Credential aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CredentialExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ICredentialExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICredentialExtensionSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public CredentialExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Credential Credential { get; set; }

        Entities.Common.EdFi.ICredential ICredentialExtension.Credential
        {
            get { return Credential; }
            set { Credential = (EdFi.Credential) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual bool? BoardCertificationIndicator  { get; set; }
        public virtual int? CertificationRouteDescriptorId 
        {
            get
            {
                if (_certificationRouteDescriptorId == default(int?))
                    _certificationRouteDescriptorId = string.IsNullOrWhiteSpace(_certificationRouteDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("CertificationRouteDescriptor", _certificationRouteDescriptor);

                return _certificationRouteDescriptorId;
            } 
            set
            {
                _certificationRouteDescriptorId = value;
                _certificationRouteDescriptor = null;
            }
        }

        private int? _certificationRouteDescriptorId;
        private string _certificationRouteDescriptor;

        public virtual string CertificationRouteDescriptor
        {
            get
            {
                if (_certificationRouteDescriptor == null)
                    _certificationRouteDescriptor = _certificationRouteDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("CertificationRouteDescriptor", _certificationRouteDescriptorId.Value);
                    
                return _certificationRouteDescriptor;
            }
            set
            {
                _certificationRouteDescriptor = value;
                _certificationRouteDescriptorId = default(int?);
            }
        }
        [StringLength(64), NoDangerousText]
        public virtual string CertificationTitle  { get; set; }
        [SqlServerDateTimeRange]
        public virtual DateTime? CredentialStatusDate 
        {
            get { return _credentialStatusDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _credentialStatusDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _credentialStatusDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _credentialStatusDate;
        
        public virtual int? CredentialStatusDescriptorId 
        {
            get
            {
                if (_credentialStatusDescriptorId == default(int?))
                    _credentialStatusDescriptorId = string.IsNullOrWhiteSpace(_credentialStatusDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("CredentialStatusDescriptor", _credentialStatusDescriptor);

                return _credentialStatusDescriptorId;
            } 
            set
            {
                _credentialStatusDescriptorId = value;
                _credentialStatusDescriptor = null;
            }
        }

        private int? _credentialStatusDescriptorId;
        private string _credentialStatusDescriptor;

        public virtual string CredentialStatusDescriptor
        {
            get
            {
                if (_credentialStatusDescriptor == null)
                    _credentialStatusDescriptor = _credentialStatusDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("CredentialStatusDescriptor", _credentialStatusDescriptorId.Value);
                    
                return _credentialStatusDescriptor;
            }
            set
            {
                _credentialStatusDescriptor = value;
                _credentialStatusDescriptorId = default(int?);
            }
        }
        public virtual int? EducatorRoleDescriptorId 
        {
            get
            {
                if (_educatorRoleDescriptorId == default(int?))
                    _educatorRoleDescriptorId = string.IsNullOrWhiteSpace(_educatorRoleDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("EducatorRoleDescriptor", _educatorRoleDescriptor);

                return _educatorRoleDescriptorId;
            } 
            set
            {
                _educatorRoleDescriptorId = value;
                _educatorRoleDescriptor = null;
            }
        }

        private int? _educatorRoleDescriptorId;
        private string _educatorRoleDescriptor;

        public virtual string EducatorRoleDescriptor
        {
            get
            {
                if (_educatorRoleDescriptor == null)
                    _educatorRoleDescriptor = _educatorRoleDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("EducatorRoleDescriptor", _educatorRoleDescriptorId.Value);
                    
                return _educatorRoleDescriptor;
            }
            set
            {
                _educatorRoleDescriptor = value;
                _educatorRoleDescriptorId = default(int?);
            }
        }
        [StringLength(32), NoDangerousText]
        public virtual string PersonId  { get; set; }
        public virtual int? SourceSystemDescriptorId 
        {
            get
            {
                if (_sourceSystemDescriptorId == default(int?))
                    _sourceSystemDescriptorId = string.IsNullOrWhiteSpace(_sourceSystemDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("SourceSystemDescriptor", _sourceSystemDescriptor);

                return _sourceSystemDescriptorId;
            } 
            set
            {
                _sourceSystemDescriptorId = value;
                _sourceSystemDescriptor = null;
            }
        }

        private int? _sourceSystemDescriptorId;
        private string _sourceSystemDescriptor;

        public virtual string SourceSystemDescriptor
        {
            get
            {
                if (_sourceSystemDescriptor == null)
                    _sourceSystemDescriptor = _sourceSystemDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("SourceSystemDescriptor", _sourceSystemDescriptorId.Value);
                    
                return _sourceSystemDescriptor;
            }
            set
            {
                _sourceSystemDescriptor = value;
                _sourceSystemDescriptorId = default(int?);
            }
        }
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
        public virtual NHibernate.PersonAggregate.EdFi.PersonReferenceData PersonReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Person discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.ICredentialExtension.PersonDiscriminator
        {
            get { return PersonReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Person resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.ICredentialExtension.PersonResourceId
        {
            get { return PersonReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<Entities.Common.TPDM.ICredentialStudentAcademicRecord> _credentialStudentAcademicRecords;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.TPDM.ICredentialStudentAcademicRecord> ICredentialExtension.CredentialStudentAcademicRecords
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, CredentialStudentAcademicRecord>((IList<object>) Credential.AggregateExtensions["TPDM_CredentialStudentAcademicRecords"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (CredentialStudentAcademicRecord item in sourceList)
                    if (item.Credential == null)
                        item.Credential = this.Credential;
                // -------------------------------------------------------------

                if (_credentialStudentAcademicRecords == null)
                    _credentialStudentAcademicRecords = new CovariantCollectionAdapter<Entities.Common.TPDM.ICredentialStudentAcademicRecord, CredentialStudentAcademicRecord>(sourceList);

                return _credentialStudentAcademicRecords;
            }
            set
            {
                Credential.AggregateExtensions["TPDM_CredentialStudentAcademicRecords"] = value;
            }
        }
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "CertificationRouteDescriptor", new LookupColumnDetails { PropertyName = "CertificationRouteDescriptorId", LookupTypeName = "CertificationRouteDescriptor"} },
                { "CredentialStatusDescriptor", new LookupColumnDetails { PropertyName = "CredentialStatusDescriptorId", LookupTypeName = "CredentialStatusDescriptor"} },
                { "EducatorRoleDescriptor", new LookupColumnDetails { PropertyName = "EducatorRoleDescriptorId", LookupTypeName = "EducatorRoleDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Credential as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICredentialExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICredentialExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Credential = (EdFi.Credential) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isBoardCertificationIndicatorSupported = true;
        bool Entities.Common.TPDM.ICredentialExtensionSynchronizationSourceSupport.IsBoardCertificationIndicatorSupported
        {
            get { return _isBoardCertificationIndicatorSupported; }
            set { _isBoardCertificationIndicatorSupported = value; }
        }

        private bool _isCertificationRouteDescriptorSupported = true;
        bool Entities.Common.TPDM.ICredentialExtensionSynchronizationSourceSupport.IsCertificationRouteDescriptorSupported
        {
            get { return _isCertificationRouteDescriptorSupported; }
            set { _isCertificationRouteDescriptorSupported = value; }
        }

        private bool _isCertificationTitleSupported = true;
        bool Entities.Common.TPDM.ICredentialExtensionSynchronizationSourceSupport.IsCertificationTitleSupported
        {
            get { return _isCertificationTitleSupported; }
            set { _isCertificationTitleSupported = value; }
        }

        private bool _isCredentialStatusDateSupported = true;
        bool Entities.Common.TPDM.ICredentialExtensionSynchronizationSourceSupport.IsCredentialStatusDateSupported
        {
            get { return _isCredentialStatusDateSupported; }
            set { _isCredentialStatusDateSupported = value; }
        }

        private bool _isCredentialStatusDescriptorSupported = true;
        bool Entities.Common.TPDM.ICredentialExtensionSynchronizationSourceSupport.IsCredentialStatusDescriptorSupported
        {
            get { return _isCredentialStatusDescriptorSupported; }
            set { _isCredentialStatusDescriptorSupported = value; }
        }

        private bool _isCredentialStudentAcademicRecordsSupported = true;
        bool Entities.Common.TPDM.ICredentialExtensionSynchronizationSourceSupport.IsCredentialStudentAcademicRecordsSupported
        {
            get { return _isCredentialStudentAcademicRecordsSupported; }
            set { _isCredentialStudentAcademicRecordsSupported = value; }
        }

        private bool _isEducatorRoleDescriptorSupported = true;
        bool Entities.Common.TPDM.ICredentialExtensionSynchronizationSourceSupport.IsEducatorRoleDescriptorSupported
        {
            get { return _isEducatorRoleDescriptorSupported; }
            set { _isEducatorRoleDescriptorSupported = value; }
        }

        private bool _isPersonIdSupported = true;
        bool Entities.Common.TPDM.ICredentialExtensionSynchronizationSourceSupport.IsPersonIdSupported
        {
            get { return _isPersonIdSupported; }
            set { _isPersonIdSupported = value; }
        }

        private bool _isSourceSystemDescriptorSupported = true;
        bool Entities.Common.TPDM.ICredentialExtensionSynchronizationSourceSupport.IsSourceSystemDescriptorSupported
        {
            get { return _isSourceSystemDescriptorSupported; }
            set { _isSourceSystemDescriptorSupported = value; }
        }

        private Func<Entities.Common.TPDM.ICredentialStudentAcademicRecord, bool> _isCredentialStudentAcademicRecordIncluded;
        Func<Entities.Common.TPDM.ICredentialStudentAcademicRecord, bool> Entities.Common.TPDM.ICredentialExtensionSynchronizationSourceSupport.IsCredentialStudentAcademicRecordIncluded
        {
            get { return _isCredentialStudentAcademicRecordIncluded; }
            set { _isCredentialStudentAcademicRecordIncluded = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: CredentialStatusDescriptor

namespace EdFi.Ods.Entities.NHibernate.CredentialStatusDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.CredentialStatusDescriptor table of the CredentialStatusDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class CredentialStatusDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.ICredentialStatusDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ICredentialStatusDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int CredentialStatusDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("CredentialStatusDescriptorId", CredentialStatusDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ICredentialStatusDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ICredentialStatusDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.ICredentialStatusDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.ICredentialStatusDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.ICredentialStatusDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.ICredentialStatusDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.ICredentialStatusDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.ICredentialStatusDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.ICredentialStatusDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EducatorPreparationProgram

namespace EdFi.Ods.Entities.NHibernate.EducatorPreparationProgramAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="EducatorPreparationProgram"/> entity.
    /// </summary>
    public class EducatorPreparationProgramReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId { get; set; }
        public virtual string ProgramName { get; set; }
        public virtual int ProgramTypeDescriptorId { get; set; }
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("ProgramName", ProgramName);
            keyValues.Add("ProgramTypeDescriptorId", ProgramTypeDescriptorId);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EducatorPreparationProgram table of the EducatorPreparationProgram aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EducatorPreparationProgram : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.IEducatorPreparationProgram, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEducatorPreparationProgramSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EducatorPreparationProgram()
        {
            EducatorPreparationProgramGradeLevels = new HashSet<EducatorPreparationProgramGradeLevel>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(255), NoDangerousText, NoWhitespace]
        public virtual string ProgramName  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int ProgramTypeDescriptorId 
        {
            get
            {
                if (_programTypeDescriptorId == default(int))
                    _programTypeDescriptorId = DescriptorsCache.GetCache().GetId("ProgramTypeDescriptor", _programTypeDescriptor);

                return _programTypeDescriptorId;
            } 
            set
            {
                _programTypeDescriptorId = value;
                _programTypeDescriptor = null;
            }
        }

        private int _programTypeDescriptorId;
        private string _programTypeDescriptor;

        public virtual string ProgramTypeDescriptor
        {
            get
            {
                if (_programTypeDescriptor == null)
                    _programTypeDescriptor = DescriptorsCache.GetCache().GetValue("ProgramTypeDescriptor", _programTypeDescriptorId);
                    
                return _programTypeDescriptor;
            }
            set
            {
                _programTypeDescriptor = value;
                _programTypeDescriptorId = default(int);
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
        public virtual int? AccreditationStatusDescriptorId 
        {
            get
            {
                if (_accreditationStatusDescriptorId == default(int?))
                    _accreditationStatusDescriptorId = string.IsNullOrWhiteSpace(_accreditationStatusDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("AccreditationStatusDescriptor", _accreditationStatusDescriptor);

                return _accreditationStatusDescriptorId;
            } 
            set
            {
                _accreditationStatusDescriptorId = value;
                _accreditationStatusDescriptor = null;
            }
        }

        private int? _accreditationStatusDescriptorId;
        private string _accreditationStatusDescriptor;

        public virtual string AccreditationStatusDescriptor
        {
            get
            {
                if (_accreditationStatusDescriptor == null)
                    _accreditationStatusDescriptor = _accreditationStatusDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("AccreditationStatusDescriptor", _accreditationStatusDescriptorId.Value);
                    
                return _accreditationStatusDescriptor;
            }
            set
            {
                _accreditationStatusDescriptor = value;
                _accreditationStatusDescriptorId = default(int?);
            }
        }
        [StringLength(20), NoDangerousText]
        public virtual string ProgramId  { get; set; }
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
        string Entities.Common.TPDM.IEducatorPreparationProgram.EducationOrganizationDiscriminator
        {
            get { return EducationOrganizationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the EducationOrganization resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IEducatorPreparationProgram.EducationOrganizationResourceId
        {
            get { return EducationOrganizationReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.EducatorPreparationProgramAggregate.TPDM.EducatorPreparationProgramGradeLevel> _educatorPreparationProgramGradeLevels;
        private ICollection<Entities.Common.TPDM.IEducatorPreparationProgramGradeLevel> _educatorPreparationProgramGradeLevelsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.EducatorPreparationProgramAggregate.TPDM.EducatorPreparationProgramGradeLevel> EducatorPreparationProgramGradeLevels
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _educatorPreparationProgramGradeLevels)
                    if (item.EducatorPreparationProgram == null)
                        item.EducatorPreparationProgram = this;
                // -------------------------------------------------------------

                return _educatorPreparationProgramGradeLevels;
            }
            set
            {
                _educatorPreparationProgramGradeLevels = value;
                _educatorPreparationProgramGradeLevelsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.IEducatorPreparationProgramGradeLevel, Entities.NHibernate.EducatorPreparationProgramAggregate.TPDM.EducatorPreparationProgramGradeLevel>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.IEducatorPreparationProgramGradeLevel> Entities.Common.TPDM.IEducatorPreparationProgram.EducatorPreparationProgramGradeLevels
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _educatorPreparationProgramGradeLevels)
                    if (item.EducatorPreparationProgram == null)
                        item.EducatorPreparationProgram = this;
                // -------------------------------------------------------------

                return _educatorPreparationProgramGradeLevelsCovariant;
            }
            set
            {
                EducatorPreparationProgramGradeLevels = new HashSet<Entities.NHibernate.EducatorPreparationProgramAggregate.TPDM.EducatorPreparationProgramGradeLevel>(value.Cast<Entities.NHibernate.EducatorPreparationProgramAggregate.TPDM.EducatorPreparationProgramGradeLevel>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "AccreditationStatusDescriptor", new LookupColumnDetails { PropertyName = "AccreditationStatusDescriptorId", LookupTypeName = "AccreditationStatusDescriptor"} },
                { "ProgramTypeDescriptor", new LookupColumnDetails { PropertyName = "ProgramTypeDescriptorId", LookupTypeName = "ProgramTypeDescriptor"} },
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("ProgramName", ProgramName);
            keyValues.Add("ProgramTypeDescriptorId", ProgramTypeDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEducatorPreparationProgram)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEducatorPreparationProgram) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isAccreditationStatusDescriptorSupported = true;
        bool Entities.Common.TPDM.IEducatorPreparationProgramSynchronizationSourceSupport.IsAccreditationStatusDescriptorSupported
        {
            get { return _isAccreditationStatusDescriptorSupported; }
            set { _isAccreditationStatusDescriptorSupported = value; }
        }

        private bool _isEducatorPreparationProgramGradeLevelsSupported = true;
        bool Entities.Common.TPDM.IEducatorPreparationProgramSynchronizationSourceSupport.IsEducatorPreparationProgramGradeLevelsSupported
        {
            get { return _isEducatorPreparationProgramGradeLevelsSupported; }
            set { _isEducatorPreparationProgramGradeLevelsSupported = value; }
        }

        private bool _isProgramIdSupported = true;
        bool Entities.Common.TPDM.IEducatorPreparationProgramSynchronizationSourceSupport.IsProgramIdSupported
        {
            get { return _isProgramIdSupported; }
            set { _isProgramIdSupported = value; }
        }

        private Func<Entities.Common.TPDM.IEducatorPreparationProgramGradeLevel, bool> _isEducatorPreparationProgramGradeLevelIncluded;
        Func<Entities.Common.TPDM.IEducatorPreparationProgramGradeLevel, bool> Entities.Common.TPDM.IEducatorPreparationProgramSynchronizationSourceSupport.IsEducatorPreparationProgramGradeLevelIncluded
        {
            get { return _isEducatorPreparationProgramGradeLevelIncluded; }
            set { _isEducatorPreparationProgramGradeLevelIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EducatorPreparationProgramGradeLevel table of the EducatorPreparationProgram aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EducatorPreparationProgramGradeLevel : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IEducatorPreparationProgramGradeLevel, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEducatorPreparationProgramGradeLevelSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EducatorPreparationProgramGradeLevel()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EducatorPreparationProgram EducatorPreparationProgram { get; set; }

        Entities.Common.TPDM.IEducatorPreparationProgram IEducatorPreparationProgramGradeLevel.EducatorPreparationProgram
        {
            get { return EducatorPreparationProgram; }
            set { EducatorPreparationProgram = (EducatorPreparationProgram) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int GradeLevelDescriptorId 
        {
            get
            {
                if (_gradeLevelDescriptorId == default(int))
                    _gradeLevelDescriptorId = DescriptorsCache.GetCache().GetId("GradeLevelDescriptor", _gradeLevelDescriptor);

                return _gradeLevelDescriptorId;
            } 
            set
            {
                _gradeLevelDescriptorId = value;
                _gradeLevelDescriptor = null;
            }
        }

        private int _gradeLevelDescriptorId;
        private string _gradeLevelDescriptor;

        public virtual string GradeLevelDescriptor
        {
            get
            {
                if (_gradeLevelDescriptor == null)
                    _gradeLevelDescriptor = DescriptorsCache.GetCache().GetValue("GradeLevelDescriptor", _gradeLevelDescriptorId);
                    
                return _gradeLevelDescriptor;
            }
            set
            {
                _gradeLevelDescriptor = value;
                _gradeLevelDescriptorId = default(int);
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
                { "GradeLevelDescriptor", new LookupColumnDetails { PropertyName = "GradeLevelDescriptorId", LookupTypeName = "GradeLevelDescriptor"} },
                { "ProgramTypeDescriptor", new LookupColumnDetails { PropertyName = "ProgramTypeDescriptorId", LookupTypeName = "ProgramTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (EducatorPreparationProgram as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("GradeLevelDescriptorId", GradeLevelDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEducatorPreparationProgramGradeLevel)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEducatorPreparationProgramGradeLevel) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            EducatorPreparationProgram = (EducatorPreparationProgram) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        // -----------------------------------------
    }
}
// Aggregate: EducatorRoleDescriptor

namespace EdFi.Ods.Entities.NHibernate.EducatorRoleDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EducatorRoleDescriptor table of the EducatorRoleDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EducatorRoleDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IEducatorRoleDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEducatorRoleDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int EducatorRoleDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("EducatorRoleDescriptorId", EducatorRoleDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEducatorRoleDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEducatorRoleDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IEducatorRoleDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IEducatorRoleDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IEducatorRoleDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IEducatorRoleDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IEducatorRoleDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IEducatorRoleDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IEducatorRoleDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EnglishLanguageExamDescriptor

namespace EdFi.Ods.Entities.NHibernate.EnglishLanguageExamDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EnglishLanguageExamDescriptor table of the EnglishLanguageExamDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IEnglishLanguageExamDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEnglishLanguageExamDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int EnglishLanguageExamDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("EnglishLanguageExamDescriptorId", EnglishLanguageExamDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEnglishLanguageExamDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEnglishLanguageExamDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IEnglishLanguageExamDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IEnglishLanguageExamDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IEnglishLanguageExamDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IEnglishLanguageExamDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IEnglishLanguageExamDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IEnglishLanguageExamDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IEnglishLanguageExamDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EPPProgramPathwayDescriptor

namespace EdFi.Ods.Entities.NHibernate.EPPProgramPathwayDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EPPProgramPathwayDescriptor table of the EPPProgramPathwayDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EPPProgramPathwayDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IEPPProgramPathwayDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEPPProgramPathwayDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int EPPProgramPathwayDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("EPPProgramPathwayDescriptorId", EPPProgramPathwayDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEPPProgramPathwayDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEPPProgramPathwayDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IEPPProgramPathwayDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IEPPProgramPathwayDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IEPPProgramPathwayDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IEPPProgramPathwayDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IEPPProgramPathwayDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IEPPProgramPathwayDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IEPPProgramPathwayDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: Evaluation

namespace EdFi.Ods.Entities.NHibernate.EvaluationAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="Evaluation"/> entity.
    /// </summary>
    public class EvaluationReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId { get; set; }
        public virtual int EvaluationPeriodDescriptorId { get; set; }
        public virtual string EvaluationTitle { get; set; }
        public virtual string PerformanceEvaluationTitle { get; set; }
        public virtual int PerformanceEvaluationTypeDescriptorId { get; set; }
        public virtual short SchoolYear { get; set; }
        public virtual int TermDescriptorId { get; set; }
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.Evaluation table of the Evaluation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class Evaluation : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.IEvaluation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public Evaluation()
        {
            EvaluationRatingLevels = new HashSet<EvaluationRatingLevel>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationPeriodDescriptorId 
        {
            get
            {
                if (_evaluationPeriodDescriptorId == default(int))
                    _evaluationPeriodDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationPeriodDescriptor", _evaluationPeriodDescriptor);

                return _evaluationPeriodDescriptorId;
            } 
            set
            {
                _evaluationPeriodDescriptorId = value;
                _evaluationPeriodDescriptor = null;
            }
        }

        private int _evaluationPeriodDescriptorId;
        private string _evaluationPeriodDescriptor;

        public virtual string EvaluationPeriodDescriptor
        {
            get
            {
                if (_evaluationPeriodDescriptor == null)
                    _evaluationPeriodDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationPeriodDescriptor", _evaluationPeriodDescriptorId);
                    
                return _evaluationPeriodDescriptor;
            }
            set
            {
                _evaluationPeriodDescriptor = value;
                _evaluationPeriodDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string EvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string PerformanceEvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int PerformanceEvaluationTypeDescriptorId 
        {
            get
            {
                if (_performanceEvaluationTypeDescriptorId == default(int))
                    _performanceEvaluationTypeDescriptorId = DescriptorsCache.GetCache().GetId("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptor);

                return _performanceEvaluationTypeDescriptorId;
            } 
            set
            {
                _performanceEvaluationTypeDescriptorId = value;
                _performanceEvaluationTypeDescriptor = null;
            }
        }

        private int _performanceEvaluationTypeDescriptorId;
        private string _performanceEvaluationTypeDescriptor;

        public virtual string PerformanceEvaluationTypeDescriptor
        {
            get
            {
                if (_performanceEvaluationTypeDescriptor == null)
                    _performanceEvaluationTypeDescriptor = DescriptorsCache.GetCache().GetValue("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptorId);
                    
                return _performanceEvaluationTypeDescriptor;
            }
            set
            {
                _performanceEvaluationTypeDescriptor = value;
                _performanceEvaluationTypeDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual short SchoolYear  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int))
                    _termDescriptorId = DescriptorsCache.GetCache().GetId("TermDescriptor", _termDescriptor);

                return _termDescriptorId;
            } 
            set
            {
                _termDescriptorId = value;
                _termDescriptor = null;
            }
        }

        private int _termDescriptorId;
        private string _termDescriptor;

        public virtual string TermDescriptor
        {
            get
            {
                if (_termDescriptor == null)
                    _termDescriptor = DescriptorsCache.GetCache().GetValue("TermDescriptor", _termDescriptorId);
                    
                return _termDescriptor;
            }
            set
            {
                _termDescriptor = value;
                _termDescriptorId = default(int);
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
        [StringLength(255), NoDangerousText]
        public virtual string EvaluationDescription  { get; set; }
        public virtual int? EvaluationTypeDescriptorId 
        {
            get
            {
                if (_evaluationTypeDescriptorId == default(int?))
                    _evaluationTypeDescriptorId = string.IsNullOrWhiteSpace(_evaluationTypeDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("EvaluationTypeDescriptor", _evaluationTypeDescriptor);

                return _evaluationTypeDescriptorId;
            } 
            set
            {
                _evaluationTypeDescriptorId = value;
                _evaluationTypeDescriptor = null;
            }
        }

        private int? _evaluationTypeDescriptorId;
        private string _evaluationTypeDescriptor;

        public virtual string EvaluationTypeDescriptor
        {
            get
            {
                if (_evaluationTypeDescriptor == null)
                    _evaluationTypeDescriptor = _evaluationTypeDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("EvaluationTypeDescriptor", _evaluationTypeDescriptorId.Value);
                    
                return _evaluationTypeDescriptor;
            }
            set
            {
                _evaluationTypeDescriptor = value;
                _evaluationTypeDescriptorId = default(int?);
            }
        }
        public virtual int? InterRaterReliabilityScore  { get; set; }
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MaxRating  { get; set; }
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MinRating  { get; set; }
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
        public virtual NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluationReferenceData PerformanceEvaluationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the PerformanceEvaluation discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IEvaluation.PerformanceEvaluationDiscriminator
        {
            get { return PerformanceEvaluationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the PerformanceEvaluation resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IEvaluation.PerformanceEvaluationResourceId
        {
            get { return PerformanceEvaluationReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.EvaluationAggregate.TPDM.EvaluationRatingLevel> _evaluationRatingLevels;
        private ICollection<Entities.Common.TPDM.IEvaluationRatingLevel> _evaluationRatingLevelsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.EvaluationAggregate.TPDM.EvaluationRatingLevel> EvaluationRatingLevels
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationRatingLevels)
                    if (item.Evaluation == null)
                        item.Evaluation = this;
                // -------------------------------------------------------------

                return _evaluationRatingLevels;
            }
            set
            {
                _evaluationRatingLevels = value;
                _evaluationRatingLevelsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.IEvaluationRatingLevel, Entities.NHibernate.EvaluationAggregate.TPDM.EvaluationRatingLevel>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.IEvaluationRatingLevel> Entities.Common.TPDM.IEvaluation.EvaluationRatingLevels
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationRatingLevels)
                    if (item.Evaluation == null)
                        item.Evaluation = this;
                // -------------------------------------------------------------

                return _evaluationRatingLevelsCovariant;
            }
            set
            {
                EvaluationRatingLevels = new HashSet<Entities.NHibernate.EvaluationAggregate.TPDM.EvaluationRatingLevel>(value.Cast<Entities.NHibernate.EvaluationAggregate.TPDM.EvaluationRatingLevel>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "EvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "EvaluationTypeDescriptorId", LookupTypeName = "EvaluationTypeDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluation) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isEvaluationDescriptionSupported = true;
        bool Entities.Common.TPDM.IEvaluationSynchronizationSourceSupport.IsEvaluationDescriptionSupported
        {
            get { return _isEvaluationDescriptionSupported; }
            set { _isEvaluationDescriptionSupported = value; }
        }

        private bool _isEvaluationRatingLevelsSupported = true;
        bool Entities.Common.TPDM.IEvaluationSynchronizationSourceSupport.IsEvaluationRatingLevelsSupported
        {
            get { return _isEvaluationRatingLevelsSupported; }
            set { _isEvaluationRatingLevelsSupported = value; }
        }

        private bool _isEvaluationTypeDescriptorSupported = true;
        bool Entities.Common.TPDM.IEvaluationSynchronizationSourceSupport.IsEvaluationTypeDescriptorSupported
        {
            get { return _isEvaluationTypeDescriptorSupported; }
            set { _isEvaluationTypeDescriptorSupported = value; }
        }

        private bool _isInterRaterReliabilityScoreSupported = true;
        bool Entities.Common.TPDM.IEvaluationSynchronizationSourceSupport.IsInterRaterReliabilityScoreSupported
        {
            get { return _isInterRaterReliabilityScoreSupported; }
            set { _isInterRaterReliabilityScoreSupported = value; }
        }

        private bool _isMaxRatingSupported = true;
        bool Entities.Common.TPDM.IEvaluationSynchronizationSourceSupport.IsMaxRatingSupported
        {
            get { return _isMaxRatingSupported; }
            set { _isMaxRatingSupported = value; }
        }

        private bool _isMinRatingSupported = true;
        bool Entities.Common.TPDM.IEvaluationSynchronizationSourceSupport.IsMinRatingSupported
        {
            get { return _isMinRatingSupported; }
            set { _isMinRatingSupported = value; }
        }

        private Func<Entities.Common.TPDM.IEvaluationRatingLevel, bool> _isEvaluationRatingLevelIncluded;
        Func<Entities.Common.TPDM.IEvaluationRatingLevel, bool> Entities.Common.TPDM.IEvaluationSynchronizationSourceSupport.IsEvaluationRatingLevelIncluded
        {
            get { return _isEvaluationRatingLevelIncluded; }
            set { _isEvaluationRatingLevelIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationRatingLevel table of the Evaluation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevel : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IEvaluationRatingLevel, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationRatingLevelSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationRatingLevel()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Evaluation Evaluation { get; set; }

        Entities.Common.TPDM.IEvaluation IEvaluationRatingLevel.Evaluation
        {
            get { return Evaluation; }
            set { Evaluation = (Evaluation) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationRatingLevelDescriptorId 
        {
            get
            {
                if (_evaluationRatingLevelDescriptorId == default(int))
                    _evaluationRatingLevelDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationRatingLevelDescriptor", _evaluationRatingLevelDescriptor);

                return _evaluationRatingLevelDescriptorId;
            } 
            set
            {
                _evaluationRatingLevelDescriptorId = value;
                _evaluationRatingLevelDescriptor = null;
            }
        }

        private int _evaluationRatingLevelDescriptorId;
        private string _evaluationRatingLevelDescriptor;

        public virtual string EvaluationRatingLevelDescriptor
        {
            get
            {
                if (_evaluationRatingLevelDescriptor == null)
                    _evaluationRatingLevelDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationRatingLevelDescriptor", _evaluationRatingLevelDescriptorId);
                    
                return _evaluationRatingLevelDescriptor;
            }
            set
            {
                _evaluationRatingLevelDescriptor = value;
                _evaluationRatingLevelDescriptorId = default(int);
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
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MaxRating  { get; set; }
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MinRating  { get; set; }
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
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "EvaluationRatingLevelDescriptor", new LookupColumnDetails { PropertyName = "EvaluationRatingLevelDescriptorId", LookupTypeName = "EvaluationRatingLevelDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Evaluation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("EvaluationRatingLevelDescriptorId", EvaluationRatingLevelDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationRatingLevel)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationRatingLevel) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Evaluation = (Evaluation) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isMaxRatingSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingLevelSynchronizationSourceSupport.IsMaxRatingSupported
        {
            get { return _isMaxRatingSupported; }
            set { _isMaxRatingSupported = value; }
        }

        private bool _isMinRatingSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingLevelSynchronizationSourceSupport.IsMinRatingSupported
        {
            get { return _isMinRatingSupported; }
            set { _isMinRatingSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EvaluationElement

namespace EdFi.Ods.Entities.NHibernate.EvaluationElementAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="EvaluationElement"/> entity.
    /// </summary>
    public class EvaluationElementReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId { get; set; }
        public virtual string EvaluationElementTitle { get; set; }
        public virtual string EvaluationObjectiveTitle { get; set; }
        public virtual int EvaluationPeriodDescriptorId { get; set; }
        public virtual string EvaluationTitle { get; set; }
        public virtual string PerformanceEvaluationTitle { get; set; }
        public virtual int PerformanceEvaluationTypeDescriptorId { get; set; }
        public virtual short SchoolYear { get; set; }
        public virtual int TermDescriptorId { get; set; }
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationElementTitle", EvaluationElementTitle);
            keyValues.Add("EvaluationObjectiveTitle", EvaluationObjectiveTitle);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationElement table of the EvaluationElement aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationElement : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.IEvaluationElement, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationElementSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationElement()
        {
            EvaluationElementRatingLevels = new HashSet<EvaluationElementRatingLevel>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(255), NoDangerousText, NoWhitespace]
        public virtual string EvaluationElementTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string EvaluationObjectiveTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationPeriodDescriptorId 
        {
            get
            {
                if (_evaluationPeriodDescriptorId == default(int))
                    _evaluationPeriodDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationPeriodDescriptor", _evaluationPeriodDescriptor);

                return _evaluationPeriodDescriptorId;
            } 
            set
            {
                _evaluationPeriodDescriptorId = value;
                _evaluationPeriodDescriptor = null;
            }
        }

        private int _evaluationPeriodDescriptorId;
        private string _evaluationPeriodDescriptor;

        public virtual string EvaluationPeriodDescriptor
        {
            get
            {
                if (_evaluationPeriodDescriptor == null)
                    _evaluationPeriodDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationPeriodDescriptor", _evaluationPeriodDescriptorId);
                    
                return _evaluationPeriodDescriptor;
            }
            set
            {
                _evaluationPeriodDescriptor = value;
                _evaluationPeriodDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string EvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string PerformanceEvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int PerformanceEvaluationTypeDescriptorId 
        {
            get
            {
                if (_performanceEvaluationTypeDescriptorId == default(int))
                    _performanceEvaluationTypeDescriptorId = DescriptorsCache.GetCache().GetId("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptor);

                return _performanceEvaluationTypeDescriptorId;
            } 
            set
            {
                _performanceEvaluationTypeDescriptorId = value;
                _performanceEvaluationTypeDescriptor = null;
            }
        }

        private int _performanceEvaluationTypeDescriptorId;
        private string _performanceEvaluationTypeDescriptor;

        public virtual string PerformanceEvaluationTypeDescriptor
        {
            get
            {
                if (_performanceEvaluationTypeDescriptor == null)
                    _performanceEvaluationTypeDescriptor = DescriptorsCache.GetCache().GetValue("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptorId);
                    
                return _performanceEvaluationTypeDescriptor;
            }
            set
            {
                _performanceEvaluationTypeDescriptor = value;
                _performanceEvaluationTypeDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual short SchoolYear  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int))
                    _termDescriptorId = DescriptorsCache.GetCache().GetId("TermDescriptor", _termDescriptor);

                return _termDescriptorId;
            } 
            set
            {
                _termDescriptorId = value;
                _termDescriptor = null;
            }
        }

        private int _termDescriptorId;
        private string _termDescriptor;

        public virtual string TermDescriptor
        {
            get
            {
                if (_termDescriptor == null)
                    _termDescriptor = DescriptorsCache.GetCache().GetValue("TermDescriptor", _termDescriptorId);
                    
                return _termDescriptor;
            }
            set
            {
                _termDescriptor = value;
                _termDescriptorId = default(int);
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
        public virtual int? EvaluationTypeDescriptorId 
        {
            get
            {
                if (_evaluationTypeDescriptorId == default(int?))
                    _evaluationTypeDescriptorId = string.IsNullOrWhiteSpace(_evaluationTypeDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("EvaluationTypeDescriptor", _evaluationTypeDescriptor);

                return _evaluationTypeDescriptorId;
            } 
            set
            {
                _evaluationTypeDescriptorId = value;
                _evaluationTypeDescriptor = null;
            }
        }

        private int? _evaluationTypeDescriptorId;
        private string _evaluationTypeDescriptor;

        public virtual string EvaluationTypeDescriptor
        {
            get
            {
                if (_evaluationTypeDescriptor == null)
                    _evaluationTypeDescriptor = _evaluationTypeDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("EvaluationTypeDescriptor", _evaluationTypeDescriptorId.Value);
                    
                return _evaluationTypeDescriptor;
            }
            set
            {
                _evaluationTypeDescriptor = value;
                _evaluationTypeDescriptorId = default(int?);
            }
        }
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MaxRating  { get; set; }
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MinRating  { get; set; }
        public virtual int? SortOrder  { get; set; }
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
        public virtual NHibernate.EvaluationObjectiveAggregate.TPDM.EvaluationObjectiveReferenceData EvaluationObjectiveReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the EvaluationObjective discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IEvaluationElement.EvaluationObjectiveDiscriminator
        {
            get { return EvaluationObjectiveReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the EvaluationObjective resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IEvaluationElement.EvaluationObjectiveResourceId
        {
            get { return EvaluationObjectiveReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.EvaluationElementAggregate.TPDM.EvaluationElementRatingLevel> _evaluationElementRatingLevels;
        private ICollection<Entities.Common.TPDM.IEvaluationElementRatingLevel> _evaluationElementRatingLevelsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.EvaluationElementAggregate.TPDM.EvaluationElementRatingLevel> EvaluationElementRatingLevels
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationElementRatingLevels)
                    if (item.EvaluationElement == null)
                        item.EvaluationElement = this;
                // -------------------------------------------------------------

                return _evaluationElementRatingLevels;
            }
            set
            {
                _evaluationElementRatingLevels = value;
                _evaluationElementRatingLevelsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.IEvaluationElementRatingLevel, Entities.NHibernate.EvaluationElementAggregate.TPDM.EvaluationElementRatingLevel>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.IEvaluationElementRatingLevel> Entities.Common.TPDM.IEvaluationElement.EvaluationElementRatingLevels
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationElementRatingLevels)
                    if (item.EvaluationElement == null)
                        item.EvaluationElement = this;
                // -------------------------------------------------------------

                return _evaluationElementRatingLevelsCovariant;
            }
            set
            {
                EvaluationElementRatingLevels = new HashSet<Entities.NHibernate.EvaluationElementAggregate.TPDM.EvaluationElementRatingLevel>(value.Cast<Entities.NHibernate.EvaluationElementAggregate.TPDM.EvaluationElementRatingLevel>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "EvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "EvaluationTypeDescriptorId", LookupTypeName = "EvaluationTypeDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationElementTitle", EvaluationElementTitle);
            keyValues.Add("EvaluationObjectiveTitle", EvaluationObjectiveTitle);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationElement)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationElement) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isEvaluationElementRatingLevelsSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementSynchronizationSourceSupport.IsEvaluationElementRatingLevelsSupported
        {
            get { return _isEvaluationElementRatingLevelsSupported; }
            set { _isEvaluationElementRatingLevelsSupported = value; }
        }

        private bool _isEvaluationTypeDescriptorSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementSynchronizationSourceSupport.IsEvaluationTypeDescriptorSupported
        {
            get { return _isEvaluationTypeDescriptorSupported; }
            set { _isEvaluationTypeDescriptorSupported = value; }
        }

        private bool _isMaxRatingSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementSynchronizationSourceSupport.IsMaxRatingSupported
        {
            get { return _isMaxRatingSupported; }
            set { _isMaxRatingSupported = value; }
        }

        private bool _isMinRatingSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementSynchronizationSourceSupport.IsMinRatingSupported
        {
            get { return _isMinRatingSupported; }
            set { _isMinRatingSupported = value; }
        }

        private bool _isSortOrderSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementSynchronizationSourceSupport.IsSortOrderSupported
        {
            get { return _isSortOrderSupported; }
            set { _isSortOrderSupported = value; }
        }

        private Func<Entities.Common.TPDM.IEvaluationElementRatingLevel, bool> _isEvaluationElementRatingLevelIncluded;
        Func<Entities.Common.TPDM.IEvaluationElementRatingLevel, bool> Entities.Common.TPDM.IEvaluationElementSynchronizationSourceSupport.IsEvaluationElementRatingLevelIncluded
        {
            get { return _isEvaluationElementRatingLevelIncluded; }
            set { _isEvaluationElementRatingLevelIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationElementRatingLevel table of the EvaluationElement aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevel : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IEvaluationElementRatingLevel, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationElementRatingLevelSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationElementRatingLevel()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EvaluationElement EvaluationElement { get; set; }

        Entities.Common.TPDM.IEvaluationElement IEvaluationElementRatingLevel.EvaluationElement
        {
            get { return EvaluationElement; }
            set { EvaluationElement = (EvaluationElement) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationRatingLevelDescriptorId 
        {
            get
            {
                if (_evaluationRatingLevelDescriptorId == default(int))
                    _evaluationRatingLevelDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationRatingLevelDescriptor", _evaluationRatingLevelDescriptor);

                return _evaluationRatingLevelDescriptorId;
            } 
            set
            {
                _evaluationRatingLevelDescriptorId = value;
                _evaluationRatingLevelDescriptor = null;
            }
        }

        private int _evaluationRatingLevelDescriptorId;
        private string _evaluationRatingLevelDescriptor;

        public virtual string EvaluationRatingLevelDescriptor
        {
            get
            {
                if (_evaluationRatingLevelDescriptor == null)
                    _evaluationRatingLevelDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationRatingLevelDescriptor", _evaluationRatingLevelDescriptorId);
                    
                return _evaluationRatingLevelDescriptor;
            }
            set
            {
                _evaluationRatingLevelDescriptor = value;
                _evaluationRatingLevelDescriptorId = default(int);
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
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MaxRating  { get; set; }
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MinRating  { get; set; }
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
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "EvaluationRatingLevelDescriptor", new LookupColumnDetails { PropertyName = "EvaluationRatingLevelDescriptorId", LookupTypeName = "EvaluationRatingLevelDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (EvaluationElement as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("EvaluationRatingLevelDescriptorId", EvaluationRatingLevelDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationElementRatingLevel)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationElementRatingLevel) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            EvaluationElement = (EvaluationElement) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isMaxRatingSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingLevelSynchronizationSourceSupport.IsMaxRatingSupported
        {
            get { return _isMaxRatingSupported; }
            set { _isMaxRatingSupported = value; }
        }

        private bool _isMinRatingSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingLevelSynchronizationSourceSupport.IsMinRatingSupported
        {
            get { return _isMinRatingSupported; }
            set { _isMinRatingSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EvaluationElementRating

namespace EdFi.Ods.Entities.NHibernate.EvaluationElementRatingAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="EvaluationElementRating"/> entity.
    /// </summary>
    public class EvaluationElementRatingReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId { get; set; }
        public virtual DateTime EvaluationDate { get; set; }
        public virtual string EvaluationElementTitle { get; set; }
        public virtual string EvaluationObjectiveTitle { get; set; }
        public virtual int EvaluationPeriodDescriptorId { get; set; }
        public virtual string EvaluationTitle { get; set; }
        public virtual string PerformanceEvaluationTitle { get; set; }
        public virtual int PerformanceEvaluationTypeDescriptorId { get; set; }
        public virtual string PersonId { get; set; }
        public virtual short SchoolYear { get; set; }
        public virtual int SourceSystemDescriptorId { get; set; }
        public virtual int TermDescriptorId { get; set; }
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationDate", EvaluationDate);
            keyValues.Add("EvaluationElementTitle", EvaluationElementTitle);
            keyValues.Add("EvaluationObjectiveTitle", EvaluationObjectiveTitle);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("PersonId", PersonId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("SourceSystemDescriptorId", SourceSystemDescriptorId);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationElementRating table of the EvaluationElementRating aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationElementRating : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.IEvaluationElementRating, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationElementRatingSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationElementRating()
        {
            EvaluationElementRatingResults = new HashSet<EvaluationElementRatingResult>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault, SqlServerDateTimeRange]
        public virtual DateTime EvaluationDate 
        {
            get { return _evaluationDate; }
            set
            {
                // This is only stored as a UTC DateTime in the DB and NHibernate will retrieve it back as the (UTC) DateTime.Kind.
                // Note ToUniversal will work differently based on DateTime.Kind
                // See https://docs.microsoft.com/en-us/dotnet/api/system.datetime.touniversaltime?view=netframework-4.5#System_DateTime_ToUniversalTime
                // Utc - No conversion is performed.
                // Local - The current DateTime object is converted to UTC.
                // Unspecified - The current DateTime object is assumed to be a local time, and the conversion is performed as if Kind were Local.
                if (value != (DateTime)typeof(DateTime).GetDefaultValue())
                    _evaluationDate = value.ToUniversalTime();
            }
        }

        private DateTime _evaluationDate;

        [DomainSignature, RequiredWithNonDefault, StringLength(255), NoDangerousText, NoWhitespace]
        public virtual string EvaluationElementTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string EvaluationObjectiveTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationPeriodDescriptorId 
        {
            get
            {
                if (_evaluationPeriodDescriptorId == default(int))
                    _evaluationPeriodDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationPeriodDescriptor", _evaluationPeriodDescriptor);

                return _evaluationPeriodDescriptorId;
            } 
            set
            {
                _evaluationPeriodDescriptorId = value;
                _evaluationPeriodDescriptor = null;
            }
        }

        private int _evaluationPeriodDescriptorId;
        private string _evaluationPeriodDescriptor;

        public virtual string EvaluationPeriodDescriptor
        {
            get
            {
                if (_evaluationPeriodDescriptor == null)
                    _evaluationPeriodDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationPeriodDescriptor", _evaluationPeriodDescriptorId);
                    
                return _evaluationPeriodDescriptor;
            }
            set
            {
                _evaluationPeriodDescriptor = value;
                _evaluationPeriodDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string EvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string PerformanceEvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int PerformanceEvaluationTypeDescriptorId 
        {
            get
            {
                if (_performanceEvaluationTypeDescriptorId == default(int))
                    _performanceEvaluationTypeDescriptorId = DescriptorsCache.GetCache().GetId("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptor);

                return _performanceEvaluationTypeDescriptorId;
            } 
            set
            {
                _performanceEvaluationTypeDescriptorId = value;
                _performanceEvaluationTypeDescriptor = null;
            }
        }

        private int _performanceEvaluationTypeDescriptorId;
        private string _performanceEvaluationTypeDescriptor;

        public virtual string PerformanceEvaluationTypeDescriptor
        {
            get
            {
                if (_performanceEvaluationTypeDescriptor == null)
                    _performanceEvaluationTypeDescriptor = DescriptorsCache.GetCache().GetValue("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptorId);
                    
                return _performanceEvaluationTypeDescriptor;
            }
            set
            {
                _performanceEvaluationTypeDescriptor = value;
                _performanceEvaluationTypeDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(32), NoDangerousText, NoWhitespace]
        public virtual string PersonId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual short SchoolYear  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int SourceSystemDescriptorId 
        {
            get
            {
                if (_sourceSystemDescriptorId == default(int))
                    _sourceSystemDescriptorId = DescriptorsCache.GetCache().GetId("SourceSystemDescriptor", _sourceSystemDescriptor);

                return _sourceSystemDescriptorId;
            } 
            set
            {
                _sourceSystemDescriptorId = value;
                _sourceSystemDescriptor = null;
            }
        }

        private int _sourceSystemDescriptorId;
        private string _sourceSystemDescriptor;

        public virtual string SourceSystemDescriptor
        {
            get
            {
                if (_sourceSystemDescriptor == null)
                    _sourceSystemDescriptor = DescriptorsCache.GetCache().GetValue("SourceSystemDescriptor", _sourceSystemDescriptorId);
                    
                return _sourceSystemDescriptor;
            }
            set
            {
                _sourceSystemDescriptor = value;
                _sourceSystemDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int))
                    _termDescriptorId = DescriptorsCache.GetCache().GetId("TermDescriptor", _termDescriptor);

                return _termDescriptorId;
            } 
            set
            {
                _termDescriptorId = value;
                _termDescriptor = null;
            }
        }

        private int _termDescriptorId;
        private string _termDescriptor;

        public virtual string TermDescriptor
        {
            get
            {
                if (_termDescriptor == null)
                    _termDescriptor = DescriptorsCache.GetCache().GetValue("TermDescriptor", _termDescriptorId);
                    
                return _termDescriptor;
            }
            set
            {
                _termDescriptor = value;
                _termDescriptorId = default(int);
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
        [StringLength(1024), NoDangerousText]
        public virtual string AreaOfRefinement  { get; set; }
        [StringLength(1024), NoDangerousText]
        public virtual string AreaOfReinforcement  { get; set; }
        [StringLength(1024), NoDangerousText]
        public virtual string Comments  { get; set; }
        public virtual int? EvaluationElementRatingLevelDescriptorId 
        {
            get
            {
                if (_evaluationElementRatingLevelDescriptorId == default(int?))
                    _evaluationElementRatingLevelDescriptorId = string.IsNullOrWhiteSpace(_evaluationElementRatingLevelDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("EvaluationElementRatingLevelDescriptor", _evaluationElementRatingLevelDescriptor);

                return _evaluationElementRatingLevelDescriptorId;
            } 
            set
            {
                _evaluationElementRatingLevelDescriptorId = value;
                _evaluationElementRatingLevelDescriptor = null;
            }
        }

        private int? _evaluationElementRatingLevelDescriptorId;
        private string _evaluationElementRatingLevelDescriptor;

        public virtual string EvaluationElementRatingLevelDescriptor
        {
            get
            {
                if (_evaluationElementRatingLevelDescriptor == null)
                    _evaluationElementRatingLevelDescriptor = _evaluationElementRatingLevelDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("EvaluationElementRatingLevelDescriptor", _evaluationElementRatingLevelDescriptorId.Value);
                    
                return _evaluationElementRatingLevelDescriptor;
            }
            set
            {
                _evaluationElementRatingLevelDescriptor = value;
                _evaluationElementRatingLevelDescriptorId = default(int?);
            }
        }
        [StringLength(2048), NoDangerousText]
        public virtual string Feedback  { get; set; }
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
        public virtual NHibernate.EvaluationElementAggregate.TPDM.EvaluationElementReferenceData EvaluationElementReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the EvaluationElement discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IEvaluationElementRating.EvaluationElementDiscriminator
        {
            get { return EvaluationElementReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the EvaluationElement resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IEvaluationElementRating.EvaluationElementResourceId
        {
            get { return EvaluationElementReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.EvaluationObjectiveRatingAggregate.TPDM.EvaluationObjectiveRatingReferenceData EvaluationObjectiveRatingReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the EvaluationObjectiveRating discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IEvaluationElementRating.EvaluationObjectiveRatingDiscriminator
        {
            get { return EvaluationObjectiveRatingReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the EvaluationObjectiveRating resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IEvaluationElementRating.EvaluationObjectiveRatingResourceId
        {
            get { return EvaluationObjectiveRatingReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.EvaluationElementRatingAggregate.TPDM.EvaluationElementRatingResult> _evaluationElementRatingResults;
        private ICollection<Entities.Common.TPDM.IEvaluationElementRatingResult> _evaluationElementRatingResultsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.EvaluationElementRatingAggregate.TPDM.EvaluationElementRatingResult> EvaluationElementRatingResults
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationElementRatingResults)
                    if (item.EvaluationElementRating == null)
                        item.EvaluationElementRating = this;
                // -------------------------------------------------------------

                return _evaluationElementRatingResults;
            }
            set
            {
                _evaluationElementRatingResults = value;
                _evaluationElementRatingResultsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.IEvaluationElementRatingResult, Entities.NHibernate.EvaluationElementRatingAggregate.TPDM.EvaluationElementRatingResult>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.IEvaluationElementRatingResult> Entities.Common.TPDM.IEvaluationElementRating.EvaluationElementRatingResults
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationElementRatingResults)
                    if (item.EvaluationElementRating == null)
                        item.EvaluationElementRating = this;
                // -------------------------------------------------------------

                return _evaluationElementRatingResultsCovariant;
            }
            set
            {
                EvaluationElementRatingResults = new HashSet<Entities.NHibernate.EvaluationElementRatingAggregate.TPDM.EvaluationElementRatingResult>(value.Cast<Entities.NHibernate.EvaluationElementRatingAggregate.TPDM.EvaluationElementRatingResult>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "EvaluationElementRatingLevelDescriptor", new LookupColumnDetails { PropertyName = "EvaluationElementRatingLevelDescriptorId", LookupTypeName = "EvaluationElementRatingLevelDescriptor"} },
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationDate", EvaluationDate);
            keyValues.Add("EvaluationElementTitle", EvaluationElementTitle);
            keyValues.Add("EvaluationObjectiveTitle", EvaluationObjectiveTitle);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("PersonId", PersonId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("SourceSystemDescriptorId", SourceSystemDescriptorId);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationElementRating)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationElementRating) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isAreaOfRefinementSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingSynchronizationSourceSupport.IsAreaOfRefinementSupported
        {
            get { return _isAreaOfRefinementSupported; }
            set { _isAreaOfRefinementSupported = value; }
        }

        private bool _isAreaOfReinforcementSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingSynchronizationSourceSupport.IsAreaOfReinforcementSupported
        {
            get { return _isAreaOfReinforcementSupported; }
            set { _isAreaOfReinforcementSupported = value; }
        }

        private bool _isCommentsSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingSynchronizationSourceSupport.IsCommentsSupported
        {
            get { return _isCommentsSupported; }
            set { _isCommentsSupported = value; }
        }

        private bool _isEvaluationElementRatingLevelDescriptorSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingSynchronizationSourceSupport.IsEvaluationElementRatingLevelDescriptorSupported
        {
            get { return _isEvaluationElementRatingLevelDescriptorSupported; }
            set { _isEvaluationElementRatingLevelDescriptorSupported = value; }
        }

        private bool _isEvaluationElementRatingResultsSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingSynchronizationSourceSupport.IsEvaluationElementRatingResultsSupported
        {
            get { return _isEvaluationElementRatingResultsSupported; }
            set { _isEvaluationElementRatingResultsSupported = value; }
        }

        private bool _isFeedbackSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingSynchronizationSourceSupport.IsFeedbackSupported
        {
            get { return _isFeedbackSupported; }
            set { _isFeedbackSupported = value; }
        }

        private Func<Entities.Common.TPDM.IEvaluationElementRatingResult, bool> _isEvaluationElementRatingResultIncluded;
        Func<Entities.Common.TPDM.IEvaluationElementRatingResult, bool> Entities.Common.TPDM.IEvaluationElementRatingSynchronizationSourceSupport.IsEvaluationElementRatingResultIncluded
        {
            get { return _isEvaluationElementRatingResultIncluded; }
            set { _isEvaluationElementRatingResultIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationElementRatingResult table of the EvaluationElementRating aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingResult : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IEvaluationElementRatingResult, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationElementRatingResultSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationElementRatingResult()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EvaluationElementRating EvaluationElementRating { get; set; }

        Entities.Common.TPDM.IEvaluationElementRating IEvaluationElementRatingResult.EvaluationElementRating
        {
            get { return EvaluationElementRating; }
            set { EvaluationElementRating = (EvaluationElementRating) value; }
        }

        [DomainSignature]
        public virtual decimal Rating  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string RatingResultTitle  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [RequiredWithNonDefault]
        public virtual int ResultDatatypeTypeDescriptorId 
        {
            get
            {
                if (_resultDatatypeTypeDescriptorId == default(int))
                    _resultDatatypeTypeDescriptorId = DescriptorsCache.GetCache().GetId("ResultDatatypeTypeDescriptor", _resultDatatypeTypeDescriptor);

                return _resultDatatypeTypeDescriptorId;
            } 
            set
            {
                _resultDatatypeTypeDescriptorId = value;
                _resultDatatypeTypeDescriptor = null;
            }
        }

        private int _resultDatatypeTypeDescriptorId;
        private string _resultDatatypeTypeDescriptor;

        public virtual string ResultDatatypeTypeDescriptor
        {
            get
            {
                if (_resultDatatypeTypeDescriptor == null)
                    _resultDatatypeTypeDescriptor = DescriptorsCache.GetCache().GetValue("ResultDatatypeTypeDescriptor", _resultDatatypeTypeDescriptorId);
                    
                return _resultDatatypeTypeDescriptor;
            }
            set
            {
                _resultDatatypeTypeDescriptor = value;
                _resultDatatypeTypeDescriptorId = default(int);
            }
        }
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
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "ResultDatatypeTypeDescriptor", new LookupColumnDetails { PropertyName = "ResultDatatypeTypeDescriptorId", LookupTypeName = "ResultDatatypeTypeDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (EvaluationElementRating as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("Rating", Rating);
            keyValues.Add("RatingResultTitle", RatingResultTitle);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationElementRatingResult)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationElementRatingResult) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            EvaluationElementRating = (EvaluationElementRating) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isResultDatatypeTypeDescriptorSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingResultSynchronizationSourceSupport.IsResultDatatypeTypeDescriptorSupported
        {
            get { return _isResultDatatypeTypeDescriptorSupported; }
            set { _isResultDatatypeTypeDescriptorSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EvaluationElementRatingLevelDescriptor

namespace EdFi.Ods.Entities.NHibernate.EvaluationElementRatingLevelDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationElementRatingLevelDescriptor table of the EvaluationElementRatingLevelDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevelDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int EvaluationElementRatingLevelDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("EvaluationElementRatingLevelDescriptorId", EvaluationElementRatingLevelDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EvaluationObjective

namespace EdFi.Ods.Entities.NHibernate.EvaluationObjectiveAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="EvaluationObjective"/> entity.
    /// </summary>
    public class EvaluationObjectiveReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId { get; set; }
        public virtual string EvaluationObjectiveTitle { get; set; }
        public virtual int EvaluationPeriodDescriptorId { get; set; }
        public virtual string EvaluationTitle { get; set; }
        public virtual string PerformanceEvaluationTitle { get; set; }
        public virtual int PerformanceEvaluationTypeDescriptorId { get; set; }
        public virtual short SchoolYear { get; set; }
        public virtual int TermDescriptorId { get; set; }
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationObjectiveTitle", EvaluationObjectiveTitle);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationObjective table of the EvaluationObjective aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationObjective : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.IEvaluationObjective, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationObjectiveSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationObjective()
        {
            EvaluationObjectiveRatingLevels = new HashSet<EvaluationObjectiveRatingLevel>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string EvaluationObjectiveTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationPeriodDescriptorId 
        {
            get
            {
                if (_evaluationPeriodDescriptorId == default(int))
                    _evaluationPeriodDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationPeriodDescriptor", _evaluationPeriodDescriptor);

                return _evaluationPeriodDescriptorId;
            } 
            set
            {
                _evaluationPeriodDescriptorId = value;
                _evaluationPeriodDescriptor = null;
            }
        }

        private int _evaluationPeriodDescriptorId;
        private string _evaluationPeriodDescriptor;

        public virtual string EvaluationPeriodDescriptor
        {
            get
            {
                if (_evaluationPeriodDescriptor == null)
                    _evaluationPeriodDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationPeriodDescriptor", _evaluationPeriodDescriptorId);
                    
                return _evaluationPeriodDescriptor;
            }
            set
            {
                _evaluationPeriodDescriptor = value;
                _evaluationPeriodDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string EvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string PerformanceEvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int PerformanceEvaluationTypeDescriptorId 
        {
            get
            {
                if (_performanceEvaluationTypeDescriptorId == default(int))
                    _performanceEvaluationTypeDescriptorId = DescriptorsCache.GetCache().GetId("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptor);

                return _performanceEvaluationTypeDescriptorId;
            } 
            set
            {
                _performanceEvaluationTypeDescriptorId = value;
                _performanceEvaluationTypeDescriptor = null;
            }
        }

        private int _performanceEvaluationTypeDescriptorId;
        private string _performanceEvaluationTypeDescriptor;

        public virtual string PerformanceEvaluationTypeDescriptor
        {
            get
            {
                if (_performanceEvaluationTypeDescriptor == null)
                    _performanceEvaluationTypeDescriptor = DescriptorsCache.GetCache().GetValue("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptorId);
                    
                return _performanceEvaluationTypeDescriptor;
            }
            set
            {
                _performanceEvaluationTypeDescriptor = value;
                _performanceEvaluationTypeDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual short SchoolYear  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int))
                    _termDescriptorId = DescriptorsCache.GetCache().GetId("TermDescriptor", _termDescriptor);

                return _termDescriptorId;
            } 
            set
            {
                _termDescriptorId = value;
                _termDescriptor = null;
            }
        }

        private int _termDescriptorId;
        private string _termDescriptor;

        public virtual string TermDescriptor
        {
            get
            {
                if (_termDescriptor == null)
                    _termDescriptor = DescriptorsCache.GetCache().GetValue("TermDescriptor", _termDescriptorId);
                    
                return _termDescriptor;
            }
            set
            {
                _termDescriptor = value;
                _termDescriptorId = default(int);
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
        [StringLength(255), NoDangerousText]
        public virtual string EvaluationObjectiveDescription  { get; set; }
        public virtual int? EvaluationTypeDescriptorId 
        {
            get
            {
                if (_evaluationTypeDescriptorId == default(int?))
                    _evaluationTypeDescriptorId = string.IsNullOrWhiteSpace(_evaluationTypeDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("EvaluationTypeDescriptor", _evaluationTypeDescriptor);

                return _evaluationTypeDescriptorId;
            } 
            set
            {
                _evaluationTypeDescriptorId = value;
                _evaluationTypeDescriptor = null;
            }
        }

        private int? _evaluationTypeDescriptorId;
        private string _evaluationTypeDescriptor;

        public virtual string EvaluationTypeDescriptor
        {
            get
            {
                if (_evaluationTypeDescriptor == null)
                    _evaluationTypeDescriptor = _evaluationTypeDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("EvaluationTypeDescriptor", _evaluationTypeDescriptorId.Value);
                    
                return _evaluationTypeDescriptor;
            }
            set
            {
                _evaluationTypeDescriptor = value;
                _evaluationTypeDescriptorId = default(int?);
            }
        }
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MaxRating  { get; set; }
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MinRating  { get; set; }
        public virtual int? SortOrder  { get; set; }
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
        public virtual NHibernate.EvaluationAggregate.TPDM.EvaluationReferenceData EvaluationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Evaluation discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IEvaluationObjective.EvaluationDiscriminator
        {
            get { return EvaluationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Evaluation resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IEvaluationObjective.EvaluationResourceId
        {
            get { return EvaluationReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.EvaluationObjectiveAggregate.TPDM.EvaluationObjectiveRatingLevel> _evaluationObjectiveRatingLevels;
        private ICollection<Entities.Common.TPDM.IEvaluationObjectiveRatingLevel> _evaluationObjectiveRatingLevelsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.EvaluationObjectiveAggregate.TPDM.EvaluationObjectiveRatingLevel> EvaluationObjectiveRatingLevels
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationObjectiveRatingLevels)
                    if (item.EvaluationObjective == null)
                        item.EvaluationObjective = this;
                // -------------------------------------------------------------

                return _evaluationObjectiveRatingLevels;
            }
            set
            {
                _evaluationObjectiveRatingLevels = value;
                _evaluationObjectiveRatingLevelsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.IEvaluationObjectiveRatingLevel, Entities.NHibernate.EvaluationObjectiveAggregate.TPDM.EvaluationObjectiveRatingLevel>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.IEvaluationObjectiveRatingLevel> Entities.Common.TPDM.IEvaluationObjective.EvaluationObjectiveRatingLevels
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationObjectiveRatingLevels)
                    if (item.EvaluationObjective == null)
                        item.EvaluationObjective = this;
                // -------------------------------------------------------------

                return _evaluationObjectiveRatingLevelsCovariant;
            }
            set
            {
                EvaluationObjectiveRatingLevels = new HashSet<Entities.NHibernate.EvaluationObjectiveAggregate.TPDM.EvaluationObjectiveRatingLevel>(value.Cast<Entities.NHibernate.EvaluationObjectiveAggregate.TPDM.EvaluationObjectiveRatingLevel>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "EvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "EvaluationTypeDescriptorId", LookupTypeName = "EvaluationTypeDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationObjectiveTitle", EvaluationObjectiveTitle);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationObjective)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationObjective) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isEvaluationObjectiveDescriptionSupported = true;
        bool Entities.Common.TPDM.IEvaluationObjectiveSynchronizationSourceSupport.IsEvaluationObjectiveDescriptionSupported
        {
            get { return _isEvaluationObjectiveDescriptionSupported; }
            set { _isEvaluationObjectiveDescriptionSupported = value; }
        }

        private bool _isEvaluationObjectiveRatingLevelsSupported = true;
        bool Entities.Common.TPDM.IEvaluationObjectiveSynchronizationSourceSupport.IsEvaluationObjectiveRatingLevelsSupported
        {
            get { return _isEvaluationObjectiveRatingLevelsSupported; }
            set { _isEvaluationObjectiveRatingLevelsSupported = value; }
        }

        private bool _isEvaluationTypeDescriptorSupported = true;
        bool Entities.Common.TPDM.IEvaluationObjectiveSynchronizationSourceSupport.IsEvaluationTypeDescriptorSupported
        {
            get { return _isEvaluationTypeDescriptorSupported; }
            set { _isEvaluationTypeDescriptorSupported = value; }
        }

        private bool _isMaxRatingSupported = true;
        bool Entities.Common.TPDM.IEvaluationObjectiveSynchronizationSourceSupport.IsMaxRatingSupported
        {
            get { return _isMaxRatingSupported; }
            set { _isMaxRatingSupported = value; }
        }

        private bool _isMinRatingSupported = true;
        bool Entities.Common.TPDM.IEvaluationObjectiveSynchronizationSourceSupport.IsMinRatingSupported
        {
            get { return _isMinRatingSupported; }
            set { _isMinRatingSupported = value; }
        }

        private bool _isSortOrderSupported = true;
        bool Entities.Common.TPDM.IEvaluationObjectiveSynchronizationSourceSupport.IsSortOrderSupported
        {
            get { return _isSortOrderSupported; }
            set { _isSortOrderSupported = value; }
        }

        private Func<Entities.Common.TPDM.IEvaluationObjectiveRatingLevel, bool> _isEvaluationObjectiveRatingLevelIncluded;
        Func<Entities.Common.TPDM.IEvaluationObjectiveRatingLevel, bool> Entities.Common.TPDM.IEvaluationObjectiveSynchronizationSourceSupport.IsEvaluationObjectiveRatingLevelIncluded
        {
            get { return _isEvaluationObjectiveRatingLevelIncluded; }
            set { _isEvaluationObjectiveRatingLevelIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationObjectiveRatingLevel table of the EvaluationObjective aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingLevel : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IEvaluationObjectiveRatingLevel, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationObjectiveRatingLevelSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationObjectiveRatingLevel()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EvaluationObjective EvaluationObjective { get; set; }

        Entities.Common.TPDM.IEvaluationObjective IEvaluationObjectiveRatingLevel.EvaluationObjective
        {
            get { return EvaluationObjective; }
            set { EvaluationObjective = (EvaluationObjective) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationRatingLevelDescriptorId 
        {
            get
            {
                if (_evaluationRatingLevelDescriptorId == default(int))
                    _evaluationRatingLevelDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationRatingLevelDescriptor", _evaluationRatingLevelDescriptor);

                return _evaluationRatingLevelDescriptorId;
            } 
            set
            {
                _evaluationRatingLevelDescriptorId = value;
                _evaluationRatingLevelDescriptor = null;
            }
        }

        private int _evaluationRatingLevelDescriptorId;
        private string _evaluationRatingLevelDescriptor;

        public virtual string EvaluationRatingLevelDescriptor
        {
            get
            {
                if (_evaluationRatingLevelDescriptor == null)
                    _evaluationRatingLevelDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationRatingLevelDescriptor", _evaluationRatingLevelDescriptorId);
                    
                return _evaluationRatingLevelDescriptor;
            }
            set
            {
                _evaluationRatingLevelDescriptor = value;
                _evaluationRatingLevelDescriptorId = default(int);
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
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MaxRating  { get; set; }
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MinRating  { get; set; }
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
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "EvaluationRatingLevelDescriptor", new LookupColumnDetails { PropertyName = "EvaluationRatingLevelDescriptorId", LookupTypeName = "EvaluationRatingLevelDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (EvaluationObjective as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("EvaluationRatingLevelDescriptorId", EvaluationRatingLevelDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationObjectiveRatingLevel)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationObjectiveRatingLevel) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            EvaluationObjective = (EvaluationObjective) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isMaxRatingSupported = true;
        bool Entities.Common.TPDM.IEvaluationObjectiveRatingLevelSynchronizationSourceSupport.IsMaxRatingSupported
        {
            get { return _isMaxRatingSupported; }
            set { _isMaxRatingSupported = value; }
        }

        private bool _isMinRatingSupported = true;
        bool Entities.Common.TPDM.IEvaluationObjectiveRatingLevelSynchronizationSourceSupport.IsMinRatingSupported
        {
            get { return _isMinRatingSupported; }
            set { _isMinRatingSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EvaluationObjectiveRating

namespace EdFi.Ods.Entities.NHibernate.EvaluationObjectiveRatingAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="EvaluationObjectiveRating"/> entity.
    /// </summary>
    public class EvaluationObjectiveRatingReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId { get; set; }
        public virtual DateTime EvaluationDate { get; set; }
        public virtual string EvaluationObjectiveTitle { get; set; }
        public virtual int EvaluationPeriodDescriptorId { get; set; }
        public virtual string EvaluationTitle { get; set; }
        public virtual string PerformanceEvaluationTitle { get; set; }
        public virtual int PerformanceEvaluationTypeDescriptorId { get; set; }
        public virtual string PersonId { get; set; }
        public virtual short SchoolYear { get; set; }
        public virtual int SourceSystemDescriptorId { get; set; }
        public virtual int TermDescriptorId { get; set; }
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationDate", EvaluationDate);
            keyValues.Add("EvaluationObjectiveTitle", EvaluationObjectiveTitle);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("PersonId", PersonId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("SourceSystemDescriptorId", SourceSystemDescriptorId);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationObjectiveRating table of the EvaluationObjectiveRating aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRating : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.IEvaluationObjectiveRating, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationObjectiveRatingSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationObjectiveRating()
        {
            EvaluationObjectiveRatingResults = new HashSet<EvaluationObjectiveRatingResult>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault, SqlServerDateTimeRange]
        public virtual DateTime EvaluationDate 
        {
            get { return _evaluationDate; }
            set
            {
                // This is only stored as a UTC DateTime in the DB and NHibernate will retrieve it back as the (UTC) DateTime.Kind.
                // Note ToUniversal will work differently based on DateTime.Kind
                // See https://docs.microsoft.com/en-us/dotnet/api/system.datetime.touniversaltime?view=netframework-4.5#System_DateTime_ToUniversalTime
                // Utc - No conversion is performed.
                // Local - The current DateTime object is converted to UTC.
                // Unspecified - The current DateTime object is assumed to be a local time, and the conversion is performed as if Kind were Local.
                if (value != (DateTime)typeof(DateTime).GetDefaultValue())
                    _evaluationDate = value.ToUniversalTime();
            }
        }

        private DateTime _evaluationDate;

        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string EvaluationObjectiveTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationPeriodDescriptorId 
        {
            get
            {
                if (_evaluationPeriodDescriptorId == default(int))
                    _evaluationPeriodDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationPeriodDescriptor", _evaluationPeriodDescriptor);

                return _evaluationPeriodDescriptorId;
            } 
            set
            {
                _evaluationPeriodDescriptorId = value;
                _evaluationPeriodDescriptor = null;
            }
        }

        private int _evaluationPeriodDescriptorId;
        private string _evaluationPeriodDescriptor;

        public virtual string EvaluationPeriodDescriptor
        {
            get
            {
                if (_evaluationPeriodDescriptor == null)
                    _evaluationPeriodDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationPeriodDescriptor", _evaluationPeriodDescriptorId);
                    
                return _evaluationPeriodDescriptor;
            }
            set
            {
                _evaluationPeriodDescriptor = value;
                _evaluationPeriodDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string EvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string PerformanceEvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int PerformanceEvaluationTypeDescriptorId 
        {
            get
            {
                if (_performanceEvaluationTypeDescriptorId == default(int))
                    _performanceEvaluationTypeDescriptorId = DescriptorsCache.GetCache().GetId("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptor);

                return _performanceEvaluationTypeDescriptorId;
            } 
            set
            {
                _performanceEvaluationTypeDescriptorId = value;
                _performanceEvaluationTypeDescriptor = null;
            }
        }

        private int _performanceEvaluationTypeDescriptorId;
        private string _performanceEvaluationTypeDescriptor;

        public virtual string PerformanceEvaluationTypeDescriptor
        {
            get
            {
                if (_performanceEvaluationTypeDescriptor == null)
                    _performanceEvaluationTypeDescriptor = DescriptorsCache.GetCache().GetValue("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptorId);
                    
                return _performanceEvaluationTypeDescriptor;
            }
            set
            {
                _performanceEvaluationTypeDescriptor = value;
                _performanceEvaluationTypeDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(32), NoDangerousText, NoWhitespace]
        public virtual string PersonId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual short SchoolYear  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int SourceSystemDescriptorId 
        {
            get
            {
                if (_sourceSystemDescriptorId == default(int))
                    _sourceSystemDescriptorId = DescriptorsCache.GetCache().GetId("SourceSystemDescriptor", _sourceSystemDescriptor);

                return _sourceSystemDescriptorId;
            } 
            set
            {
                _sourceSystemDescriptorId = value;
                _sourceSystemDescriptor = null;
            }
        }

        private int _sourceSystemDescriptorId;
        private string _sourceSystemDescriptor;

        public virtual string SourceSystemDescriptor
        {
            get
            {
                if (_sourceSystemDescriptor == null)
                    _sourceSystemDescriptor = DescriptorsCache.GetCache().GetValue("SourceSystemDescriptor", _sourceSystemDescriptorId);
                    
                return _sourceSystemDescriptor;
            }
            set
            {
                _sourceSystemDescriptor = value;
                _sourceSystemDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int))
                    _termDescriptorId = DescriptorsCache.GetCache().GetId("TermDescriptor", _termDescriptor);

                return _termDescriptorId;
            } 
            set
            {
                _termDescriptorId = value;
                _termDescriptor = null;
            }
        }

        private int _termDescriptorId;
        private string _termDescriptor;

        public virtual string TermDescriptor
        {
            get
            {
                if (_termDescriptor == null)
                    _termDescriptor = DescriptorsCache.GetCache().GetValue("TermDescriptor", _termDescriptorId);
                    
                return _termDescriptor;
            }
            set
            {
                _termDescriptor = value;
                _termDescriptorId = default(int);
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
        [StringLength(1024), NoDangerousText]
        public virtual string Comments  { get; set; }
        public virtual int? ObjectiveRatingLevelDescriptorId 
        {
            get
            {
                if (_objectiveRatingLevelDescriptorId == default(int?))
                    _objectiveRatingLevelDescriptorId = string.IsNullOrWhiteSpace(_objectiveRatingLevelDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("ObjectiveRatingLevelDescriptor", _objectiveRatingLevelDescriptor);

                return _objectiveRatingLevelDescriptorId;
            } 
            set
            {
                _objectiveRatingLevelDescriptorId = value;
                _objectiveRatingLevelDescriptor = null;
            }
        }

        private int? _objectiveRatingLevelDescriptorId;
        private string _objectiveRatingLevelDescriptor;

        public virtual string ObjectiveRatingLevelDescriptor
        {
            get
            {
                if (_objectiveRatingLevelDescriptor == null)
                    _objectiveRatingLevelDescriptor = _objectiveRatingLevelDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("ObjectiveRatingLevelDescriptor", _objectiveRatingLevelDescriptorId.Value);
                    
                return _objectiveRatingLevelDescriptor;
            }
            set
            {
                _objectiveRatingLevelDescriptor = value;
                _objectiveRatingLevelDescriptorId = default(int?);
            }
        }
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
        public virtual NHibernate.EvaluationObjectiveAggregate.TPDM.EvaluationObjectiveReferenceData EvaluationObjectiveReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the EvaluationObjective discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IEvaluationObjectiveRating.EvaluationObjectiveDiscriminator
        {
            get { return EvaluationObjectiveReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the EvaluationObjective resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IEvaluationObjectiveRating.EvaluationObjectiveResourceId
        {
            get { return EvaluationObjectiveReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingReferenceData EvaluationRatingReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the EvaluationRating discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IEvaluationObjectiveRating.EvaluationRatingDiscriminator
        {
            get { return EvaluationRatingReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the EvaluationRating resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IEvaluationObjectiveRating.EvaluationRatingResourceId
        {
            get { return EvaluationRatingReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.EvaluationObjectiveRatingAggregate.TPDM.EvaluationObjectiveRatingResult> _evaluationObjectiveRatingResults;
        private ICollection<Entities.Common.TPDM.IEvaluationObjectiveRatingResult> _evaluationObjectiveRatingResultsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.EvaluationObjectiveRatingAggregate.TPDM.EvaluationObjectiveRatingResult> EvaluationObjectiveRatingResults
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationObjectiveRatingResults)
                    if (item.EvaluationObjectiveRating == null)
                        item.EvaluationObjectiveRating = this;
                // -------------------------------------------------------------

                return _evaluationObjectiveRatingResults;
            }
            set
            {
                _evaluationObjectiveRatingResults = value;
                _evaluationObjectiveRatingResultsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.IEvaluationObjectiveRatingResult, Entities.NHibernate.EvaluationObjectiveRatingAggregate.TPDM.EvaluationObjectiveRatingResult>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.IEvaluationObjectiveRatingResult> Entities.Common.TPDM.IEvaluationObjectiveRating.EvaluationObjectiveRatingResults
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationObjectiveRatingResults)
                    if (item.EvaluationObjectiveRating == null)
                        item.EvaluationObjectiveRating = this;
                // -------------------------------------------------------------

                return _evaluationObjectiveRatingResultsCovariant;
            }
            set
            {
                EvaluationObjectiveRatingResults = new HashSet<Entities.NHibernate.EvaluationObjectiveRatingAggregate.TPDM.EvaluationObjectiveRatingResult>(value.Cast<Entities.NHibernate.EvaluationObjectiveRatingAggregate.TPDM.EvaluationObjectiveRatingResult>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "ObjectiveRatingLevelDescriptor", new LookupColumnDetails { PropertyName = "ObjectiveRatingLevelDescriptorId", LookupTypeName = "ObjectiveRatingLevelDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationDate", EvaluationDate);
            keyValues.Add("EvaluationObjectiveTitle", EvaluationObjectiveTitle);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("PersonId", PersonId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("SourceSystemDescriptorId", SourceSystemDescriptorId);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationObjectiveRating)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationObjectiveRating) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCommentsSupported = true;
        bool Entities.Common.TPDM.IEvaluationObjectiveRatingSynchronizationSourceSupport.IsCommentsSupported
        {
            get { return _isCommentsSupported; }
            set { _isCommentsSupported = value; }
        }

        private bool _isEvaluationObjectiveRatingResultsSupported = true;
        bool Entities.Common.TPDM.IEvaluationObjectiveRatingSynchronizationSourceSupport.IsEvaluationObjectiveRatingResultsSupported
        {
            get { return _isEvaluationObjectiveRatingResultsSupported; }
            set { _isEvaluationObjectiveRatingResultsSupported = value; }
        }

        private bool _isObjectiveRatingLevelDescriptorSupported = true;
        bool Entities.Common.TPDM.IEvaluationObjectiveRatingSynchronizationSourceSupport.IsObjectiveRatingLevelDescriptorSupported
        {
            get { return _isObjectiveRatingLevelDescriptorSupported; }
            set { _isObjectiveRatingLevelDescriptorSupported = value; }
        }

        private Func<Entities.Common.TPDM.IEvaluationObjectiveRatingResult, bool> _isEvaluationObjectiveRatingResultIncluded;
        Func<Entities.Common.TPDM.IEvaluationObjectiveRatingResult, bool> Entities.Common.TPDM.IEvaluationObjectiveRatingSynchronizationSourceSupport.IsEvaluationObjectiveRatingResultIncluded
        {
            get { return _isEvaluationObjectiveRatingResultIncluded; }
            set { _isEvaluationObjectiveRatingResultIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationObjectiveRatingResult table of the EvaluationObjectiveRating aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingResult : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IEvaluationObjectiveRatingResult, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationObjectiveRatingResultSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationObjectiveRatingResult()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EvaluationObjectiveRating EvaluationObjectiveRating { get; set; }

        Entities.Common.TPDM.IEvaluationObjectiveRating IEvaluationObjectiveRatingResult.EvaluationObjectiveRating
        {
            get { return EvaluationObjectiveRating; }
            set { EvaluationObjectiveRating = (EvaluationObjectiveRating) value; }
        }

        [DomainSignature]
        public virtual decimal Rating  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string RatingResultTitle  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [RequiredWithNonDefault]
        public virtual int ResultDatatypeTypeDescriptorId 
        {
            get
            {
                if (_resultDatatypeTypeDescriptorId == default(int))
                    _resultDatatypeTypeDescriptorId = DescriptorsCache.GetCache().GetId("ResultDatatypeTypeDescriptor", _resultDatatypeTypeDescriptor);

                return _resultDatatypeTypeDescriptorId;
            } 
            set
            {
                _resultDatatypeTypeDescriptorId = value;
                _resultDatatypeTypeDescriptor = null;
            }
        }

        private int _resultDatatypeTypeDescriptorId;
        private string _resultDatatypeTypeDescriptor;

        public virtual string ResultDatatypeTypeDescriptor
        {
            get
            {
                if (_resultDatatypeTypeDescriptor == null)
                    _resultDatatypeTypeDescriptor = DescriptorsCache.GetCache().GetValue("ResultDatatypeTypeDescriptor", _resultDatatypeTypeDescriptorId);
                    
                return _resultDatatypeTypeDescriptor;
            }
            set
            {
                _resultDatatypeTypeDescriptor = value;
                _resultDatatypeTypeDescriptorId = default(int);
            }
        }
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
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "ResultDatatypeTypeDescriptor", new LookupColumnDetails { PropertyName = "ResultDatatypeTypeDescriptorId", LookupTypeName = "ResultDatatypeTypeDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (EvaluationObjectiveRating as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("Rating", Rating);
            keyValues.Add("RatingResultTitle", RatingResultTitle);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationObjectiveRatingResult)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationObjectiveRatingResult) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            EvaluationObjectiveRating = (EvaluationObjectiveRating) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isResultDatatypeTypeDescriptorSupported = true;
        bool Entities.Common.TPDM.IEvaluationObjectiveRatingResultSynchronizationSourceSupport.IsResultDatatypeTypeDescriptorSupported
        {
            get { return _isResultDatatypeTypeDescriptorSupported; }
            set { _isResultDatatypeTypeDescriptorSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EvaluationPeriodDescriptor

namespace EdFi.Ods.Entities.NHibernate.EvaluationPeriodDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationPeriodDescriptor table of the EvaluationPeriodDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationPeriodDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IEvaluationPeriodDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationPeriodDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int EvaluationPeriodDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationPeriodDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationPeriodDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IEvaluationPeriodDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IEvaluationPeriodDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IEvaluationPeriodDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IEvaluationPeriodDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IEvaluationPeriodDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IEvaluationPeriodDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IEvaluationPeriodDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EvaluationRating

namespace EdFi.Ods.Entities.NHibernate.EvaluationRatingAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="EvaluationRating"/> entity.
    /// </summary>
    public class EvaluationRatingReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId { get; set; }
        public virtual DateTime EvaluationDate { get; set; }
        public virtual int EvaluationPeriodDescriptorId { get; set; }
        public virtual string EvaluationTitle { get; set; }
        public virtual string PerformanceEvaluationTitle { get; set; }
        public virtual int PerformanceEvaluationTypeDescriptorId { get; set; }
        public virtual string PersonId { get; set; }
        public virtual short SchoolYear { get; set; }
        public virtual int SourceSystemDescriptorId { get; set; }
        public virtual int TermDescriptorId { get; set; }
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationDate", EvaluationDate);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("PersonId", PersonId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("SourceSystemDescriptorId", SourceSystemDescriptorId);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationRating table of the EvaluationRating aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationRating : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.IEvaluationRating, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationRatingSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationRating()
        {
            EvaluationRatingResults = new HashSet<EvaluationRatingResult>();
            EvaluationRatingReviewers = new HashSet<EvaluationRatingReviewer>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault, SqlServerDateTimeRange]
        public virtual DateTime EvaluationDate 
        {
            get { return _evaluationDate; }
            set
            {
                // This is only stored as a UTC DateTime in the DB and NHibernate will retrieve it back as the (UTC) DateTime.Kind.
                // Note ToUniversal will work differently based on DateTime.Kind
                // See https://docs.microsoft.com/en-us/dotnet/api/system.datetime.touniversaltime?view=netframework-4.5#System_DateTime_ToUniversalTime
                // Utc - No conversion is performed.
                // Local - The current DateTime object is converted to UTC.
                // Unspecified - The current DateTime object is assumed to be a local time, and the conversion is performed as if Kind were Local.
                if (value != (DateTime)typeof(DateTime).GetDefaultValue())
                    _evaluationDate = value.ToUniversalTime();
            }
        }

        private DateTime _evaluationDate;

        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationPeriodDescriptorId 
        {
            get
            {
                if (_evaluationPeriodDescriptorId == default(int))
                    _evaluationPeriodDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationPeriodDescriptor", _evaluationPeriodDescriptor);

                return _evaluationPeriodDescriptorId;
            } 
            set
            {
                _evaluationPeriodDescriptorId = value;
                _evaluationPeriodDescriptor = null;
            }
        }

        private int _evaluationPeriodDescriptorId;
        private string _evaluationPeriodDescriptor;

        public virtual string EvaluationPeriodDescriptor
        {
            get
            {
                if (_evaluationPeriodDescriptor == null)
                    _evaluationPeriodDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationPeriodDescriptor", _evaluationPeriodDescriptorId);
                    
                return _evaluationPeriodDescriptor;
            }
            set
            {
                _evaluationPeriodDescriptor = value;
                _evaluationPeriodDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string EvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string PerformanceEvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int PerformanceEvaluationTypeDescriptorId 
        {
            get
            {
                if (_performanceEvaluationTypeDescriptorId == default(int))
                    _performanceEvaluationTypeDescriptorId = DescriptorsCache.GetCache().GetId("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptor);

                return _performanceEvaluationTypeDescriptorId;
            } 
            set
            {
                _performanceEvaluationTypeDescriptorId = value;
                _performanceEvaluationTypeDescriptor = null;
            }
        }

        private int _performanceEvaluationTypeDescriptorId;
        private string _performanceEvaluationTypeDescriptor;

        public virtual string PerformanceEvaluationTypeDescriptor
        {
            get
            {
                if (_performanceEvaluationTypeDescriptor == null)
                    _performanceEvaluationTypeDescriptor = DescriptorsCache.GetCache().GetValue("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptorId);
                    
                return _performanceEvaluationTypeDescriptor;
            }
            set
            {
                _performanceEvaluationTypeDescriptor = value;
                _performanceEvaluationTypeDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(32), NoDangerousText, NoWhitespace]
        public virtual string PersonId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual short SchoolYear  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int SourceSystemDescriptorId 
        {
            get
            {
                if (_sourceSystemDescriptorId == default(int))
                    _sourceSystemDescriptorId = DescriptorsCache.GetCache().GetId("SourceSystemDescriptor", _sourceSystemDescriptor);

                return _sourceSystemDescriptorId;
            } 
            set
            {
                _sourceSystemDescriptorId = value;
                _sourceSystemDescriptor = null;
            }
        }

        private int _sourceSystemDescriptorId;
        private string _sourceSystemDescriptor;

        public virtual string SourceSystemDescriptor
        {
            get
            {
                if (_sourceSystemDescriptor == null)
                    _sourceSystemDescriptor = DescriptorsCache.GetCache().GetValue("SourceSystemDescriptor", _sourceSystemDescriptorId);
                    
                return _sourceSystemDescriptor;
            }
            set
            {
                _sourceSystemDescriptor = value;
                _sourceSystemDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int))
                    _termDescriptorId = DescriptorsCache.GetCache().GetId("TermDescriptor", _termDescriptor);

                return _termDescriptorId;
            } 
            set
            {
                _termDescriptorId = value;
                _termDescriptor = null;
            }
        }

        private int _termDescriptorId;
        private string _termDescriptor;

        public virtual string TermDescriptor
        {
            get
            {
                if (_termDescriptor == null)
                    _termDescriptor = DescriptorsCache.GetCache().GetValue("TermDescriptor", _termDescriptorId);
                    
                return _termDescriptor;
            }
            set
            {
                _termDescriptor = value;
                _termDescriptorId = default(int);
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
        public virtual int? EvaluationRatingLevelDescriptorId 
        {
            get
            {
                if (_evaluationRatingLevelDescriptorId == default(int?))
                    _evaluationRatingLevelDescriptorId = string.IsNullOrWhiteSpace(_evaluationRatingLevelDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("EvaluationRatingLevelDescriptor", _evaluationRatingLevelDescriptor);

                return _evaluationRatingLevelDescriptorId;
            } 
            set
            {
                _evaluationRatingLevelDescriptorId = value;
                _evaluationRatingLevelDescriptor = null;
            }
        }

        private int? _evaluationRatingLevelDescriptorId;
        private string _evaluationRatingLevelDescriptor;

        public virtual string EvaluationRatingLevelDescriptor
        {
            get
            {
                if (_evaluationRatingLevelDescriptor == null)
                    _evaluationRatingLevelDescriptor = _evaluationRatingLevelDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("EvaluationRatingLevelDescriptor", _evaluationRatingLevelDescriptorId.Value);
                    
                return _evaluationRatingLevelDescriptor;
            }
            set
            {
                _evaluationRatingLevelDescriptor = value;
                _evaluationRatingLevelDescriptorId = default(int?);
            }
        }
        public virtual int? EvaluationRatingStatusDescriptorId 
        {
            get
            {
                if (_evaluationRatingStatusDescriptorId == default(int?))
                    _evaluationRatingStatusDescriptorId = string.IsNullOrWhiteSpace(_evaluationRatingStatusDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("EvaluationRatingStatusDescriptor", _evaluationRatingStatusDescriptor);

                return _evaluationRatingStatusDescriptorId;
            } 
            set
            {
                _evaluationRatingStatusDescriptorId = value;
                _evaluationRatingStatusDescriptor = null;
            }
        }

        private int? _evaluationRatingStatusDescriptorId;
        private string _evaluationRatingStatusDescriptor;

        public virtual string EvaluationRatingStatusDescriptor
        {
            get
            {
                if (_evaluationRatingStatusDescriptor == null)
                    _evaluationRatingStatusDescriptor = _evaluationRatingStatusDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("EvaluationRatingStatusDescriptor", _evaluationRatingStatusDescriptorId.Value);
                    
                return _evaluationRatingStatusDescriptor;
            }
            set
            {
                _evaluationRatingStatusDescriptor = value;
                _evaluationRatingStatusDescriptorId = default(int?);
            }
        }
        [StringLength(60), NoDangerousText]
        public virtual string LocalCourseCode  { get; set; }
        public virtual int? SchoolId  { get; set; }
        [StringLength(255), NoDangerousText]
        public virtual string SectionIdentifier  { get; set; }
        [StringLength(60), NoDangerousText]
        public virtual string SessionName  { get; set; }
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
        public virtual NHibernate.EvaluationAggregate.TPDM.EvaluationReferenceData EvaluationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Evaluation discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IEvaluationRating.EvaluationDiscriminator
        {
            get { return EvaluationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Evaluation resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IEvaluationRating.EvaluationResourceId
        {
            get { return EvaluationReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingReferenceData PerformanceEvaluationRatingReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the PerformanceEvaluationRating discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IEvaluationRating.PerformanceEvaluationRatingDiscriminator
        {
            get { return PerformanceEvaluationRatingReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the PerformanceEvaluationRating resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IEvaluationRating.PerformanceEvaluationRatingResourceId
        {
            get { return PerformanceEvaluationRatingReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.SectionAggregate.EdFi.SectionReferenceData SectionReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Section discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IEvaluationRating.SectionDiscriminator
        {
            get { return SectionReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Section resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IEvaluationRating.SectionResourceId
        {
            get { return SectionReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingResult> _evaluationRatingResults;
        private ICollection<Entities.Common.TPDM.IEvaluationRatingResult> _evaluationRatingResultsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingResult> EvaluationRatingResults
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationRatingResults)
                    if (item.EvaluationRating == null)
                        item.EvaluationRating = this;
                // -------------------------------------------------------------

                return _evaluationRatingResults;
            }
            set
            {
                _evaluationRatingResults = value;
                _evaluationRatingResultsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.IEvaluationRatingResult, Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingResult>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.IEvaluationRatingResult> Entities.Common.TPDM.IEvaluationRating.EvaluationRatingResults
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationRatingResults)
                    if (item.EvaluationRating == null)
                        item.EvaluationRating = this;
                // -------------------------------------------------------------

                return _evaluationRatingResultsCovariant;
            }
            set
            {
                EvaluationRatingResults = new HashSet<Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingResult>(value.Cast<Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingResult>());
            }
        }


        private ICollection<Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingReviewer> _evaluationRatingReviewers;
        private ICollection<Entities.Common.TPDM.IEvaluationRatingReviewer> _evaluationRatingReviewersCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingReviewer> EvaluationRatingReviewers
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationRatingReviewers)
                    if (item.EvaluationRating == null)
                        item.EvaluationRating = this;
                // -------------------------------------------------------------

                return _evaluationRatingReviewers;
            }
            set
            {
                _evaluationRatingReviewers = value;
                _evaluationRatingReviewersCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.IEvaluationRatingReviewer, Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingReviewer>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.IEvaluationRatingReviewer> Entities.Common.TPDM.IEvaluationRating.EvaluationRatingReviewers
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationRatingReviewers)
                    if (item.EvaluationRating == null)
                        item.EvaluationRating = this;
                // -------------------------------------------------------------

                return _evaluationRatingReviewersCovariant;
            }
            set
            {
                EvaluationRatingReviewers = new HashSet<Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingReviewer>(value.Cast<Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingReviewer>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "EvaluationRatingLevelDescriptor", new LookupColumnDetails { PropertyName = "EvaluationRatingLevelDescriptorId", LookupTypeName = "EvaluationRatingLevelDescriptor"} },
                { "EvaluationRatingStatusDescriptor", new LookupColumnDetails { PropertyName = "EvaluationRatingStatusDescriptorId", LookupTypeName = "EvaluationRatingStatusDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationDate", EvaluationDate);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("PersonId", PersonId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("SourceSystemDescriptorId", SourceSystemDescriptorId);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationRating)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationRating) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isEvaluationRatingLevelDescriptorSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingSynchronizationSourceSupport.IsEvaluationRatingLevelDescriptorSupported
        {
            get { return _isEvaluationRatingLevelDescriptorSupported; }
            set { _isEvaluationRatingLevelDescriptorSupported = value; }
        }

        private bool _isEvaluationRatingResultsSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingSynchronizationSourceSupport.IsEvaluationRatingResultsSupported
        {
            get { return _isEvaluationRatingResultsSupported; }
            set { _isEvaluationRatingResultsSupported = value; }
        }

        private bool _isEvaluationRatingReviewersSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingSynchronizationSourceSupport.IsEvaluationRatingReviewersSupported
        {
            get { return _isEvaluationRatingReviewersSupported; }
            set { _isEvaluationRatingReviewersSupported = value; }
        }

        private bool _isEvaluationRatingStatusDescriptorSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingSynchronizationSourceSupport.IsEvaluationRatingStatusDescriptorSupported
        {
            get { return _isEvaluationRatingStatusDescriptorSupported; }
            set { _isEvaluationRatingStatusDescriptorSupported = value; }
        }

        private bool _isLocalCourseCodeSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingSynchronizationSourceSupport.IsLocalCourseCodeSupported
        {
            get { return _isLocalCourseCodeSupported; }
            set { _isLocalCourseCodeSupported = value; }
        }

        private bool _isSchoolIdSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingSynchronizationSourceSupport.IsSchoolIdSupported
        {
            get { return _isSchoolIdSupported; }
            set { _isSchoolIdSupported = value; }
        }

        private bool _isSectionIdentifierSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingSynchronizationSourceSupport.IsSectionIdentifierSupported
        {
            get { return _isSectionIdentifierSupported; }
            set { _isSectionIdentifierSupported = value; }
        }

        private bool _isSessionNameSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingSynchronizationSourceSupport.IsSessionNameSupported
        {
            get { return _isSessionNameSupported; }
            set { _isSessionNameSupported = value; }
        }

        private Func<Entities.Common.TPDM.IEvaluationRatingResult, bool> _isEvaluationRatingResultIncluded;
        Func<Entities.Common.TPDM.IEvaluationRatingResult, bool> Entities.Common.TPDM.IEvaluationRatingSynchronizationSourceSupport.IsEvaluationRatingResultIncluded
        {
            get { return _isEvaluationRatingResultIncluded; }
            set { _isEvaluationRatingResultIncluded = value; }
        }

        private Func<Entities.Common.TPDM.IEvaluationRatingReviewer, bool> _isEvaluationRatingReviewerIncluded;
        Func<Entities.Common.TPDM.IEvaluationRatingReviewer, bool> Entities.Common.TPDM.IEvaluationRatingSynchronizationSourceSupport.IsEvaluationRatingReviewerIncluded
        {
            get { return _isEvaluationRatingReviewerIncluded; }
            set { _isEvaluationRatingReviewerIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationRatingResult table of the EvaluationRating aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationRatingResult : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IEvaluationRatingResult, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationRatingResultSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationRatingResult()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EvaluationRating EvaluationRating { get; set; }

        Entities.Common.TPDM.IEvaluationRating IEvaluationRatingResult.EvaluationRating
        {
            get { return EvaluationRating; }
            set { EvaluationRating = (EvaluationRating) value; }
        }

        [DomainSignature]
        public virtual decimal Rating  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string RatingResultTitle  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [RequiredWithNonDefault]
        public virtual int ResultDatatypeTypeDescriptorId 
        {
            get
            {
                if (_resultDatatypeTypeDescriptorId == default(int))
                    _resultDatatypeTypeDescriptorId = DescriptorsCache.GetCache().GetId("ResultDatatypeTypeDescriptor", _resultDatatypeTypeDescriptor);

                return _resultDatatypeTypeDescriptorId;
            } 
            set
            {
                _resultDatatypeTypeDescriptorId = value;
                _resultDatatypeTypeDescriptor = null;
            }
        }

        private int _resultDatatypeTypeDescriptorId;
        private string _resultDatatypeTypeDescriptor;

        public virtual string ResultDatatypeTypeDescriptor
        {
            get
            {
                if (_resultDatatypeTypeDescriptor == null)
                    _resultDatatypeTypeDescriptor = DescriptorsCache.GetCache().GetValue("ResultDatatypeTypeDescriptor", _resultDatatypeTypeDescriptorId);
                    
                return _resultDatatypeTypeDescriptor;
            }
            set
            {
                _resultDatatypeTypeDescriptor = value;
                _resultDatatypeTypeDescriptorId = default(int);
            }
        }
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
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "ResultDatatypeTypeDescriptor", new LookupColumnDetails { PropertyName = "ResultDatatypeTypeDescriptorId", LookupTypeName = "ResultDatatypeTypeDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (EvaluationRating as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("Rating", Rating);
            keyValues.Add("RatingResultTitle", RatingResultTitle);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationRatingResult)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationRatingResult) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            EvaluationRating = (EvaluationRating) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isResultDatatypeTypeDescriptorSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingResultSynchronizationSourceSupport.IsResultDatatypeTypeDescriptorSupported
        {
            get { return _isResultDatatypeTypeDescriptorSupported; }
            set { _isResultDatatypeTypeDescriptorSupported = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationRatingReviewer table of the EvaluationRating aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationRatingReviewer : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IEvaluationRatingReviewer, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationRatingReviewerSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationRatingReviewer()
        {
           EvaluationRatingReviewerReceivedTrainingPersistentList = new HashSet<EvaluationRatingReviewerReceivedTraining>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EvaluationRating EvaluationRating { get; set; }

        Entities.Common.TPDM.IEvaluationRating IEvaluationRatingReviewer.EvaluationRating
        {
            get { return EvaluationRating; }
            set { EvaluationRating = (EvaluationRating) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(75), NoDangerousText, NoWhitespace]
        public virtual string FirstName  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(75), NoDangerousText, NoWhitespace]
        public virtual string LastSurname  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [StringLength(32), NoDangerousText]
        public virtual string ReviewerPersonId  { get; set; }
        public virtual int? ReviewerSourceSystemDescriptorId 
        {
            get
            {
                if (_reviewerSourceSystemDescriptorId == default(int?))
                    _reviewerSourceSystemDescriptorId = string.IsNullOrWhiteSpace(_reviewerSourceSystemDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("SourceSystemDescriptor", _reviewerSourceSystemDescriptor);

                return _reviewerSourceSystemDescriptorId;
            } 
            set
            {
                _reviewerSourceSystemDescriptorId = value;
                _reviewerSourceSystemDescriptor = null;
            }
        }

        private int? _reviewerSourceSystemDescriptorId;
        private string _reviewerSourceSystemDescriptor;

        public virtual string ReviewerSourceSystemDescriptor
        {
            get
            {
                if (_reviewerSourceSystemDescriptor == null)
                    _reviewerSourceSystemDescriptor = _reviewerSourceSystemDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("SourceSystemDescriptor", _reviewerSourceSystemDescriptorId.Value);
                    
                return _reviewerSourceSystemDescriptor;
            }
            set
            {
                _reviewerSourceSystemDescriptor = value;
                _reviewerSourceSystemDescriptorId = default(int?);
            }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        [ValidateObject]
        public virtual Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingReviewerReceivedTraining EvaluationRatingReviewerReceivedTraining
        {
            get
            {
                // Return the item in the list, if one exists
                if (EvaluationRatingReviewerReceivedTrainingPersistentList.Any())
                    return EvaluationRatingReviewerReceivedTrainingPersistentList.First();

                // No reference is present
                return null;
            }
            set
            {
                // Delete the existing object
                if (EvaluationRatingReviewerReceivedTrainingPersistentList.Any())
                    EvaluationRatingReviewerReceivedTrainingPersistentList.Clear();

                // If we're setting a value, add it to the list now
                if (value != null)
                {
                    // Set the back-reference to the parent
                    value.EvaluationRatingReviewer = this;

                    EvaluationRatingReviewerReceivedTrainingPersistentList.Add(value);
                }
            }
        }

        Entities.Common.TPDM.IEvaluationRatingReviewerReceivedTraining Entities.Common.TPDM.IEvaluationRatingReviewer.EvaluationRatingReviewerReceivedTraining
        {
            get { return EvaluationRatingReviewerReceivedTraining; }
            set { EvaluationRatingReviewerReceivedTraining = (Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingReviewerReceivedTraining) value; }
        }

        private ICollection<Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingReviewerReceivedTraining> _evaluationRatingReviewerReceivedTrainingPersistentList;

        public virtual ICollection<Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRatingReviewerReceivedTraining> EvaluationRatingReviewerReceivedTrainingPersistentList
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _evaluationRatingReviewerReceivedTrainingPersistentList)
                    if (item.EvaluationRatingReviewer == null)
                        item.EvaluationRatingReviewer = this;
                // -------------------------------------------------------------

                return _evaluationRatingReviewerReceivedTrainingPersistentList;
            }
            set
            {
                _evaluationRatingReviewerReceivedTrainingPersistentList = value;
            }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                          Extensions
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        public virtual NHibernate.PersonAggregate.EdFi.PersonReferenceData ReviewerPersonReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the ReviewerPerson discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IEvaluationRatingReviewer.ReviewerPersonDiscriminator
        {
            get { return ReviewerPersonReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the ReviewerPerson resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IEvaluationRatingReviewer.ReviewerPersonResourceId
        {
            get { return ReviewerPersonReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "ReviewerSourceSystemDescriptor", new LookupColumnDetails { PropertyName = "ReviewerSourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (EvaluationRating as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("FirstName", FirstName);
            keyValues.Add("LastSurname", LastSurname);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationRatingReviewer)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationRatingReviewer) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            EvaluationRating = (EvaluationRating) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isEvaluationRatingReviewerReceivedTrainingSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingReviewerSynchronizationSourceSupport.IsEvaluationRatingReviewerReceivedTrainingSupported
        {
            get { return _isEvaluationRatingReviewerReceivedTrainingSupported; }
            set { _isEvaluationRatingReviewerReceivedTrainingSupported = value; }
        }

        private bool _isReviewerPersonIdSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingReviewerSynchronizationSourceSupport.IsReviewerPersonIdSupported
        {
            get { return _isReviewerPersonIdSupported; }
            set { _isReviewerPersonIdSupported = value; }
        }

        private bool _isReviewerSourceSystemDescriptorSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingReviewerSynchronizationSourceSupport.IsReviewerSourceSystemDescriptorSupported
        {
            get { return _isReviewerSourceSystemDescriptorSupported; }
            set { _isReviewerSourceSystemDescriptorSupported = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationRatingReviewerReceivedTraining table of the EvaluationRating aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationRatingReviewerReceivedTraining : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IEvaluationRatingReviewerReceivedTraining, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public EvaluationRatingReviewerReceivedTraining()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EvaluationRatingReviewer EvaluationRatingReviewer { get; set; }

        Entities.Common.TPDM.IEvaluationRatingReviewer IEvaluationRatingReviewerReceivedTraining.EvaluationRatingReviewer
        {
            get { return EvaluationRatingReviewer; }
            set { EvaluationRatingReviewer = (EvaluationRatingReviewer) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? InterRaterReliabilityScore  { get; set; }
        [SqlServerDateTimeRange]
        public virtual DateTime? ReceivedTrainingDate 
        {
            get { return _receivedTrainingDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _receivedTrainingDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _receivedTrainingDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _receivedTrainingDate;
        
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
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (EvaluationRatingReviewer as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationRatingReviewerReceivedTraining)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationRatingReviewerReceivedTraining) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            EvaluationRatingReviewer = (EvaluationRatingReviewer) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isInterRaterReliabilityScoreSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport.IsInterRaterReliabilityScoreSupported
        {
            get { return _isInterRaterReliabilityScoreSupported; }
            set { _isInterRaterReliabilityScoreSupported = value; }
        }

        private bool _isReceivedTrainingDateSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport.IsReceivedTrainingDateSupported
        {
            get { return _isReceivedTrainingDateSupported; }
            set { _isReceivedTrainingDateSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EvaluationRatingLevelDescriptor

namespace EdFi.Ods.Entities.NHibernate.EvaluationRatingLevelDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationRatingLevelDescriptor table of the EvaluationRatingLevelDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevelDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IEvaluationRatingLevelDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationRatingLevelDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int EvaluationRatingLevelDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("EvaluationRatingLevelDescriptorId", EvaluationRatingLevelDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationRatingLevelDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationRatingLevelDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EvaluationRatingStatusDescriptor

namespace EdFi.Ods.Entities.NHibernate.EvaluationRatingStatusDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationRatingStatusDescriptor table of the EvaluationRatingStatusDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationRatingStatusDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IEvaluationRatingStatusDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationRatingStatusDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int EvaluationRatingStatusDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("EvaluationRatingStatusDescriptorId", EvaluationRatingStatusDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationRatingStatusDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationRatingStatusDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingStatusDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingStatusDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingStatusDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingStatusDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingStatusDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingStatusDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IEvaluationRatingStatusDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: EvaluationTypeDescriptor

namespace EdFi.Ods.Entities.NHibernate.EvaluationTypeDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.EvaluationTypeDescriptor table of the EvaluationTypeDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class EvaluationTypeDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IEvaluationTypeDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IEvaluationTypeDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int EvaluationTypeDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("EvaluationTypeDescriptorId", EvaluationTypeDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IEvaluationTypeDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IEvaluationTypeDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IEvaluationTypeDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IEvaluationTypeDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IEvaluationTypeDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IEvaluationTypeDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IEvaluationTypeDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IEvaluationTypeDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IEvaluationTypeDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: FinancialAid

namespace EdFi.Ods.Entities.NHibernate.FinancialAidAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="FinancialAid"/> entity.
    /// </summary>
    public class FinancialAidReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual int AidTypeDescriptorId { get; set; }
        public virtual DateTime BeginDate { get; set; }
        public virtual int StudentUSI { get; set; }
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
            keyValues.Add("AidTypeDescriptorId", AidTypeDescriptorId);
            keyValues.Add("BeginDate", BeginDate);
            keyValues.Add("StudentUSI", StudentUSI);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.FinancialAid table of the FinancialAid aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class FinancialAid : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.IFinancialAid, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IFinancialAidSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public FinancialAid()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual int AidTypeDescriptorId 
        {
            get
            {
                if (_aidTypeDescriptorId == default(int))
                    _aidTypeDescriptorId = DescriptorsCache.GetCache().GetId("AidTypeDescriptor", _aidTypeDescriptor);

                return _aidTypeDescriptorId;
            } 
            set
            {
                _aidTypeDescriptorId = value;
                _aidTypeDescriptor = null;
            }
        }

        private int _aidTypeDescriptorId;
        private string _aidTypeDescriptor;

        public virtual string AidTypeDescriptor
        {
            get
            {
                if (_aidTypeDescriptor == null)
                    _aidTypeDescriptor = DescriptorsCache.GetCache().GetValue("AidTypeDescriptor", _aidTypeDescriptorId);
                    
                return _aidTypeDescriptor;
            }
            set
            {
                _aidTypeDescriptor = value;
                _aidTypeDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual DateTime BeginDate 
        {
            get { return _beginDate; }
            //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
            set { _beginDate = new DateTime(value.Year, value.Month, value.Day); }
        }

        private DateTime _beginDate;
        
        [Display(Name="StudentUniqueId")]
        [DomainSignature, RequiredWithNonDefault("Student")]
        public virtual int StudentUSI 
        {
            get
            {
                if (_studentUSI == default(int))
                    _studentUSI = PersonUniqueIdToUsiCache.GetCache().GetUsi("Student", _studentUniqueId);

                return _studentUSI;
            } 
            set
            {
                _studentUSI = value;
            }
        }

        private int _studentUSI;
        private string _studentUniqueId;

        [RequiredWithNonDefault]
        public virtual string StudentUniqueId
        {
            get
            {
                if (_studentUniqueId == null)
                    _studentUniqueId = PersonUniqueIdToUsiCache.GetCache().GetUniqueId("Student", _studentUSI);
                    
                return _studentUniqueId;
            }
            set
            {
                if (_studentUniqueId != value)
                        _studentUSI = default(int);

                _studentUniqueId = value;
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
        [Range(typeof(decimal), "-999999999999999.9999", "999999999999999.9999")]
        public virtual decimal? AidAmount  { get; set; }
        [StringLength(1024), NoDangerousText]
        public virtual string AidConditionDescription  { get; set; }
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
        
        public virtual bool? PellGrantRecipient  { get; set; }
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
        public virtual NHibernate.StudentAggregate.EdFi.StudentReferenceData StudentReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Student discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IFinancialAid.StudentDiscriminator
        {
            get { return StudentReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Student resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IFinancialAid.StudentResourceId
        {
            get { return StudentReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "AidTypeDescriptor", new LookupColumnDetails { PropertyName = "AidTypeDescriptorId", LookupTypeName = "AidTypeDescriptor"} },
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
            keyValues.Add("AidTypeDescriptorId", AidTypeDescriptorId);
            keyValues.Add("BeginDate", BeginDate);
            keyValues.Add("StudentUSI", StudentUSI);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IFinancialAid)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IFinancialAid) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isAidAmountSupported = true;
        bool Entities.Common.TPDM.IFinancialAidSynchronizationSourceSupport.IsAidAmountSupported
        {
            get { return _isAidAmountSupported; }
            set { _isAidAmountSupported = value; }
        }

        private bool _isAidConditionDescriptionSupported = true;
        bool Entities.Common.TPDM.IFinancialAidSynchronizationSourceSupport.IsAidConditionDescriptionSupported
        {
            get { return _isAidConditionDescriptionSupported; }
            set { _isAidConditionDescriptionSupported = value; }
        }

        private bool _isEndDateSupported = true;
        bool Entities.Common.TPDM.IFinancialAidSynchronizationSourceSupport.IsEndDateSupported
        {
            get { return _isEndDateSupported; }
            set { _isEndDateSupported = value; }
        }

        private bool _isPellGrantRecipientSupported = true;
        bool Entities.Common.TPDM.IFinancialAidSynchronizationSourceSupport.IsPellGrantRecipientSupported
        {
            get { return _isPellGrantRecipientSupported; }
            set { _isPellGrantRecipientSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: GenderDescriptor

namespace EdFi.Ods.Entities.NHibernate.GenderDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.GenderDescriptor table of the GenderDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class GenderDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IGenderDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IGenderDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int GenderDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("GenderDescriptorId", GenderDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IGenderDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IGenderDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IGenderDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IGenderDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IGenderDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IGenderDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IGenderDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IGenderDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IGenderDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: ObjectiveRatingLevelDescriptor

namespace EdFi.Ods.Entities.NHibernate.ObjectiveRatingLevelDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.ObjectiveRatingLevelDescriptor table of the ObjectiveRatingLevelDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class ObjectiveRatingLevelDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IObjectiveRatingLevelDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IObjectiveRatingLevelDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int ObjectiveRatingLevelDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("ObjectiveRatingLevelDescriptorId", ObjectiveRatingLevelDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IObjectiveRatingLevelDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IObjectiveRatingLevelDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IObjectiveRatingLevelDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IObjectiveRatingLevelDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IObjectiveRatingLevelDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IObjectiveRatingLevelDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IObjectiveRatingLevelDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IObjectiveRatingLevelDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IObjectiveRatingLevelDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: PerformanceEvaluation

namespace EdFi.Ods.Entities.NHibernate.PerformanceEvaluationAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="PerformanceEvaluation"/> entity.
    /// </summary>
    public class PerformanceEvaluationReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId { get; set; }
        public virtual int EvaluationPeriodDescriptorId { get; set; }
        public virtual string PerformanceEvaluationTitle { get; set; }
        public virtual int PerformanceEvaluationTypeDescriptorId { get; set; }
        public virtual short SchoolYear { get; set; }
        public virtual int TermDescriptorId { get; set; }
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.PerformanceEvaluation table of the PerformanceEvaluation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluation : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.IPerformanceEvaluation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IPerformanceEvaluationSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public PerformanceEvaluation()
        {
            PerformanceEvaluationGradeLevels = new HashSet<PerformanceEvaluationGradeLevel>();
            PerformanceEvaluationRatingLevels = new HashSet<PerformanceEvaluationRatingLevel>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationPeriodDescriptorId 
        {
            get
            {
                if (_evaluationPeriodDescriptorId == default(int))
                    _evaluationPeriodDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationPeriodDescriptor", _evaluationPeriodDescriptor);

                return _evaluationPeriodDescriptorId;
            } 
            set
            {
                _evaluationPeriodDescriptorId = value;
                _evaluationPeriodDescriptor = null;
            }
        }

        private int _evaluationPeriodDescriptorId;
        private string _evaluationPeriodDescriptor;

        public virtual string EvaluationPeriodDescriptor
        {
            get
            {
                if (_evaluationPeriodDescriptor == null)
                    _evaluationPeriodDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationPeriodDescriptor", _evaluationPeriodDescriptorId);
                    
                return _evaluationPeriodDescriptor;
            }
            set
            {
                _evaluationPeriodDescriptor = value;
                _evaluationPeriodDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string PerformanceEvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int PerformanceEvaluationTypeDescriptorId 
        {
            get
            {
                if (_performanceEvaluationTypeDescriptorId == default(int))
                    _performanceEvaluationTypeDescriptorId = DescriptorsCache.GetCache().GetId("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptor);

                return _performanceEvaluationTypeDescriptorId;
            } 
            set
            {
                _performanceEvaluationTypeDescriptorId = value;
                _performanceEvaluationTypeDescriptor = null;
            }
        }

        private int _performanceEvaluationTypeDescriptorId;
        private string _performanceEvaluationTypeDescriptor;

        public virtual string PerformanceEvaluationTypeDescriptor
        {
            get
            {
                if (_performanceEvaluationTypeDescriptor == null)
                    _performanceEvaluationTypeDescriptor = DescriptorsCache.GetCache().GetValue("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptorId);
                    
                return _performanceEvaluationTypeDescriptor;
            }
            set
            {
                _performanceEvaluationTypeDescriptor = value;
                _performanceEvaluationTypeDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual short SchoolYear  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int))
                    _termDescriptorId = DescriptorsCache.GetCache().GetId("TermDescriptor", _termDescriptor);

                return _termDescriptorId;
            } 
            set
            {
                _termDescriptorId = value;
                _termDescriptor = null;
            }
        }

        private int _termDescriptorId;
        private string _termDescriptor;

        public virtual string TermDescriptor
        {
            get
            {
                if (_termDescriptor == null)
                    _termDescriptor = DescriptorsCache.GetCache().GetValue("TermDescriptor", _termDescriptorId);
                    
                return _termDescriptor;
            }
            set
            {
                _termDescriptor = value;
                _termDescriptorId = default(int);
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
        public virtual int? AcademicSubjectDescriptorId 
        {
            get
            {
                if (_academicSubjectDescriptorId == default(int?))
                    _academicSubjectDescriptorId = string.IsNullOrWhiteSpace(_academicSubjectDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("AcademicSubjectDescriptor", _academicSubjectDescriptor);

                return _academicSubjectDescriptorId;
            } 
            set
            {
                _academicSubjectDescriptorId = value;
                _academicSubjectDescriptor = null;
            }
        }

        private int? _academicSubjectDescriptorId;
        private string _academicSubjectDescriptor;

        public virtual string AcademicSubjectDescriptor
        {
            get
            {
                if (_academicSubjectDescriptor == null)
                    _academicSubjectDescriptor = _academicSubjectDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("AcademicSubjectDescriptor", _academicSubjectDescriptorId.Value);
                    
                return _academicSubjectDescriptor;
            }
            set
            {
                _academicSubjectDescriptor = value;
                _academicSubjectDescriptorId = default(int?);
            }
        }
        [StringLength(255), NoDangerousText]
        public virtual string PerformanceEvaluationDescription  { get; set; }
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
        string Entities.Common.TPDM.IPerformanceEvaluation.EducationOrganizationDiscriminator
        {
            get { return EducationOrganizationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the EducationOrganization resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IPerformanceEvaluation.EducationOrganizationResourceId
        {
            get { return EducationOrganizationReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.SchoolYearTypeAggregate.EdFi.SchoolYearTypeReferenceData SchoolYearTypeReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the SchoolYearType resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IPerformanceEvaluation.SchoolYearTypeResourceId
        {
            get { return SchoolYearTypeReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluationGradeLevel> _performanceEvaluationGradeLevels;
        private ICollection<Entities.Common.TPDM.IPerformanceEvaluationGradeLevel> _performanceEvaluationGradeLevelsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluationGradeLevel> PerformanceEvaluationGradeLevels
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _performanceEvaluationGradeLevels)
                    if (item.PerformanceEvaluation == null)
                        item.PerformanceEvaluation = this;
                // -------------------------------------------------------------

                return _performanceEvaluationGradeLevels;
            }
            set
            {
                _performanceEvaluationGradeLevels = value;
                _performanceEvaluationGradeLevelsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.IPerformanceEvaluationGradeLevel, Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluationGradeLevel>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.IPerformanceEvaluationGradeLevel> Entities.Common.TPDM.IPerformanceEvaluation.PerformanceEvaluationGradeLevels
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _performanceEvaluationGradeLevels)
                    if (item.PerformanceEvaluation == null)
                        item.PerformanceEvaluation = this;
                // -------------------------------------------------------------

                return _performanceEvaluationGradeLevelsCovariant;
            }
            set
            {
                PerformanceEvaluationGradeLevels = new HashSet<Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluationGradeLevel>(value.Cast<Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluationGradeLevel>());
            }
        }


        private ICollection<Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluationRatingLevel> _performanceEvaluationRatingLevels;
        private ICollection<Entities.Common.TPDM.IPerformanceEvaluationRatingLevel> _performanceEvaluationRatingLevelsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluationRatingLevel> PerformanceEvaluationRatingLevels
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _performanceEvaluationRatingLevels)
                    if (item.PerformanceEvaluation == null)
                        item.PerformanceEvaluation = this;
                // -------------------------------------------------------------

                return _performanceEvaluationRatingLevels;
            }
            set
            {
                _performanceEvaluationRatingLevels = value;
                _performanceEvaluationRatingLevelsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.IPerformanceEvaluationRatingLevel, Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluationRatingLevel>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.IPerformanceEvaluationRatingLevel> Entities.Common.TPDM.IPerformanceEvaluation.PerformanceEvaluationRatingLevels
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _performanceEvaluationRatingLevels)
                    if (item.PerformanceEvaluation == null)
                        item.PerformanceEvaluation = this;
                // -------------------------------------------------------------

                return _performanceEvaluationRatingLevelsCovariant;
            }
            set
            {
                PerformanceEvaluationRatingLevels = new HashSet<Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluationRatingLevel>(value.Cast<Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluationRatingLevel>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "AcademicSubjectDescriptor", new LookupColumnDetails { PropertyName = "AcademicSubjectDescriptorId", LookupTypeName = "AcademicSubjectDescriptor"} },
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IPerformanceEvaluation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IPerformanceEvaluation) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isAcademicSubjectDescriptorSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationSynchronizationSourceSupport.IsAcademicSubjectDescriptorSupported
        {
            get { return _isAcademicSubjectDescriptorSupported; }
            set { _isAcademicSubjectDescriptorSupported = value; }
        }

        private bool _isPerformanceEvaluationDescriptionSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationSynchronizationSourceSupport.IsPerformanceEvaluationDescriptionSupported
        {
            get { return _isPerformanceEvaluationDescriptionSupported; }
            set { _isPerformanceEvaluationDescriptionSupported = value; }
        }

        private bool _isPerformanceEvaluationGradeLevelsSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationSynchronizationSourceSupport.IsPerformanceEvaluationGradeLevelsSupported
        {
            get { return _isPerformanceEvaluationGradeLevelsSupported; }
            set { _isPerformanceEvaluationGradeLevelsSupported = value; }
        }

        private bool _isPerformanceEvaluationRatingLevelsSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationSynchronizationSourceSupport.IsPerformanceEvaluationRatingLevelsSupported
        {
            get { return _isPerformanceEvaluationRatingLevelsSupported; }
            set { _isPerformanceEvaluationRatingLevelsSupported = value; }
        }

        private Func<Entities.Common.TPDM.IPerformanceEvaluationGradeLevel, bool> _isPerformanceEvaluationGradeLevelIncluded;
        Func<Entities.Common.TPDM.IPerformanceEvaluationGradeLevel, bool> Entities.Common.TPDM.IPerformanceEvaluationSynchronizationSourceSupport.IsPerformanceEvaluationGradeLevelIncluded
        {
            get { return _isPerformanceEvaluationGradeLevelIncluded; }
            set { _isPerformanceEvaluationGradeLevelIncluded = value; }
        }

        private Func<Entities.Common.TPDM.IPerformanceEvaluationRatingLevel, bool> _isPerformanceEvaluationRatingLevelIncluded;
        Func<Entities.Common.TPDM.IPerformanceEvaluationRatingLevel, bool> Entities.Common.TPDM.IPerformanceEvaluationSynchronizationSourceSupport.IsPerformanceEvaluationRatingLevelIncluded
        {
            get { return _isPerformanceEvaluationRatingLevelIncluded; }
            set { _isPerformanceEvaluationRatingLevelIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.PerformanceEvaluationGradeLevel table of the PerformanceEvaluation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationGradeLevel : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IPerformanceEvaluationGradeLevel, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IPerformanceEvaluationGradeLevelSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public PerformanceEvaluationGradeLevel()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual PerformanceEvaluation PerformanceEvaluation { get; set; }

        Entities.Common.TPDM.IPerformanceEvaluation IPerformanceEvaluationGradeLevel.PerformanceEvaluation
        {
            get { return PerformanceEvaluation; }
            set { PerformanceEvaluation = (PerformanceEvaluation) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int GradeLevelDescriptorId 
        {
            get
            {
                if (_gradeLevelDescriptorId == default(int))
                    _gradeLevelDescriptorId = DescriptorsCache.GetCache().GetId("GradeLevelDescriptor", _gradeLevelDescriptor);

                return _gradeLevelDescriptorId;
            } 
            set
            {
                _gradeLevelDescriptorId = value;
                _gradeLevelDescriptor = null;
            }
        }

        private int _gradeLevelDescriptorId;
        private string _gradeLevelDescriptor;

        public virtual string GradeLevelDescriptor
        {
            get
            {
                if (_gradeLevelDescriptor == null)
                    _gradeLevelDescriptor = DescriptorsCache.GetCache().GetValue("GradeLevelDescriptor", _gradeLevelDescriptorId);
                    
                return _gradeLevelDescriptor;
            }
            set
            {
                _gradeLevelDescriptor = value;
                _gradeLevelDescriptorId = default(int);
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
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "GradeLevelDescriptor", new LookupColumnDetails { PropertyName = "GradeLevelDescriptorId", LookupTypeName = "GradeLevelDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (PerformanceEvaluation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("GradeLevelDescriptorId", GradeLevelDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IPerformanceEvaluationGradeLevel)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IPerformanceEvaluationGradeLevel) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            PerformanceEvaluation = (PerformanceEvaluation) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.PerformanceEvaluationRatingLevel table of the PerformanceEvaluation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevel : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IPerformanceEvaluationRatingLevel, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IPerformanceEvaluationRatingLevelSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public PerformanceEvaluationRatingLevel()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual PerformanceEvaluation PerformanceEvaluation { get; set; }

        Entities.Common.TPDM.IPerformanceEvaluation IPerformanceEvaluationRatingLevel.PerformanceEvaluation
        {
            get { return PerformanceEvaluation; }
            set { PerformanceEvaluation = (PerformanceEvaluation) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationRatingLevelDescriptorId 
        {
            get
            {
                if (_evaluationRatingLevelDescriptorId == default(int))
                    _evaluationRatingLevelDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationRatingLevelDescriptor", _evaluationRatingLevelDescriptor);

                return _evaluationRatingLevelDescriptorId;
            } 
            set
            {
                _evaluationRatingLevelDescriptorId = value;
                _evaluationRatingLevelDescriptor = null;
            }
        }

        private int _evaluationRatingLevelDescriptorId;
        private string _evaluationRatingLevelDescriptor;

        public virtual string EvaluationRatingLevelDescriptor
        {
            get
            {
                if (_evaluationRatingLevelDescriptor == null)
                    _evaluationRatingLevelDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationRatingLevelDescriptor", _evaluationRatingLevelDescriptorId);
                    
                return _evaluationRatingLevelDescriptor;
            }
            set
            {
                _evaluationRatingLevelDescriptor = value;
                _evaluationRatingLevelDescriptorId = default(int);
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
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MaxRating  { get; set; }
        [Range(typeof(decimal), "-999.999", "999.999")]
        public virtual decimal? MinRating  { get; set; }
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
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "EvaluationRatingLevelDescriptor", new LookupColumnDetails { PropertyName = "EvaluationRatingLevelDescriptorId", LookupTypeName = "EvaluationRatingLevelDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (PerformanceEvaluation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("EvaluationRatingLevelDescriptorId", EvaluationRatingLevelDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IPerformanceEvaluationRatingLevel)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IPerformanceEvaluationRatingLevel) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            PerformanceEvaluation = (PerformanceEvaluation) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isMaxRatingSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingLevelSynchronizationSourceSupport.IsMaxRatingSupported
        {
            get { return _isMaxRatingSupported; }
            set { _isMaxRatingSupported = value; }
        }

        private bool _isMinRatingSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingLevelSynchronizationSourceSupport.IsMinRatingSupported
        {
            get { return _isMinRatingSupported; }
            set { _isMinRatingSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: PerformanceEvaluationRating

namespace EdFi.Ods.Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="PerformanceEvaluationRating"/> entity.
    /// </summary>
    public class PerformanceEvaluationRatingReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId { get; set; }
        public virtual int EvaluationPeriodDescriptorId { get; set; }
        public virtual string PerformanceEvaluationTitle { get; set; }
        public virtual int PerformanceEvaluationTypeDescriptorId { get; set; }
        public virtual string PersonId { get; set; }
        public virtual short SchoolYear { get; set; }
        public virtual int SourceSystemDescriptorId { get; set; }
        public virtual int TermDescriptorId { get; set; }
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("PersonId", PersonId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("SourceSystemDescriptorId", SourceSystemDescriptorId);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.PerformanceEvaluationRating table of the PerformanceEvaluationRating aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRating : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.IPerformanceEvaluationRating, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public PerformanceEvaluationRating()
        {
            PerformanceEvaluationRatingResults = new HashSet<PerformanceEvaluationRatingResult>();
            PerformanceEvaluationRatingReviewers = new HashSet<PerformanceEvaluationRatingReviewer>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationPeriodDescriptorId 
        {
            get
            {
                if (_evaluationPeriodDescriptorId == default(int))
                    _evaluationPeriodDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationPeriodDescriptor", _evaluationPeriodDescriptor);

                return _evaluationPeriodDescriptorId;
            } 
            set
            {
                _evaluationPeriodDescriptorId = value;
                _evaluationPeriodDescriptor = null;
            }
        }

        private int _evaluationPeriodDescriptorId;
        private string _evaluationPeriodDescriptor;

        public virtual string EvaluationPeriodDescriptor
        {
            get
            {
                if (_evaluationPeriodDescriptor == null)
                    _evaluationPeriodDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationPeriodDescriptor", _evaluationPeriodDescriptorId);
                    
                return _evaluationPeriodDescriptor;
            }
            set
            {
                _evaluationPeriodDescriptor = value;
                _evaluationPeriodDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string PerformanceEvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int PerformanceEvaluationTypeDescriptorId 
        {
            get
            {
                if (_performanceEvaluationTypeDescriptorId == default(int))
                    _performanceEvaluationTypeDescriptorId = DescriptorsCache.GetCache().GetId("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptor);

                return _performanceEvaluationTypeDescriptorId;
            } 
            set
            {
                _performanceEvaluationTypeDescriptorId = value;
                _performanceEvaluationTypeDescriptor = null;
            }
        }

        private int _performanceEvaluationTypeDescriptorId;
        private string _performanceEvaluationTypeDescriptor;

        public virtual string PerformanceEvaluationTypeDescriptor
        {
            get
            {
                if (_performanceEvaluationTypeDescriptor == null)
                    _performanceEvaluationTypeDescriptor = DescriptorsCache.GetCache().GetValue("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptorId);
                    
                return _performanceEvaluationTypeDescriptor;
            }
            set
            {
                _performanceEvaluationTypeDescriptor = value;
                _performanceEvaluationTypeDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(32), NoDangerousText, NoWhitespace]
        public virtual string PersonId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual short SchoolYear  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int SourceSystemDescriptorId 
        {
            get
            {
                if (_sourceSystemDescriptorId == default(int))
                    _sourceSystemDescriptorId = DescriptorsCache.GetCache().GetId("SourceSystemDescriptor", _sourceSystemDescriptor);

                return _sourceSystemDescriptorId;
            } 
            set
            {
                _sourceSystemDescriptorId = value;
                _sourceSystemDescriptor = null;
            }
        }

        private int _sourceSystemDescriptorId;
        private string _sourceSystemDescriptor;

        public virtual string SourceSystemDescriptor
        {
            get
            {
                if (_sourceSystemDescriptor == null)
                    _sourceSystemDescriptor = DescriptorsCache.GetCache().GetValue("SourceSystemDescriptor", _sourceSystemDescriptorId);
                    
                return _sourceSystemDescriptor;
            }
            set
            {
                _sourceSystemDescriptor = value;
                _sourceSystemDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int))
                    _termDescriptorId = DescriptorsCache.GetCache().GetId("TermDescriptor", _termDescriptor);

                return _termDescriptorId;
            } 
            set
            {
                _termDescriptorId = value;
                _termDescriptor = null;
            }
        }

        private int _termDescriptorId;
        private string _termDescriptor;

        public virtual string TermDescriptor
        {
            get
            {
                if (_termDescriptor == null)
                    _termDescriptor = DescriptorsCache.GetCache().GetValue("TermDescriptor", _termDescriptorId);
                    
                return _termDescriptor;
            }
            set
            {
                _termDescriptor = value;
                _termDescriptorId = default(int);
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
        [RequiredWithNonDefault, SqlServerDateTimeRange]
        public virtual DateTime ActualDate 
        {
            get { return _actualDate; }
            //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
            set { _actualDate = new DateTime(value.Year, value.Month, value.Day); }
        }

        private DateTime _actualDate;
        
        public virtual int? ActualDuration  { get; set; }
        public virtual TimeSpan? ActualTime  { get; set; }
        public virtual bool? Announced  { get; set; }
        [StringLength(1024), NoDangerousText]
        public virtual string Comments  { get; set; }
        public virtual int? CoteachingStyleObservedDescriptorId 
        {
            get
            {
                if (_coteachingStyleObservedDescriptorId == default(int?))
                    _coteachingStyleObservedDescriptorId = string.IsNullOrWhiteSpace(_coteachingStyleObservedDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("CoteachingStyleObservedDescriptor", _coteachingStyleObservedDescriptor);

                return _coteachingStyleObservedDescriptorId;
            } 
            set
            {
                _coteachingStyleObservedDescriptorId = value;
                _coteachingStyleObservedDescriptor = null;
            }
        }

        private int? _coteachingStyleObservedDescriptorId;
        private string _coteachingStyleObservedDescriptor;

        public virtual string CoteachingStyleObservedDescriptor
        {
            get
            {
                if (_coteachingStyleObservedDescriptor == null)
                    _coteachingStyleObservedDescriptor = _coteachingStyleObservedDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("CoteachingStyleObservedDescriptor", _coteachingStyleObservedDescriptorId.Value);
                    
                return _coteachingStyleObservedDescriptor;
            }
            set
            {
                _coteachingStyleObservedDescriptor = value;
                _coteachingStyleObservedDescriptorId = default(int?);
            }
        }
        public virtual int? PerformanceEvaluationRatingLevelDescriptorId 
        {
            get
            {
                if (_performanceEvaluationRatingLevelDescriptorId == default(int?))
                    _performanceEvaluationRatingLevelDescriptorId = string.IsNullOrWhiteSpace(_performanceEvaluationRatingLevelDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("PerformanceEvaluationRatingLevelDescriptor", _performanceEvaluationRatingLevelDescriptor);

                return _performanceEvaluationRatingLevelDescriptorId;
            } 
            set
            {
                _performanceEvaluationRatingLevelDescriptorId = value;
                _performanceEvaluationRatingLevelDescriptor = null;
            }
        }

        private int? _performanceEvaluationRatingLevelDescriptorId;
        private string _performanceEvaluationRatingLevelDescriptor;

        public virtual string PerformanceEvaluationRatingLevelDescriptor
        {
            get
            {
                if (_performanceEvaluationRatingLevelDescriptor == null)
                    _performanceEvaluationRatingLevelDescriptor = _performanceEvaluationRatingLevelDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("PerformanceEvaluationRatingLevelDescriptor", _performanceEvaluationRatingLevelDescriptorId.Value);
                    
                return _performanceEvaluationRatingLevelDescriptor;
            }
            set
            {
                _performanceEvaluationRatingLevelDescriptor = value;
                _performanceEvaluationRatingLevelDescriptorId = default(int?);
            }
        }
        [SqlServerDateTimeRange]
        public virtual DateTime? ScheduleDate 
        {
            get { return _scheduleDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _scheduleDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _scheduleDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _scheduleDate;
        
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
        public virtual NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluationReferenceData PerformanceEvaluationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the PerformanceEvaluation discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IPerformanceEvaluationRating.PerformanceEvaluationDiscriminator
        {
            get { return PerformanceEvaluationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the PerformanceEvaluation resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IPerformanceEvaluationRating.PerformanceEvaluationResourceId
        {
            get { return PerformanceEvaluationReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.PersonAggregate.EdFi.PersonReferenceData PersonReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Person discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IPerformanceEvaluationRating.PersonDiscriminator
        {
            get { return PersonReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Person resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IPerformanceEvaluationRating.PersonResourceId
        {
            get { return PersonReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingResult> _performanceEvaluationRatingResults;
        private ICollection<Entities.Common.TPDM.IPerformanceEvaluationRatingResult> _performanceEvaluationRatingResultsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingResult> PerformanceEvaluationRatingResults
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _performanceEvaluationRatingResults)
                    if (item.PerformanceEvaluationRating == null)
                        item.PerformanceEvaluationRating = this;
                // -------------------------------------------------------------

                return _performanceEvaluationRatingResults;
            }
            set
            {
                _performanceEvaluationRatingResults = value;
                _performanceEvaluationRatingResultsCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.IPerformanceEvaluationRatingResult, Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingResult>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.IPerformanceEvaluationRatingResult> Entities.Common.TPDM.IPerformanceEvaluationRating.PerformanceEvaluationRatingResults
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _performanceEvaluationRatingResults)
                    if (item.PerformanceEvaluationRating == null)
                        item.PerformanceEvaluationRating = this;
                // -------------------------------------------------------------

                return _performanceEvaluationRatingResultsCovariant;
            }
            set
            {
                PerformanceEvaluationRatingResults = new HashSet<Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingResult>(value.Cast<Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingResult>());
            }
        }


        private ICollection<Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingReviewer> _performanceEvaluationRatingReviewers;
        private ICollection<Entities.Common.TPDM.IPerformanceEvaluationRatingReviewer> _performanceEvaluationRatingReviewersCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingReviewer> PerformanceEvaluationRatingReviewers
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _performanceEvaluationRatingReviewers)
                    if (item.PerformanceEvaluationRating == null)
                        item.PerformanceEvaluationRating = this;
                // -------------------------------------------------------------

                return _performanceEvaluationRatingReviewers;
            }
            set
            {
                _performanceEvaluationRatingReviewers = value;
                _performanceEvaluationRatingReviewersCovariant = new CovariantCollectionAdapter<Entities.Common.TPDM.IPerformanceEvaluationRatingReviewer, Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingReviewer>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.TPDM.IPerformanceEvaluationRatingReviewer> Entities.Common.TPDM.IPerformanceEvaluationRating.PerformanceEvaluationRatingReviewers
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _performanceEvaluationRatingReviewers)
                    if (item.PerformanceEvaluationRating == null)
                        item.PerformanceEvaluationRating = this;
                // -------------------------------------------------------------

                return _performanceEvaluationRatingReviewersCovariant;
            }
            set
            {
                PerformanceEvaluationRatingReviewers = new HashSet<Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingReviewer>(value.Cast<Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingReviewer>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "CoteachingStyleObservedDescriptor", new LookupColumnDetails { PropertyName = "CoteachingStyleObservedDescriptorId", LookupTypeName = "CoteachingStyleObservedDescriptor"} },
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "PerformanceEvaluationRatingLevelDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationRatingLevelDescriptorId", LookupTypeName = "PerformanceEvaluationRatingLevelDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("PersonId", PersonId);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("SourceSystemDescriptorId", SourceSystemDescriptorId);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IPerformanceEvaluationRating)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IPerformanceEvaluationRating) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isActualDateSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport.IsActualDateSupported
        {
            get { return _isActualDateSupported; }
            set { _isActualDateSupported = value; }
        }

        private bool _isActualDurationSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport.IsActualDurationSupported
        {
            get { return _isActualDurationSupported; }
            set { _isActualDurationSupported = value; }
        }

        private bool _isActualTimeSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport.IsActualTimeSupported
        {
            get { return _isActualTimeSupported; }
            set { _isActualTimeSupported = value; }
        }

        private bool _isAnnouncedSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport.IsAnnouncedSupported
        {
            get { return _isAnnouncedSupported; }
            set { _isAnnouncedSupported = value; }
        }

        private bool _isCommentsSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport.IsCommentsSupported
        {
            get { return _isCommentsSupported; }
            set { _isCommentsSupported = value; }
        }

        private bool _isCoteachingStyleObservedDescriptorSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport.IsCoteachingStyleObservedDescriptorSupported
        {
            get { return _isCoteachingStyleObservedDescriptorSupported; }
            set { _isCoteachingStyleObservedDescriptorSupported = value; }
        }

        private bool _isPerformanceEvaluationRatingLevelDescriptorSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport.IsPerformanceEvaluationRatingLevelDescriptorSupported
        {
            get { return _isPerformanceEvaluationRatingLevelDescriptorSupported; }
            set { _isPerformanceEvaluationRatingLevelDescriptorSupported = value; }
        }

        private bool _isPerformanceEvaluationRatingResultsSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport.IsPerformanceEvaluationRatingResultsSupported
        {
            get { return _isPerformanceEvaluationRatingResultsSupported; }
            set { _isPerformanceEvaluationRatingResultsSupported = value; }
        }

        private bool _isPerformanceEvaluationRatingReviewersSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport.IsPerformanceEvaluationRatingReviewersSupported
        {
            get { return _isPerformanceEvaluationRatingReviewersSupported; }
            set { _isPerformanceEvaluationRatingReviewersSupported = value; }
        }

        private bool _isScheduleDateSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport.IsScheduleDateSupported
        {
            get { return _isScheduleDateSupported; }
            set { _isScheduleDateSupported = value; }
        }

        private Func<Entities.Common.TPDM.IPerformanceEvaluationRatingResult, bool> _isPerformanceEvaluationRatingResultIncluded;
        Func<Entities.Common.TPDM.IPerformanceEvaluationRatingResult, bool> Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport.IsPerformanceEvaluationRatingResultIncluded
        {
            get { return _isPerformanceEvaluationRatingResultIncluded; }
            set { _isPerformanceEvaluationRatingResultIncluded = value; }
        }

        private Func<Entities.Common.TPDM.IPerformanceEvaluationRatingReviewer, bool> _isPerformanceEvaluationRatingReviewerIncluded;
        Func<Entities.Common.TPDM.IPerformanceEvaluationRatingReviewer, bool> Entities.Common.TPDM.IPerformanceEvaluationRatingSynchronizationSourceSupport.IsPerformanceEvaluationRatingReviewerIncluded
        {
            get { return _isPerformanceEvaluationRatingReviewerIncluded; }
            set { _isPerformanceEvaluationRatingReviewerIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.PerformanceEvaluationRatingResult table of the PerformanceEvaluationRating aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingResult : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IPerformanceEvaluationRatingResult, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IPerformanceEvaluationRatingResultSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public PerformanceEvaluationRatingResult()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual PerformanceEvaluationRating PerformanceEvaluationRating { get; set; }

        Entities.Common.TPDM.IPerformanceEvaluationRating IPerformanceEvaluationRatingResult.PerformanceEvaluationRating
        {
            get { return PerformanceEvaluationRating; }
            set { PerformanceEvaluationRating = (PerformanceEvaluationRating) value; }
        }

        [DomainSignature]
        public virtual decimal Rating  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string RatingResultTitle  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [RequiredWithNonDefault]
        public virtual int ResultDatatypeTypeDescriptorId 
        {
            get
            {
                if (_resultDatatypeTypeDescriptorId == default(int))
                    _resultDatatypeTypeDescriptorId = DescriptorsCache.GetCache().GetId("ResultDatatypeTypeDescriptor", _resultDatatypeTypeDescriptor);

                return _resultDatatypeTypeDescriptorId;
            } 
            set
            {
                _resultDatatypeTypeDescriptorId = value;
                _resultDatatypeTypeDescriptor = null;
            }
        }

        private int _resultDatatypeTypeDescriptorId;
        private string _resultDatatypeTypeDescriptor;

        public virtual string ResultDatatypeTypeDescriptor
        {
            get
            {
                if (_resultDatatypeTypeDescriptor == null)
                    _resultDatatypeTypeDescriptor = DescriptorsCache.GetCache().GetValue("ResultDatatypeTypeDescriptor", _resultDatatypeTypeDescriptorId);
                    
                return _resultDatatypeTypeDescriptor;
            }
            set
            {
                _resultDatatypeTypeDescriptor = value;
                _resultDatatypeTypeDescriptorId = default(int);
            }
        }
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
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "ResultDatatypeTypeDescriptor", new LookupColumnDetails { PropertyName = "ResultDatatypeTypeDescriptorId", LookupTypeName = "ResultDatatypeTypeDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (PerformanceEvaluationRating as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("Rating", Rating);
            keyValues.Add("RatingResultTitle", RatingResultTitle);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IPerformanceEvaluationRatingResult)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IPerformanceEvaluationRatingResult) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            PerformanceEvaluationRating = (PerformanceEvaluationRating) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isResultDatatypeTypeDescriptorSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingResultSynchronizationSourceSupport.IsResultDatatypeTypeDescriptorSupported
        {
            get { return _isResultDatatypeTypeDescriptorSupported; }
            set { _isResultDatatypeTypeDescriptorSupported = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.PerformanceEvaluationRatingReviewer table of the PerformanceEvaluationRating aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingReviewer : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IPerformanceEvaluationRatingReviewer, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IPerformanceEvaluationRatingReviewerSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public PerformanceEvaluationRatingReviewer()
        {
           PerformanceEvaluationRatingReviewerReceivedTrainingPersistentList = new HashSet<PerformanceEvaluationRatingReviewerReceivedTraining>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual PerformanceEvaluationRating PerformanceEvaluationRating { get; set; }

        Entities.Common.TPDM.IPerformanceEvaluationRating IPerformanceEvaluationRatingReviewer.PerformanceEvaluationRating
        {
            get { return PerformanceEvaluationRating; }
            set { PerformanceEvaluationRating = (PerformanceEvaluationRating) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(75), NoDangerousText, NoWhitespace]
        public virtual string FirstName  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(75), NoDangerousText, NoWhitespace]
        public virtual string LastSurname  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [StringLength(32), NoDangerousText]
        public virtual string ReviewerPersonId  { get; set; }
        public virtual int? ReviewerSourceSystemDescriptorId 
        {
            get
            {
                if (_reviewerSourceSystemDescriptorId == default(int?))
                    _reviewerSourceSystemDescriptorId = string.IsNullOrWhiteSpace(_reviewerSourceSystemDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("SourceSystemDescriptor", _reviewerSourceSystemDescriptor);

                return _reviewerSourceSystemDescriptorId;
            } 
            set
            {
                _reviewerSourceSystemDescriptorId = value;
                _reviewerSourceSystemDescriptor = null;
            }
        }

        private int? _reviewerSourceSystemDescriptorId;
        private string _reviewerSourceSystemDescriptor;

        public virtual string ReviewerSourceSystemDescriptor
        {
            get
            {
                if (_reviewerSourceSystemDescriptor == null)
                    _reviewerSourceSystemDescriptor = _reviewerSourceSystemDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("SourceSystemDescriptor", _reviewerSourceSystemDescriptorId.Value);
                    
                return _reviewerSourceSystemDescriptor;
            }
            set
            {
                _reviewerSourceSystemDescriptor = value;
                _reviewerSourceSystemDescriptorId = default(int?);
            }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        [ValidateObject]
        public virtual Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingReviewerReceivedTraining PerformanceEvaluationRatingReviewerReceivedTraining
        {
            get
            {
                // Return the item in the list, if one exists
                if (PerformanceEvaluationRatingReviewerReceivedTrainingPersistentList.Any())
                    return PerformanceEvaluationRatingReviewerReceivedTrainingPersistentList.First();

                // No reference is present
                return null;
            }
            set
            {
                // Delete the existing object
                if (PerformanceEvaluationRatingReviewerReceivedTrainingPersistentList.Any())
                    PerformanceEvaluationRatingReviewerReceivedTrainingPersistentList.Clear();

                // If we're setting a value, add it to the list now
                if (value != null)
                {
                    // Set the back-reference to the parent
                    value.PerformanceEvaluationRatingReviewer = this;

                    PerformanceEvaluationRatingReviewerReceivedTrainingPersistentList.Add(value);
                }
            }
        }

        Entities.Common.TPDM.IPerformanceEvaluationRatingReviewerReceivedTraining Entities.Common.TPDM.IPerformanceEvaluationRatingReviewer.PerformanceEvaluationRatingReviewerReceivedTraining
        {
            get { return PerformanceEvaluationRatingReviewerReceivedTraining; }
            set { PerformanceEvaluationRatingReviewerReceivedTraining = (Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingReviewerReceivedTraining) value; }
        }

        private ICollection<Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingReviewerReceivedTraining> _performanceEvaluationRatingReviewerReceivedTrainingPersistentList;

        public virtual ICollection<Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRatingReviewerReceivedTraining> PerformanceEvaluationRatingReviewerReceivedTrainingPersistentList
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _performanceEvaluationRatingReviewerReceivedTrainingPersistentList)
                    if (item.PerformanceEvaluationRatingReviewer == null)
                        item.PerformanceEvaluationRatingReviewer = this;
                // -------------------------------------------------------------

                return _performanceEvaluationRatingReviewerReceivedTrainingPersistentList;
            }
            set
            {
                _performanceEvaluationRatingReviewerReceivedTrainingPersistentList = value;
            }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                          Extensions
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        public virtual NHibernate.PersonAggregate.EdFi.PersonReferenceData ReviewerPersonReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the ReviewerPerson discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IPerformanceEvaluationRatingReviewer.ReviewerPersonDiscriminator
        {
            get { return ReviewerPersonReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the ReviewerPerson resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IPerformanceEvaluationRatingReviewer.ReviewerPersonResourceId
        {
            get { return ReviewerPersonReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "ReviewerSourceSystemDescriptor", new LookupColumnDetails { PropertyName = "ReviewerSourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (PerformanceEvaluationRating as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("FirstName", FirstName);
            keyValues.Add("LastSurname", LastSurname);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IPerformanceEvaluationRatingReviewer)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IPerformanceEvaluationRatingReviewer) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            PerformanceEvaluationRating = (PerformanceEvaluationRating) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isPerformanceEvaluationRatingReviewerReceivedTrainingSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingReviewerSynchronizationSourceSupport.IsPerformanceEvaluationRatingReviewerReceivedTrainingSupported
        {
            get { return _isPerformanceEvaluationRatingReviewerReceivedTrainingSupported; }
            set { _isPerformanceEvaluationRatingReviewerReceivedTrainingSupported = value; }
        }

        private bool _isReviewerPersonIdSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingReviewerSynchronizationSourceSupport.IsReviewerPersonIdSupported
        {
            get { return _isReviewerPersonIdSupported; }
            set { _isReviewerPersonIdSupported = value; }
        }

        private bool _isReviewerSourceSystemDescriptorSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingReviewerSynchronizationSourceSupport.IsReviewerSourceSystemDescriptorSupported
        {
            get { return _isReviewerSourceSystemDescriptorSupported; }
            set { _isReviewerSourceSystemDescriptorSupported = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.PerformanceEvaluationRatingReviewerReceivedTraining table of the PerformanceEvaluationRating aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingReviewerReceivedTraining : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.IPerformanceEvaluationRatingReviewerReceivedTraining, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IPerformanceEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public PerformanceEvaluationRatingReviewerReceivedTraining()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual PerformanceEvaluationRatingReviewer PerformanceEvaluationRatingReviewer { get; set; }

        Entities.Common.TPDM.IPerformanceEvaluationRatingReviewer IPerformanceEvaluationRatingReviewerReceivedTraining.PerformanceEvaluationRatingReviewer
        {
            get { return PerformanceEvaluationRatingReviewer; }
            set { PerformanceEvaluationRatingReviewer = (PerformanceEvaluationRatingReviewer) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? InterRaterReliabilityScore  { get; set; }
        [SqlServerDateTimeRange]
        public virtual DateTime? ReceivedTrainingDate 
        {
            get { return _receivedTrainingDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _receivedTrainingDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _receivedTrainingDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _receivedTrainingDate;
        
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
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (PerformanceEvaluationRatingReviewer as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IPerformanceEvaluationRatingReviewerReceivedTraining)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IPerformanceEvaluationRatingReviewerReceivedTraining) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            PerformanceEvaluationRatingReviewer = (PerformanceEvaluationRatingReviewer) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isInterRaterReliabilityScoreSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport.IsInterRaterReliabilityScoreSupported
        {
            get { return _isInterRaterReliabilityScoreSupported; }
            set { _isInterRaterReliabilityScoreSupported = value; }
        }

        private bool _isReceivedTrainingDateSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport.IsReceivedTrainingDateSupported
        {
            get { return _isReceivedTrainingDateSupported; }
            set { _isReceivedTrainingDateSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: PerformanceEvaluationRatingLevelDescriptor

namespace EdFi.Ods.Entities.NHibernate.PerformanceEvaluationRatingLevelDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.PerformanceEvaluationRatingLevelDescriptor table of the PerformanceEvaluationRatingLevelDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevelDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int PerformanceEvaluationRatingLevelDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("PerformanceEvaluationRatingLevelDescriptorId", PerformanceEvaluationRatingLevelDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: PerformanceEvaluationTypeDescriptor

namespace EdFi.Ods.Entities.NHibernate.PerformanceEvaluationTypeDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.PerformanceEvaluationTypeDescriptor table of the PerformanceEvaluationTypeDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationTypeDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int PerformanceEvaluationTypeDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: RubricDimension

namespace EdFi.Ods.Entities.NHibernate.RubricDimensionAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="RubricDimension"/> entity.
    /// </summary>
    public class RubricDimensionReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId { get; set; }
        public virtual string EvaluationElementTitle { get; set; }
        public virtual string EvaluationObjectiveTitle { get; set; }
        public virtual int EvaluationPeriodDescriptorId { get; set; }
        public virtual string EvaluationTitle { get; set; }
        public virtual string PerformanceEvaluationTitle { get; set; }
        public virtual int PerformanceEvaluationTypeDescriptorId { get; set; }
        public virtual int RubricRating { get; set; }
        public virtual short SchoolYear { get; set; }
        public virtual int TermDescriptorId { get; set; }
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationElementTitle", EvaluationElementTitle);
            keyValues.Add("EvaluationObjectiveTitle", EvaluationObjectiveTitle);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("RubricRating", RubricRating);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.RubricDimension table of the RubricDimension aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class RubricDimension : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.IRubricDimension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IRubricDimensionSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public RubricDimension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(255), NoDangerousText, NoWhitespace]
        public virtual string EvaluationElementTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string EvaluationObjectiveTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EvaluationPeriodDescriptorId 
        {
            get
            {
                if (_evaluationPeriodDescriptorId == default(int))
                    _evaluationPeriodDescriptorId = DescriptorsCache.GetCache().GetId("EvaluationPeriodDescriptor", _evaluationPeriodDescriptor);

                return _evaluationPeriodDescriptorId;
            } 
            set
            {
                _evaluationPeriodDescriptorId = value;
                _evaluationPeriodDescriptor = null;
            }
        }

        private int _evaluationPeriodDescriptorId;
        private string _evaluationPeriodDescriptor;

        public virtual string EvaluationPeriodDescriptor
        {
            get
            {
                if (_evaluationPeriodDescriptor == null)
                    _evaluationPeriodDescriptor = DescriptorsCache.GetCache().GetValue("EvaluationPeriodDescriptor", _evaluationPeriodDescriptorId);
                    
                return _evaluationPeriodDescriptor;
            }
            set
            {
                _evaluationPeriodDescriptor = value;
                _evaluationPeriodDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string EvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(50), NoDangerousText, NoWhitespace]
        public virtual string PerformanceEvaluationTitle  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int PerformanceEvaluationTypeDescriptorId 
        {
            get
            {
                if (_performanceEvaluationTypeDescriptorId == default(int))
                    _performanceEvaluationTypeDescriptorId = DescriptorsCache.GetCache().GetId("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptor);

                return _performanceEvaluationTypeDescriptorId;
            } 
            set
            {
                _performanceEvaluationTypeDescriptorId = value;
                _performanceEvaluationTypeDescriptor = null;
            }
        }

        private int _performanceEvaluationTypeDescriptorId;
        private string _performanceEvaluationTypeDescriptor;

        public virtual string PerformanceEvaluationTypeDescriptor
        {
            get
            {
                if (_performanceEvaluationTypeDescriptor == null)
                    _performanceEvaluationTypeDescriptor = DescriptorsCache.GetCache().GetValue("PerformanceEvaluationTypeDescriptor", _performanceEvaluationTypeDescriptorId);
                    
                return _performanceEvaluationTypeDescriptor;
            }
            set
            {
                _performanceEvaluationTypeDescriptor = value;
                _performanceEvaluationTypeDescriptorId = default(int);
            }
        }
        [DomainSignature]
        public virtual int RubricRating  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual short SchoolYear  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int))
                    _termDescriptorId = DescriptorsCache.GetCache().GetId("TermDescriptor", _termDescriptor);

                return _termDescriptorId;
            } 
            set
            {
                _termDescriptorId = value;
                _termDescriptor = null;
            }
        }

        private int _termDescriptorId;
        private string _termDescriptor;

        public virtual string TermDescriptor
        {
            get
            {
                if (_termDescriptor == null)
                    _termDescriptor = DescriptorsCache.GetCache().GetValue("TermDescriptor", _termDescriptorId);
                    
                return _termDescriptor;
            }
            set
            {
                _termDescriptor = value;
                _termDescriptorId = default(int);
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
        [RequiredWithNonDefault, StringLength(1024), NoDangerousText]
        public virtual string CriterionDescription  { get; set; }
        public virtual int? DimensionOrder  { get; set; }
        public virtual int? RubricRatingLevelDescriptorId 
        {
            get
            {
                if (_rubricRatingLevelDescriptorId == default(int?))
                    _rubricRatingLevelDescriptorId = string.IsNullOrWhiteSpace(_rubricRatingLevelDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("RubricRatingLevelDescriptor", _rubricRatingLevelDescriptor);

                return _rubricRatingLevelDescriptorId;
            } 
            set
            {
                _rubricRatingLevelDescriptorId = value;
                _rubricRatingLevelDescriptor = null;
            }
        }

        private int? _rubricRatingLevelDescriptorId;
        private string _rubricRatingLevelDescriptor;

        public virtual string RubricRatingLevelDescriptor
        {
            get
            {
                if (_rubricRatingLevelDescriptor == null)
                    _rubricRatingLevelDescriptor = _rubricRatingLevelDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("RubricRatingLevelDescriptor", _rubricRatingLevelDescriptorId.Value);
                    
                return _rubricRatingLevelDescriptor;
            }
            set
            {
                _rubricRatingLevelDescriptor = value;
                _rubricRatingLevelDescriptorId = default(int?);
            }
        }
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
        public virtual NHibernate.EvaluationElementAggregate.TPDM.EvaluationElementReferenceData EvaluationElementReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the EvaluationElement discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.IRubricDimension.EvaluationElementDiscriminator
        {
            get { return EvaluationElementReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the EvaluationElement resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.IRubricDimension.EvaluationElementResourceId
        {
            get { return EvaluationElementReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "EvaluationPeriodDescriptor", new LookupColumnDetails { PropertyName = "EvaluationPeriodDescriptorId", LookupTypeName = "EvaluationPeriodDescriptor"} },
                { "PerformanceEvaluationTypeDescriptor", new LookupColumnDetails { PropertyName = "PerformanceEvaluationTypeDescriptorId", LookupTypeName = "PerformanceEvaluationTypeDescriptor"} },
                { "RubricRatingLevelDescriptor", new LookupColumnDetails { PropertyName = "RubricRatingLevelDescriptorId", LookupTypeName = "RubricRatingLevelDescriptor"} },
                { "TermDescriptor", new LookupColumnDetails { PropertyName = "TermDescriptorId", LookupTypeName = "TermDescriptor"} },
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EvaluationElementTitle", EvaluationElementTitle);
            keyValues.Add("EvaluationObjectiveTitle", EvaluationObjectiveTitle);
            keyValues.Add("EvaluationPeriodDescriptorId", EvaluationPeriodDescriptorId);
            keyValues.Add("EvaluationTitle", EvaluationTitle);
            keyValues.Add("PerformanceEvaluationTitle", PerformanceEvaluationTitle);
            keyValues.Add("PerformanceEvaluationTypeDescriptorId", PerformanceEvaluationTypeDescriptorId);
            keyValues.Add("RubricRating", RubricRating);
            keyValues.Add("SchoolYear", SchoolYear);
            keyValues.Add("TermDescriptorId", TermDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IRubricDimension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IRubricDimension) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCriterionDescriptionSupported = true;
        bool Entities.Common.TPDM.IRubricDimensionSynchronizationSourceSupport.IsCriterionDescriptionSupported
        {
            get { return _isCriterionDescriptionSupported; }
            set { _isCriterionDescriptionSupported = value; }
        }

        private bool _isDimensionOrderSupported = true;
        bool Entities.Common.TPDM.IRubricDimensionSynchronizationSourceSupport.IsDimensionOrderSupported
        {
            get { return _isDimensionOrderSupported; }
            set { _isDimensionOrderSupported = value; }
        }

        private bool _isRubricRatingLevelDescriptorSupported = true;
        bool Entities.Common.TPDM.IRubricDimensionSynchronizationSourceSupport.IsRubricRatingLevelDescriptorSupported
        {
            get { return _isRubricRatingLevelDescriptorSupported; }
            set { _isRubricRatingLevelDescriptorSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: RubricRatingLevelDescriptor

namespace EdFi.Ods.Entities.NHibernate.RubricRatingLevelDescriptorAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.RubricRatingLevelDescriptor table of the RubricRatingLevelDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class RubricRatingLevelDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.TPDM.IRubricRatingLevelDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.IRubricRatingLevelDescriptorSynchronizationSourceSupport, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int RubricRatingLevelDescriptorId 
        {
            get { return base.DescriptorId; }
            set { base.DescriptorId = value; }
        }
        
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        string IDescriptor.CodeValue
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }
        string IDescriptor.Description
        {
            get { return Description; }
            set { Description = value; }
        }
        DateTime? IDescriptor.EffectiveBeginDate
        {
            get { return EffectiveBeginDate; }
            set { EffectiveBeginDate = value; }
        }
        DateTime? IDescriptor.EffectiveEndDate
        {
            get { return EffectiveEndDate; }
            set { EffectiveEndDate = value; }
        }
        string IDescriptor.Namespace
        {
            get { return Namespace; }
            set { Namespace = value; }
        }
        int? IDescriptor.PriorDescriptorId
        {
            get { return PriorDescriptorId; }
            set { PriorDescriptorId = value; }
        }
        string IDescriptor.ShortDescription
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }
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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("RubricRatingLevelDescriptorId", RubricRatingLevelDescriptorId);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.IRubricRatingLevelDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.IRubricRatingLevelDescriptor) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isCodeValueSupported = true;
        bool Entities.Common.TPDM.IRubricRatingLevelDescriptorSynchronizationSourceSupport.IsCodeValueSupported
        {
            get { return _isCodeValueSupported; }
            set { _isCodeValueSupported = value; }
        }

        private bool _isDescriptionSupported = true;
        bool Entities.Common.TPDM.IRubricRatingLevelDescriptorSynchronizationSourceSupport.IsDescriptionSupported
        {
            get { return _isDescriptionSupported; }
            set { _isDescriptionSupported = value; }
        }

        private bool _isEffectiveBeginDateSupported = true;
        bool Entities.Common.TPDM.IRubricRatingLevelDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported
        {
            get { return _isEffectiveBeginDateSupported; }
            set { _isEffectiveBeginDateSupported = value; }
        }

        private bool _isEffectiveEndDateSupported = true;
        bool Entities.Common.TPDM.IRubricRatingLevelDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported
        {
            get { return _isEffectiveEndDateSupported; }
            set { _isEffectiveEndDateSupported = value; }
        }

        private bool _isNamespaceSupported = true;
        bool Entities.Common.TPDM.IRubricRatingLevelDescriptorSynchronizationSourceSupport.IsNamespaceSupported
        {
            get { return _isNamespaceSupported; }
            set { _isNamespaceSupported = value; }
        }

        private bool _isPriorDescriptorIdSupported = true;
        bool Entities.Common.TPDM.IRubricRatingLevelDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported
        {
            get { return _isPriorDescriptorIdSupported; }
            set { _isPriorDescriptorIdSupported = value; }
        }

        private bool _isShortDescriptionSupported = true;
        bool Entities.Common.TPDM.IRubricRatingLevelDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported
        {
            get { return _isShortDescriptionSupported; }
            set { _isShortDescriptionSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: School

namespace EdFi.Ods.Entities.NHibernate.SchoolAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.SchoolExtension table of the School aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class SchoolExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ISchoolExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public SchoolExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.School School { get; set; }

        Entities.Common.EdFi.ISchool ISchoolExtension.School
        {
            get { return School; }
            set { School = (EdFi.School) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? PostSecondaryInstitutionId  { get; set; }
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
        public virtual NHibernate.EducationOrganizationAggregate.EdFi.EducationOrganizationReferenceData PostSecondaryInstitutionReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the PostSecondaryInstitution resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.ISchoolExtension.PostSecondaryInstitutionResourceId
        {
            get { return PostSecondaryInstitutionReferenceData?.Id; }
            set { }
        }

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
            var keyValues = (School as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ISchoolExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ISchoolExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            School = (EdFi.School) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isPostSecondaryInstitutionIdSupported = true;
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsPostSecondaryInstitutionIdSupported
        {
            get { return _isPostSecondaryInstitutionIdSupported; }
            set { _isPostSecondaryInstitutionIdSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: SurveyResponse

namespace EdFi.Ods.Entities.NHibernate.SurveyResponseAggregate.TPDM
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.SurveyResponseExtension table of the SurveyResponse aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class SurveyResponseExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.TPDM.ISurveyResponseExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ISurveyResponseExtensionSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public SurveyResponseExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.SurveyResponse SurveyResponse { get; set; }

        Entities.Common.EdFi.ISurveyResponse ISurveyResponseExtension.SurveyResponse
        {
            get { return SurveyResponse; }
            set { SurveyResponse = (EdFi.SurveyResponse) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [StringLength(32), NoDangerousText]
        public virtual string PersonId  { get; set; }
        public virtual int? SourceSystemDescriptorId 
        {
            get
            {
                if (_sourceSystemDescriptorId == default(int?))
                    _sourceSystemDescriptorId = string.IsNullOrWhiteSpace(_sourceSystemDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("SourceSystemDescriptor", _sourceSystemDescriptor);

                return _sourceSystemDescriptorId;
            } 
            set
            {
                _sourceSystemDescriptorId = value;
                _sourceSystemDescriptor = null;
            }
        }

        private int? _sourceSystemDescriptorId;
        private string _sourceSystemDescriptor;

        public virtual string SourceSystemDescriptor
        {
            get
            {
                if (_sourceSystemDescriptor == null)
                    _sourceSystemDescriptor = _sourceSystemDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("SourceSystemDescriptor", _sourceSystemDescriptorId.Value);
                    
                return _sourceSystemDescriptor;
            }
            set
            {
                _sourceSystemDescriptor = value;
                _sourceSystemDescriptorId = default(int?);
            }
        }
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
        public virtual NHibernate.PersonAggregate.EdFi.PersonReferenceData PersonReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Person discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.ISurveyResponseExtension.PersonDiscriminator
        {
            get { return PersonReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Person resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.ISurveyResponseExtension.PersonResourceId
        {
            get { return PersonReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (SurveyResponse as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ISurveyResponseExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ISurveyResponseExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            SurveyResponse = (EdFi.SurveyResponse) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isPersonIdSupported = true;
        bool Entities.Common.TPDM.ISurveyResponseExtensionSynchronizationSourceSupport.IsPersonIdSupported
        {
            get { return _isPersonIdSupported; }
            set { _isPersonIdSupported = value; }
        }

        private bool _isSourceSystemDescriptorSupported = true;
        bool Entities.Common.TPDM.ISurveyResponseExtensionSynchronizationSourceSupport.IsSourceSystemDescriptorSupported
        {
            get { return _isSourceSystemDescriptorSupported; }
            set { _isSourceSystemDescriptorSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: SurveyResponsePersonTargetAssociation

namespace EdFi.Ods.Entities.NHibernate.SurveyResponsePersonTargetAssociationAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="SurveyResponsePersonTargetAssociation"/> entity.
    /// </summary>
    public class SurveyResponsePersonTargetAssociationReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string Namespace { get; set; }
        public virtual string PersonId { get; set; }
        public virtual int SourceSystemDescriptorId { get; set; }
        public virtual string SurveyIdentifier { get; set; }
        public virtual string SurveyResponseIdentifier { get; set; }
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
            keyValues.Add("Namespace", Namespace);
            keyValues.Add("PersonId", PersonId);
            keyValues.Add("SourceSystemDescriptorId", SourceSystemDescriptorId);
            keyValues.Add("SurveyIdentifier", SurveyIdentifier);
            keyValues.Add("SurveyResponseIdentifier", SurveyResponseIdentifier);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.SurveyResponsePersonTargetAssociation table of the SurveyResponsePersonTargetAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class SurveyResponsePersonTargetAssociation : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.ISurveyResponsePersonTargetAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ISurveyResponsePersonTargetAssociationSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public SurveyResponsePersonTargetAssociation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(255), NoDangerousText, NoWhitespace]
        public virtual string Namespace  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(32), NoDangerousText, NoWhitespace]
        public virtual string PersonId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int SourceSystemDescriptorId 
        {
            get
            {
                if (_sourceSystemDescriptorId == default(int))
                    _sourceSystemDescriptorId = DescriptorsCache.GetCache().GetId("SourceSystemDescriptor", _sourceSystemDescriptor);

                return _sourceSystemDescriptorId;
            } 
            set
            {
                _sourceSystemDescriptorId = value;
                _sourceSystemDescriptor = null;
            }
        }

        private int _sourceSystemDescriptorId;
        private string _sourceSystemDescriptor;

        public virtual string SourceSystemDescriptor
        {
            get
            {
                if (_sourceSystemDescriptor == null)
                    _sourceSystemDescriptor = DescriptorsCache.GetCache().GetValue("SourceSystemDescriptor", _sourceSystemDescriptorId);
                    
                return _sourceSystemDescriptor;
            }
            set
            {
                _sourceSystemDescriptor = value;
                _sourceSystemDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(60), NoDangerousText, NoWhitespace]
        public virtual string SurveyIdentifier  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(60), NoDangerousText, NoWhitespace]
        public virtual string SurveyResponseIdentifier  { get; set; }
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
        //                          Extensions
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        public virtual NHibernate.PersonAggregate.EdFi.PersonReferenceData PersonReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Person discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.ISurveyResponsePersonTargetAssociation.PersonDiscriminator
        {
            get { return PersonReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Person resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.ISurveyResponsePersonTargetAssociation.PersonResourceId
        {
            get { return PersonReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.SurveyResponseAggregate.EdFi.SurveyResponseReferenceData SurveyResponseReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the SurveyResponse discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.ISurveyResponsePersonTargetAssociation.SurveyResponseDiscriminator
        {
            get { return SurveyResponseReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the SurveyResponse resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.ISurveyResponsePersonTargetAssociation.SurveyResponseResourceId
        {
            get { return SurveyResponseReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
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
            keyValues.Add("Namespace", Namespace);
            keyValues.Add("PersonId", PersonId);
            keyValues.Add("SourceSystemDescriptorId", SourceSystemDescriptorId);
            keyValues.Add("SurveyIdentifier", SurveyIdentifier);
            keyValues.Add("SurveyResponseIdentifier", SurveyResponseIdentifier);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ISurveyResponsePersonTargetAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ISurveyResponsePersonTargetAssociation) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        // -----------------------------------------
    }
}
// Aggregate: SurveySectionResponsePersonTargetAssociation

namespace EdFi.Ods.Entities.NHibernate.SurveySectionResponsePersonTargetAssociationAggregate.TPDM
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="SurveySectionResponsePersonTargetAssociation"/> entity.
    /// </summary>
    public class SurveySectionResponsePersonTargetAssociationReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string Namespace { get; set; }
        public virtual string PersonId { get; set; }
        public virtual int SourceSystemDescriptorId { get; set; }
        public virtual string SurveyIdentifier { get; set; }
        public virtual string SurveyResponseIdentifier { get; set; }
        public virtual string SurveySectionTitle { get; set; }
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
            keyValues.Add("Namespace", Namespace);
            keyValues.Add("PersonId", PersonId);
            keyValues.Add("SourceSystemDescriptorId", SourceSystemDescriptorId);
            keyValues.Add("SurveyIdentifier", SurveyIdentifier);
            keyValues.Add("SurveyResponseIdentifier", SurveyResponseIdentifier);
            keyValues.Add("SurveySectionTitle", SurveySectionTitle);

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

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                hashCode.Add(entry.Value);
            }

            return hashCode.ToHashCode();
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the tpdm.SurveySectionResponsePersonTargetAssociation table of the SurveySectionResponsePersonTargetAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("tpdm")]
    [ExcludeFromCodeCoverage]
    public class SurveySectionResponsePersonTargetAssociation : AggregateRootWithCompositeKey,
        Entities.Common.TPDM.ISurveySectionResponsePersonTargetAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.TPDM.ISurveySectionResponsePersonTargetAssociationSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public SurveySectionResponsePersonTargetAssociation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(255), NoDangerousText, NoWhitespace]
        public virtual string Namespace  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(32), NoDangerousText, NoWhitespace]
        public virtual string PersonId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int SourceSystemDescriptorId 
        {
            get
            {
                if (_sourceSystemDescriptorId == default(int))
                    _sourceSystemDescriptorId = DescriptorsCache.GetCache().GetId("SourceSystemDescriptor", _sourceSystemDescriptor);

                return _sourceSystemDescriptorId;
            } 
            set
            {
                _sourceSystemDescriptorId = value;
                _sourceSystemDescriptor = null;
            }
        }

        private int _sourceSystemDescriptorId;
        private string _sourceSystemDescriptor;

        public virtual string SourceSystemDescriptor
        {
            get
            {
                if (_sourceSystemDescriptor == null)
                    _sourceSystemDescriptor = DescriptorsCache.GetCache().GetValue("SourceSystemDescriptor", _sourceSystemDescriptorId);
                    
                return _sourceSystemDescriptor;
            }
            set
            {
                _sourceSystemDescriptor = value;
                _sourceSystemDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault, StringLength(60), NoDangerousText, NoWhitespace]
        public virtual string SurveyIdentifier  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(60), NoDangerousText, NoWhitespace]
        public virtual string SurveyResponseIdentifier  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(255), NoDangerousText, NoWhitespace]
        public virtual string SurveySectionTitle  { get; set; }
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
        //                          Extensions
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        public virtual NHibernate.PersonAggregate.EdFi.PersonReferenceData PersonReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Person discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.ISurveySectionResponsePersonTargetAssociation.PersonDiscriminator
        {
            get { return PersonReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Person resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.ISurveySectionResponsePersonTargetAssociation.PersonResourceId
        {
            get { return PersonReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.SurveySectionResponseAggregate.EdFi.SurveySectionResponseReferenceData SurveySectionResponseReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the SurveySectionResponse discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.TPDM.ISurveySectionResponsePersonTargetAssociation.SurveySectionResponseDiscriminator
        {
            get { return SurveySectionResponseReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the SurveySectionResponse resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.TPDM.ISurveySectionResponsePersonTargetAssociation.SurveySectionResponseResourceId
        {
            get { return SurveySectionResponseReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "SourceSystemDescriptor", new LookupColumnDetails { PropertyName = "SourceSystemDescriptorId", LookupTypeName = "SourceSystemDescriptor"} },
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
            keyValues.Add("Namespace", Namespace);
            keyValues.Add("PersonId", PersonId);
            keyValues.Add("SourceSystemDescriptorId", SourceSystemDescriptorId);
            keyValues.Add("SurveyIdentifier", SurveyIdentifier);
            keyValues.Add("SurveyResponseIdentifier", SurveyResponseIdentifier);
            keyValues.Add("SurveySectionTitle", SurveySectionTitle);

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
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            if (keyValues.Count == 0)
                return base.GetHashCode();

            var hashCode = new HashCode();

            foreach (DictionaryEntry entry in keyValues)
            {
                if (entry.Value is string)
                {
                    hashCode.Add(entry.Value as string, StringComparer.InvariantCultureIgnoreCase);
                }
                else
                {
                    hashCode.Add(entry.Value);
                }
            }

            return hashCode.ToHashCode();
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.TPDM.ISurveySectionResponsePersonTargetAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.TPDM.ISurveySectionResponsePersonTargetAssociation) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        // -----------------------------------------
    }
}

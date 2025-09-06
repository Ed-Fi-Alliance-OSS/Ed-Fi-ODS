using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Adapters;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Serialization;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Entities.Common.SampleStudentTranscript;
using Newtonsoft.Json;
using MessagePack;
using KeyAttribute = MessagePack.KeyAttribute;

// Aggregate: InstitutionControlDescriptor

namespace EdFi.Ods.Entities.NHibernate.InstitutionControlDescriptorAggregate.SampleStudentTranscript
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the samplestudenttranscript.InstitutionControlDescriptor table of the InstitutionControlDescriptor aggregate in the ODS database.
    /// </summary>
    [Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class InstitutionControlDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.SampleStudentTranscript.IInstitutionControlDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
    {

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        [IgnoreMember]
        public virtual int InstitutionControlDescriptorId 
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
            keyValues.Add("InstitutionControlDescriptorId", InstitutionControlDescriptorId);

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
                    if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((string) entry.Value, (string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer);
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
            return this.SynchronizeTo((Entities.Common.SampleStudentTranscript.IInstitutionControlDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.SampleStudentTranscript.IInstitutionControlDescriptor) target, null);
        }

    }
}
// Aggregate: InstitutionLevelDescriptor

namespace EdFi.Ods.Entities.NHibernate.InstitutionLevelDescriptorAggregate.SampleStudentTranscript
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the samplestudenttranscript.InstitutionLevelDescriptor table of the InstitutionLevelDescriptor aggregate in the ODS database.
    /// </summary>
    [Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class InstitutionLevelDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.SampleStudentTranscript.IInstitutionLevelDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
    {

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        [IgnoreMember]
        public virtual int InstitutionLevelDescriptorId 
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
            keyValues.Add("InstitutionLevelDescriptorId", InstitutionLevelDescriptorId);

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
                    if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((string) entry.Value, (string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer);
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
            return this.SynchronizeTo((Entities.Common.SampleStudentTranscript.IInstitutionLevelDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.SampleStudentTranscript.IInstitutionLevelDescriptor) target, null);
        }

    }
}
// Aggregate: PostSecondaryOrganization

namespace EdFi.Ods.Entities.NHibernate.PostSecondaryOrganizationAggregate.SampleStudentTranscript
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="PostSecondaryOrganization"/> entity.
    /// </summary>
    [MessagePackObject]
    public class PostSecondaryOrganizationReferenceData : IEntityReferenceData
    {
        private bool _trackLookupContext;
        private Action<PostSecondaryOrganizationReferenceData> _contextualValuesInitializer;
        private bool _contextualValuesInitialized;

        // Default constructor (used by NHibernate)
        public PostSecondaryOrganizationReferenceData() { }

        // Constructor used for deferred initialization when the parent reference hasn't yet been initialized because we're falling back from stale serialized data to NHibernate hydration
        public PostSecondaryOrganizationReferenceData(Action<PostSecondaryOrganizationReferenceData> contextualValuesInitializer)
        {
            _trackLookupContext = true;
            _contextualValuesInitializer = contextualValuesInitializer;
        }

        // Constructor used for link support with Serialized Data feature
        public PostSecondaryOrganizationReferenceData(string contextualNameOfInstitution = default, bool trackLookupContext = true)
        {
            _trackLookupContext = trackLookupContext;
    
            // Assign supplied contextual values (values pre-determined from parent context)
            _nameOfInstitution = contextualNameOfInstitution;

            _contextualValuesInitialized = true;
        }

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Guid? _id;

        /// <summary>
        /// The id of the referenced entity (used as the resource identifier in the API).
        /// </summary>
        [Key(0)]
        public virtual Guid? Id
        {
            get => _id;
            set
            {
                _id = value;

                if (_trackLookupContext || (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled))
                {
                    // If explicitly setting this to a non-value, it needs to be resolved.
                    if (value == default(Guid) || value == null)
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
            }
        }

        private string _nameOfInstitution;

        [Key(1)]
        public virtual string NameOfInstitution
        {
            get { EnsureContextualValuesInitialized(); return _nameOfInstitution; }
            set
            {
                var originalValue = _nameOfInstitution;
                _nameOfInstitution = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                    // If key value is changing (i.e. only via Synchronize)
                    else if (originalValue != default && value != originalValue) 
                    {
                        // Clear the values
                        Id = default;
                        Discriminator = null;
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
            }
        }

        private void EnsureContextualValuesInitialized()
        {
            if (!_contextualValuesInitialized && _contextualValuesInitializer != null)
            {
                _contextualValuesInitializer(this);
                _contextualValuesInitialized = true;
            }
        }

        public virtual bool IsFullyDefined()
        {
            return
                _nameOfInstitution != default
            ;
        }

        /// <summary>
        /// Gets and sets the discriminator value which identifies the concrete sub-type of the referenced entity
        /// when that entity has been derived; otherwise <b>null</b>.
        /// </summary>
        [Key(2)]
        public virtual string Discriminator { get; set; }

        private static FullName _fullName = new FullName("samplestudenttranscript", "PostSecondaryOrganization"); 
        FullName IEntityReferenceData.FullName { get => _fullName; }
    
        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("NameOfInstitution", NameOfInstitution);

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
    /// A class which represents the samplestudenttranscript.PostSecondaryOrganization table of the PostSecondaryOrganization aggregate in the ODS database.
    /// </summary>
    [Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class PostSecondaryOrganization : AggregateRootWithCompositeKey,
        Entities.Common.SampleStudentTranscript.IPostSecondaryOrganization, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public PostSecondaryOrganization()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        [Key(6)]
        public virtual string NameOfInstitution  { get; set; }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [Key(7)]
        public virtual bool AcceptanceIndicator  { get; set; }

        [Key(8)]
        public virtual int InstitutionControlDescriptorId 
        {
            get
            {
                if (_institutionControlDescriptorId == default(int))
                {
                    _institutionControlDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("InstitutionControlDescriptor", _institutionControlDescriptor);
                }

                return _institutionControlDescriptorId;
            } 
            set
            {
                _institutionControlDescriptorId = value;
                _institutionControlDescriptor = null;
            }
        }

        private int _institutionControlDescriptorId;
        private string _institutionControlDescriptor;

        [IgnoreMember]
        public virtual string InstitutionControlDescriptor
        {
            get
            {
                if (_institutionControlDescriptor == null)
                    _institutionControlDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("InstitutionControlDescriptor", _institutionControlDescriptorId);
                    
                return _institutionControlDescriptor;
            }
            set
            {
                _institutionControlDescriptor = value;
                _institutionControlDescriptorId = default(int);
            }
        }

        [Key(9)]
        public virtual int InstitutionLevelDescriptorId 
        {
            get
            {
                if (_institutionLevelDescriptorId == default(int))
                {
                    _institutionLevelDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("InstitutionLevelDescriptor", _institutionLevelDescriptor);
                }

                return _institutionLevelDescriptorId;
            } 
            set
            {
                _institutionLevelDescriptorId = value;
                _institutionLevelDescriptor = null;
            }
        }

        private int _institutionLevelDescriptorId;
        private string _institutionLevelDescriptor;

        [IgnoreMember]
        public virtual string InstitutionLevelDescriptor
        {
            get
            {
                if (_institutionLevelDescriptor == null)
                    _institutionLevelDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("InstitutionLevelDescriptor", _institutionLevelDescriptorId);
                    
                return _institutionLevelDescriptor;
            }
            set
            {
                _institutionLevelDescriptor = value;
                _institutionLevelDescriptorId = default(int);
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

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "InstitutionControlDescriptor", new LookupColumnDetails { PropertyName = "InstitutionControlDescriptorId", LookupTypeName = "InstitutionControlDescriptor"} },
                { "InstitutionLevelDescriptor", new LookupColumnDetails { PropertyName = "InstitutionLevelDescriptorId", LookupTypeName = "InstitutionLevelDescriptor"} },
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
            keyValues.Add("NameOfInstitution", NameOfInstitution);

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
                    if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((string) entry.Value, (string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer);
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
            return this.SynchronizeTo((Entities.Common.SampleStudentTranscript.IPostSecondaryOrganization)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.SampleStudentTranscript.IPostSecondaryOrganization) target, null);
        }

    }
}
// Aggregate: SpecialEducationGraduationStatusDescriptor

namespace EdFi.Ods.Entities.NHibernate.SpecialEducationGraduationStatusDescriptorAggregate.SampleStudentTranscript
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the samplestudenttranscript.SpecialEducationGraduationStatusDescriptor table of the SpecialEducationGraduationStatusDescriptor aggregate in the ODS database.
    /// </summary>
    [Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class SpecialEducationGraduationStatusDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.SampleStudentTranscript.ISpecialEducationGraduationStatusDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
    {

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        [IgnoreMember]
        public virtual int SpecialEducationGraduationStatusDescriptorId 
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
            keyValues.Add("SpecialEducationGraduationStatusDescriptorId", SpecialEducationGraduationStatusDescriptorId);

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
                    if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((string) entry.Value, (string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer);
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
            return this.SynchronizeTo((Entities.Common.SampleStudentTranscript.ISpecialEducationGraduationStatusDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.SampleStudentTranscript.ISpecialEducationGraduationStatusDescriptor) target, null);
        }

    }
}
// Aggregate: StudentAcademicRecord

namespace EdFi.Ods.Entities.NHibernate.StudentAcademicRecordAggregate.SampleStudentTranscript
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the samplestudenttranscript.StudentAcademicRecordExtension table of the StudentAcademicRecord aggregate in the ODS database.
    /// </summary>
    [Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class StudentAcademicRecordExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentAcademicRecordExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        private NHibernate.PostSecondaryOrganizationAggregate.SampleStudentTranscript.PostSecondaryOrganizationReferenceData _postSecondaryOrganizationReferenceData;

        private bool PostSecondaryOrganizationReferenceDataIsProxied()
        {
            return _postSecondaryOrganizationReferenceData != null 
                && _postSecondaryOrganizationReferenceData.GetType() != typeof(NHibernate.PostSecondaryOrganizationAggregate.SampleStudentTranscript.PostSecondaryOrganizationReferenceData);
        }

        [IgnoreMember]
        public virtual NHibernate.PostSecondaryOrganizationAggregate.SampleStudentTranscript.PostSecondaryOrganizationReferenceData PostSecondaryOrganizationReferenceData
        {
            get => _postSecondaryOrganizationReferenceData;
            set
            {
                _postSecondaryOrganizationReferenceData = value;

                if (value != null && GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled
                    // NHibernate will proxy this object reference if it is not hydrated through an outer join in the query
                    && !PostSecondaryOrganizationReferenceDataIsProxied())
                {
                    // We've encountered an NHibernate hydrated reference data meaning we've already got all reference data needed
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Suppress();
                }
            }
        }

        [Key(1)]
        public virtual NHibernate.PostSecondaryOrganizationAggregate.SampleStudentTranscript.PostSecondaryOrganizationReferenceData PostSecondaryOrganizationSerializedReferenceData { get => _postSecondaryOrganizationSerializedReferenceData; set { if (value != null) _postSecondaryOrganizationSerializedReferenceData = value; } }
        private NHibernate.PostSecondaryOrganizationAggregate.SampleStudentTranscript.PostSecondaryOrganizationReferenceData _postSecondaryOrganizationSerializedReferenceData;

        /// <summary>
        /// A read-only property implementation that allows the PostSecondaryOrganization discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension.PostSecondaryOrganizationDiscriminator
        {
            get
            {
                return PostSecondaryOrganizationReferenceDataIsProxied()
                    ? (PostSecondaryOrganizationSerializedReferenceData ?? PostSecondaryOrganizationReferenceData)?.Discriminator
                    : (PostSecondaryOrganizationReferenceData ?? PostSecondaryOrganizationSerializedReferenceData)?.Discriminator;
            }
            set { }
        }

        /// <summary>
        /// A property implementation whose getter allows the PostSecondaryOrganization resource identifier value to be mapped to the resource reference,
        /// and whose setter is used with serialized data and links features to signal need to resolve reference data from the ODS.
        /// </summary>
        Guid? Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension.PostSecondaryOrganizationResourceId
        {
            get
            {
                return PostSecondaryOrganizationReferenceDataIsProxied()
                    ? (PostSecondaryOrganizationSerializedReferenceData ?? PostSecondaryOrganizationReferenceData)?.Id
                    : (PostSecondaryOrganizationReferenceData ?? PostSecondaryOrganizationSerializedReferenceData)?.Id;
            }
            set { if (PostSecondaryOrganizationSerializedReferenceData?.IsFullyDefined() == true) PostSecondaryOrganizationSerializedReferenceData.Id = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, IgnoreMember]
        public virtual EdFi.StudentAcademicRecord StudentAcademicRecord { get; set; }

        Entities.Common.EdFi.IStudentAcademicRecord IStudentAcademicRecordExtension.StudentAcademicRecord
        {
            get { return StudentAcademicRecord; }
            set { StudentAcademicRecord = (EdFi.StudentAcademicRecord) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [Key(2)]
        public virtual string NameOfInstitution 
        {
            get => _nameOfInstitution;
            set
            {
                _nameOfInstitution = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    PostSecondaryOrganizationSerializedReferenceData ??= new NHibernate.PostSecondaryOrganizationAggregate.SampleStudentTranscript.PostSecondaryOrganizationReferenceData(trackLookupContext: true);
                    PostSecondaryOrganizationSerializedReferenceData.NameOfInstitution = value ?? default;
                }
            }
        }

        private string _nameOfInstitution;

        [Key(3)]
        public virtual int? SubmissionCertificationDescriptorId 
        {
            get
            {
                if (_submissionCertificationDescriptorId == default(int?))
                {
                    _submissionCertificationDescriptorId = string.IsNullOrWhiteSpace(_submissionCertificationDescriptor) ? default(int?) : GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("SubmissionCertificationDescriptor", _submissionCertificationDescriptor);
                }

                return _submissionCertificationDescriptorId;
            } 
            set
            {
                _submissionCertificationDescriptorId = value;
                _submissionCertificationDescriptor = null;
            }
        }

        private int? _submissionCertificationDescriptorId;
        private string _submissionCertificationDescriptor;

        [IgnoreMember]
        public virtual string SubmissionCertificationDescriptor
        {
            get
            {
                if (_submissionCertificationDescriptor == null)
                    _submissionCertificationDescriptor = _submissionCertificationDescriptorId == null ? null : GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("SubmissionCertificationDescriptor", _submissionCertificationDescriptorId.Value);
                    
                return _submissionCertificationDescriptor;
            }
            set
            {
                _submissionCertificationDescriptor = value;
                _submissionCertificationDescriptorId = default(int?);
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

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "SubmissionCertificationDescriptor", new LookupColumnDetails { PropertyName = "SubmissionCertificationDescriptorId", LookupTypeName = "SubmissionCertificationDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentAcademicRecord as IHasPrimaryKeyValues)?.GetPrimaryKeyValues() ?? new OrderedDictionary();

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
                    if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((string) entry.Value, (string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer);
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
            return this.SynchronizeTo((Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentAcademicRecord = (EdFi.StudentAcademicRecord) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the samplestudenttranscript.StudentAcademicRecordClassRankingExtension table of the StudentAcademicRecord aggregate in the ODS database.
    /// </summary>
    [Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class StudentAcademicRecordClassRankingExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.SampleStudentTranscript.IStudentAcademicRecordClassRankingExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentAcademicRecordClassRankingExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, IgnoreMember]
        public virtual EdFi.StudentAcademicRecordClassRanking StudentAcademicRecordClassRanking { get; set; }

        Entities.Common.EdFi.IStudentAcademicRecordClassRanking IStudentAcademicRecordClassRankingExtension.StudentAcademicRecordClassRanking
        {
            get { return StudentAcademicRecordClassRanking; }
            set { StudentAcademicRecordClassRanking = (EdFi.StudentAcademicRecordClassRanking) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [Key(1)]
        public virtual int SpecialEducationGraduationStatusDescriptorId 
        {
            get
            {
                if (_specialEducationGraduationStatusDescriptorId == default(int))
                {
                    _specialEducationGraduationStatusDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("SpecialEducationGraduationStatusDescriptor", _specialEducationGraduationStatusDescriptor);
                }

                return _specialEducationGraduationStatusDescriptorId;
            } 
            set
            {
                _specialEducationGraduationStatusDescriptorId = value;
                _specialEducationGraduationStatusDescriptor = null;
            }
        }

        private int _specialEducationGraduationStatusDescriptorId;
        private string _specialEducationGraduationStatusDescriptor;

        [IgnoreMember]
        public virtual string SpecialEducationGraduationStatusDescriptor
        {
            get
            {
                if (_specialEducationGraduationStatusDescriptor == null)
                    _specialEducationGraduationStatusDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("SpecialEducationGraduationStatusDescriptor", _specialEducationGraduationStatusDescriptorId);
                    
                return _specialEducationGraduationStatusDescriptor;
            }
            set
            {
                _specialEducationGraduationStatusDescriptor = value;
                _specialEducationGraduationStatusDescriptorId = default(int);
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

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "SpecialEducationGraduationStatusDescriptor", new LookupColumnDetails { PropertyName = "SpecialEducationGraduationStatusDescriptorId", LookupTypeName = "SpecialEducationGraduationStatusDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentAcademicRecordClassRanking as IHasPrimaryKeyValues)?.GetPrimaryKeyValues() ?? new OrderedDictionary();

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
                    if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((string) entry.Value, (string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer);
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
            return this.SynchronizeTo((Entities.Common.SampleStudentTranscript.IStudentAcademicRecordClassRankingExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.SampleStudentTranscript.IStudentAcademicRecordClassRankingExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentAcademicRecordClassRanking = (EdFi.StudentAcademicRecordClassRanking) value;
        }
    }
}
// Aggregate: SubmissionCertificationDescriptor

namespace EdFi.Ods.Entities.NHibernate.SubmissionCertificationDescriptorAggregate.SampleStudentTranscript
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the samplestudenttranscript.SubmissionCertificationDescriptor table of the SubmissionCertificationDescriptor aggregate in the ODS database.
    /// </summary>
    [Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class SubmissionCertificationDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
    {

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        [IgnoreMember]
        public virtual int SubmissionCertificationDescriptorId 
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
            keyValues.Add("SubmissionCertificationDescriptorId", SubmissionCertificationDescriptorId);

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
                    if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((string) entry.Value, (string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer);
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
            return this.SynchronizeTo((Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor) target, null);
        }

    }
}

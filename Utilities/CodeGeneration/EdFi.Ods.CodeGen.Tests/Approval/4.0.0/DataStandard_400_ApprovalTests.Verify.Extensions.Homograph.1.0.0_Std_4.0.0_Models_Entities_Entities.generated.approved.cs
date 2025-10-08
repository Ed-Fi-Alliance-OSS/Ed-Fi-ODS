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
using EdFi.Ods.Entities.Common.Homograph;
using Newtonsoft.Json;
using MessagePack;
using KeyAttribute = MessagePack.KeyAttribute;

// Aggregate: Name

namespace EdFi.Ods.Entities.NHibernate.NameAggregate.Homograph
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="Name"/> entity.
    /// </summary>
    [MessagePackObject]
    public class NameReferenceData : IEntityReferenceData
    {
        private bool _trackLookupContext;
        private Action<NameReferenceData> _contextualValuesInitializer;
        private bool _contextualValuesInitialized;

        // Default constructor (used by NHibernate)
        public NameReferenceData() { }

        // Constructor used for deferred initialization when the parent reference hasn't yet been initialized because we're falling back from stale serialized data to NHibernate hydration
        public NameReferenceData(Action<NameReferenceData> contextualValuesInitializer)
        {
            _trackLookupContext = true;
            _contextualValuesInitializer = contextualValuesInitializer;
        }

        // Constructor used for link support with Serialized Data feature
        public NameReferenceData(string contextualFirstName = default, string contextualLastSurname = default, bool trackLookupContext = true)
        {
            _trackLookupContext = trackLookupContext;
    
            // Assign supplied contextual values (values pre-determined from parent context)
            _firstName = contextualFirstName;
            _lastSurname = contextualLastSurname;

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

        private string _firstName;

        [Key(1)]
        public virtual string FirstName
        {
            get { EnsureContextualValuesInitialized(); return _firstName; }
            set
            {
                var originalValue = _firstName;
                _firstName = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                }
            }
        }
        private string _lastSurname;

        [Key(2)]
        public virtual string LastSurname
        {
            get { EnsureContextualValuesInitialized(); return _lastSurname; }
            set
            {
                var originalValue = _lastSurname;
                _lastSurname = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
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
                _firstName != default
                            && _lastSurname != default
            ;
        }

        /// <summary>
        /// Gets and sets the discriminator value which identifies the concrete sub-type of the referenced entity
        /// when that entity has been derived; otherwise <b>null</b>.
        /// </summary>
        [Key(3)]
        public virtual string Discriminator { get; set; }

        private static FullName _fullName = new FullName("homograph", "Name"); 
        FullName IEntityReferenceData.FullName { get => _fullName; }
    
        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

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
    /// A class which represents the homograph.Name table of the Name aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class Name : AggregateRootWithCompositeKey,
        Entities.Common.Homograph.IName, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public Name()
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
        public virtual string FirstName { get => _firstName; set { _firstName = value; } }
        private string _firstName;

        [DomainSignature]
        [Key(7)]
        public virtual string LastSurname { get => _lastSurname; set { _lastSurname = value; } }
        private string _lastSurname;

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
            return this.SynchronizeTo((Entities.Common.Homograph.IName)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.IName) target, null);
        }

    }
}
// Aggregate: Parent

namespace EdFi.Ods.Entities.NHibernate.ParentAggregate.Homograph
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="Parent"/> entity.
    /// </summary>
    [MessagePackObject]
    public class ParentReferenceData : IEntityReferenceData
    {
        private bool _trackLookupContext;
        private Action<ParentReferenceData> _contextualValuesInitializer;
        private bool _contextualValuesInitialized;

        // Default constructor (used by NHibernate)
        public ParentReferenceData() { }

        // Constructor used for deferred initialization when the parent reference hasn't yet been initialized because we're falling back from stale serialized data to NHibernate hydration
        public ParentReferenceData(Action<ParentReferenceData> contextualValuesInitializer)
        {
            _trackLookupContext = true;
            _contextualValuesInitializer = contextualValuesInitializer;
        }

        // Constructor used for link support with Serialized Data feature
        public ParentReferenceData(string contextualParentFirstName = default, string contextualParentLastSurname = default, bool trackLookupContext = true)
        {
            _trackLookupContext = trackLookupContext;
    
            // Assign supplied contextual values (values pre-determined from parent context)
            _parentFirstName = contextualParentFirstName;
            _parentLastSurname = contextualParentLastSurname;

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

        private string _parentFirstName;

        [Key(1)]
        public virtual string ParentFirstName
        {
            get { EnsureContextualValuesInitialized(); return _parentFirstName; }
            set
            {
                var originalValue = _parentFirstName;
                _parentFirstName = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                }
            }
        }
        private string _parentLastSurname;

        [Key(2)]
        public virtual string ParentLastSurname
        {
            get { EnsureContextualValuesInitialized(); return _parentLastSurname; }
            set
            {
                var originalValue = _parentLastSurname;
                _parentLastSurname = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
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
                _parentFirstName != default
                            && _parentLastSurname != default
            ;
        }

        /// <summary>
        /// Gets and sets the discriminator value which identifies the concrete sub-type of the referenced entity
        /// when that entity has been derived; otherwise <b>null</b>.
        /// </summary>
        [Key(3)]
        public virtual string Discriminator { get; set; }

        private static FullName _fullName = new FullName("homograph", "Parent"); 
        FullName IEntityReferenceData.FullName { get => _fullName; }
    
        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("ParentFirstName", ParentFirstName);
            keyValues.Add("ParentLastSurname", ParentLastSurname);

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
    /// A class which represents the homograph.Parent table of the Parent aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class Parent : AggregateRootWithCompositeKey,
        Entities.Common.Homograph.IParent, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public Parent()
        {
            ParentAddresses = new HashSet<ParentAddress>();
            ParentStudentSchoolAssociations = new HashSet<ParentStudentSchoolAssociation>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        private NHibernate.NameAggregate.Homograph.NameReferenceData _parentNameReferenceData;

        private bool ParentNameReferenceDataIsProxied()
        {
            return _parentNameReferenceData != null 
                && _parentNameReferenceData.GetType() != typeof(NHibernate.NameAggregate.Homograph.NameReferenceData);
        }

        [IgnoreMember]
        public virtual NHibernate.NameAggregate.Homograph.NameReferenceData ParentNameReferenceData
        {
            get => _parentNameReferenceData;
            set
            {
                _parentNameReferenceData = value;

                if (value != null && GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled
                    // NHibernate will proxy this object reference if it is not hydrated through an outer join in the query
                    && !ParentNameReferenceDataIsProxied())
                {
                    // We've encountered an NHibernate hydrated reference data meaning we've already got all reference data needed
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Suppress();
                }
            }
        }

        [Key(6)]
        public virtual NHibernate.NameAggregate.Homograph.NameReferenceData ParentNameSerializedReferenceData { get => _parentNameSerializedReferenceData; set { if (value != null) _parentNameSerializedReferenceData = value; } }
        private NHibernate.NameAggregate.Homograph.NameReferenceData _parentNameSerializedReferenceData;

        /// <summary>
        /// A read-only property implementation that allows the ParentName discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IParent.ParentNameDiscriminator
        {
            get
            {
                return ParentNameReferenceDataIsProxied()
                    ? (ParentNameSerializedReferenceData ?? ParentNameReferenceData)?.Discriminator
                    : (ParentNameReferenceData ?? ParentNameSerializedReferenceData)?.Discriminator;
            }
            set { }
        }

        /// <summary>
        /// A property implementation whose getter allows the ParentName resource identifier value to be mapped to the resource reference,
        /// and whose setter is used with serialized data and links features to signal need to resolve reference data from the ODS.
        /// </summary>
        Guid? Entities.Common.Homograph.IParent.ParentNameResourceId
        {
            get
            {
                return ParentNameReferenceDataIsProxied()
                    ? (ParentNameSerializedReferenceData ?? ParentNameReferenceData)?.Id
                    : (ParentNameReferenceData ?? ParentNameSerializedReferenceData)?.Id;
            }
            set { if (ParentNameSerializedReferenceData?.IsFullyDefined() == true) ParentNameSerializedReferenceData.Id = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        [Key(7)]
        public virtual string ParentFirstName 
        {
            get => _parentFirstName;
            set
            {
                _parentFirstName = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    ParentNameSerializedReferenceData ??= new NHibernate.NameAggregate.Homograph.NameReferenceData(trackLookupContext: true);
                    ParentNameSerializedReferenceData.FirstName = value;
                }
            }
        }

        private string _parentFirstName;

        [DomainSignature]
        [Key(8)]
        public virtual string ParentLastSurname 
        {
            get => _parentLastSurname;
            set
            {
                _parentLastSurname = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    ParentNameSerializedReferenceData ??= new NHibernate.NameAggregate.Homograph.NameReferenceData(trackLookupContext: true);
                    ParentNameSerializedReferenceData.LastSurname = value;
                }
            }
        }

        private string _parentLastSurname;

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

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.ParentAggregate.Homograph.ParentAddress> _parentAddresses;
        private ICollection<Entities.Common.Homograph.IParentAddress> _parentAddressesCovariant;
        [Key(9)]
        [MessagePackFormatter(typeof(PersistentCollectionFormatter<Entities.NHibernate.ParentAggregate.Homograph.ParentAddress>))]
        public virtual ICollection<Entities.NHibernate.ParentAggregate.Homograph.ParentAddress> ParentAddresses
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                if (_parentAddresses is DeserializedPersistentGenericSet<Entities.NHibernate.ParentAggregate.Homograph.ParentAddress> set)
                {
                    set.Reattach(this, "ParentAddresses");
                }
            
                foreach (var item in _parentAddresses)
                    if (item.Parent == null)
                        item.Parent = this;
                // -------------------------------------------------------------

                return _parentAddresses;
            }
            set
            {
                _parentAddresses = value;
                _parentAddressesCovariant = new CovariantCollectionAdapter<Entities.Common.Homograph.IParentAddress, Entities.NHibernate.ParentAggregate.Homograph.ParentAddress>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Homograph.IParentAddress> Entities.Common.Homograph.IParent.ParentAddresses
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _parentAddresses)
                    if (item.Parent == null)
                        item.Parent = this;
                // -------------------------------------------------------------

                return _parentAddressesCovariant;
            }
            set
            {
                ParentAddresses = new HashSet<Entities.NHibernate.ParentAggregate.Homograph.ParentAddress>(value.Cast<Entities.NHibernate.ParentAggregate.Homograph.ParentAddress>());
            }
        }


        private ICollection<Entities.NHibernate.ParentAggregate.Homograph.ParentStudentSchoolAssociation> _parentStudentSchoolAssociations;
        private ICollection<Entities.Common.Homograph.IParentStudentSchoolAssociation> _parentStudentSchoolAssociationsCovariant;
        [Key(10)]
        [MessagePackFormatter(typeof(PersistentCollectionFormatter<Entities.NHibernate.ParentAggregate.Homograph.ParentStudentSchoolAssociation>))]
        public virtual ICollection<Entities.NHibernate.ParentAggregate.Homograph.ParentStudentSchoolAssociation> ParentStudentSchoolAssociations
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                if (_parentStudentSchoolAssociations is DeserializedPersistentGenericSet<Entities.NHibernate.ParentAggregate.Homograph.ParentStudentSchoolAssociation> set)
                {
                    set.Reattach(this, "ParentStudentSchoolAssociations");
                }
            
                foreach (var item in _parentStudentSchoolAssociations)
                    if (item.Parent == null)
                        item.Parent = this;
                // -------------------------------------------------------------

                return _parentStudentSchoolAssociations;
            }
            set
            {
                _parentStudentSchoolAssociations = value;
                _parentStudentSchoolAssociationsCovariant = new CovariantCollectionAdapter<Entities.Common.Homograph.IParentStudentSchoolAssociation, Entities.NHibernate.ParentAggregate.Homograph.ParentStudentSchoolAssociation>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Homograph.IParentStudentSchoolAssociation> Entities.Common.Homograph.IParent.ParentStudentSchoolAssociations
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _parentStudentSchoolAssociations)
                    if (item.Parent == null)
                        item.Parent = this;
                // -------------------------------------------------------------

                return _parentStudentSchoolAssociationsCovariant;
            }
            set
            {
                ParentStudentSchoolAssociations = new HashSet<Entities.NHibernate.ParentAggregate.Homograph.ParentStudentSchoolAssociation>(value.Cast<Entities.NHibernate.ParentAggregate.Homograph.ParentStudentSchoolAssociation>());
            }
        }

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
            keyValues.Add("ParentFirstName", ParentFirstName);
            keyValues.Add("ParentLastSurname", ParentLastSurname);

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
            return this.SynchronizeTo((Entities.Common.Homograph.IParent)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.IParent) target, null);
        }

    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the homograph.ParentAddress table of the Parent aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class ParentAddress : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Homograph.IParentAddress, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentAddress()
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
        public virtual Parent Parent { get; set; }

        Entities.Common.Homograph.IParent IParentAddress.Parent
        {
            get { return Parent; }
            set { Parent = (Parent) value; }
        }

        [DomainSignature]
        [Key(1)]
        public virtual string City { get => _city; set { _city = value; } }
        private string _city;

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
            var keyValues = (Parent as IHasPrimaryKeyValues)?.GetPrimaryKeyValues() ?? new OrderedDictionary();

            // Add current key values
            keyValues.Add("City", City);

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
            return this.SynchronizeTo((Entities.Common.Homograph.IParentAddress)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.IParentAddress) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Parent = (Parent) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the homograph.ParentStudentSchoolAssociation table of the Parent aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class ParentStudentSchoolAssociation : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Homograph.IParentStudentSchoolAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentStudentSchoolAssociation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        private NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData _studentSchoolAssociationReferenceData;

        private bool StudentSchoolAssociationReferenceDataIsProxied()
        {
            return _studentSchoolAssociationReferenceData != null 
                && _studentSchoolAssociationReferenceData.GetType() != typeof(NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData);
        }

        [IgnoreMember]
        public virtual NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData StudentSchoolAssociationReferenceData
        {
            get => _studentSchoolAssociationReferenceData;
            set
            {
                _studentSchoolAssociationReferenceData = value;

                if (value != null && GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled
                    // NHibernate will proxy this object reference if it is not hydrated through an outer join in the query
                    && !StudentSchoolAssociationReferenceDataIsProxied())
                {
                    // We've encountered an NHibernate hydrated reference data meaning we've already got all reference data needed
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Suppress();
                }
            }
        }

        [Key(1)]
        public virtual NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData StudentSchoolAssociationSerializedReferenceData { get => _studentSchoolAssociationSerializedReferenceData; set { if (value != null) _studentSchoolAssociationSerializedReferenceData = value; } }
        private NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData _studentSchoolAssociationSerializedReferenceData;

        /// <summary>
        /// A read-only property implementation that allows the StudentSchoolAssociation discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IParentStudentSchoolAssociation.StudentSchoolAssociationDiscriminator
        {
            get
            {
                return StudentSchoolAssociationReferenceDataIsProxied()
                    ? (StudentSchoolAssociationSerializedReferenceData ?? StudentSchoolAssociationReferenceData)?.Discriminator
                    : (StudentSchoolAssociationReferenceData ?? StudentSchoolAssociationSerializedReferenceData)?.Discriminator;
            }
            set { }
        }

        /// <summary>
        /// A property implementation whose getter allows the StudentSchoolAssociation resource identifier value to be mapped to the resource reference,
        /// and whose setter is used with serialized data and links features to signal need to resolve reference data from the ODS.
        /// </summary>
        Guid? Entities.Common.Homograph.IParentStudentSchoolAssociation.StudentSchoolAssociationResourceId
        {
            get
            {
                return StudentSchoolAssociationReferenceDataIsProxied()
                    ? (StudentSchoolAssociationSerializedReferenceData ?? StudentSchoolAssociationReferenceData)?.Id
                    : (StudentSchoolAssociationReferenceData ?? StudentSchoolAssociationSerializedReferenceData)?.Id;
            }
            set { if (StudentSchoolAssociationSerializedReferenceData?.IsFullyDefined() == true) StudentSchoolAssociationSerializedReferenceData.Id = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, IgnoreMember]
        public virtual Parent Parent { get; set; }

        Entities.Common.Homograph.IParent IParentStudentSchoolAssociation.Parent
        {
            get { return Parent; }
            set { Parent = (Parent) value; }
        }

        [DomainSignature]
        [Key(2)]
        public virtual string SchoolName 
        {
            get => _schoolName;
            set
            {
                _schoolName = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    StudentSchoolAssociationSerializedReferenceData ??= new NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData(trackLookupContext: true);
                    StudentSchoolAssociationSerializedReferenceData.SchoolName = value;
                }
            }
        }

        private string _schoolName;

        [DomainSignature]
        [Key(3)]
        public virtual string StudentFirstName 
        {
            get => _studentFirstName;
            set
            {
                _studentFirstName = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    StudentSchoolAssociationSerializedReferenceData ??= new NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData(trackLookupContext: true);
                    StudentSchoolAssociationSerializedReferenceData.StudentFirstName = value;
                }
            }
        }

        private string _studentFirstName;

        [DomainSignature]
        [Key(4)]
        public virtual string StudentLastSurname 
        {
            get => _studentLastSurname;
            set
            {
                _studentLastSurname = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    StudentSchoolAssociationSerializedReferenceData ??= new NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData(trackLookupContext: true);
                    StudentSchoolAssociationSerializedReferenceData.StudentLastSurname = value;
                }
            }
        }

        private string _studentLastSurname;

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
            var keyValues = (Parent as IHasPrimaryKeyValues)?.GetPrimaryKeyValues() ?? new OrderedDictionary();

            // Add current key values
            keyValues.Add("SchoolName", SchoolName);
            keyValues.Add("StudentFirstName", StudentFirstName);
            keyValues.Add("StudentLastSurname", StudentLastSurname);

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
            return this.SynchronizeTo((Entities.Common.Homograph.IParentStudentSchoolAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.IParentStudentSchoolAssociation) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Parent = (Parent) value;
        }
    }
}
// Aggregate: School

namespace EdFi.Ods.Entities.NHibernate.SchoolAggregate.Homograph
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="School"/> entity.
    /// </summary>
    [MessagePackObject]
    public class SchoolReferenceData : IEntityReferenceData
    {
        private bool _trackLookupContext;
        private Action<SchoolReferenceData> _contextualValuesInitializer;
        private bool _contextualValuesInitialized;

        // Default constructor (used by NHibernate)
        public SchoolReferenceData() { }

        // Constructor used for deferred initialization when the parent reference hasn't yet been initialized because we're falling back from stale serialized data to NHibernate hydration
        public SchoolReferenceData(Action<SchoolReferenceData> contextualValuesInitializer)
        {
            _trackLookupContext = true;
            _contextualValuesInitializer = contextualValuesInitializer;
        }

        // Constructor used for link support with Serialized Data feature
        public SchoolReferenceData(string contextualSchoolName = default, bool trackLookupContext = true)
        {
            _trackLookupContext = trackLookupContext;
    
            // Assign supplied contextual values (values pre-determined from parent context)
            _schoolName = contextualSchoolName;

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

        private string _schoolName;

        [Key(1)]
        public virtual string SchoolName
        {
            get { EnsureContextualValuesInitialized(); return _schoolName; }
            set
            {
                var originalValue = _schoolName;
                _schoolName = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
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
                _schoolName != default
            ;
        }

        /// <summary>
        /// Gets and sets the discriminator value which identifies the concrete sub-type of the referenced entity
        /// when that entity has been derived; otherwise <b>null</b>.
        /// </summary>
        [Key(2)]
        public virtual string Discriminator { get; set; }

        private static FullName _fullName = new FullName("homograph", "School"); 
        FullName IEntityReferenceData.FullName { get => _fullName; }
    
        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("SchoolName", SchoolName);

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
    /// A class which represents the homograph.School table of the School aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class School : AggregateRootWithCompositeKey,
        Entities.Common.Homograph.ISchool, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public School()
        {
           SchoolAddressPersistentList = new HashSet<SchoolAddress>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        private NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData _schoolYearTypeReferenceData;

        private bool SchoolYearTypeReferenceDataIsProxied()
        {
            return _schoolYearTypeReferenceData != null 
                && _schoolYearTypeReferenceData.GetType() != typeof(NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData);
        }

        [IgnoreMember]
        public virtual NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData SchoolYearTypeReferenceData
        {
            get => _schoolYearTypeReferenceData;
            set
            {
                _schoolYearTypeReferenceData = value;

                if (value != null && GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled
                    // NHibernate will proxy this object reference if it is not hydrated through an outer join in the query
                    && !SchoolYearTypeReferenceDataIsProxied())
                {
                    // We've encountered an NHibernate hydrated reference data meaning we've already got all reference data needed
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Suppress();
                }
            }
        }

        [Key(6)]
        public virtual NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData SchoolYearTypeSerializedReferenceData { get => _schoolYearTypeSerializedReferenceData; set { if (value != null) _schoolYearTypeSerializedReferenceData = value; } }
        private NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData _schoolYearTypeSerializedReferenceData;

        /// <summary>
        /// A read-only property implementation that allows the SchoolYearType discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.ISchool.SchoolYearTypeDiscriminator
        {
            get
            {
                return SchoolYearTypeReferenceDataIsProxied()
                    ? (SchoolYearTypeSerializedReferenceData ?? SchoolYearTypeReferenceData)?.Discriminator
                    : (SchoolYearTypeReferenceData ?? SchoolYearTypeSerializedReferenceData)?.Discriminator;
            }
            set { }
        }

        /// <summary>
        /// A property implementation whose getter allows the SchoolYearType resource identifier value to be mapped to the resource reference,
        /// and whose setter is used with serialized data and links features to signal need to resolve reference data from the ODS.
        /// </summary>
        Guid? Entities.Common.Homograph.ISchool.SchoolYearTypeResourceId
        {
            get
            {
                return SchoolYearTypeReferenceDataIsProxied()
                    ? (SchoolYearTypeSerializedReferenceData ?? SchoolYearTypeReferenceData)?.Id
                    : (SchoolYearTypeReferenceData ?? SchoolYearTypeSerializedReferenceData)?.Id;
            }
            set { if (SchoolYearTypeSerializedReferenceData?.IsFullyDefined() == true) SchoolYearTypeSerializedReferenceData.Id = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        [Key(7)]
        public virtual string SchoolName { get => _schoolName; set { _schoolName = value; } }
        private string _schoolName;

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [Key(8)]
        public virtual string SchoolYear 
        {
            get => _schoolYear;
            set
            {
                _schoolYear = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    SchoolYearTypeSerializedReferenceData ??= new NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData(trackLookupContext: true);
                    SchoolYearTypeSerializedReferenceData.SchoolYear = value ?? default;
                }
            }
        }

        private string _schoolYear;

        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        [IgnoreMember]
        public virtual Entities.NHibernate.SchoolAggregate.Homograph.SchoolAddress SchoolAddress
        {
            get
            {
                // Return the item in the list, if one exists
                if (SchoolAddressPersistentList.Any())
                    return SchoolAddressPersistentList.First();

                // No reference is present
                return null;
            }
            set
            {
                // Delete the existing object
                if (SchoolAddressPersistentList.Any())
                    SchoolAddressPersistentList.Clear();

                // If we're setting a value, add it to the list now
                if (value != null)
                {
                    // Set the back-reference to the parent
                    value.School = this;

                    SchoolAddressPersistentList.Add(value);
                }
            }
        }

        Entities.Common.Homograph.ISchoolAddress Entities.Common.Homograph.ISchool.SchoolAddress
        {
            get { return SchoolAddress; }
            set { SchoolAddress = (Entities.NHibernate.SchoolAggregate.Homograph.SchoolAddress) value; }
        }

        private ICollection<Entities.NHibernate.SchoolAggregate.Homograph.SchoolAddress> _schoolAddressPersistentList;

        [Key(9)]
        [MessagePackFormatter(typeof(PersistentCollectionFormatter<Entities.NHibernate.SchoolAggregate.Homograph.SchoolAddress>))]
        public virtual ICollection<Entities.NHibernate.SchoolAggregate.Homograph.SchoolAddress> SchoolAddressPersistentList
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                if (_schoolAddressPersistentList is DeserializedPersistentGenericSet<Entities.NHibernate.SchoolAggregate.Homograph.SchoolAddress> set)
                {
                    set.Reattach(this, "SchoolAddress");
                }

                foreach (var item in _schoolAddressPersistentList)
                    if (item.School == null)
                        item.School = this;
                // -------------------------------------------------------------

                return _schoolAddressPersistentList;
            }
            set
            {
                _schoolAddressPersistentList = value;
            }
        }

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
            keyValues.Add("SchoolName", SchoolName);

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
            return this.SynchronizeTo((Entities.Common.Homograph.ISchool)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.ISchool) target, null);
        }

    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the homograph.SchoolAddress table of the School aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class SchoolAddress : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Homograph.ISchoolAddress, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public SchoolAddress()
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
        public virtual School School { get; set; }

        Entities.Common.Homograph.ISchool ISchoolAddress.School
        {
            get { return School; }
            set { School = (School) value; }
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
        public virtual string City { get => _city; set { _city = value; } }
        private string _city;

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
            // Get parent key values
            var keyValues = (School as IHasPrimaryKeyValues)?.GetPrimaryKeyValues() ?? new OrderedDictionary();

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
            return this.SynchronizeTo((Entities.Common.Homograph.ISchoolAddress)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.ISchoolAddress) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            School = (School) value;
        }
    }
}
// Aggregate: SchoolYearType

namespace EdFi.Ods.Entities.NHibernate.SchoolYearTypeAggregate.Homograph
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="SchoolYearType"/> entity.
    /// </summary>
    [MessagePackObject]
    public class SchoolYearTypeReferenceData : IEntityReferenceData
    {
        private bool _trackLookupContext;
        private Action<SchoolYearTypeReferenceData> _contextualValuesInitializer;
        private bool _contextualValuesInitialized;

        // Default constructor (used by NHibernate)
        public SchoolYearTypeReferenceData() { }

        // Constructor used for deferred initialization when the parent reference hasn't yet been initialized because we're falling back from stale serialized data to NHibernate hydration
        public SchoolYearTypeReferenceData(Action<SchoolYearTypeReferenceData> contextualValuesInitializer)
        {
            _trackLookupContext = true;
            _contextualValuesInitializer = contextualValuesInitializer;
        }

        // Constructor used for link support with Serialized Data feature
        public SchoolYearTypeReferenceData(string contextualSchoolYear = default, bool trackLookupContext = true)
        {
            _trackLookupContext = trackLookupContext;
    
            // Assign supplied contextual values (values pre-determined from parent context)
            _schoolYear = contextualSchoolYear;

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

        private string _schoolYear;

        [Key(1)]
        public virtual string SchoolYear
        {
            get { EnsureContextualValuesInitialized(); return _schoolYear; }
            set
            {
                var originalValue = _schoolYear;
                _schoolYear = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
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
                _schoolYear != default
            ;
        }

        /// <summary>
        /// Gets and sets the discriminator value which identifies the concrete sub-type of the referenced entity
        /// when that entity has been derived; otherwise <b>null</b>.
        /// </summary>
        [Key(2)]
        public virtual string Discriminator { get; set; }

        private static FullName _fullName = new FullName("homograph", "SchoolYearType"); 
        FullName IEntityReferenceData.FullName { get => _fullName; }
    
        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
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
    /// A class which represents the homograph.SchoolYearType table of the SchoolYearType aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class SchoolYearType : AggregateRootWithCompositeKey,
        Entities.Common.Homograph.ISchoolYearType, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public SchoolYearType()
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
        public virtual string SchoolYear { get => _schoolYear; set { _schoolYear = value; } }
        private string _schoolYear;

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
            return this.SynchronizeTo((Entities.Common.Homograph.ISchoolYearType)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.ISchoolYearType) target, null);
        }

    }
}
// Aggregate: Staff

namespace EdFi.Ods.Entities.NHibernate.StaffAggregate.Homograph
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="Staff"/> entity.
    /// </summary>
    [MessagePackObject]
    public class StaffReferenceData : IEntityReferenceData
    {
        private bool _trackLookupContext;
        private Action<StaffReferenceData> _contextualValuesInitializer;
        private bool _contextualValuesInitialized;

        // Default constructor (used by NHibernate)
        public StaffReferenceData() { }

        // Constructor used for deferred initialization when the parent reference hasn't yet been initialized because we're falling back from stale serialized data to NHibernate hydration
        public StaffReferenceData(Action<StaffReferenceData> contextualValuesInitializer)
        {
            _trackLookupContext = true;
            _contextualValuesInitializer = contextualValuesInitializer;
        }

        // Constructor used for link support with Serialized Data feature
        public StaffReferenceData(string contextualStaffFirstName = default, string contextualStaffLastSurname = default, bool trackLookupContext = true)
        {
            _trackLookupContext = trackLookupContext;
    
            // Assign supplied contextual values (values pre-determined from parent context)
            _staffFirstName = contextualStaffFirstName;
            _staffLastSurname = contextualStaffLastSurname;

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

        private string _staffFirstName;

        [Key(1)]
        public virtual string StaffFirstName
        {
            get { EnsureContextualValuesInitialized(); return _staffFirstName; }
            set
            {
                var originalValue = _staffFirstName;
                _staffFirstName = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                }
            }
        }
        private string _staffLastSurname;

        [Key(2)]
        public virtual string StaffLastSurname
        {
            get { EnsureContextualValuesInitialized(); return _staffLastSurname; }
            set
            {
                var originalValue = _staffLastSurname;
                _staffLastSurname = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
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
                _staffFirstName != default
                            && _staffLastSurname != default
            ;
        }

        /// <summary>
        /// Gets and sets the discriminator value which identifies the concrete sub-type of the referenced entity
        /// when that entity has been derived; otherwise <b>null</b>.
        /// </summary>
        [Key(3)]
        public virtual string Discriminator { get; set; }

        private static FullName _fullName = new FullName("homograph", "Staff"); 
        FullName IEntityReferenceData.FullName { get => _fullName; }
    
        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("StaffFirstName", StaffFirstName);
            keyValues.Add("StaffLastSurname", StaffLastSurname);

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
    /// A class which represents the homograph.Staff table of the Staff aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class Staff : AggregateRootWithCompositeKey,
        Entities.Common.Homograph.IStaff, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public Staff()
        {
            StaffAddresses = new HashSet<StaffAddress>();
            StaffStudentSchoolAssociations = new HashSet<StaffStudentSchoolAssociation>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        private NHibernate.NameAggregate.Homograph.NameReferenceData _staffNameReferenceData;

        private bool StaffNameReferenceDataIsProxied()
        {
            return _staffNameReferenceData != null 
                && _staffNameReferenceData.GetType() != typeof(NHibernate.NameAggregate.Homograph.NameReferenceData);
        }

        [IgnoreMember]
        public virtual NHibernate.NameAggregate.Homograph.NameReferenceData StaffNameReferenceData
        {
            get => _staffNameReferenceData;
            set
            {
                _staffNameReferenceData = value;

                if (value != null && GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled
                    // NHibernate will proxy this object reference if it is not hydrated through an outer join in the query
                    && !StaffNameReferenceDataIsProxied())
                {
                    // We've encountered an NHibernate hydrated reference data meaning we've already got all reference data needed
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Suppress();
                }
            }
        }

        [Key(6)]
        public virtual NHibernate.NameAggregate.Homograph.NameReferenceData StaffNameSerializedReferenceData { get => _staffNameSerializedReferenceData; set { if (value != null) _staffNameSerializedReferenceData = value; } }
        private NHibernate.NameAggregate.Homograph.NameReferenceData _staffNameSerializedReferenceData;

        /// <summary>
        /// A read-only property implementation that allows the StaffName discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IStaff.StaffNameDiscriminator
        {
            get
            {
                return StaffNameReferenceDataIsProxied()
                    ? (StaffNameSerializedReferenceData ?? StaffNameReferenceData)?.Discriminator
                    : (StaffNameReferenceData ?? StaffNameSerializedReferenceData)?.Discriminator;
            }
            set { }
        }

        /// <summary>
        /// A property implementation whose getter allows the StaffName resource identifier value to be mapped to the resource reference,
        /// and whose setter is used with serialized data and links features to signal need to resolve reference data from the ODS.
        /// </summary>
        Guid? Entities.Common.Homograph.IStaff.StaffNameResourceId
        {
            get
            {
                return StaffNameReferenceDataIsProxied()
                    ? (StaffNameSerializedReferenceData ?? StaffNameReferenceData)?.Id
                    : (StaffNameReferenceData ?? StaffNameSerializedReferenceData)?.Id;
            }
            set { if (StaffNameSerializedReferenceData?.IsFullyDefined() == true) StaffNameSerializedReferenceData.Id = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        [Key(7)]
        public virtual string StaffFirstName 
        {
            get => _staffFirstName;
            set
            {
                _staffFirstName = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    StaffNameSerializedReferenceData ??= new NHibernate.NameAggregate.Homograph.NameReferenceData(trackLookupContext: true);
                    StaffNameSerializedReferenceData.FirstName = value;
                }
            }
        }

        private string _staffFirstName;

        [DomainSignature]
        [Key(8)]
        public virtual string StaffLastSurname 
        {
            get => _staffLastSurname;
            set
            {
                _staffLastSurname = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    StaffNameSerializedReferenceData ??= new NHibernate.NameAggregate.Homograph.NameReferenceData(trackLookupContext: true);
                    StaffNameSerializedReferenceData.LastSurname = value;
                }
            }
        }

        private string _staffLastSurname;

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

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.StaffAggregate.Homograph.StaffAddress> _staffAddresses;
        private ICollection<Entities.Common.Homograph.IStaffAddress> _staffAddressesCovariant;
        [Key(9)]
        [MessagePackFormatter(typeof(PersistentCollectionFormatter<Entities.NHibernate.StaffAggregate.Homograph.StaffAddress>))]
        public virtual ICollection<Entities.NHibernate.StaffAggregate.Homograph.StaffAddress> StaffAddresses
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                if (_staffAddresses is DeserializedPersistentGenericSet<Entities.NHibernate.StaffAggregate.Homograph.StaffAddress> set)
                {
                    set.Reattach(this, "StaffAddresses");
                }
            
                foreach (var item in _staffAddresses)
                    if (item.Staff == null)
                        item.Staff = this;
                // -------------------------------------------------------------

                return _staffAddresses;
            }
            set
            {
                _staffAddresses = value;
                _staffAddressesCovariant = new CovariantCollectionAdapter<Entities.Common.Homograph.IStaffAddress, Entities.NHibernate.StaffAggregate.Homograph.StaffAddress>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Homograph.IStaffAddress> Entities.Common.Homograph.IStaff.StaffAddresses
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _staffAddresses)
                    if (item.Staff == null)
                        item.Staff = this;
                // -------------------------------------------------------------

                return _staffAddressesCovariant;
            }
            set
            {
                StaffAddresses = new HashSet<Entities.NHibernate.StaffAggregate.Homograph.StaffAddress>(value.Cast<Entities.NHibernate.StaffAggregate.Homograph.StaffAddress>());
            }
        }


        private ICollection<Entities.NHibernate.StaffAggregate.Homograph.StaffStudentSchoolAssociation> _staffStudentSchoolAssociations;
        private ICollection<Entities.Common.Homograph.IStaffStudentSchoolAssociation> _staffStudentSchoolAssociationsCovariant;
        [Key(10)]
        [MessagePackFormatter(typeof(PersistentCollectionFormatter<Entities.NHibernate.StaffAggregate.Homograph.StaffStudentSchoolAssociation>))]
        public virtual ICollection<Entities.NHibernate.StaffAggregate.Homograph.StaffStudentSchoolAssociation> StaffStudentSchoolAssociations
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                if (_staffStudentSchoolAssociations is DeserializedPersistentGenericSet<Entities.NHibernate.StaffAggregate.Homograph.StaffStudentSchoolAssociation> set)
                {
                    set.Reattach(this, "StaffStudentSchoolAssociations");
                }
            
                foreach (var item in _staffStudentSchoolAssociations)
                    if (item.Staff == null)
                        item.Staff = this;
                // -------------------------------------------------------------

                return _staffStudentSchoolAssociations;
            }
            set
            {
                _staffStudentSchoolAssociations = value;
                _staffStudentSchoolAssociationsCovariant = new CovariantCollectionAdapter<Entities.Common.Homograph.IStaffStudentSchoolAssociation, Entities.NHibernate.StaffAggregate.Homograph.StaffStudentSchoolAssociation>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Homograph.IStaffStudentSchoolAssociation> Entities.Common.Homograph.IStaff.StaffStudentSchoolAssociations
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _staffStudentSchoolAssociations)
                    if (item.Staff == null)
                        item.Staff = this;
                // -------------------------------------------------------------

                return _staffStudentSchoolAssociationsCovariant;
            }
            set
            {
                StaffStudentSchoolAssociations = new HashSet<Entities.NHibernate.StaffAggregate.Homograph.StaffStudentSchoolAssociation>(value.Cast<Entities.NHibernate.StaffAggregate.Homograph.StaffStudentSchoolAssociation>());
            }
        }

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
            keyValues.Add("StaffFirstName", StaffFirstName);
            keyValues.Add("StaffLastSurname", StaffLastSurname);

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
            return this.SynchronizeTo((Entities.Common.Homograph.IStaff)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.IStaff) target, null);
        }

    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the homograph.StaffAddress table of the Staff aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class StaffAddress : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Homograph.IStaffAddress, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StaffAddress()
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
        public virtual Staff Staff { get; set; }

        Entities.Common.Homograph.IStaff IStaffAddress.Staff
        {
            get { return Staff; }
            set { Staff = (Staff) value; }
        }

        [DomainSignature]
        [Key(1)]
        public virtual string City { get => _city; set { _city = value; } }
        private string _city;

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
            var keyValues = (Staff as IHasPrimaryKeyValues)?.GetPrimaryKeyValues() ?? new OrderedDictionary();

            // Add current key values
            keyValues.Add("City", City);

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
            return this.SynchronizeTo((Entities.Common.Homograph.IStaffAddress)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.IStaffAddress) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Staff = (Staff) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the homograph.StaffStudentSchoolAssociation table of the Staff aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class StaffStudentSchoolAssociation : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Homograph.IStaffStudentSchoolAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StaffStudentSchoolAssociation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        private NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData _studentSchoolAssociationReferenceData;

        private bool StudentSchoolAssociationReferenceDataIsProxied()
        {
            return _studentSchoolAssociationReferenceData != null 
                && _studentSchoolAssociationReferenceData.GetType() != typeof(NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData);
        }

        [IgnoreMember]
        public virtual NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData StudentSchoolAssociationReferenceData
        {
            get => _studentSchoolAssociationReferenceData;
            set
            {
                _studentSchoolAssociationReferenceData = value;

                if (value != null && GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled
                    // NHibernate will proxy this object reference if it is not hydrated through an outer join in the query
                    && !StudentSchoolAssociationReferenceDataIsProxied())
                {
                    // We've encountered an NHibernate hydrated reference data meaning we've already got all reference data needed
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Suppress();
                }
            }
        }

        [Key(1)]
        public virtual NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData StudentSchoolAssociationSerializedReferenceData { get => _studentSchoolAssociationSerializedReferenceData; set { if (value != null) _studentSchoolAssociationSerializedReferenceData = value; } }
        private NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData _studentSchoolAssociationSerializedReferenceData;

        /// <summary>
        /// A read-only property implementation that allows the StudentSchoolAssociation discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IStaffStudentSchoolAssociation.StudentSchoolAssociationDiscriminator
        {
            get
            {
                return StudentSchoolAssociationReferenceDataIsProxied()
                    ? (StudentSchoolAssociationSerializedReferenceData ?? StudentSchoolAssociationReferenceData)?.Discriminator
                    : (StudentSchoolAssociationReferenceData ?? StudentSchoolAssociationSerializedReferenceData)?.Discriminator;
            }
            set { }
        }

        /// <summary>
        /// A property implementation whose getter allows the StudentSchoolAssociation resource identifier value to be mapped to the resource reference,
        /// and whose setter is used with serialized data and links features to signal need to resolve reference data from the ODS.
        /// </summary>
        Guid? Entities.Common.Homograph.IStaffStudentSchoolAssociation.StudentSchoolAssociationResourceId
        {
            get
            {
                return StudentSchoolAssociationReferenceDataIsProxied()
                    ? (StudentSchoolAssociationSerializedReferenceData ?? StudentSchoolAssociationReferenceData)?.Id
                    : (StudentSchoolAssociationReferenceData ?? StudentSchoolAssociationSerializedReferenceData)?.Id;
            }
            set { if (StudentSchoolAssociationSerializedReferenceData?.IsFullyDefined() == true) StudentSchoolAssociationSerializedReferenceData.Id = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, IgnoreMember]
        public virtual Staff Staff { get; set; }

        Entities.Common.Homograph.IStaff IStaffStudentSchoolAssociation.Staff
        {
            get { return Staff; }
            set { Staff = (Staff) value; }
        }

        [DomainSignature]
        [Key(2)]
        public virtual string SchoolName 
        {
            get => _schoolName;
            set
            {
                _schoolName = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    StudentSchoolAssociationSerializedReferenceData ??= new NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData(trackLookupContext: true);
                    StudentSchoolAssociationSerializedReferenceData.SchoolName = value;
                }
            }
        }

        private string _schoolName;

        [DomainSignature]
        [Key(3)]
        public virtual string StudentFirstName 
        {
            get => _studentFirstName;
            set
            {
                _studentFirstName = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    StudentSchoolAssociationSerializedReferenceData ??= new NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData(trackLookupContext: true);
                    StudentSchoolAssociationSerializedReferenceData.StudentFirstName = value;
                }
            }
        }

        private string _studentFirstName;

        [DomainSignature]
        [Key(4)]
        public virtual string StudentLastSurname 
        {
            get => _studentLastSurname;
            set
            {
                _studentLastSurname = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    StudentSchoolAssociationSerializedReferenceData ??= new NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData(trackLookupContext: true);
                    StudentSchoolAssociationSerializedReferenceData.StudentLastSurname = value;
                }
            }
        }

        private string _studentLastSurname;

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
            var keyValues = (Staff as IHasPrimaryKeyValues)?.GetPrimaryKeyValues() ?? new OrderedDictionary();

            // Add current key values
            keyValues.Add("SchoolName", SchoolName);
            keyValues.Add("StudentFirstName", StudentFirstName);
            keyValues.Add("StudentLastSurname", StudentLastSurname);

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
            return this.SynchronizeTo((Entities.Common.Homograph.IStaffStudentSchoolAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.IStaffStudentSchoolAssociation) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Staff = (Staff) value;
        }
    }
}
// Aggregate: Student

namespace EdFi.Ods.Entities.NHibernate.StudentAggregate.Homograph
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="Student"/> entity.
    /// </summary>
    [MessagePackObject]
    public class StudentReferenceData : IEntityReferenceData
    {
        private bool _trackLookupContext;
        private Action<StudentReferenceData> _contextualValuesInitializer;
        private bool _contextualValuesInitialized;

        // Default constructor (used by NHibernate)
        public StudentReferenceData() { }

        // Constructor used for deferred initialization when the parent reference hasn't yet been initialized because we're falling back from stale serialized data to NHibernate hydration
        public StudentReferenceData(Action<StudentReferenceData> contextualValuesInitializer)
        {
            _trackLookupContext = true;
            _contextualValuesInitializer = contextualValuesInitializer;
        }

        // Constructor used for link support with Serialized Data feature
        public StudentReferenceData(string contextualStudentFirstName = default, string contextualStudentLastSurname = default, bool trackLookupContext = true)
        {
            _trackLookupContext = trackLookupContext;
    
            // Assign supplied contextual values (values pre-determined from parent context)
            _studentFirstName = contextualStudentFirstName;
            _studentLastSurname = contextualStudentLastSurname;

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

        private string _studentFirstName;

        [Key(1)]
        public virtual string StudentFirstName
        {
            get { EnsureContextualValuesInitialized(); return _studentFirstName; }
            set
            {
                var originalValue = _studentFirstName;
                _studentFirstName = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                }
            }
        }
        private string _studentLastSurname;

        [Key(2)]
        public virtual string StudentLastSurname
        {
            get { EnsureContextualValuesInitialized(); return _studentLastSurname; }
            set
            {
                var originalValue = _studentLastSurname;
                _studentLastSurname = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
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
                _studentFirstName != default
                            && _studentLastSurname != default
            ;
        }

        /// <summary>
        /// Gets and sets the discriminator value which identifies the concrete sub-type of the referenced entity
        /// when that entity has been derived; otherwise <b>null</b>.
        /// </summary>
        [Key(3)]
        public virtual string Discriminator { get; set; }

        private static FullName _fullName = new FullName("homograph", "Student"); 
        FullName IEntityReferenceData.FullName { get => _fullName; }
    
        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("StudentFirstName", StudentFirstName);
            keyValues.Add("StudentLastSurname", StudentLastSurname);

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
    /// A class which represents the homograph.Student table of the Student aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class Student : AggregateRootWithCompositeKey,
        Entities.Common.Homograph.IStudent, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public Student()
        {
           StudentAddressPersistentList = new HashSet<StudentAddress>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        private NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData _schoolYearTypeReferenceData;

        private bool SchoolYearTypeReferenceDataIsProxied()
        {
            return _schoolYearTypeReferenceData != null 
                && _schoolYearTypeReferenceData.GetType() != typeof(NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData);
        }

        [IgnoreMember]
        public virtual NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData SchoolYearTypeReferenceData
        {
            get => _schoolYearTypeReferenceData;
            set
            {
                _schoolYearTypeReferenceData = value;

                if (value != null && GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled
                    // NHibernate will proxy this object reference if it is not hydrated through an outer join in the query
                    && !SchoolYearTypeReferenceDataIsProxied())
                {
                    // We've encountered an NHibernate hydrated reference data meaning we've already got all reference data needed
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Suppress();
                }
            }
        }

        [Key(6)]
        public virtual NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData SchoolYearTypeSerializedReferenceData { get => _schoolYearTypeSerializedReferenceData; set { if (value != null) _schoolYearTypeSerializedReferenceData = value; } }
        private NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData _schoolYearTypeSerializedReferenceData;

        /// <summary>
        /// A read-only property implementation that allows the SchoolYearType discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IStudent.SchoolYearTypeDiscriminator
        {
            get
            {
                return SchoolYearTypeReferenceDataIsProxied()
                    ? (SchoolYearTypeSerializedReferenceData ?? SchoolYearTypeReferenceData)?.Discriminator
                    : (SchoolYearTypeReferenceData ?? SchoolYearTypeSerializedReferenceData)?.Discriminator;
            }
            set { }
        }

        /// <summary>
        /// A property implementation whose getter allows the SchoolYearType resource identifier value to be mapped to the resource reference,
        /// and whose setter is used with serialized data and links features to signal need to resolve reference data from the ODS.
        /// </summary>
        Guid? Entities.Common.Homograph.IStudent.SchoolYearTypeResourceId
        {
            get
            {
                return SchoolYearTypeReferenceDataIsProxied()
                    ? (SchoolYearTypeSerializedReferenceData ?? SchoolYearTypeReferenceData)?.Id
                    : (SchoolYearTypeReferenceData ?? SchoolYearTypeSerializedReferenceData)?.Id;
            }
            set { if (SchoolYearTypeSerializedReferenceData?.IsFullyDefined() == true) SchoolYearTypeSerializedReferenceData.Id = value; }
        }

        private NHibernate.NameAggregate.Homograph.NameReferenceData _studentNameReferenceData;

        private bool StudentNameReferenceDataIsProxied()
        {
            return _studentNameReferenceData != null 
                && _studentNameReferenceData.GetType() != typeof(NHibernate.NameAggregate.Homograph.NameReferenceData);
        }

        [IgnoreMember]
        public virtual NHibernate.NameAggregate.Homograph.NameReferenceData StudentNameReferenceData
        {
            get => _studentNameReferenceData;
            set
            {
                _studentNameReferenceData = value;

                if (value != null && GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled
                    // NHibernate will proxy this object reference if it is not hydrated through an outer join in the query
                    && !StudentNameReferenceDataIsProxied())
                {
                    // We've encountered an NHibernate hydrated reference data meaning we've already got all reference data needed
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Suppress();
                }
            }
        }

        [Key(7)]
        public virtual NHibernate.NameAggregate.Homograph.NameReferenceData StudentNameSerializedReferenceData { get => _studentNameSerializedReferenceData; set { if (value != null) _studentNameSerializedReferenceData = value; } }
        private NHibernate.NameAggregate.Homograph.NameReferenceData _studentNameSerializedReferenceData;

        /// <summary>
        /// A read-only property implementation that allows the StudentName discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IStudent.StudentNameDiscriminator
        {
            get
            {
                return StudentNameReferenceDataIsProxied()
                    ? (StudentNameSerializedReferenceData ?? StudentNameReferenceData)?.Discriminator
                    : (StudentNameReferenceData ?? StudentNameSerializedReferenceData)?.Discriminator;
            }
            set { }
        }

        /// <summary>
        /// A property implementation whose getter allows the StudentName resource identifier value to be mapped to the resource reference,
        /// and whose setter is used with serialized data and links features to signal need to resolve reference data from the ODS.
        /// </summary>
        Guid? Entities.Common.Homograph.IStudent.StudentNameResourceId
        {
            get
            {
                return StudentNameReferenceDataIsProxied()
                    ? (StudentNameSerializedReferenceData ?? StudentNameReferenceData)?.Id
                    : (StudentNameReferenceData ?? StudentNameSerializedReferenceData)?.Id;
            }
            set { if (StudentNameSerializedReferenceData?.IsFullyDefined() == true) StudentNameSerializedReferenceData.Id = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        [Key(8)]
        public virtual string StudentFirstName 
        {
            get => _studentFirstName;
            set
            {
                _studentFirstName = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    StudentNameSerializedReferenceData ??= new NHibernate.NameAggregate.Homograph.NameReferenceData(trackLookupContext: true);
                    StudentNameSerializedReferenceData.FirstName = value;
                }
            }
        }

        private string _studentFirstName;

        [DomainSignature]
        [Key(9)]
        public virtual string StudentLastSurname 
        {
            get => _studentLastSurname;
            set
            {
                _studentLastSurname = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    StudentNameSerializedReferenceData ??= new NHibernate.NameAggregate.Homograph.NameReferenceData(trackLookupContext: true);
                    StudentNameSerializedReferenceData.LastSurname = value;
                }
            }
        }

        private string _studentLastSurname;

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [Key(10)]
        public virtual string SchoolYear 
        {
            get => _schoolYear;
            set
            {
                _schoolYear = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    SchoolYearTypeSerializedReferenceData ??= new NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData(trackLookupContext: true);
                    SchoolYearTypeSerializedReferenceData.SchoolYear = value;
                }
            }
        }

        private string _schoolYear;

        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        [IgnoreMember]
        public virtual Entities.NHibernate.StudentAggregate.Homograph.StudentAddress StudentAddress
        {
            get
            {
                // Return the item in the list, if one exists
                if (StudentAddressPersistentList.Any())
                    return StudentAddressPersistentList.First();

                // No reference is present
                return null;
            }
            set
            {
                // Delete the existing object
                if (StudentAddressPersistentList.Any())
                    StudentAddressPersistentList.Clear();

                // If we're setting a value, add it to the list now
                if (value != null)
                {
                    // Set the back-reference to the parent
                    value.Student = this;

                    StudentAddressPersistentList.Add(value);
                }
            }
        }

        Entities.Common.Homograph.IStudentAddress Entities.Common.Homograph.IStudent.StudentAddress
        {
            get { return StudentAddress; }
            set { StudentAddress = (Entities.NHibernate.StudentAggregate.Homograph.StudentAddress) value; }
        }

        private ICollection<Entities.NHibernate.StudentAggregate.Homograph.StudentAddress> _studentAddressPersistentList;

        [Key(11)]
        [MessagePackFormatter(typeof(PersistentCollectionFormatter<Entities.NHibernate.StudentAggregate.Homograph.StudentAddress>))]
        public virtual ICollection<Entities.NHibernate.StudentAggregate.Homograph.StudentAddress> StudentAddressPersistentList
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                if (_studentAddressPersistentList is DeserializedPersistentGenericSet<Entities.NHibernate.StudentAggregate.Homograph.StudentAddress> set)
                {
                    set.Reattach(this, "StudentAddress");
                }

                foreach (var item in _studentAddressPersistentList)
                    if (item.Student == null)
                        item.Student = this;
                // -------------------------------------------------------------

                return _studentAddressPersistentList;
            }
            set
            {
                _studentAddressPersistentList = value;
            }
        }

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
            keyValues.Add("StudentFirstName", StudentFirstName);
            keyValues.Add("StudentLastSurname", StudentLastSurname);

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
            return this.SynchronizeTo((Entities.Common.Homograph.IStudent)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.IStudent) target, null);
        }

    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the homograph.StudentAddress table of the Student aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class StudentAddress : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Homograph.IStudentAddress, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentAddress()
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
        public virtual Student Student { get; set; }

        Entities.Common.Homograph.IStudent IStudentAddress.Student
        {
            get { return Student; }
            set { Student = (Student) value; }
        }

        [DomainSignature]
        [Key(1)]
        public virtual string City { get => _city; set { _city = value; } }
        private string _city;

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
            var keyValues = (Student as IHasPrimaryKeyValues)?.GetPrimaryKeyValues() ?? new OrderedDictionary();

            // Add current key values
            keyValues.Add("City", City);

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
            return this.SynchronizeTo((Entities.Common.Homograph.IStudentAddress)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.IStudentAddress) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Student = (Student) value;
        }
    }
}
// Aggregate: StudentSchoolAssociation

namespace EdFi.Ods.Entities.NHibernate.StudentSchoolAssociationAggregate.Homograph
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="StudentSchoolAssociation"/> entity.
    /// </summary>
    [MessagePackObject]
    public class StudentSchoolAssociationReferenceData : IEntityReferenceData
    {
        private bool _trackLookupContext;
        private Action<StudentSchoolAssociationReferenceData> _contextualValuesInitializer;
        private bool _contextualValuesInitialized;

        // Default constructor (used by NHibernate)
        public StudentSchoolAssociationReferenceData() { }

        // Constructor used for deferred initialization when the parent reference hasn't yet been initialized because we're falling back from stale serialized data to NHibernate hydration
        public StudentSchoolAssociationReferenceData(Action<StudentSchoolAssociationReferenceData> contextualValuesInitializer)
        {
            _trackLookupContext = true;
            _contextualValuesInitializer = contextualValuesInitializer;
        }

        // Constructor used for link support with Serialized Data feature
        public StudentSchoolAssociationReferenceData(string contextualSchoolName = default, string contextualStudentFirstName = default, string contextualStudentLastSurname = default, bool trackLookupContext = true)
        {
            _trackLookupContext = trackLookupContext;
    
            // Assign supplied contextual values (values pre-determined from parent context)
            _schoolName = contextualSchoolName;
            _studentFirstName = contextualStudentFirstName;
            _studentLastSurname = contextualStudentLastSurname;

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

        private string _schoolName;

        [Key(1)]
        public virtual string SchoolName
        {
            get { EnsureContextualValuesInitialized(); return _schoolName; }
            set
            {
                var originalValue = _schoolName;
                _schoolName = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                }
            }
        }
        private string _studentFirstName;

        [Key(2)]
        public virtual string StudentFirstName
        {
            get { EnsureContextualValuesInitialized(); return _studentFirstName; }
            set
            {
                var originalValue = _studentFirstName;
                _studentFirstName = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                }
            }
        }
        private string _studentLastSurname;

        [Key(3)]
        public virtual string StudentLastSurname
        {
            get { EnsureContextualValuesInitialized(); return _studentLastSurname; }
            set
            {
                var originalValue = _studentLastSurname;
                _studentLastSurname = value;

                if (_trackLookupContext)
                {
                    // If Id is NOT already known then value is being initialized (from mapping or syncing -- not deserialized) and needs resolution 
                    if (_id == default && originalValue == default && value != default && IsFullyDefined())
                    {
                        GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
                    }
                }
                
                // If reference's key value is changing from a non-default value (i.e. only via Synchronize) it needs resolution
                if (originalValue != default && value != originalValue) 
                {
                    // Clear the values
                    Id = default;
                    Discriminator = null;
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Add(this);
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
                _schoolName != default
                            && _studentFirstName != default
                            && _studentLastSurname != default
            ;
        }

        /// <summary>
        /// Gets and sets the discriminator value which identifies the concrete sub-type of the referenced entity
        /// when that entity has been derived; otherwise <b>null</b>.
        /// </summary>
        [Key(4)]
        public virtual string Discriminator { get; set; }

        private static FullName _fullName = new FullName("homograph", "StudentSchoolAssociation"); 
        FullName IEntityReferenceData.FullName { get => _fullName; }
    
        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("SchoolName", SchoolName);
            keyValues.Add("StudentFirstName", StudentFirstName);
            keyValues.Add("StudentLastSurname", StudentLastSurname);

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
    /// A class which represents the homograph.StudentSchoolAssociation table of the StudentSchoolAssociation aggregate in the ODS database.
    /// </summary>
    [Schema("homograph")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class StudentSchoolAssociation : AggregateRootWithCompositeKey, IHasCascadableKeyValues,
        Entities.Common.Homograph.IStudentSchoolAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentSchoolAssociation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        private NHibernate.SchoolAggregate.Homograph.SchoolReferenceData _schoolReferenceData;

        private bool SchoolReferenceDataIsProxied()
        {
            return _schoolReferenceData != null 
                && _schoolReferenceData.GetType() != typeof(NHibernate.SchoolAggregate.Homograph.SchoolReferenceData);
        }

        [IgnoreMember]
        public virtual NHibernate.SchoolAggregate.Homograph.SchoolReferenceData SchoolReferenceData
        {
            get => _schoolReferenceData;
            set
            {
                _schoolReferenceData = value;

                if (value != null && GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled
                    // NHibernate will proxy this object reference if it is not hydrated through an outer join in the query
                    && !SchoolReferenceDataIsProxied())
                {
                    // We've encountered an NHibernate hydrated reference data meaning we've already got all reference data needed
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Suppress();
                }
            }
        }

        [Key(6)]
        public virtual NHibernate.SchoolAggregate.Homograph.SchoolReferenceData SchoolSerializedReferenceData { get => _schoolSerializedReferenceData; set { if (value != null) _schoolSerializedReferenceData = value; } }
        private NHibernate.SchoolAggregate.Homograph.SchoolReferenceData _schoolSerializedReferenceData;

        /// <summary>
        /// A read-only property implementation that allows the School discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IStudentSchoolAssociation.SchoolDiscriminator
        {
            get
            {
                return SchoolReferenceDataIsProxied()
                    ? (SchoolSerializedReferenceData ?? SchoolReferenceData)?.Discriminator
                    : (SchoolReferenceData ?? SchoolSerializedReferenceData)?.Discriminator;
            }
            set { }
        }

        /// <summary>
        /// A property implementation whose getter allows the School resource identifier value to be mapped to the resource reference,
        /// and whose setter is used with serialized data and links features to signal need to resolve reference data from the ODS.
        /// </summary>
        Guid? Entities.Common.Homograph.IStudentSchoolAssociation.SchoolResourceId
        {
            get
            {
                return SchoolReferenceDataIsProxied()
                    ? (SchoolSerializedReferenceData ?? SchoolReferenceData)?.Id
                    : (SchoolReferenceData ?? SchoolSerializedReferenceData)?.Id;
            }
            set { if (SchoolSerializedReferenceData?.IsFullyDefined() == true) SchoolSerializedReferenceData.Id = value; }
        }

        private NHibernate.StudentAggregate.Homograph.StudentReferenceData _studentReferenceData;

        private bool StudentReferenceDataIsProxied()
        {
            return _studentReferenceData != null 
                && _studentReferenceData.GetType() != typeof(NHibernate.StudentAggregate.Homograph.StudentReferenceData);
        }

        [IgnoreMember]
        public virtual NHibernate.StudentAggregate.Homograph.StudentReferenceData StudentReferenceData
        {
            get => _studentReferenceData;
            set
            {
                _studentReferenceData = value;

                if (value != null && GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled
                    // NHibernate will proxy this object reference if it is not hydrated through an outer join in the query
                    && !StudentReferenceDataIsProxied())
                {
                    // We've encountered an NHibernate hydrated reference data meaning we've already got all reference data needed
                    GeneratedArtifactStaticDependencies.ReferenceDataLookupContextProvider.Get()?.Suppress();
                }
            }
        }

        [Key(7)]
        public virtual NHibernate.StudentAggregate.Homograph.StudentReferenceData StudentSerializedReferenceData { get => _studentSerializedReferenceData; set { if (value != null) _studentSerializedReferenceData = value; } }
        private NHibernate.StudentAggregate.Homograph.StudentReferenceData _studentSerializedReferenceData;

        /// <summary>
        /// A read-only property implementation that allows the Student discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IStudentSchoolAssociation.StudentDiscriminator
        {
            get
            {
                return StudentReferenceDataIsProxied()
                    ? (StudentSerializedReferenceData ?? StudentReferenceData)?.Discriminator
                    : (StudentReferenceData ?? StudentSerializedReferenceData)?.Discriminator;
            }
            set { }
        }

        /// <summary>
        /// A property implementation whose getter allows the Student resource identifier value to be mapped to the resource reference,
        /// and whose setter is used with serialized data and links features to signal need to resolve reference data from the ODS.
        /// </summary>
        Guid? Entities.Common.Homograph.IStudentSchoolAssociation.StudentResourceId
        {
            get
            {
                return StudentReferenceDataIsProxied()
                    ? (StudentSerializedReferenceData ?? StudentReferenceData)?.Id
                    : (StudentReferenceData ?? StudentSerializedReferenceData)?.Id;
            }
            set { if (StudentSerializedReferenceData?.IsFullyDefined() == true) StudentSerializedReferenceData.Id = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        [Key(8)]
        public virtual string SchoolName 
        {
            get => _schoolName;
            set
            {
                _schoolName = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    SchoolSerializedReferenceData ??= new NHibernate.SchoolAggregate.Homograph.SchoolReferenceData(trackLookupContext: true);
                    SchoolSerializedReferenceData.SchoolName = value;
                }
            }
        }

        private string _schoolName;

        [DomainSignature]
        [Key(9)]
        public virtual string StudentFirstName 
        {
            get => _studentFirstName;
            set
            {
                _studentFirstName = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    StudentSerializedReferenceData ??= new NHibernate.StudentAggregate.Homograph.StudentReferenceData(trackLookupContext: true);
                    StudentSerializedReferenceData.StudentFirstName = value;
                }
            }
        }

        private string _studentFirstName;

        [DomainSignature]
        [Key(10)]
        public virtual string StudentLastSurname 
        {
            get => _studentLastSurname;
            set
            {
                _studentLastSurname = value;

                if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
                {
                    StudentSerializedReferenceData ??= new NHibernate.StudentAggregate.Homograph.StudentReferenceData(trackLookupContext: true);
                    StudentSerializedReferenceData.StudentLastSurname = value;
                }
            }
        }

        private string _studentLastSurname;

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
            keyValues.Add("SchoolName", SchoolName);
            keyValues.Add("StudentFirstName", StudentFirstName);
            keyValues.Add("StudentLastSurname", StudentLastSurname);

            return keyValues;
        }

        OrderedDictionary IHasCascadableKeyValues.NewKeyValues { get; set; }
        OrderedDictionary IHasCascadableKeyValues.OriginalKeyValues { get => _originalKeyValues; set { _originalKeyValues = value; } }

        private OrderedDictionary _originalKeyValues;

        void IHasCascadableKeyValues.RestoreOriginalKeyValues()
        {
            // Restore original key values to prevent NHibernate from processing the key change (see EdFiOdsPostUpdateEventListener)
            _schoolName = (string) _originalKeyValues["SchoolName"];
            _studentFirstName = (string) _originalKeyValues["StudentFirstName"];
            _studentLastSurname = (string) _originalKeyValues["StudentLastSurname"];
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
            return this.SynchronizeTo((Entities.Common.Homograph.IStudentSchoolAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Homograph.IStudentSchoolAssociation) target, null);
        }

    }
}

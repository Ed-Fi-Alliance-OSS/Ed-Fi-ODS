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
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Entities.Common.Homograph;
using Newtonsoft.Json;

// Aggregate: Name

namespace EdFi.Ods.Entities.NHibernate.NameAggregate.Homograph
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="Name"/> entity.
    /// </summary>
    public class NameReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string FirstName { get; set; }
        public virtual string LastSurname { get; set; }
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class Name : AggregateRootWithCompositeKey,
        Entities.Common.Homograph.IName, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public Name()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string FirstName  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string LastSurname  { get; set; }
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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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
    public class ParentReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string ParentFirstName { get; set; }
        public virtual string ParentLastSurname { get; set; }
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class Parent : AggregateRootWithCompositeKey,
        Entities.Common.Homograph.IParent, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public Parent()
        {
            ParentAddresses = new HashSet<ParentAddress>();
            ParentStudentSchoolAssociations = new HashSet<ParentStudentSchoolAssociation>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string ParentFirstName  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string ParentLastSurname  { get; set; }
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
        public virtual NHibernate.NameAggregate.Homograph.NameReferenceData ParentNameReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the ParentName discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IParent.ParentNameDiscriminator
        {
            get { return ParentNameReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the ParentName resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Homograph.IParent.ParentNameResourceId
        {
            get { return ParentNameReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.ParentAggregate.Homograph.ParentAddress> _parentAddresses;
        private ICollection<Entities.Common.Homograph.IParentAddress> _parentAddressesCovariant;
        [RequiredCollection]
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.ParentAggregate.Homograph.ParentAddress> ParentAddresses
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
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
        [RequiredCollection]
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.ParentAggregate.Homograph.ParentStudentSchoolAssociation> ParentStudentSchoolAssociations
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class ParentAddress : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Homograph.IParentAddress, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentAddress()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Parent Parent { get; set; }

        Entities.Common.Homograph.IParent IParentAddress.Parent
        {
            get { return Parent; }
            set { Parent = (Parent) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(30, MinimumLength=2), NoDangerousText, NoWhitespace]
        public virtual string City  { get; set; }
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
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Parent as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class ParentStudentSchoolAssociation : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Homograph.IParentStudentSchoolAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentStudentSchoolAssociation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Parent Parent { get; set; }

        Entities.Common.Homograph.IParent IParentStudentSchoolAssociation.Parent
        {
            get { return Parent; }
            set { Parent = (Parent) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(100, MinimumLength=0), NoDangerousText, NoWhitespace]
        public virtual string SchoolName  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string StudentFirstName  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string StudentLastSurname  { get; set; }
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
        public virtual NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData StudentSchoolAssociationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the StudentSchoolAssociation discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IParentStudentSchoolAssociation.StudentSchoolAssociationDiscriminator
        {
            get { return StudentSchoolAssociationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the StudentSchoolAssociation resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Homograph.IParentStudentSchoolAssociation.StudentSchoolAssociationResourceId
        {
            get { return StudentSchoolAssociationReferenceData?.Id; }
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
            var keyValues = (Parent as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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
    public class SchoolReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string SchoolName { get; set; }
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class School : AggregateRootWithCompositeKey,
        Entities.Common.Homograph.ISchool, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public School()
        {
           SchoolAddressPersistentList = new HashSet<SchoolAddress>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(100, MinimumLength=0), NoDangerousText, NoWhitespace]
        public virtual string SchoolName  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [StringLength(20, MinimumLength=0), NoDangerousText]
        public virtual string SchoolYear  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        [ValidateObject]
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

        public virtual ICollection<Entities.NHibernate.SchoolAggregate.Homograph.SchoolAddress> SchoolAddressPersistentList
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
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

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        public virtual NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData SchoolYearTypeReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the SchoolYearType discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.ISchool.SchoolYearTypeDiscriminator
        {
            get { return SchoolYearTypeReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the SchoolYearType resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Homograph.ISchool.SchoolYearTypeResourceId
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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class SchoolAddress : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Homograph.ISchoolAddress, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public SchoolAddress()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
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
        [RequiredWithNonDefault, StringLength(30, MinimumLength=2), NoDangerousText]
        public virtual string City  { get; set; }
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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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
    public class SchoolYearTypeReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string SchoolYear { get; set; }
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class SchoolYearType : AggregateRootWithCompositeKey,
        Entities.Common.Homograph.ISchoolYearType, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public SchoolYearType()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(20, MinimumLength=0), NoDangerousText, NoWhitespace]
        public virtual string SchoolYear  { get; set; }
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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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
    public class StaffReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string StaffFirstName { get; set; }
        public virtual string StaffLastSurname { get; set; }
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class Staff : AggregateRootWithCompositeKey,
        Entities.Common.Homograph.IStaff, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public Staff()
        {
            StaffAddresses = new HashSet<StaffAddress>();
            StaffStudentSchoolAssociations = new HashSet<StaffStudentSchoolAssociation>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string StaffFirstName  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string StaffLastSurname  { get; set; }
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
        public virtual NHibernate.NameAggregate.Homograph.NameReferenceData StaffNameReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the StaffName discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IStaff.StaffNameDiscriminator
        {
            get { return StaffNameReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the StaffName resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Homograph.IStaff.StaffNameResourceId
        {
            get { return StaffNameReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.StaffAggregate.Homograph.StaffAddress> _staffAddresses;
        private ICollection<Entities.Common.Homograph.IStaffAddress> _staffAddressesCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StaffAggregate.Homograph.StaffAddress> StaffAddresses
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
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
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StaffAggregate.Homograph.StaffStudentSchoolAssociation> StaffStudentSchoolAssociations
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class StaffAddress : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Homograph.IStaffAddress, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StaffAddress()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Staff Staff { get; set; }

        Entities.Common.Homograph.IStaff IStaffAddress.Staff
        {
            get { return Staff; }
            set { Staff = (Staff) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(30, MinimumLength=2), NoDangerousText, NoWhitespace]
        public virtual string City  { get; set; }
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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class StaffStudentSchoolAssociation : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Homograph.IStaffStudentSchoolAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StaffStudentSchoolAssociation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Staff Staff { get; set; }

        Entities.Common.Homograph.IStaff IStaffStudentSchoolAssociation.Staff
        {
            get { return Staff; }
            set { Staff = (Staff) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(100, MinimumLength=0), NoDangerousText, NoWhitespace]
        public virtual string SchoolName  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string StudentFirstName  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string StudentLastSurname  { get; set; }
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
        public virtual NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociationReferenceData StudentSchoolAssociationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the StudentSchoolAssociation discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IStaffStudentSchoolAssociation.StudentSchoolAssociationDiscriminator
        {
            get { return StudentSchoolAssociationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the StudentSchoolAssociation resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Homograph.IStaffStudentSchoolAssociation.StudentSchoolAssociationResourceId
        {
            get { return StudentSchoolAssociationReferenceData?.Id; }
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
            var keyValues = (Staff as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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
    public class StudentReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string StudentFirstName { get; set; }
        public virtual string StudentLastSurname { get; set; }
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class Student : AggregateRootWithCompositeKey,
        Entities.Common.Homograph.IStudent, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public Student()
        {
           StudentAddressPersistentList = new HashSet<StudentAddress>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string StudentFirstName  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string StudentLastSurname  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [RequiredWithNonDefault, StringLength(20, MinimumLength=0), NoDangerousText]
        public virtual string SchoolYear  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        [ValidateObject]
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

        public virtual ICollection<Entities.NHibernate.StudentAggregate.Homograph.StudentAddress> StudentAddressPersistentList
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
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

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        public virtual NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearTypeReferenceData SchoolYearTypeReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the SchoolYearType discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IStudent.SchoolYearTypeDiscriminator
        {
            get { return SchoolYearTypeReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the SchoolYearType resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Homograph.IStudent.SchoolYearTypeResourceId
        {
            get { return SchoolYearTypeReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.NameAggregate.Homograph.NameReferenceData StudentNameReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the StudentName discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IStudent.StudentNameDiscriminator
        {
            get { return StudentNameReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the StudentName resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Homograph.IStudent.StudentNameResourceId
        {
            get { return StudentNameReferenceData?.Id; }
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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class StudentAddress : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Homograph.IStudentAddress, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentAddress()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Student Student { get; set; }

        Entities.Common.Homograph.IStudent IStudentAddress.Student
        {
            get { return Student; }
            set { Student = (Student) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(30, MinimumLength=2), NoDangerousText, NoWhitespace]
        public virtual string City  { get; set; }
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
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Student as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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
    public class StudentSchoolAssociationReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string SchoolName { get; set; }
        public virtual string StudentFirstName { get; set; }
        public virtual string StudentLastSurname { get; set; }
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
    [Serializable, Schema("homograph")]
    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociation : AggregateRootWithCompositeKey, IHasCascadableKeyValues,
        Entities.Common.Homograph.IStudentSchoolAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentSchoolAssociation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(100, MinimumLength=0), NoDangerousText, NoWhitespace]
        public virtual string SchoolName  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string StudentFirstName  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string StudentLastSurname  { get; set; }
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
        public virtual NHibernate.SchoolAggregate.Homograph.SchoolReferenceData SchoolReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the School discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IStudentSchoolAssociation.SchoolDiscriminator
        {
            get { return SchoolReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the School resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Homograph.IStudentSchoolAssociation.SchoolResourceId
        {
            get { return SchoolReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.StudentAggregate.Homograph.StudentReferenceData StudentReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Student discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Homograph.IStudentSchoolAssociation.StudentDiscriminator
        {
            get { return StudentReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Student resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Homograph.IStudentSchoolAssociation.StudentResourceId
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

        /// <summary>
        /// Gets or sets the <see cref="OrderedDictionary"/> capturing the new key values that have
        /// not been modified directly on the entity.
        /// </summary>
        OrderedDictionary IHasCascadableKeyValues.NewKeyValues { get; set; }

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
                    if (!_databaseEngineSpecificStringComparer.Equals((string) entry.Value,(string) thoseKeys[entry.Key]))
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
                    hashCode.Add(entry.Value as string, _databaseEngineSpecificStringComparer);
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

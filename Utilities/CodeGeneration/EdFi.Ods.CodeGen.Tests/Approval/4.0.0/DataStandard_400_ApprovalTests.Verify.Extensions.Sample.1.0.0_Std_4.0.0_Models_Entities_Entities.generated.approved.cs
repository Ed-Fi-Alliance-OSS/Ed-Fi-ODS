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
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Entities.Common.Sample;
using Newtonsoft.Json;

// Aggregate: ArtMediumDescriptor

namespace EdFi.Ods.Entities.NHibernate.ArtMediumDescriptorAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.ArtMediumDescriptor table of the ArtMediumDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class ArtMediumDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.Sample.IArtMediumDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int ArtMediumDescriptorId 
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
            keyValues.Add("ArtMediumDescriptorId", ArtMediumDescriptorId);

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
            return this.SynchronizeTo((Entities.Common.Sample.IArtMediumDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IArtMediumDescriptor) target, null);
        }

    }
}
// Aggregate: Bus

namespace EdFi.Ods.Entities.NHibernate.BusAggregate.Sample
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="Bus"/> entity.
    /// </summary>
    public class BusReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string BusId { get; set; }
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
            keyValues.Add("BusId", BusId);

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
    /// A class which represents the sample.Bus table of the Bus aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class Bus : AggregateRootWithCompositeKey,
        Entities.Common.Sample.IBus, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public Bus()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(60, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string BusId  { get; set; }
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
            keyValues.Add("BusId", BusId);

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
            return this.SynchronizeTo((Entities.Common.Sample.IBus)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IBus) target, null);
        }

    }
}
// Aggregate: BusRoute

namespace EdFi.Ods.Entities.NHibernate.BusRouteAggregate.Sample
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="BusRoute"/> entity.
    /// </summary>
    public class BusRouteReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string BusId { get; set; }
        public virtual int BusRouteNumber { get; set; }
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
            keyValues.Add("BusId", BusId);
            keyValues.Add("BusRouteNumber", BusRouteNumber);

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
    /// A class which represents the sample.BusRoute table of the BusRoute aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class BusRoute : AggregateRootWithCompositeKey,
        Entities.Common.Sample.IBusRoute, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public BusRoute()
        {
            BusRouteBusYears = new HashSet<BusRouteBusYear>();
            BusRoutePrograms = new HashSet<BusRouteProgram>();
            BusRouteServiceAreaPostalCodes = new HashSet<BusRouteServiceAreaPostalCode>();
            BusRouteStartTimes = new HashSet<BusRouteStartTime>();
            BusRouteTelephones = new HashSet<BusRouteTelephone>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(60, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string BusId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int BusRouteNumber  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
        
        [RequiredWithNonDefault, StringLength(15, MinimumLength=0), NoDangerousText]
        public virtual string BusRouteDirection  { get; set; }
        [Range(1, 2147483647)]
        public virtual int? BusRouteDuration  { get; set; }
        public virtual bool? Daily  { get; set; }
        public virtual int? DisabilityDescriptorId 
        {
            get
            {
                if (_disabilityDescriptorId == default(int?))
                    _disabilityDescriptorId = string.IsNullOrWhiteSpace(_disabilityDescriptor) ? default(int?) : GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("DisabilityDescriptor", _disabilityDescriptor);

                return _disabilityDescriptorId;
            } 
            set
            {
                _disabilityDescriptorId = value;
                _disabilityDescriptor = null;
            }
        }

        private int? _disabilityDescriptorId;
        private string _disabilityDescriptor;

        public virtual string DisabilityDescriptor
        {
            get
            {
                if (_disabilityDescriptor == null)
                    _disabilityDescriptor = _disabilityDescriptorId == null ? null : GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("DisabilityDescriptor", _disabilityDescriptorId.Value);
                    
                return _disabilityDescriptor;
            }
            set
            {
                _disabilityDescriptor = value;
                _disabilityDescriptorId = default(int?);
            }
        }
        public virtual int? EducationOrganizationId  { get; set; }
        [RequiredWithNonDefault, StringLength(30, MinimumLength=0), NoDangerousText]
        public virtual string ExpectedTransitTime  { get; set; }
        [Range(typeof(decimal), "-999.99", "999.99")]
        public virtual decimal HoursPerWeek  { get; set; }
        [Range(typeof(decimal), "-922337203685477.5808", "922337203685477.5807")]
        public virtual decimal OperatingCost  { get; set; }
        [Range(typeof(decimal), "-9.9999", "9.9999")]
        public virtual decimal? OptimalCapacity  { get; set; }
        public virtual int? StaffClassificationDescriptorId 
        {
            get
            {
                if (_staffClassificationDescriptorId == default(int?))
                    _staffClassificationDescriptorId = string.IsNullOrWhiteSpace(_staffClassificationDescriptor) ? default(int?) : GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("StaffClassificationDescriptor", _staffClassificationDescriptor);

                return _staffClassificationDescriptorId;
            } 
            set
            {
                _staffClassificationDescriptorId = value;
                _staffClassificationDescriptor = null;
            }
        }

        private int? _staffClassificationDescriptorId;
        private string _staffClassificationDescriptor;

        public virtual string StaffClassificationDescriptor
        {
            get
            {
                if (_staffClassificationDescriptor == null)
                    _staffClassificationDescriptor = _staffClassificationDescriptorId == null ? null : GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("StaffClassificationDescriptor", _staffClassificationDescriptorId.Value);
                    
                return _staffClassificationDescriptor;
            }
            set
            {
                _staffClassificationDescriptor = value;
                _staffClassificationDescriptorId = default(int?);
            }
        }
        public virtual int? StaffUSI 
        {
            get
            {
                if (_staffUSI == default(int?))
                    _staffUSI = PersonUniqueIdToUsiCache.GetCache().GetUsiNullable("Staff", _staffUniqueId);

                return _staffUSI;
            } 
            set
            {
                _staffUSI = value;
            }
        }

        private int? _staffUSI;
        private string _staffUniqueId;

        
        public virtual string StaffUniqueId
        {
            get
            {
                if (_staffUniqueId == null && _staffUSI.HasValue)
                    _staffUniqueId = PersonUniqueIdToUsiCache.GetCache().GetUniqueId("Staff", _staffUSI.Value);
                    
                return _staffUniqueId;
            }
            set
            {
                if (_staffUniqueId != value)
                        _staffUSI = default(int?);

                _staffUniqueId = value;
            }
        }
        public virtual DateTime? StartDate 
        {
            get { return _startDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _startDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _startDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _startDate;
        
        [Range(typeof(decimal), "-999.99", "999.99")]
        public virtual decimal? WeeklyMileage  { get; set; }
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
        public virtual NHibernate.StaffEducationOrganizationAssignmentAssociationAggregate.EdFi.StaffEducationOrganizationAssignmentAssociationReferenceData StaffEducationOrganizationAssignmentAssociationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the StaffEducationOrganizationAssignmentAssociation discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Sample.IBusRoute.StaffEducationOrganizationAssignmentAssociationDiscriminator
        {
            get { return StaffEducationOrganizationAssignmentAssociationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the StaffEducationOrganizationAssignmentAssociation resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.IBusRoute.StaffEducationOrganizationAssignmentAssociationResourceId
        {
            get { return StaffEducationOrganizationAssignmentAssociationReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteBusYear> _busRouteBusYears;
        private ICollection<Entities.Common.Sample.IBusRouteBusYear> _busRouteBusYearsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteBusYear> BusRouteBusYears
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _busRouteBusYears)
                    if (item.BusRoute == null)
                        item.BusRoute = this;
                // -------------------------------------------------------------

                return _busRouteBusYears;
            }
            set
            {
                _busRouteBusYears = value;
                _busRouteBusYearsCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IBusRouteBusYear, Entities.NHibernate.BusRouteAggregate.Sample.BusRouteBusYear>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IBusRouteBusYear> Entities.Common.Sample.IBusRoute.BusRouteBusYears
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _busRouteBusYears)
                    if (item.BusRoute == null)
                        item.BusRoute = this;
                // -------------------------------------------------------------

                return _busRouteBusYearsCovariant;
            }
            set
            {
                BusRouteBusYears = new HashSet<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteBusYear>(value.Cast<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteBusYear>());
            }
        }


        private ICollection<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteProgram> _busRoutePrograms;
        private ICollection<Entities.Common.Sample.IBusRouteProgram> _busRouteProgramsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteProgram> BusRoutePrograms
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _busRoutePrograms)
                    if (item.BusRoute == null)
                        item.BusRoute = this;
                // -------------------------------------------------------------

                return _busRoutePrograms;
            }
            set
            {
                _busRoutePrograms = value;
                _busRouteProgramsCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IBusRouteProgram, Entities.NHibernate.BusRouteAggregate.Sample.BusRouteProgram>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IBusRouteProgram> Entities.Common.Sample.IBusRoute.BusRoutePrograms
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _busRoutePrograms)
                    if (item.BusRoute == null)
                        item.BusRoute = this;
                // -------------------------------------------------------------

                return _busRouteProgramsCovariant;
            }
            set
            {
                BusRoutePrograms = new HashSet<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteProgram>(value.Cast<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteProgram>());
            }
        }


        private ICollection<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteServiceAreaPostalCode> _busRouteServiceAreaPostalCodes;
        private ICollection<Entities.Common.Sample.IBusRouteServiceAreaPostalCode> _busRouteServiceAreaPostalCodesCovariant;
        [RequiredCollection]
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteServiceAreaPostalCode> BusRouteServiceAreaPostalCodes
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _busRouteServiceAreaPostalCodes)
                    if (item.BusRoute == null)
                        item.BusRoute = this;
                // -------------------------------------------------------------

                return _busRouteServiceAreaPostalCodes;
            }
            set
            {
                _busRouteServiceAreaPostalCodes = value;
                _busRouteServiceAreaPostalCodesCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IBusRouteServiceAreaPostalCode, Entities.NHibernate.BusRouteAggregate.Sample.BusRouteServiceAreaPostalCode>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IBusRouteServiceAreaPostalCode> Entities.Common.Sample.IBusRoute.BusRouteServiceAreaPostalCodes
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _busRouteServiceAreaPostalCodes)
                    if (item.BusRoute == null)
                        item.BusRoute = this;
                // -------------------------------------------------------------

                return _busRouteServiceAreaPostalCodesCovariant;
            }
            set
            {
                BusRouteServiceAreaPostalCodes = new HashSet<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteServiceAreaPostalCode>(value.Cast<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteServiceAreaPostalCode>());
            }
        }


        private ICollection<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteStartTime> _busRouteStartTimes;
        private ICollection<Entities.Common.Sample.IBusRouteStartTime> _busRouteStartTimesCovariant;
        [RequiredCollection]
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteStartTime> BusRouteStartTimes
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _busRouteStartTimes)
                    if (item.BusRoute == null)
                        item.BusRoute = this;
                // -------------------------------------------------------------

                return _busRouteStartTimes;
            }
            set
            {
                _busRouteStartTimes = value;
                _busRouteStartTimesCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IBusRouteStartTime, Entities.NHibernate.BusRouteAggregate.Sample.BusRouteStartTime>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IBusRouteStartTime> Entities.Common.Sample.IBusRoute.BusRouteStartTimes
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _busRouteStartTimes)
                    if (item.BusRoute == null)
                        item.BusRoute = this;
                // -------------------------------------------------------------

                return _busRouteStartTimesCovariant;
            }
            set
            {
                BusRouteStartTimes = new HashSet<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteStartTime>(value.Cast<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteStartTime>());
            }
        }


        private ICollection<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteTelephone> _busRouteTelephones;
        private ICollection<Entities.Common.Sample.IBusRouteTelephone> _busRouteTelephonesCovariant;
        [RequiredCollection]
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteTelephone> BusRouteTelephones
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _busRouteTelephones)
                    if (item.BusRoute == null)
                        item.BusRoute = this;
                // -------------------------------------------------------------

                return _busRouteTelephones;
            }
            set
            {
                _busRouteTelephones = value;
                _busRouteTelephonesCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IBusRouteTelephone, Entities.NHibernate.BusRouteAggregate.Sample.BusRouteTelephone>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IBusRouteTelephone> Entities.Common.Sample.IBusRoute.BusRouteTelephones
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _busRouteTelephones)
                    if (item.BusRoute == null)
                        item.BusRoute = this;
                // -------------------------------------------------------------

                return _busRouteTelephonesCovariant;
            }
            set
            {
                BusRouteTelephones = new HashSet<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteTelephone>(value.Cast<Entities.NHibernate.BusRouteAggregate.Sample.BusRouteTelephone>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "DisabilityDescriptor", new LookupColumnDetails { PropertyName = "DisabilityDescriptorId", LookupTypeName = "DisabilityDescriptor"} },
                { "StaffClassificationDescriptor", new LookupColumnDetails { PropertyName = "StaffClassificationDescriptorId", LookupTypeName = "StaffClassificationDescriptor"} },
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
            keyValues.Add("BusId", BusId);
            keyValues.Add("BusRouteNumber", BusRouteNumber);

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
            return this.SynchronizeTo((Entities.Common.Sample.IBusRoute)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IBusRoute) target, null);
        }

    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.BusRouteBusYear table of the BusRoute aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class BusRouteBusYear : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IBusRouteBusYear, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public BusRouteBusYear()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual BusRoute BusRoute { get; set; }

        Entities.Common.Sample.IBusRoute IBusRouteBusYear.BusRoute
        {
            get { return BusRoute; }
            set { BusRoute = (BusRoute) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual short BusYear  { get; set; }
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
            var keyValues = (BusRoute as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("BusYear", BusYear);

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
            return this.SynchronizeTo((Entities.Common.Sample.IBusRouteBusYear)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IBusRouteBusYear) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            BusRoute = (BusRoute) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.BusRouteProgram table of the BusRoute aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class BusRouteProgram : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IBusRouteProgram, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public BusRouteProgram()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual BusRoute BusRoute { get; set; }

        Entities.Common.Sample.IBusRoute IBusRouteProgram.BusRoute
        {
            get { return BusRoute; }
            set { BusRoute = (BusRoute) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(60, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string ProgramName  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int ProgramTypeDescriptorId 
        {
            get
            {
                if (_programTypeDescriptorId == default(int))
                    _programTypeDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("ProgramTypeDescriptor", _programTypeDescriptor);

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
                    _programTypeDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("ProgramTypeDescriptor", _programTypeDescriptorId);
                    
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
        public virtual NHibernate.ProgramAggregate.EdFi.ProgramReferenceData ProgramReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Program discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Sample.IBusRouteProgram.ProgramDiscriminator
        {
            get { return ProgramReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Program resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.IBusRouteProgram.ProgramResourceId
        {
            get { return ProgramReferenceData?.Id; }
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
            var keyValues = (BusRoute as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
            return this.SynchronizeTo((Entities.Common.Sample.IBusRouteProgram)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IBusRouteProgram) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            BusRoute = (BusRoute) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.BusRouteServiceAreaPostalCode table of the BusRoute aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class BusRouteServiceAreaPostalCode : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IBusRouteServiceAreaPostalCode, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public BusRouteServiceAreaPostalCode()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual BusRoute BusRoute { get; set; }

        Entities.Common.Sample.IBusRoute IBusRouteServiceAreaPostalCode.BusRoute
        {
            get { return BusRoute; }
            set { BusRoute = (BusRoute) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(17, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string ServiceAreaPostalCode  { get; set; }
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
            var keyValues = (BusRoute as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("ServiceAreaPostalCode", ServiceAreaPostalCode);

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
            return this.SynchronizeTo((Entities.Common.Sample.IBusRouteServiceAreaPostalCode)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IBusRouteServiceAreaPostalCode) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            BusRoute = (BusRoute) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.BusRouteStartTime table of the BusRoute aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class BusRouteStartTime : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IBusRouteStartTime, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public BusRouteStartTime()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual BusRoute BusRoute { get; set; }

        Entities.Common.Sample.IBusRoute IBusRouteStartTime.BusRoute
        {
            get { return BusRoute; }
            set { BusRoute = (BusRoute) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual TimeSpan StartTime  { get; set; }
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
            var keyValues = (BusRoute as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("StartTime", StartTime);

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
            return this.SynchronizeTo((Entities.Common.Sample.IBusRouteStartTime)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IBusRouteStartTime) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            BusRoute = (BusRoute) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.BusRouteTelephone table of the BusRoute aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class BusRouteTelephone : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IBusRouteTelephone, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public BusRouteTelephone()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual BusRoute BusRoute { get; set; }

        Entities.Common.Sample.IBusRoute IBusRouteTelephone.BusRoute
        {
            get { return BusRoute; }
            set { BusRoute = (BusRoute) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(24, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string TelephoneNumber  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int TelephoneNumberTypeDescriptorId 
        {
            get
            {
                if (_telephoneNumberTypeDescriptorId == default(int))
                    _telephoneNumberTypeDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("TelephoneNumberTypeDescriptor", _telephoneNumberTypeDescriptor);

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
                    _telephoneNumberTypeDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("TelephoneNumberTypeDescriptor", _telephoneNumberTypeDescriptorId);
                    
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
        [Range(1, 2147483647)]
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
            var keyValues = (BusRoute as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
            return this.SynchronizeTo((Entities.Common.Sample.IBusRouteTelephone)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IBusRouteTelephone) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            BusRoute = (BusRoute) value;
        }
    }
}
// Aggregate: FavoriteBookCategoryDescriptor

namespace EdFi.Ods.Entities.NHibernate.FavoriteBookCategoryDescriptorAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.FavoriteBookCategoryDescriptor table of the FavoriteBookCategoryDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class FavoriteBookCategoryDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.Sample.IFavoriteBookCategoryDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int FavoriteBookCategoryDescriptorId 
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
            keyValues.Add("FavoriteBookCategoryDescriptorId", FavoriteBookCategoryDescriptorId);

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
            return this.SynchronizeTo((Entities.Common.Sample.IFavoriteBookCategoryDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IFavoriteBookCategoryDescriptor) target, null);
        }

    }
}
// Aggregate: MembershipTypeDescriptor

namespace EdFi.Ods.Entities.NHibernate.MembershipTypeDescriptorAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.MembershipTypeDescriptor table of the MembershipTypeDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class MembershipTypeDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.Sample.IMembershipTypeDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public virtual int MembershipTypeDescriptorId 
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
            keyValues.Add("MembershipTypeDescriptorId", MembershipTypeDescriptorId);

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
            return this.SynchronizeTo((Entities.Common.Sample.IMembershipTypeDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IMembershipTypeDescriptor) target, null);
        }

    }
}
// Aggregate: Parent

namespace EdFi.Ods.Entities.NHibernate.ParentAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.ParentAddressSchoolDistrict table of the Parent aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class ParentAddressSchoolDistrict : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IParentAddressSchoolDistrict, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentAddressSchoolDistrict()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.ParentAddress ParentAddress { get; set; }

        Entities.Common.Sample.IParentAddressExtension IParentAddressSchoolDistrict.ParentAddressExtension
        {
            get { return (IParentAddressExtension) ParentAddress.Extensions["Sample"]; }
            set { ParentAddress.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(250, MinimumLength=0), NoDangerousText, NoWhitespace]
        public virtual string SchoolDistrict  { get; set; }
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
            var keyValues = (ParentAddress as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("SchoolDistrict", SchoolDistrict);

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
            return this.SynchronizeTo((Entities.Common.Sample.IParentAddressSchoolDistrict)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IParentAddressSchoolDistrict) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            ParentAddress = (EdFi.ParentAddress) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.ParentAddressTerm table of the Parent aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class ParentAddressTerm : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IParentAddressTerm, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentAddressTerm()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.ParentAddress ParentAddress { get; set; }

        Entities.Common.Sample.IParentAddressExtension IParentAddressTerm.ParentAddressExtension
        {
            get { return (IParentAddressExtension) ParentAddress.Extensions["Sample"]; }
            set { ParentAddress.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int))
                    _termDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("TermDescriptor", _termDescriptor);

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
                    _termDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("TermDescriptor", _termDescriptorId);
                    
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
            var keyValues = (ParentAddress as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
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
            return this.SynchronizeTo((Entities.Common.Sample.IParentAddressTerm)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IParentAddressTerm) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            ParentAddress = (EdFi.ParentAddress) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.ParentAuthor table of the Parent aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class ParentAuthor : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IParentAuthor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentAuthor()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Parent Parent { get; set; }

        Entities.Common.Sample.IParentExtension IParentAuthor.ParentExtension
        {
            get { return (IParentExtension) Parent.Extensions["Sample"]; }
            set { Parent.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(100, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string Author  { get; set; }
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
            keyValues.Add("Author", Author);

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
            return this.SynchronizeTo((Entities.Common.Sample.IParentAuthor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IParentAuthor) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Parent = (EdFi.Parent) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.ParentCeilingHeight table of the Parent aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class ParentCeilingHeight : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IParentCeilingHeight, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentCeilingHeight()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Parent Parent { get; set; }

        Entities.Common.Sample.IParentExtension IParentCeilingHeight.ParentExtension
        {
            get { return (IParentExtension) Parent.Extensions["Sample"]; }
            set { Parent.Extensions["Sample"] = value; }
        }

        [DomainSignature][Range(typeof(decimal), "-9999.9", "9999.9")]
        public virtual decimal CeilingHeight  { get; set; }
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
            keyValues.Add("CeilingHeight", CeilingHeight);

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
            return this.SynchronizeTo((Entities.Common.Sample.IParentCeilingHeight)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IParentCeilingHeight) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Parent = (EdFi.Parent) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.ParentCTEProgram table of the Parent aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class ParentCTEProgram : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IParentCTEProgram, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentCTEProgram()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Parent Parent { get; set; }

        Entities.Common.Sample.IParentExtension IParentCTEProgram.ParentExtension
        {
            get { return (IParentExtension) Parent.Extensions["Sample"]; }
            set { Parent.Extensions["Sample"] = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [RequiredWithNonDefault]
        public virtual int CareerPathwayDescriptorId 
        {
            get
            {
                if (_careerPathwayDescriptorId == default(int))
                    _careerPathwayDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("CareerPathwayDescriptor", _careerPathwayDescriptor);

                return _careerPathwayDescriptorId;
            } 
            set
            {
                _careerPathwayDescriptorId = value;
                _careerPathwayDescriptor = null;
            }
        }

        private int _careerPathwayDescriptorId;
        private string _careerPathwayDescriptor;

        public virtual string CareerPathwayDescriptor
        {
            get
            {
                if (_careerPathwayDescriptor == null)
                    _careerPathwayDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("CareerPathwayDescriptor", _careerPathwayDescriptorId);
                    
                return _careerPathwayDescriptor;
            }
            set
            {
                _careerPathwayDescriptor = value;
                _careerPathwayDescriptorId = default(int);
            }
        }
        [StringLength(120, MinimumLength=1), NoDangerousText]
        public virtual string CIPCode  { get; set; }
        public virtual bool? CTEProgramCompletionIndicator  { get; set; }
        public virtual bool? PrimaryCTEProgramIndicator  { get; set; }
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
                { "CareerPathwayDescriptor", new LookupColumnDetails { PropertyName = "CareerPathwayDescriptorId", LookupTypeName = "CareerPathwayDescriptor"} },
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
            return this.SynchronizeTo((Entities.Common.Sample.IParentCTEProgram)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IParentCTEProgram) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Parent = (EdFi.Parent) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.ParentEducationContent table of the Parent aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class ParentEducationContent : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IParentEducationContent, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentEducationContent()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Parent Parent { get; set; }

        Entities.Common.Sample.IParentExtension IParentEducationContent.ParentExtension
        {
            get { return (IParentExtension) Parent.Extensions["Sample"]; }
            set { Parent.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(225, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string ContentIdentifier  { get; set; }
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
        public virtual NHibernate.EducationContentAggregate.EdFi.EducationContentReferenceData EducationContentReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the EducationContent discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Sample.IParentEducationContent.EducationContentDiscriminator
        {
            get { return EducationContentReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the EducationContent resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.IParentEducationContent.EducationContentResourceId
        {
            get { return EducationContentReferenceData?.Id; }
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
            keyValues.Add("ContentIdentifier", ContentIdentifier);

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
            return this.SynchronizeTo((Entities.Common.Sample.IParentEducationContent)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IParentEducationContent) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Parent = (EdFi.Parent) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.ParentFavoriteBookTitle table of the Parent aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class ParentFavoriteBookTitle : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IParentFavoriteBookTitle, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentFavoriteBookTitle()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Parent Parent { get; set; }

        Entities.Common.Sample.IParentExtension IParentFavoriteBookTitle.ParentExtension
        {
            get { return (IParentExtension) Parent.Extensions["Sample"]; }
            set { Parent.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(100, MinimumLength=0), NoDangerousText, NoWhitespace]
        public virtual string FavoriteBookTitle  { get; set; }
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
            keyValues.Add("FavoriteBookTitle", FavoriteBookTitle);

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
            return this.SynchronizeTo((Entities.Common.Sample.IParentFavoriteBookTitle)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IParentFavoriteBookTitle) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Parent = (EdFi.Parent) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.ParentStudentProgramAssociation table of the Parent aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class ParentStudentProgramAssociation : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IParentStudentProgramAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentStudentProgramAssociation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Parent Parent { get; set; }

        Entities.Common.Sample.IParentExtension IParentStudentProgramAssociation.ParentExtension
        {
            get { return (IParentExtension) Parent.Extensions["Sample"]; }
            set { Parent.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual DateTime BeginDate 
        {
            get { return _beginDate; }
            //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
            set { _beginDate = new DateTime(value.Year, value.Month, value.Day); }
        }

        private DateTime _beginDate;
        
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int ProgramEducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(60, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string ProgramName  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int ProgramTypeDescriptorId 
        {
            get
            {
                if (_programTypeDescriptorId == default(int))
                    _programTypeDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("ProgramTypeDescriptor", _programTypeDescriptor);

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
                    _programTypeDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("ProgramTypeDescriptor", _programTypeDescriptorId);
                    
                return _programTypeDescriptor;
            }
            set
            {
                _programTypeDescriptor = value;
                _programTypeDescriptorId = default(int);
            }
        }
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
        public virtual NHibernate.GeneralStudentProgramAssociationAggregate.EdFi.GeneralStudentProgramAssociationReferenceData StudentProgramAssociationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the StudentProgramAssociation resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.IParentStudentProgramAssociation.StudentProgramAssociationResourceId
        {
            get { return StudentProgramAssociationReferenceData?.Id; }
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
            var keyValues = (Parent as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("BeginDate", BeginDate);
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("ProgramEducationOrganizationId", ProgramEducationOrganizationId);
            keyValues.Add("ProgramName", ProgramName);
            keyValues.Add("ProgramTypeDescriptorId", ProgramTypeDescriptorId);
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
            return this.SynchronizeTo((Entities.Common.Sample.IParentStudentProgramAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IParentStudentProgramAssociation) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Parent = (EdFi.Parent) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.ParentTeacherConference table of the Parent aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class ParentTeacherConference : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IParentTeacherConference, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentTeacherConference()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Parent Parent { get; set; }

        Entities.Common.Sample.IParentExtension IParentTeacherConference.ParentExtension
        {
            get { return (IParentExtension) Parent.Extensions["Sample"]; }
            set { Parent.Extensions["Sample"] = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [RequiredWithNonDefault, StringLength(10, MinimumLength=0), NoDangerousText]
        public virtual string DayOfWeek  { get; set; }
        [RequiredWithNonDefault]
        public virtual TimeSpan EndTime  { get; set; }
        [RequiredWithNonDefault]
        public virtual TimeSpan StartTime  { get; set; }
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
            return this.SynchronizeTo((Entities.Common.Sample.IParentTeacherConference)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IParentTeacherConference) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Parent = (EdFi.Parent) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.ParentExtension table of the Parent aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class ParentExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IParentExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Parent Parent { get; set; }

        Entities.Common.EdFi.IParent IParentExtension.Parent
        {
            get { return Parent; }
            set { Parent = (EdFi.Parent) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [StringLength(30, MinimumLength=0), NoDangerousText]
        public virtual string AverageCarLineWait  { get; set; }
        public virtual short? BecameParent  { get; set; }
        [Range(typeof(decimal), "-922337203685477.5808", "922337203685477.5807")]
        public virtual decimal? CoffeeSpend  { get; set; }
        public virtual int? CredentialFieldDescriptorId 
        {
            get
            {
                if (_credentialFieldDescriptorId == default(int?))
                    _credentialFieldDescriptorId = string.IsNullOrWhiteSpace(_credentialFieldDescriptor) ? default(int?) : GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("CredentialFieldDescriptor", _credentialFieldDescriptor);

                return _credentialFieldDescriptorId;
            } 
            set
            {
                _credentialFieldDescriptorId = value;
                _credentialFieldDescriptor = null;
            }
        }

        private int? _credentialFieldDescriptorId;
        private string _credentialFieldDescriptor;

        public virtual string CredentialFieldDescriptor
        {
            get
            {
                if (_credentialFieldDescriptor == null)
                    _credentialFieldDescriptor = _credentialFieldDescriptorId == null ? null : GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("CredentialFieldDescriptor", _credentialFieldDescriptorId.Value);
                    
                return _credentialFieldDescriptor;
            }
            set
            {
                _credentialFieldDescriptor = value;
                _credentialFieldDescriptorId = default(int?);
            }
        }
        [Range(1, 2147483647)]
        public virtual int? Duration  { get; set; }
        [Range(typeof(decimal), "0", "99999999999999.9999")]
        public virtual decimal? GPA  { get; set; }
        public virtual DateTime? GraduationDate 
        {
            get { return _graduationDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _graduationDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _graduationDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _graduationDate;
        
        public virtual bool IsSportsFan  { get; set; }
        public virtual int? LuckyNumber  { get; set; }
        public virtual TimeSpan? PreferredWakeUpTime  { get; set; }
        [Range(typeof(decimal), "-9.9999", "9.9999")]
        public virtual decimal? RainCertainty  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // This property implementation exists to provide the mapper with reflection-based access to the target instance's .NET type (for creating new instances)
        public Entities.NHibernate.ParentAggregate.Sample.ParentCTEProgram ParentCTEProgram
        {
            get { return (Entities.NHibernate.ParentAggregate.Sample.ParentCTEProgram) (this as Entities.Common.Sample.IParentExtension).ParentCTEProgram;  }
            set { (this as Entities.Common.Sample.IParentExtension).ParentCTEProgram = value;  }
        }

        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        Entities.Common.Sample.IParentCTEProgram Entities.Common.Sample.IParentExtension.ParentCTEProgram
        {
            get
            {
                var list = (IList) Parent.AggregateExtensions["Sample_ParentCTEProgram"];

                if (list != null && list.Count > 0)
                    return (Entities.Common.Sample.IParentCTEProgram) list[0];

                return null;
            }
            set
            {
                // Delete the existing object
                var list = (IList) Parent.AggregateExtensions["Sample_ParentCTEProgram"] ?? new List<object>();
                list.Clear();

                // If we're setting a value, add it to the list now
                if (value != null)
                {
                    list.Add(value);

                    // Set the parent reference
                    (value as IChildEntity).SetParent(Parent);
                }
            }
        }
        // This property implementation exists to provide the mapper with reflection-based access to the target instance's .NET type (for creating new instances)
        public Entities.NHibernate.ParentAggregate.Sample.ParentTeacherConference ParentTeacherConference
        {
            get { return (Entities.NHibernate.ParentAggregate.Sample.ParentTeacherConference) (this as Entities.Common.Sample.IParentExtension).ParentTeacherConference;  }
            set { (this as Entities.Common.Sample.IParentExtension).ParentTeacherConference = value;  }
        }

        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        Entities.Common.Sample.IParentTeacherConference Entities.Common.Sample.IParentExtension.ParentTeacherConference
        {
            get
            {
                var list = (IList) Parent.AggregateExtensions["Sample_ParentTeacherConference"];

                if (list != null && list.Count > 0)
                    return (Entities.Common.Sample.IParentTeacherConference) list[0];

                return null;
            }
            set
            {
                // Delete the existing object
                var list = (IList) Parent.AggregateExtensions["Sample_ParentTeacherConference"] ?? new List<object>();
                list.Clear();

                // If we're setting a value, add it to the list now
                if (value != null)
                {
                    list.Add(value);

                    // Set the parent reference
                    (value as IChildEntity).SetParent(Parent);
                }
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
        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<Entities.Common.Sample.IParentAuthor> _parentAuthors;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IParentAuthor> IParentExtension.ParentAuthors
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, ParentAuthor>((IList<object>) Parent.AggregateExtensions["Sample_ParentAuthors"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (ParentAuthor item in sourceList)
                    if (item.Parent == null)
                        item.Parent = this.Parent;
                // -------------------------------------------------------------

                if (_parentAuthors == null)
                    _parentAuthors = new CovariantCollectionAdapter<Entities.Common.Sample.IParentAuthor, ParentAuthor>(sourceList);

                return _parentAuthors;
            }
            set
            {
                Parent.AggregateExtensions["Sample_ParentAuthors"] = value;
            }
        }
        private ICollection<Entities.Common.Sample.IParentCeilingHeight> _parentCeilingHeights;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IParentCeilingHeight> IParentExtension.ParentCeilingHeights
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, ParentCeilingHeight>((IList<object>) Parent.AggregateExtensions["Sample_ParentCeilingHeights"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (ParentCeilingHeight item in sourceList)
                    if (item.Parent == null)
                        item.Parent = this.Parent;
                // -------------------------------------------------------------

                if (_parentCeilingHeights == null)
                    _parentCeilingHeights = new CovariantCollectionAdapter<Entities.Common.Sample.IParentCeilingHeight, ParentCeilingHeight>(sourceList);

                return _parentCeilingHeights;
            }
            set
            {
                Parent.AggregateExtensions["Sample_ParentCeilingHeights"] = value;
            }
        }
        private ICollection<Entities.Common.Sample.IParentEducationContent> _parentEducationContents;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IParentEducationContent> IParentExtension.ParentEducationContents
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, ParentEducationContent>((IList<object>) Parent.AggregateExtensions["Sample_ParentEducationContents"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (ParentEducationContent item in sourceList)
                    if (item.Parent == null)
                        item.Parent = this.Parent;
                // -------------------------------------------------------------

                if (_parentEducationContents == null)
                    _parentEducationContents = new CovariantCollectionAdapter<Entities.Common.Sample.IParentEducationContent, ParentEducationContent>(sourceList);

                return _parentEducationContents;
            }
            set
            {
                Parent.AggregateExtensions["Sample_ParentEducationContents"] = value;
            }
        }
        [RequiredCollection]
        private ICollection<Entities.Common.Sample.IParentFavoriteBookTitle> _parentFavoriteBookTitles;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IParentFavoriteBookTitle> IParentExtension.ParentFavoriteBookTitles
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, ParentFavoriteBookTitle>((IList<object>) Parent.AggregateExtensions["Sample_ParentFavoriteBookTitles"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (ParentFavoriteBookTitle item in sourceList)
                    if (item.Parent == null)
                        item.Parent = this.Parent;
                // -------------------------------------------------------------

                if (_parentFavoriteBookTitles == null)
                    _parentFavoriteBookTitles = new CovariantCollectionAdapter<Entities.Common.Sample.IParentFavoriteBookTitle, ParentFavoriteBookTitle>(sourceList);

                return _parentFavoriteBookTitles;
            }
            set
            {
                Parent.AggregateExtensions["Sample_ParentFavoriteBookTitles"] = value;
            }
        }
        private ICollection<Entities.Common.Sample.IParentStudentProgramAssociation> _parentStudentProgramAssociations;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IParentStudentProgramAssociation> IParentExtension.ParentStudentProgramAssociations
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, ParentStudentProgramAssociation>((IList<object>) Parent.AggregateExtensions["Sample_ParentStudentProgramAssociations"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (ParentStudentProgramAssociation item in sourceList)
                    if (item.Parent == null)
                        item.Parent = this.Parent;
                // -------------------------------------------------------------

                if (_parentStudentProgramAssociations == null)
                    _parentStudentProgramAssociations = new CovariantCollectionAdapter<Entities.Common.Sample.IParentStudentProgramAssociation, ParentStudentProgramAssociation>(sourceList);

                return _parentStudentProgramAssociations;
            }
            set
            {
                Parent.AggregateExtensions["Sample_ParentStudentProgramAssociations"] = value;
            }
        }
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "CredentialFieldDescriptor", new LookupColumnDetails { PropertyName = "CredentialFieldDescriptorId", LookupTypeName = "CredentialFieldDescriptor"} },
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
            return this.SynchronizeTo((Entities.Common.Sample.IParentExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IParentExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Parent = (EdFi.Parent) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.ParentAddressExtension table of the Parent aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class ParentAddressExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IParentAddressExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ParentAddressExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.ParentAddress ParentAddress { get; set; }

        Entities.Common.EdFi.IParentAddress IParentAddressExtension.ParentAddress
        {
            get { return ParentAddress; }
            set { ParentAddress = (EdFi.ParentAddress) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [StringLength(255, MinimumLength=1), NoDangerousText]
        public virtual string Complex  { get; set; }
        public virtual bool OnBusRoute  { get; set; }
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
        [RequiredCollection]
        private ICollection<Entities.Common.Sample.IParentAddressSchoolDistrict> _parentAddressSchoolDistricts;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IParentAddressSchoolDistrict> IParentAddressExtension.ParentAddressSchoolDistricts
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, ParentAddressSchoolDistrict>((IList<object>) ParentAddress.AggregateExtensions["Sample_ParentAddressSchoolDistricts"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (ParentAddressSchoolDistrict item in sourceList)
                    if (item.ParentAddress == null)
                        item.ParentAddress = this.ParentAddress;
                // -------------------------------------------------------------

                if (_parentAddressSchoolDistricts == null)
                    _parentAddressSchoolDistricts = new CovariantCollectionAdapter<Entities.Common.Sample.IParentAddressSchoolDistrict, ParentAddressSchoolDistrict>(sourceList);

                return _parentAddressSchoolDistricts;
            }
            set
            {
                ParentAddress.AggregateExtensions["Sample_ParentAddressSchoolDistricts"] = value;
            }
        }
        private ICollection<Entities.Common.Sample.IParentAddressTerm> _parentAddressTerms;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IParentAddressTerm> IParentAddressExtension.ParentAddressTerms
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, ParentAddressTerm>((IList<object>) ParentAddress.AggregateExtensions["Sample_ParentAddressTerms"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (ParentAddressTerm item in sourceList)
                    if (item.ParentAddress == null)
                        item.ParentAddress = this.ParentAddress;
                // -------------------------------------------------------------

                if (_parentAddressTerms == null)
                    _parentAddressTerms = new CovariantCollectionAdapter<Entities.Common.Sample.IParentAddressTerm, ParentAddressTerm>(sourceList);

                return _parentAddressTerms;
            }
            set
            {
                ParentAddress.AggregateExtensions["Sample_ParentAddressTerms"] = value;
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
            // Get parent key values
            var keyValues = (ParentAddress as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
            return this.SynchronizeTo((Entities.Common.Sample.IParentAddressExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IParentAddressExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            ParentAddress = (EdFi.ParentAddress) value;
        }
    }
}
// Aggregate: School

namespace EdFi.Ods.Entities.NHibernate.SchoolAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.SchoolCTEProgram table of the School aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class SchoolCTEProgram : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.ISchoolCTEProgram, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public SchoolCTEProgram()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.School School { get; set; }

        Entities.Common.Sample.ISchoolExtension ISchoolCTEProgram.SchoolExtension
        {
            get { return (ISchoolExtension) School.Extensions["Sample"]; }
            set { School.Extensions["Sample"] = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [RequiredWithNonDefault]
        public virtual int CareerPathwayDescriptorId 
        {
            get
            {
                if (_careerPathwayDescriptorId == default(int))
                    _careerPathwayDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("CareerPathwayDescriptor", _careerPathwayDescriptor);

                return _careerPathwayDescriptorId;
            } 
            set
            {
                _careerPathwayDescriptorId = value;
                _careerPathwayDescriptor = null;
            }
        }

        private int _careerPathwayDescriptorId;
        private string _careerPathwayDescriptor;

        public virtual string CareerPathwayDescriptor
        {
            get
            {
                if (_careerPathwayDescriptor == null)
                    _careerPathwayDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("CareerPathwayDescriptor", _careerPathwayDescriptorId);
                    
                return _careerPathwayDescriptor;
            }
            set
            {
                _careerPathwayDescriptor = value;
                _careerPathwayDescriptorId = default(int);
            }
        }
        [StringLength(120, MinimumLength=1), NoDangerousText]
        public virtual string CIPCode  { get; set; }
        public virtual bool? CTEProgramCompletionIndicator  { get; set; }
        public virtual bool? PrimaryCTEProgramIndicator  { get; set; }
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
                { "CareerPathwayDescriptor", new LookupColumnDetails { PropertyName = "CareerPathwayDescriptorId", LookupTypeName = "CareerPathwayDescriptor"} },
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
            return this.SynchronizeTo((Entities.Common.Sample.ISchoolCTEProgram)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.ISchoolCTEProgram) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            School = (EdFi.School) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.SchoolDirectlyOwnedBus table of the School aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class SchoolDirectlyOwnedBus : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.ISchoolDirectlyOwnedBus, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public SchoolDirectlyOwnedBus()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.School School { get; set; }

        Entities.Common.Sample.ISchoolExtension ISchoolDirectlyOwnedBus.SchoolExtension
        {
            get { return (ISchoolExtension) School.Extensions["Sample"]; }
            set { School.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(60, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string DirectlyOwnedBusId  { get; set; }
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
        public virtual NHibernate.BusAggregate.Sample.BusReferenceData DirectlyOwnedBusReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the DirectlyOwnedBus discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusDiscriminator
        {
            get { return DirectlyOwnedBusReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the DirectlyOwnedBus resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusResourceId
        {
            get { return DirectlyOwnedBusReferenceData?.Id; }
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
            keyValues.Add("DirectlyOwnedBusId", DirectlyOwnedBusId);

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
            return this.SynchronizeTo((Entities.Common.Sample.ISchoolDirectlyOwnedBus)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.ISchoolDirectlyOwnedBus) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            School = (EdFi.School) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.SchoolExtension table of the School aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class SchoolExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.ISchoolExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
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
        public virtual bool? IsExemplary  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // This property implementation exists to provide the mapper with reflection-based access to the target instance's .NET type (for creating new instances)
        public Entities.NHibernate.SchoolAggregate.Sample.SchoolCTEProgram SchoolCTEProgram
        {
            get { return (Entities.NHibernate.SchoolAggregate.Sample.SchoolCTEProgram) (this as Entities.Common.Sample.ISchoolExtension).SchoolCTEProgram;  }
            set { (this as Entities.Common.Sample.ISchoolExtension).SchoolCTEProgram = value;  }
        }

        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        Entities.Common.Sample.ISchoolCTEProgram Entities.Common.Sample.ISchoolExtension.SchoolCTEProgram
        {
            get
            {
                var list = (IList) School.AggregateExtensions["Sample_SchoolCTEProgram"];

                if (list != null && list.Count > 0)
                    return (Entities.Common.Sample.ISchoolCTEProgram) list[0];

                return null;
            }
            set
            {
                // Delete the existing object
                var list = (IList) School.AggregateExtensions["Sample_SchoolCTEProgram"] ?? new List<object>();
                list.Clear();

                // If we're setting a value, add it to the list now
                if (value != null)
                {
                    list.Add(value);

                    // Set the parent reference
                    (value as IChildEntity).SetParent(School);
                }
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
        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<Entities.Common.Sample.ISchoolDirectlyOwnedBus> _schoolDirectlyOwnedBuses;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.ISchoolDirectlyOwnedBus> ISchoolExtension.SchoolDirectlyOwnedBuses
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, SchoolDirectlyOwnedBus>((IList<object>) School.AggregateExtensions["Sample_SchoolDirectlyOwnedBuses"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (SchoolDirectlyOwnedBus item in sourceList)
                    if (item.School == null)
                        item.School = this.School;
                // -------------------------------------------------------------

                if (_schoolDirectlyOwnedBuses == null)
                    _schoolDirectlyOwnedBuses = new CovariantCollectionAdapter<Entities.Common.Sample.ISchoolDirectlyOwnedBus, SchoolDirectlyOwnedBus>(sourceList);

                return _schoolDirectlyOwnedBuses;
            }
            set
            {
                School.AggregateExtensions["Sample_SchoolDirectlyOwnedBuses"] = value;
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
            return this.SynchronizeTo((Entities.Common.Sample.ISchoolExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.ISchoolExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            School = (EdFi.School) value;
        }
    }
}
// Aggregate: Staff

namespace EdFi.Ods.Entities.NHibernate.StaffAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StaffPet table of the Staff aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StaffPet : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStaffPet, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StaffPet()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Staff Staff { get; set; }

        Entities.Common.Sample.IStaffExtension IStaffPet.StaffExtension
        {
            get { return (IStaffExtension) Staff.Extensions["Sample"]; }
            set { Staff.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(20, MinimumLength=3), NoDangerousText, NoWhitespace]
        public virtual string PetName  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual bool? IsFixed  { get; set; }
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
            keyValues.Add("PetName", PetName);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStaffPet)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStaffPet) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Staff = (EdFi.Staff) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StaffPetPreference table of the Staff aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StaffPetPreference : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStaffPetPreference, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StaffPetPreference()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Staff Staff { get; set; }

        Entities.Common.Sample.IStaffExtension IStaffPetPreference.StaffExtension
        {
            get { return (IStaffExtension) Staff.Extensions["Sample"]; }
            set { Staff.Extensions["Sample"] = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int MaximumWeight  { get; set; }
        public virtual int MinimumWeight  { get; set; }
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
            return this.SynchronizeTo((Entities.Common.Sample.IStaffPetPreference)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStaffPetPreference) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Staff = (EdFi.Staff) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StaffExtension table of the Staff aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StaffExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStaffExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
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

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual DateTime? FirstPetOwnedDate 
        {
            get { return _firstPetOwnedDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _firstPetOwnedDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _firstPetOwnedDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _firstPetOwnedDate;
        
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // This property implementation exists to provide the mapper with reflection-based access to the target instance's .NET type (for creating new instances)
        public Entities.NHibernate.StaffAggregate.Sample.StaffPetPreference StaffPetPreference
        {
            get { return (Entities.NHibernate.StaffAggregate.Sample.StaffPetPreference) (this as Entities.Common.Sample.IStaffExtension).StaffPetPreference;  }
            set { (this as Entities.Common.Sample.IStaffExtension).StaffPetPreference = value;  }
        }

        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        Entities.Common.Sample.IStaffPetPreference Entities.Common.Sample.IStaffExtension.StaffPetPreference
        {
            get
            {
                var list = (IList) Staff.AggregateExtensions["Sample_StaffPetPreference"];

                if (list != null && list.Count > 0)
                    return (Entities.Common.Sample.IStaffPetPreference) list[0];

                return null;
            }
            set
            {
                // Delete the existing object
                var list = (IList) Staff.AggregateExtensions["Sample_StaffPetPreference"] ?? new List<object>();
                list.Clear();

                // If we're setting a value, add it to the list now
                if (value != null)
                {
                    list.Add(value);

                    // Set the parent reference
                    (value as IChildEntity).SetParent(Staff);
                }
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
        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<Entities.Common.Sample.IStaffPet> _staffPets;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IStaffPet> IStaffExtension.StaffPets
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StaffPet>((IList<object>) Staff.AggregateExtensions["Sample_StaffPets"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StaffPet item in sourceList)
                    if (item.Staff == null)
                        item.Staff = this.Staff;
                // -------------------------------------------------------------

                if (_staffPets == null)
                    _staffPets = new CovariantCollectionAdapter<Entities.Common.Sample.IStaffPet, StaffPet>(sourceList);

                return _staffPets;
            }
            set
            {
                Staff.AggregateExtensions["Sample_StaffPets"] = value;
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
            return this.SynchronizeTo((Entities.Common.Sample.IStaffExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStaffExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Staff = (EdFi.Staff) value;
        }
    }
}
// Aggregate: Student

namespace EdFi.Ods.Entities.NHibernate.StudentAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentAquaticPet table of the Student aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentAquaticPet : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentAquaticPet, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentAquaticPet()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Student Student { get; set; }

        Entities.Common.Sample.IStudentExtension IStudentAquaticPet.StudentExtension
        {
            get { return (IStudentExtension) Student.Extensions["Sample"]; }
            set { Student.Extensions["Sample"] = value; }
        }

        [DomainSignature]
        public virtual int MimimumTankVolume  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(20, MinimumLength=3), NoDangerousText, NoWhitespace]
        public virtual string PetName  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual bool? IsFixed  { get; set; }
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
            keyValues.Add("MimimumTankVolume", MimimumTankVolume);
            keyValues.Add("PetName", PetName);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentAquaticPet)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentAquaticPet) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Student = (EdFi.Student) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentFavoriteBook table of the Student aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentFavoriteBook : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentFavoriteBook, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentFavoriteBook()
        {
            StudentFavoriteBookArtMedia = new HashSet<StudentFavoriteBookArtMedium>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Student Student { get; set; }

        Entities.Common.Sample.IStudentExtension IStudentFavoriteBook.StudentExtension
        {
            get { return (IStudentExtension) Student.Extensions["Sample"]; }
            set { Student.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int FavoriteBookCategoryDescriptorId 
        {
            get
            {
                if (_favoriteBookCategoryDescriptorId == default(int))
                    _favoriteBookCategoryDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("FavoriteBookCategoryDescriptor", _favoriteBookCategoryDescriptor);

                return _favoriteBookCategoryDescriptorId;
            } 
            set
            {
                _favoriteBookCategoryDescriptorId = value;
                _favoriteBookCategoryDescriptor = null;
            }
        }

        private int _favoriteBookCategoryDescriptorId;
        private string _favoriteBookCategoryDescriptor;

        public virtual string FavoriteBookCategoryDescriptor
        {
            get
            {
                if (_favoriteBookCategoryDescriptor == null)
                    _favoriteBookCategoryDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("FavoriteBookCategoryDescriptor", _favoriteBookCategoryDescriptorId);
                    
                return _favoriteBookCategoryDescriptor;
            }
            set
            {
                _favoriteBookCategoryDescriptor = value;
                _favoriteBookCategoryDescriptorId = default(int);
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
        [StringLength(200, MinimumLength=1), NoDangerousText]
        public virtual string BookTitle  { get; set; }
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

        private ICollection<Entities.NHibernate.StudentAggregate.Sample.StudentFavoriteBookArtMedium> _studentFavoriteBookArtMedia;
        private ICollection<Entities.Common.Sample.IStudentFavoriteBookArtMedium> _studentFavoriteBookArtMediaCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StudentAggregate.Sample.StudentFavoriteBookArtMedium> StudentFavoriteBookArtMedia
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentFavoriteBookArtMedia)
                    if (item.StudentFavoriteBook == null)
                        item.StudentFavoriteBook = this;
                // -------------------------------------------------------------

                return _studentFavoriteBookArtMedia;
            }
            set
            {
                _studentFavoriteBookArtMedia = value;
                _studentFavoriteBookArtMediaCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentFavoriteBookArtMedium, Entities.NHibernate.StudentAggregate.Sample.StudentFavoriteBookArtMedium>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentFavoriteBookArtMedium> Entities.Common.Sample.IStudentFavoriteBook.StudentFavoriteBookArtMedia
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentFavoriteBookArtMedia)
                    if (item.StudentFavoriteBook == null)
                        item.StudentFavoriteBook = this;
                // -------------------------------------------------------------

                return _studentFavoriteBookArtMediaCovariant;
            }
            set
            {
                StudentFavoriteBookArtMedia = new HashSet<Entities.NHibernate.StudentAggregate.Sample.StudentFavoriteBookArtMedium>(value.Cast<Entities.NHibernate.StudentAggregate.Sample.StudentFavoriteBookArtMedium>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "FavoriteBookCategoryDescriptor", new LookupColumnDetails { PropertyName = "FavoriteBookCategoryDescriptorId", LookupTypeName = "FavoriteBookCategoryDescriptor"} },
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
            keyValues.Add("FavoriteBookCategoryDescriptorId", FavoriteBookCategoryDescriptorId);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentFavoriteBook)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentFavoriteBook) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Student = (EdFi.Student) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentFavoriteBookArtMedium table of the Student aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentFavoriteBookArtMedium : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentFavoriteBookArtMedium, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentFavoriteBookArtMedium()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentFavoriteBook StudentFavoriteBook { get; set; }

        Entities.Common.Sample.IStudentFavoriteBook IStudentFavoriteBookArtMedium.StudentFavoriteBook
        {
            get { return StudentFavoriteBook; }
            set { StudentFavoriteBook = (StudentFavoriteBook) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int ArtMediumDescriptorId 
        {
            get
            {
                if (_artMediumDescriptorId == default(int))
                    _artMediumDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("ArtMediumDescriptor", _artMediumDescriptor);

                return _artMediumDescriptorId;
            } 
            set
            {
                _artMediumDescriptorId = value;
                _artMediumDescriptor = null;
            }
        }

        private int _artMediumDescriptorId;
        private string _artMediumDescriptor;

        public virtual string ArtMediumDescriptor
        {
            get
            {
                if (_artMediumDescriptor == null)
                    _artMediumDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("ArtMediumDescriptor", _artMediumDescriptorId);
                    
                return _artMediumDescriptor;
            }
            set
            {
                _artMediumDescriptor = value;
                _artMediumDescriptorId = default(int);
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
        [Range(0, 100)]
        public virtual int? ArtPieces  { get; set; }
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
                { "ArtMediumDescriptor", new LookupColumnDetails { PropertyName = "ArtMediumDescriptorId", LookupTypeName = "ArtMediumDescriptor"} },
                { "FavoriteBookCategoryDescriptor", new LookupColumnDetails { PropertyName = "FavoriteBookCategoryDescriptorId", LookupTypeName = "FavoriteBookCategoryDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentFavoriteBook as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("ArtMediumDescriptorId", ArtMediumDescriptorId);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentFavoriteBookArtMedium)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentFavoriteBookArtMedium) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentFavoriteBook = (StudentFavoriteBook) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentPet table of the Student aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentPet : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentPet, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentPet()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Student Student { get; set; }

        Entities.Common.Sample.IStudentExtension IStudentPet.StudentExtension
        {
            get { return (IStudentExtension) Student.Extensions["Sample"]; }
            set { Student.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(20, MinimumLength=3), NoDangerousText, NoWhitespace]
        public virtual string PetName  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual bool? IsFixed  { get; set; }
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
            keyValues.Add("PetName", PetName);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentPet)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentPet) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Student = (EdFi.Student) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentPetPreference table of the Student aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentPetPreference : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentPetPreference, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentPetPreference()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Student Student { get; set; }

        Entities.Common.Sample.IStudentExtension IStudentPetPreference.StudentExtension
        {
            get { return (IStudentExtension) Student.Extensions["Sample"]; }
            set { Student.Extensions["Sample"] = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int MaximumWeight  { get; set; }
        public virtual int MinimumWeight  { get; set; }
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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentPetPreference)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentPetPreference) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Student = (EdFi.Student) value;
        }
    }

    /// <summary>
    /// An implicitly created entity extension class to enable entity mapping and sychronization behavior for the Student entity's aggregate extensions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentExtension : IStudentExtension, IChildEntity, IImplicitEntityExtension, IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private EdFi.Student _student;

        Common.EdFi.IStudent IStudentExtension.Student
        {
            get { return _student; }
            set { _student = (EdFi.Student) value; }
        }

        private EdFi.Student Student
        {
            get { return (this as IStudentExtension).Student as EdFi.Student; }
        }

        bool IImplicitEntityExtension.IsEmpty()
        {
            return (true
                && StudentPetPreference == null
                && ((IList<object>) _student.AggregateExtensions["Sample_StudentAquaticPets"]).Count == 0
                && ((IList<object>) _student.AggregateExtensions["Sample_StudentFavoriteBooks"]).Count == 0
                && ((IList<object>) _student.AggregateExtensions["Sample_StudentPets"]).Count == 0
            );
        }

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // This property implementation exists to provide the mapper with reflection-based access to the target instance's .NET type (for creating new instances)
        public StudentPetPreference StudentPetPreference
        {
            get { return (StudentPetPreference) (this as IStudentExtension).StudentPetPreference;  }
            set { (this as IStudentExtension).StudentPetPreference = value;  }
        }

        IStudentPetPreference IStudentExtension.StudentPetPreference
        {
            get
            {
                var list = (IList) _student.AggregateExtensions["Sample_StudentPetPreference"];

                if (list != null && list.Count > 0)
                    return (IStudentPetPreference) list[0];

                return null;
            }
            set
            {
                // Delete the existing object
                var list = (IList) _student.AggregateExtensions["Sample_StudentPetPreference"];
                list.Clear();

                // If we're setting a value, add it to the list now
                if (value != null)
                {
                    list.Add(value);

                    // Set the parent reference
                    (value as IChildEntity).SetParent(_student);
                }
            }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        ICollection<IStudentAquaticPet> IStudentExtension.StudentAquaticPets
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StudentAquaticPet>((IList<object>) _student.AggregateExtensions["Sample_StudentAquaticPets"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StudentAquaticPet item in sourceList)
                    if (item.Student == null)
                        item.Student = this.Student;
                // -------------------------------------------------------------

                var adaptedList = new CovariantCollectionAdapter<IStudentAquaticPet, StudentAquaticPet>(sourceList);

                return adaptedList;
            }
            set
            {
                _student.AggregateExtensions["Sample_StudentAquaticPets"] = value;
            }
        }
        ICollection<IStudentFavoriteBook> IStudentExtension.StudentFavoriteBooks
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StudentFavoriteBook>((IList<object>) _student.AggregateExtensions["Sample_StudentFavoriteBooks"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StudentFavoriteBook item in sourceList)
                    if (item.Student == null)
                        item.Student = this.Student;
                // -------------------------------------------------------------

                var adaptedList = new CovariantCollectionAdapter<IStudentFavoriteBook, StudentFavoriteBook>(sourceList);

                return adaptedList;
            }
            set
            {
                _student.AggregateExtensions["Sample_StudentFavoriteBooks"] = value;
            }
        }
        ICollection<IStudentPet> IStudentExtension.StudentPets
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StudentPet>((IList<object>) _student.AggregateExtensions["Sample_StudentPets"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StudentPet item in sourceList)
                    if (item.Student == null)
                        item.Student = this.Student;
                // -------------------------------------------------------------

                var adaptedList = new CovariantCollectionAdapter<IStudentPet, StudentPet>(sourceList);

                return adaptedList;
            }
            set
            {
                _student.AggregateExtensions["Sample_StudentPets"] = value;
            }
        }
        // -------------------------------------------------------------

        void IMappable.Map(object target)
        {
            this.MapTo((IStudentExtension) target, null);
        }

        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((IStudentExtension) target);
        }

        void IChildEntity.SetParent(object value)
        {
            _student = (EdFi.Student)value;
        }

        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            return (_student as IHasPrimaryKeyValues).GetPrimaryKeyValues();
        }

        void IGetByExample.SuspendReferenceAssignmentCheck() { }
    }
}
// Aggregate: StudentArtProgramAssociation

namespace EdFi.Ods.Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentArtProgramAssociation table of the StudentArtProgramAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociation : GeneralStudentProgramAssociationAggregate.EdFi.GeneralStudentProgramAssociation,
        Entities.Common.Sample.IStudentArtProgramAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public StudentArtProgramAssociation()
        {
            StudentArtProgramAssociationArtMedia = new HashSet<StudentArtProgramAssociationArtMedium>();
            StudentArtProgramAssociationPortfolioYears = new HashSet<StudentArtProgramAssociationPortfolioYears>();
            StudentArtProgramAssociationServices = new HashSet<StudentArtProgramAssociationService>();
            StudentArtProgramAssociationStyles = new HashSet<StudentArtProgramAssociationStyle>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public override DateTime BeginDate  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public override int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public override int ProgramEducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(60, MinimumLength=1), NoDangerousText, NoWhitespace]
        public override string ProgramName  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public override int ProgramTypeDescriptorId 
        {
            get
            {
                if (_programTypeDescriptorId == default(int))
                    _programTypeDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("ProgramTypeDescriptor", _programTypeDescriptor);

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

        public override string ProgramTypeDescriptor
        {
            get
            {
                if (_programTypeDescriptor == null)
                    _programTypeDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("ProgramTypeDescriptor", _programTypeDescriptorId);
                    
                return _programTypeDescriptor;
            }
            set
            {
                _programTypeDescriptor = value;
                _programTypeDescriptorId = default(int);
            }
        }
        [Display(Name="StudentUniqueId")]
        [DomainSignature, RequiredWithNonDefault("Student")]
        public override int StudentUSI 
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
        public override string StudentUniqueId
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
        DateTime? IGeneralStudentProgramAssociation.EndDate
        {
            get { return EndDate; }
            set { EndDate = value; }
        }
        string IGeneralStudentProgramAssociation.ReasonExitedDescriptor
        {
            get { return ReasonExitedDescriptor; }
            set { ReasonExitedDescriptor = value; }
        }
        bool? IGeneralStudentProgramAssociation.ServedOutsideOfRegularSession
        {
            get { return ServedOutsideOfRegularSession; }
            set { ServedOutsideOfRegularSession = value; }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [Range(0, 100)]
        public virtual int? ArtPieces  { get; set; }
        public virtual DateTime? ExhibitDate 
        {
            get { return _exhibitDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _exhibitDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _exhibitDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _exhibitDate;
        
        [Range(typeof(decimal), "-999.99", "999.99")]
        public virtual decimal? HoursPerDay  { get; set; }
        [StringLength(60, MinimumLength=1), NoDangerousText]
        public virtual string IdentificationCode  { get; set; }
        public virtual TimeSpan? KilnReservation  { get; set; }
        [StringLength(30, MinimumLength=0), NoDangerousText]
        public virtual string KilnReservationLength  { get; set; }
        [Range(typeof(decimal), "-9.9999", "9.9999")]
        public virtual decimal? MasteredMediums  { get; set; }
        [Range(typeof(decimal), "0", "99999999999999.9999")]
        public virtual decimal? NumberOfDaysInAttendance  { get; set; }
        [Range(0, 100)]
        public virtual int? PortfolioPieces  { get; set; }
        public virtual bool PrivateArtProgram  { get; set; }
        [Range(typeof(decimal), "-922337203685477.5808", "922337203685477.5807")]
        public virtual decimal? ProgramFees  { get; set; }
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

        private ICollection<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationArtMedium> _studentArtProgramAssociationArtMedia;
        private ICollection<Entities.Common.Sample.IStudentArtProgramAssociationArtMedium> _studentArtProgramAssociationArtMediaCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationArtMedium> StudentArtProgramAssociationArtMedia
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentArtProgramAssociationArtMedia)
                    if (item.StudentArtProgramAssociation == null)
                        item.StudentArtProgramAssociation = this;
                // -------------------------------------------------------------

                return _studentArtProgramAssociationArtMedia;
            }
            set
            {
                _studentArtProgramAssociationArtMedia = value;
                _studentArtProgramAssociationArtMediaCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentArtProgramAssociationArtMedium, Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationArtMedium>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentArtProgramAssociationArtMedium> Entities.Common.Sample.IStudentArtProgramAssociation.StudentArtProgramAssociationArtMedia
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentArtProgramAssociationArtMedia)
                    if (item.StudentArtProgramAssociation == null)
                        item.StudentArtProgramAssociation = this;
                // -------------------------------------------------------------

                return _studentArtProgramAssociationArtMediaCovariant;
            }
            set
            {
                StudentArtProgramAssociationArtMedia = new HashSet<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationArtMedium>(value.Cast<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationArtMedium>());
            }
        }


        private ICollection<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationPortfolioYears> _studentArtProgramAssociationPortfolioYears;
        private ICollection<Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears> _studentArtProgramAssociationPortfolioYearsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationPortfolioYears> StudentArtProgramAssociationPortfolioYears
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentArtProgramAssociationPortfolioYears)
                    if (item.StudentArtProgramAssociation == null)
                        item.StudentArtProgramAssociation = this;
                // -------------------------------------------------------------

                return _studentArtProgramAssociationPortfolioYears;
            }
            set
            {
                _studentArtProgramAssociationPortfolioYears = value;
                _studentArtProgramAssociationPortfolioYearsCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears, Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationPortfolioYears>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears> Entities.Common.Sample.IStudentArtProgramAssociation.StudentArtProgramAssociationPortfolioYears
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentArtProgramAssociationPortfolioYears)
                    if (item.StudentArtProgramAssociation == null)
                        item.StudentArtProgramAssociation = this;
                // -------------------------------------------------------------

                return _studentArtProgramAssociationPortfolioYearsCovariant;
            }
            set
            {
                StudentArtProgramAssociationPortfolioYears = new HashSet<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationPortfolioYears>(value.Cast<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationPortfolioYears>());
            }
        }


        private ICollection<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationService> _studentArtProgramAssociationServices;
        private ICollection<Entities.Common.Sample.IStudentArtProgramAssociationService> _studentArtProgramAssociationServicesCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationService> StudentArtProgramAssociationServices
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentArtProgramAssociationServices)
                    if (item.StudentArtProgramAssociation == null)
                        item.StudentArtProgramAssociation = this;
                // -------------------------------------------------------------

                return _studentArtProgramAssociationServices;
            }
            set
            {
                _studentArtProgramAssociationServices = value;
                _studentArtProgramAssociationServicesCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentArtProgramAssociationService, Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationService>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentArtProgramAssociationService> Entities.Common.Sample.IStudentArtProgramAssociation.StudentArtProgramAssociationServices
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentArtProgramAssociationServices)
                    if (item.StudentArtProgramAssociation == null)
                        item.StudentArtProgramAssociation = this;
                // -------------------------------------------------------------

                return _studentArtProgramAssociationServicesCovariant;
            }
            set
            {
                StudentArtProgramAssociationServices = new HashSet<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationService>(value.Cast<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationService>());
            }
        }


        private ICollection<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationStyle> _studentArtProgramAssociationStyles;
        private ICollection<Entities.Common.Sample.IStudentArtProgramAssociationStyle> _studentArtProgramAssociationStylesCovariant;
        [RequiredCollection]
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationStyle> StudentArtProgramAssociationStyles
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentArtProgramAssociationStyles)
                    if (item.StudentArtProgramAssociation == null)
                        item.StudentArtProgramAssociation = this;
                // -------------------------------------------------------------

                return _studentArtProgramAssociationStyles;
            }
            set
            {
                _studentArtProgramAssociationStyles = value;
                _studentArtProgramAssociationStylesCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentArtProgramAssociationStyle, Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationStyle>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentArtProgramAssociationStyle> Entities.Common.Sample.IStudentArtProgramAssociation.StudentArtProgramAssociationStyles
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentArtProgramAssociationStyles)
                    if (item.StudentArtProgramAssociation == null)
                        item.StudentArtProgramAssociation = this;
                // -------------------------------------------------------------

                return _studentArtProgramAssociationStylesCovariant;
            }
            set
            {
                StudentArtProgramAssociationStyles = new HashSet<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationStyle>(value.Cast<Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociationStyle>());
            }
        }

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
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("BeginDate", BeginDate);
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("ProgramEducationOrganizationId", ProgramEducationOrganizationId);
            keyValues.Add("ProgramName", ProgramName);
            keyValues.Add("ProgramTypeDescriptorId", ProgramTypeDescriptorId);
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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentArtProgramAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapDerivedTo((Entities.Common.Sample.IStudentArtProgramAssociation) target, null);
        }

    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentArtProgramAssociationArtMedium table of the StudentArtProgramAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationArtMedium : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentArtProgramAssociationArtMedium, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentArtProgramAssociationArtMedium()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentArtProgramAssociation StudentArtProgramAssociation { get; set; }

        Entities.Common.Sample.IStudentArtProgramAssociation IStudentArtProgramAssociationArtMedium.StudentArtProgramAssociation
        {
            get { return StudentArtProgramAssociation; }
            set { StudentArtProgramAssociation = (StudentArtProgramAssociation) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int ArtMediumDescriptorId 
        {
            get
            {
                if (_artMediumDescriptorId == default(int))
                    _artMediumDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("ArtMediumDescriptor", _artMediumDescriptor);

                return _artMediumDescriptorId;
            } 
            set
            {
                _artMediumDescriptorId = value;
                _artMediumDescriptor = null;
            }
        }

        private int _artMediumDescriptorId;
        private string _artMediumDescriptor;

        public virtual string ArtMediumDescriptor
        {
            get
            {
                if (_artMediumDescriptor == null)
                    _artMediumDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("ArtMediumDescriptor", _artMediumDescriptorId);
                    
                return _artMediumDescriptor;
            }
            set
            {
                _artMediumDescriptor = value;
                _artMediumDescriptorId = default(int);
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
                { "ArtMediumDescriptor", new LookupColumnDetails { PropertyName = "ArtMediumDescriptorId", LookupTypeName = "ArtMediumDescriptor"} },
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
            var keyValues = (StudentArtProgramAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("ArtMediumDescriptorId", ArtMediumDescriptorId);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentArtProgramAssociationArtMedium)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentArtProgramAssociationArtMedium) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentArtProgramAssociation = (StudentArtProgramAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentArtProgramAssociationPortfolioYears table of the StudentArtProgramAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationPortfolioYears : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentArtProgramAssociationPortfolioYears()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentArtProgramAssociation StudentArtProgramAssociation { get; set; }

        Entities.Common.Sample.IStudentArtProgramAssociation IStudentArtProgramAssociationPortfolioYears.StudentArtProgramAssociation
        {
            get { return StudentArtProgramAssociation; }
            set { StudentArtProgramAssociation = (StudentArtProgramAssociation) value; }
        }

        [DomainSignature]
        public virtual short PortfolioYears  { get; set; }
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
            var keyValues = (StudentArtProgramAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("PortfolioYears", PortfolioYears);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentArtProgramAssociation = (StudentArtProgramAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentArtProgramAssociationService table of the StudentArtProgramAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationService : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentArtProgramAssociationService, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentArtProgramAssociationService()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentArtProgramAssociation StudentArtProgramAssociation { get; set; }

        Entities.Common.Sample.IStudentArtProgramAssociation IStudentArtProgramAssociationService.StudentArtProgramAssociation
        {
            get { return StudentArtProgramAssociation; }
            set { StudentArtProgramAssociation = (StudentArtProgramAssociation) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int ServiceDescriptorId 
        {
            get
            {
                if (_serviceDescriptorId == default(int))
                    _serviceDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("ServiceDescriptor", _serviceDescriptor);

                return _serviceDescriptorId;
            } 
            set
            {
                _serviceDescriptorId = value;
                _serviceDescriptor = null;
            }
        }

        private int _serviceDescriptorId;
        private string _serviceDescriptor;

        public virtual string ServiceDescriptor
        {
            get
            {
                if (_serviceDescriptor == null)
                    _serviceDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("ServiceDescriptor", _serviceDescriptorId);
                    
                return _serviceDescriptor;
            }
            set
            {
                _serviceDescriptor = value;
                _serviceDescriptorId = default(int);
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
        public virtual bool? PrimaryIndicator  { get; set; }
        public virtual DateTime? ServiceBeginDate 
        {
            get { return _serviceBeginDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _serviceBeginDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _serviceBeginDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _serviceBeginDate;
        
        public virtual DateTime? ServiceEndDate 
        {
            get { return _serviceEndDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _serviceEndDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _serviceEndDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _serviceEndDate;
        
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
                { "ServiceDescriptor", new LookupColumnDetails { PropertyName = "ServiceDescriptorId", LookupTypeName = "ServiceDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentArtProgramAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("ServiceDescriptorId", ServiceDescriptorId);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentArtProgramAssociationService)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentArtProgramAssociationService) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentArtProgramAssociation = (StudentArtProgramAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentArtProgramAssociationStyle table of the StudentArtProgramAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationStyle : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentArtProgramAssociationStyle, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentArtProgramAssociationStyle()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentArtProgramAssociation StudentArtProgramAssociation { get; set; }

        Entities.Common.Sample.IStudentArtProgramAssociation IStudentArtProgramAssociationStyle.StudentArtProgramAssociation
        {
            get { return StudentArtProgramAssociation; }
            set { StudentArtProgramAssociation = (StudentArtProgramAssociation) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(50, MinimumLength=0), NoDangerousText, NoWhitespace]
        public virtual string Style  { get; set; }
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
            var keyValues = (StudentArtProgramAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("Style", Style);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentArtProgramAssociationStyle)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentArtProgramAssociationStyle) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentArtProgramAssociation = (StudentArtProgramAssociation) value;
        }
    }
}
// Aggregate: StudentCTEProgramAssociation

namespace EdFi.Ods.Entities.NHibernate.StudentCTEProgramAssociationAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentCTEProgramAssociationExtension table of the StudentCTEProgramAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentCTEProgramAssociationExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentCTEProgramAssociationExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentCTEProgramAssociationExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentCTEProgramAssociation StudentCTEProgramAssociation { get; set; }

        Entities.Common.EdFi.IStudentCTEProgramAssociation IStudentCTEProgramAssociationExtension.StudentCTEProgramAssociation
        {
            get { return StudentCTEProgramAssociation; }
            set { StudentCTEProgramAssociation = (EdFi.StudentCTEProgramAssociation) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual bool? AnalysisCompleted  { get; set; }
        public virtual DateTime? AnalysisDate 
        {
            get { return _analysisDate; }
            set
            {
                // This is only stored as a UTC DateTime in the DB and NHibernate will retrieve it back as the (UTC) DateTime.Kind.
                // Note ToUniversal will work differently based on DateTime.Kind
                // See https://docs.microsoft.com/en-us/dotnet/api/system.datetime.touniversaltime?view=netframework-4.5#System_DateTime_ToUniversalTime
                // Utc - No conversion is performed.
                // Local - The current DateTime object is converted to UTC.
                // Unspecified - The current DateTime object is assumed to be a local time, and the conversion is performed as if Kind were Local.
                if (value.HasValue && value.Value != (DateTime)typeof(DateTime).GetDefaultValue())
                    _analysisDate = value?.ToUniversalTime();
            }
        }

        private DateTime? _analysisDate;

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
            var keyValues = (StudentCTEProgramAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentCTEProgramAssociationExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentCTEProgramAssociationExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentCTEProgramAssociation = (EdFi.StudentCTEProgramAssociation) value;
        }
    }
}
// Aggregate: StudentEducationOrganizationAssociation

namespace EdFi.Ods.Entities.NHibernate.StudentEducationOrganizationAssociationAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentEducationOrganizationAssociationAddressSchoolDistrict table of the StudentEducationOrganizationAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationAddressSchoolDistrict : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentEducationOrganizationAssociationAddressSchoolDistrict()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentEducationOrganizationAssociationAddress StudentEducationOrganizationAssociationAddress { get; set; }

        Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension IStudentEducationOrganizationAssociationAddressSchoolDistrict.StudentEducationOrganizationAssociationAddressExtension
        {
            get { return (IStudentEducationOrganizationAssociationAddressExtension) StudentEducationOrganizationAssociationAddress.Extensions["Sample"]; }
            set { StudentEducationOrganizationAssociationAddress.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(250, MinimumLength=0), NoDangerousText, NoWhitespace]
        public virtual string SchoolDistrict  { get; set; }
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
            var keyValues = (StudentEducationOrganizationAssociationAddress as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("SchoolDistrict", SchoolDistrict);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentEducationOrganizationAssociationAddress = (EdFi.StudentEducationOrganizationAssociationAddress) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentEducationOrganizationAssociationAddressTerm table of the StudentEducationOrganizationAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationAddressTerm : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentEducationOrganizationAssociationAddressTerm()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentEducationOrganizationAssociationAddress StudentEducationOrganizationAssociationAddress { get; set; }

        Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension IStudentEducationOrganizationAssociationAddressTerm.StudentEducationOrganizationAssociationAddressExtension
        {
            get { return (IStudentEducationOrganizationAssociationAddressExtension) StudentEducationOrganizationAssociationAddress.Extensions["Sample"]; }
            set { StudentEducationOrganizationAssociationAddress.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int TermDescriptorId 
        {
            get
            {
                if (_termDescriptorId == default(int))
                    _termDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("TermDescriptor", _termDescriptor);

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
                    _termDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("TermDescriptor", _termDescriptorId);
                    
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
            var keyValues = (StudentEducationOrganizationAssociationAddress as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentEducationOrganizationAssociationAddress = (EdFi.StudentEducationOrganizationAssociationAddress) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed table of the StudentEducationOrganizationAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentEducationOrganizationAssociationStudentCharacteristic StudentEducationOrganizationAssociationStudentCharacteristic { get; set; }

        Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed.StudentEducationOrganizationAssociationStudentCharacteristicExtension
        {
            get { return (IStudentEducationOrganizationAssociationStudentCharacteristicExtension) StudentEducationOrganizationAssociationStudentCharacteristic.Extensions["Sample"]; }
            set { StudentEducationOrganizationAssociationStudentCharacteristic.Extensions["Sample"] = value; }
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
        
        public virtual bool? PrimaryStudentNeedIndicator  { get; set; }
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
                { "StudentCharacteristicDescriptor", new LookupColumnDetails { PropertyName = "StudentCharacteristicDescriptorId", LookupTypeName = "StudentCharacteristicDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentEducationOrganizationAssociationStudentCharacteristic as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentEducationOrganizationAssociationStudentCharacteristic = (EdFi.StudentEducationOrganizationAssociationStudentCharacteristic) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentEducationOrganizationAssociationExtension table of the StudentEducationOrganizationAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentEducationOrganizationAssociationExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }

        Entities.Common.EdFi.IStudentEducationOrganizationAssociation IStudentEducationOrganizationAssociationExtension.StudentEducationOrganizationAssociation
        {
            get { return StudentEducationOrganizationAssociation; }
            set { StudentEducationOrganizationAssociation = (EdFi.StudentEducationOrganizationAssociation) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [StringLength(60, MinimumLength=1), NoDangerousText]
        public virtual string FavoriteProgramName  { get; set; }
        public virtual int? FavoriteProgramTypeDescriptorId 
        {
            get
            {
                if (_favoriteProgramTypeDescriptorId == default(int?))
                    _favoriteProgramTypeDescriptorId = string.IsNullOrWhiteSpace(_favoriteProgramTypeDescriptor) ? default(int?) : GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("ProgramTypeDescriptor", _favoriteProgramTypeDescriptor);

                return _favoriteProgramTypeDescriptorId;
            } 
            set
            {
                _favoriteProgramTypeDescriptorId = value;
                _favoriteProgramTypeDescriptor = null;
            }
        }

        private int? _favoriteProgramTypeDescriptorId;
        private string _favoriteProgramTypeDescriptor;

        public virtual string FavoriteProgramTypeDescriptor
        {
            get
            {
                if (_favoriteProgramTypeDescriptor == null)
                    _favoriteProgramTypeDescriptor = _favoriteProgramTypeDescriptorId == null ? null : GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("ProgramTypeDescriptor", _favoriteProgramTypeDescriptorId.Value);
                    
                return _favoriteProgramTypeDescriptor;
            }
            set
            {
                _favoriteProgramTypeDescriptor = value;
                _favoriteProgramTypeDescriptorId = default(int?);
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
        public virtual NHibernate.ProgramAggregate.EdFi.ProgramReferenceData FavoriteProgramReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the FavoriteProgram discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension.FavoriteProgramDiscriminator
        {
            get { return FavoriteProgramReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the FavoriteProgram resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension.FavoriteProgramResourceId
        {
            get { return FavoriteProgramReferenceData?.Id; }
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
                { "FavoriteProgramTypeDescriptor", new LookupColumnDetails { PropertyName = "FavoriteProgramTypeDescriptorId", LookupTypeName = "ProgramTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentEducationOrganizationAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentEducationOrganizationAssociation = (EdFi.StudentEducationOrganizationAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentEducationOrganizationAssociationAddressExtension table of the StudentEducationOrganizationAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationAddressExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentEducationOrganizationAssociationAddressExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentEducationOrganizationAssociationAddress StudentEducationOrganizationAssociationAddress { get; set; }

        Entities.Common.EdFi.IStudentEducationOrganizationAssociationAddress IStudentEducationOrganizationAssociationAddressExtension.StudentEducationOrganizationAssociationAddress
        {
            get { return StudentEducationOrganizationAssociationAddress; }
            set { StudentEducationOrganizationAssociationAddress = (EdFi.StudentEducationOrganizationAssociationAddress) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [StringLength(255, MinimumLength=1), NoDangerousText]
        public virtual string Complex  { get; set; }
        public virtual bool OnBusRoute  { get; set; }
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
        [RequiredCollection]
        private ICollection<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict> _studentEducationOrganizationAssociationAddressSchoolDistricts;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict> IStudentEducationOrganizationAssociationAddressExtension.StudentEducationOrganizationAssociationAddressSchoolDistricts
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StudentEducationOrganizationAssociationAddressSchoolDistrict>((IList<object>) StudentEducationOrganizationAssociationAddress.AggregateExtensions["Sample_StudentEducationOrganizationAssociationAddressSchoolDistricts"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StudentEducationOrganizationAssociationAddressSchoolDistrict item in sourceList)
                    if (item.StudentEducationOrganizationAssociationAddress == null)
                        item.StudentEducationOrganizationAssociationAddress = this.StudentEducationOrganizationAssociationAddress;
                // -------------------------------------------------------------

                if (_studentEducationOrganizationAssociationAddressSchoolDistricts == null)
                    _studentEducationOrganizationAssociationAddressSchoolDistricts = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict, StudentEducationOrganizationAssociationAddressSchoolDistrict>(sourceList);

                return _studentEducationOrganizationAssociationAddressSchoolDistricts;
            }
            set
            {
                StudentEducationOrganizationAssociationAddress.AggregateExtensions["Sample_StudentEducationOrganizationAssociationAddressSchoolDistricts"] = value;
            }
        }
        private ICollection<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm> _studentEducationOrganizationAssociationAddressTerms;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm> IStudentEducationOrganizationAssociationAddressExtension.StudentEducationOrganizationAssociationAddressTerms
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StudentEducationOrganizationAssociationAddressTerm>((IList<object>) StudentEducationOrganizationAssociationAddress.AggregateExtensions["Sample_StudentEducationOrganizationAssociationAddressTerms"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StudentEducationOrganizationAssociationAddressTerm item in sourceList)
                    if (item.StudentEducationOrganizationAssociationAddress == null)
                        item.StudentEducationOrganizationAssociationAddress = this.StudentEducationOrganizationAssociationAddress;
                // -------------------------------------------------------------

                if (_studentEducationOrganizationAssociationAddressTerms == null)
                    _studentEducationOrganizationAssociationAddressTerms = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm, StudentEducationOrganizationAssociationAddressTerm>(sourceList);

                return _studentEducationOrganizationAssociationAddressTerms;
            }
            set
            {
                StudentEducationOrganizationAssociationAddress.AggregateExtensions["Sample_StudentEducationOrganizationAssociationAddressTerms"] = value;
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
            // Get parent key values
            var keyValues = (StudentEducationOrganizationAssociationAddress as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentEducationOrganizationAssociationAddress = (EdFi.StudentEducationOrganizationAssociationAddress) value;
        }
    }

    /// <summary>
    /// An implicitly created entity extension class to enable entity mapping and sychronization behavior for the StudentEducationOrganizationAssociationStudentCharacteristic entity's aggregate extensions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationStudentCharacteristicExtension : IStudentEducationOrganizationAssociationStudentCharacteristicExtension, IChildEntity, IImplicitEntityExtension, IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private EdFi.StudentEducationOrganizationAssociationStudentCharacteristic _studentEducationOrganizationAssociationStudentCharacteristic;

        Common.EdFi.IStudentEducationOrganizationAssociationStudentCharacteristic IStudentEducationOrganizationAssociationStudentCharacteristicExtension.StudentEducationOrganizationAssociationStudentCharacteristic
        {
            get { return _studentEducationOrganizationAssociationStudentCharacteristic; }
            set { _studentEducationOrganizationAssociationStudentCharacteristic = (EdFi.StudentEducationOrganizationAssociationStudentCharacteristic) value; }
        }

        private EdFi.StudentEducationOrganizationAssociationStudentCharacteristic StudentEducationOrganizationAssociationStudentCharacteristic
        {
            get { return (this as IStudentEducationOrganizationAssociationStudentCharacteristicExtension).StudentEducationOrganizationAssociationStudentCharacteristic as EdFi.StudentEducationOrganizationAssociationStudentCharacteristic; }
        }

        bool IImplicitEntityExtension.IsEmpty()
        {
            return (true
                && ((IList<object>) _studentEducationOrganizationAssociationStudentCharacteristic.AggregateExtensions["Sample_StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds"]).Count == 0
            );
        }

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        ICollection<IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed> IStudentEducationOrganizationAssociationStudentCharacteristicExtension.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed>((IList<object>) _studentEducationOrganizationAssociationStudentCharacteristic.AggregateExtensions["Sample_StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed item in sourceList)
                    if (item.StudentEducationOrganizationAssociationStudentCharacteristic == null)
                        item.StudentEducationOrganizationAssociationStudentCharacteristic = this.StudentEducationOrganizationAssociationStudentCharacteristic;
                // -------------------------------------------------------------

                var adaptedList = new CovariantCollectionAdapter<IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed, StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed>(sourceList);

                return adaptedList;
            }
            set
            {
                _studentEducationOrganizationAssociationStudentCharacteristic.AggregateExtensions["Sample_StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds"] = value;
            }
        }
        // -------------------------------------------------------------

        void IMappable.Map(object target)
        {
            this.MapTo((IStudentEducationOrganizationAssociationStudentCharacteristicExtension) target, null);
        }

        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((IStudentEducationOrganizationAssociationStudentCharacteristicExtension) target);
        }

        void IChildEntity.SetParent(object value)
        {
            _studentEducationOrganizationAssociationStudentCharacteristic = (EdFi.StudentEducationOrganizationAssociationStudentCharacteristic)value;
        }

        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            return (_studentEducationOrganizationAssociationStudentCharacteristic as IHasPrimaryKeyValues).GetPrimaryKeyValues();
        }

        void IGetByExample.SuspendReferenceAssignmentCheck() { }
    }
}
// Aggregate: StudentGraduationPlanAssociation

namespace EdFi.Ods.Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="StudentGraduationPlanAssociation"/> entity.
    /// </summary>
    public class StudentGraduationPlanAssociationReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual int EducationOrganizationId { get; set; }
        public virtual int GraduationPlanTypeDescriptorId { get; set; }
        public virtual short GraduationSchoolYear { get; set; }
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
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("GraduationPlanTypeDescriptorId", GraduationPlanTypeDescriptorId);
            keyValues.Add("GraduationSchoolYear", GraduationSchoolYear);
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
    /// A class which represents the sample.StudentGraduationPlanAssociation table of the StudentGraduationPlanAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociation : AggregateRootWithCompositeKey,
        Entities.Common.Sample.IStudentGraduationPlanAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentGraduationPlanAssociation()
        {
           StudentGraduationPlanAssociationCTEProgramPersistentList = new HashSet<StudentGraduationPlanAssociationCTEProgram>();
            StudentGraduationPlanAssociationAcademicSubjects = new HashSet<StudentGraduationPlanAssociationAcademicSubject>();
            StudentGraduationPlanAssociationCareerPathwayCodes = new HashSet<StudentGraduationPlanAssociationCareerPathwayCode>();
            StudentGraduationPlanAssociationDescriptions = new HashSet<StudentGraduationPlanAssociationDescription>();
            StudentGraduationPlanAssociationDesignatedBies = new HashSet<StudentGraduationPlanAssociationDesignatedBy>();
            StudentGraduationPlanAssociationIndustryCredentials = new HashSet<StudentGraduationPlanAssociationIndustryCredential>();
            StudentGraduationPlanAssociationStudentParentAssociations = new HashSet<StudentGraduationPlanAssociationStudentParentAssociation>();
            StudentGraduationPlanAssociationYearsAttendeds = new HashSet<StudentGraduationPlanAssociationYearsAttended>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int GraduationPlanTypeDescriptorId 
        {
            get
            {
                if (_graduationPlanTypeDescriptorId == default(int))
                    _graduationPlanTypeDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("GraduationPlanTypeDescriptor", _graduationPlanTypeDescriptor);

                return _graduationPlanTypeDescriptorId;
            } 
            set
            {
                _graduationPlanTypeDescriptorId = value;
                _graduationPlanTypeDescriptor = null;
            }
        }

        private int _graduationPlanTypeDescriptorId;
        private string _graduationPlanTypeDescriptor;

        public virtual string GraduationPlanTypeDescriptor
        {
            get
            {
                if (_graduationPlanTypeDescriptor == null)
                    _graduationPlanTypeDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("GraduationPlanTypeDescriptor", _graduationPlanTypeDescriptorId);
                    
                return _graduationPlanTypeDescriptor;
            }
            set
            {
                _graduationPlanTypeDescriptor = value;
                _graduationPlanTypeDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual short GraduationSchoolYear  { get; set; }
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
        public virtual TimeSpan? CommencementTime  { get; set; }
        [RequiredWithNonDefault]
        public virtual DateTime EffectiveDate 
        {
            get { return _effectiveDate; }
            //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
            set { _effectiveDate = new DateTime(value.Year, value.Month, value.Day); }
        }

        private DateTime _effectiveDate;
        
        [Range(typeof(decimal), "-922337203685477.5808", "922337203685477.5807")]
        public virtual decimal? GraduationFee  { get; set; }
        [StringLength(30, MinimumLength=0), NoDangerousText]
        public virtual string HighSchoolDuration  { get; set; }
        [Range(typeof(decimal), "-999.99", "999.99")]
        public virtual decimal HoursPerWeek  { get; set; }
        public virtual bool? IsActivePlan  { get; set; }
        [Range(typeof(decimal), "-9.9999", "9.9999")]
        public virtual decimal? RequiredAttendance  { get; set; }
        public virtual int? StaffUSI 
        {
            get
            {
                if (_staffUSI == default(int?))
                    _staffUSI = PersonUniqueIdToUsiCache.GetCache().GetUsiNullable("Staff", _staffUniqueId);

                return _staffUSI;
            } 
            set
            {
                _staffUSI = value;
            }
        }

        private int? _staffUSI;
        private string _staffUniqueId;

        
        public virtual string StaffUniqueId
        {
            get
            {
                if (_staffUniqueId == null && _staffUSI.HasValue)
                    _staffUniqueId = PersonUniqueIdToUsiCache.GetCache().GetUniqueId("Staff", _staffUSI.Value);
                    
                return _staffUniqueId;
            }
            set
            {
                if (_staffUniqueId != value)
                        _staffUSI = default(int?);

                _staffUniqueId = value;
            }
        }
        [Range(typeof(decimal), "-99999999999999.9999", "99999999999999.9999")]
        public virtual decimal TargetGPA  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        [ValidateObject]
        public virtual Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationCTEProgram StudentGraduationPlanAssociationCTEProgram
        {
            get
            {
                // Return the item in the list, if one exists
                if (StudentGraduationPlanAssociationCTEProgramPersistentList.Any())
                    return StudentGraduationPlanAssociationCTEProgramPersistentList.First();

                // No reference is present
                return null;
            }
            set
            {
                // Delete the existing object
                if (StudentGraduationPlanAssociationCTEProgramPersistentList.Any())
                    StudentGraduationPlanAssociationCTEProgramPersistentList.Clear();

                // If we're setting a value, add it to the list now
                if (value != null)
                {
                    // Set the back-reference to the parent
                    value.StudentGraduationPlanAssociation = this;

                    StudentGraduationPlanAssociationCTEProgramPersistentList.Add(value);
                }
            }
        }

        Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgram Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationCTEProgram
        {
            get { return StudentGraduationPlanAssociationCTEProgram; }
            set { StudentGraduationPlanAssociationCTEProgram = (Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationCTEProgram) value; }
        }

        private ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationCTEProgram> _studentGraduationPlanAssociationCTEProgramPersistentList;

        public virtual ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationCTEProgram> StudentGraduationPlanAssociationCTEProgramPersistentList
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationCTEProgramPersistentList)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationCTEProgramPersistentList;
            }
            set
            {
                _studentGraduationPlanAssociationCTEProgramPersistentList = value;
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
        public virtual NHibernate.GraduationPlanAggregate.EdFi.GraduationPlanReferenceData GraduationPlanReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the GraduationPlan discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Sample.IStudentGraduationPlanAssociation.GraduationPlanDiscriminator
        {
            get { return GraduationPlanReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the GraduationPlan resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.IStudentGraduationPlanAssociation.GraduationPlanResourceId
        {
            get { return GraduationPlanReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.StaffAggregate.EdFi.StaffReferenceData StaffReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Staff discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Sample.IStudentGraduationPlanAssociation.StaffDiscriminator
        {
            get { return StaffReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Staff resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.IStudentGraduationPlanAssociation.StaffResourceId
        {
            get { return StaffReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.StudentAggregate.EdFi.StudentReferenceData StudentReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Student discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentDiscriminator
        {
            get { return StudentReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Student resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentResourceId
        {
            get { return StudentReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationAcademicSubject> _studentGraduationPlanAssociationAcademicSubjects;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject> _studentGraduationPlanAssociationAcademicSubjectsCovariant;
        [RequiredCollection]
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationAcademicSubject> StudentGraduationPlanAssociationAcademicSubjects
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationAcademicSubjects)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationAcademicSubjects;
            }
            set
            {
                _studentGraduationPlanAssociationAcademicSubjects = value;
                _studentGraduationPlanAssociationAcademicSubjectsCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject, Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationAcademicSubject>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationAcademicSubjects
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationAcademicSubjects)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationAcademicSubjectsCovariant;
            }
            set
            {
                StudentGraduationPlanAssociationAcademicSubjects = new HashSet<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationAcademicSubject>(value.Cast<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationAcademicSubject>());
            }
        }


        private ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationCareerPathwayCode> _studentGraduationPlanAssociationCareerPathwayCodes;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode> _studentGraduationPlanAssociationCareerPathwayCodesCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationCareerPathwayCode> StudentGraduationPlanAssociationCareerPathwayCodes
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationCareerPathwayCodes)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationCareerPathwayCodes;
            }
            set
            {
                _studentGraduationPlanAssociationCareerPathwayCodes = value;
                _studentGraduationPlanAssociationCareerPathwayCodesCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode, Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationCareerPathwayCode>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationCareerPathwayCodes
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationCareerPathwayCodes)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationCareerPathwayCodesCovariant;
            }
            set
            {
                StudentGraduationPlanAssociationCareerPathwayCodes = new HashSet<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationCareerPathwayCode>(value.Cast<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationCareerPathwayCode>());
            }
        }


        private ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationDescription> _studentGraduationPlanAssociationDescriptions;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationDescription> _studentGraduationPlanAssociationDescriptionsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationDescription> StudentGraduationPlanAssociationDescriptions
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationDescriptions)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationDescriptions;
            }
            set
            {
                _studentGraduationPlanAssociationDescriptions = value;
                _studentGraduationPlanAssociationDescriptionsCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentGraduationPlanAssociationDescription, Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationDescription>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationDescription> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationDescriptions
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationDescriptions)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationDescriptionsCovariant;
            }
            set
            {
                StudentGraduationPlanAssociationDescriptions = new HashSet<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationDescription>(value.Cast<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationDescription>());
            }
        }


        private ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationDesignatedBy> _studentGraduationPlanAssociationDesignatedBies;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy> _studentGraduationPlanAssociationDesignatedBiesCovariant;
        [RequiredCollection]
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationDesignatedBy> StudentGraduationPlanAssociationDesignatedBies
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationDesignatedBies)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationDesignatedBies;
            }
            set
            {
                _studentGraduationPlanAssociationDesignatedBies = value;
                _studentGraduationPlanAssociationDesignatedBiesCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy, Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationDesignatedBy>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationDesignatedBies
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationDesignatedBies)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationDesignatedBiesCovariant;
            }
            set
            {
                StudentGraduationPlanAssociationDesignatedBies = new HashSet<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationDesignatedBy>(value.Cast<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationDesignatedBy>());
            }
        }


        private ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationIndustryCredential> _studentGraduationPlanAssociationIndustryCredentials;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential> _studentGraduationPlanAssociationIndustryCredentialsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationIndustryCredential> StudentGraduationPlanAssociationIndustryCredentials
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationIndustryCredentials)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationIndustryCredentials;
            }
            set
            {
                _studentGraduationPlanAssociationIndustryCredentials = value;
                _studentGraduationPlanAssociationIndustryCredentialsCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential, Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationIndustryCredential>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationIndustryCredentials
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationIndustryCredentials)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationIndustryCredentialsCovariant;
            }
            set
            {
                StudentGraduationPlanAssociationIndustryCredentials = new HashSet<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationIndustryCredential>(value.Cast<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationIndustryCredential>());
            }
        }


        private ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationStudentParentAssociation> _studentGraduationPlanAssociationStudentParentAssociations;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation> _studentGraduationPlanAssociationStudentParentAssociationsCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationStudentParentAssociation> StudentGraduationPlanAssociationStudentParentAssociations
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationStudentParentAssociations)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationStudentParentAssociations;
            }
            set
            {
                _studentGraduationPlanAssociationStudentParentAssociations = value;
                _studentGraduationPlanAssociationStudentParentAssociationsCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation, Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationStudentParentAssociation>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationStudentParentAssociations
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationStudentParentAssociations)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationStudentParentAssociationsCovariant;
            }
            set
            {
                StudentGraduationPlanAssociationStudentParentAssociations = new HashSet<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationStudentParentAssociation>(value.Cast<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationStudentParentAssociation>());
            }
        }


        private ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationYearsAttended> _studentGraduationPlanAssociationYearsAttendeds;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended> _studentGraduationPlanAssociationYearsAttendedsCovariant;
        [RequiredCollection]
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationYearsAttended> StudentGraduationPlanAssociationYearsAttendeds
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationYearsAttendeds)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationYearsAttendeds;
            }
            set
            {
                _studentGraduationPlanAssociationYearsAttendeds = value;
                _studentGraduationPlanAssociationYearsAttendedsCovariant = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended, Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationYearsAttended>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationYearsAttendeds
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentGraduationPlanAssociationYearsAttendeds)
                    if (item.StudentGraduationPlanAssociation == null)
                        item.StudentGraduationPlanAssociation = this;
                // -------------------------------------------------------------

                return _studentGraduationPlanAssociationYearsAttendedsCovariant;
            }
            set
            {
                StudentGraduationPlanAssociationYearsAttendeds = new HashSet<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationYearsAttended>(value.Cast<Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociationYearsAttended>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "GraduationPlanTypeDescriptor", new LookupColumnDetails { PropertyName = "GraduationPlanTypeDescriptorId", LookupTypeName = "GraduationPlanTypeDescriptor"} },
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
            keyValues.Add("GraduationPlanTypeDescriptorId", GraduationPlanTypeDescriptorId);
            keyValues.Add("GraduationSchoolYear", GraduationSchoolYear);
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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentGraduationPlanAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentGraduationPlanAssociation) target, null);
        }

    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationAcademicSubject table of the StudentGraduationPlanAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationAcademicSubject : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentGraduationPlanAssociationAcademicSubject()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }

        Entities.Common.Sample.IStudentGraduationPlanAssociation IStudentGraduationPlanAssociationAcademicSubject.StudentGraduationPlanAssociation
        {
            get { return StudentGraduationPlanAssociation; }
            set { StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int AcademicSubjectDescriptorId 
        {
            get
            {
                if (_academicSubjectDescriptorId == default(int))
                    _academicSubjectDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("AcademicSubjectDescriptor", _academicSubjectDescriptor);

                return _academicSubjectDescriptorId;
            } 
            set
            {
                _academicSubjectDescriptorId = value;
                _academicSubjectDescriptor = null;
            }
        }

        private int _academicSubjectDescriptorId;
        private string _academicSubjectDescriptor;

        public virtual string AcademicSubjectDescriptor
        {
            get
            {
                if (_academicSubjectDescriptor == null)
                    _academicSubjectDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("AcademicSubjectDescriptor", _academicSubjectDescriptorId);
                    
                return _academicSubjectDescriptor;
            }
            set
            {
                _academicSubjectDescriptor = value;
                _academicSubjectDescriptorId = default(int);
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
                { "AcademicSubjectDescriptor", new LookupColumnDetails { PropertyName = "AcademicSubjectDescriptorId", LookupTypeName = "AcademicSubjectDescriptor"} },
                { "GraduationPlanTypeDescriptor", new LookupColumnDetails { PropertyName = "GraduationPlanTypeDescriptorId", LookupTypeName = "GraduationPlanTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentGraduationPlanAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("AcademicSubjectDescriptorId", AcademicSubjectDescriptorId);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationCareerPathwayCode table of the StudentGraduationPlanAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationCareerPathwayCode : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentGraduationPlanAssociationCareerPathwayCode()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }

        Entities.Common.Sample.IStudentGraduationPlanAssociation IStudentGraduationPlanAssociationCareerPathwayCode.StudentGraduationPlanAssociation
        {
            get { return StudentGraduationPlanAssociation; }
            set { StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value; }
        }

        [DomainSignature]
        public virtual int CareerPathwayCode  { get; set; }
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
                { "GraduationPlanTypeDescriptor", new LookupColumnDetails { PropertyName = "GraduationPlanTypeDescriptorId", LookupTypeName = "GraduationPlanTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentGraduationPlanAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("CareerPathwayCode", CareerPathwayCode);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationCTEProgram table of the StudentGraduationPlanAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationCTEProgram : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgram, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentGraduationPlanAssociationCTEProgram()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }

        Entities.Common.Sample.IStudentGraduationPlanAssociation IStudentGraduationPlanAssociationCTEProgram.StudentGraduationPlanAssociation
        {
            get { return StudentGraduationPlanAssociation; }
            set { StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [RequiredWithNonDefault]
        public virtual int CareerPathwayDescriptorId 
        {
            get
            {
                if (_careerPathwayDescriptorId == default(int))
                    _careerPathwayDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("CareerPathwayDescriptor", _careerPathwayDescriptor);

                return _careerPathwayDescriptorId;
            } 
            set
            {
                _careerPathwayDescriptorId = value;
                _careerPathwayDescriptor = null;
            }
        }

        private int _careerPathwayDescriptorId;
        private string _careerPathwayDescriptor;

        public virtual string CareerPathwayDescriptor
        {
            get
            {
                if (_careerPathwayDescriptor == null)
                    _careerPathwayDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("CareerPathwayDescriptor", _careerPathwayDescriptorId);
                    
                return _careerPathwayDescriptor;
            }
            set
            {
                _careerPathwayDescriptor = value;
                _careerPathwayDescriptorId = default(int);
            }
        }
        [StringLength(120, MinimumLength=1), NoDangerousText]
        public virtual string CIPCode  { get; set; }
        public virtual bool? CTEProgramCompletionIndicator  { get; set; }
        public virtual bool? PrimaryCTEProgramIndicator  { get; set; }
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
                { "CareerPathwayDescriptor", new LookupColumnDetails { PropertyName = "CareerPathwayDescriptorId", LookupTypeName = "CareerPathwayDescriptor"} },
                { "GraduationPlanTypeDescriptor", new LookupColumnDetails { PropertyName = "GraduationPlanTypeDescriptorId", LookupTypeName = "GraduationPlanTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentGraduationPlanAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgram)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgram) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationDescription table of the StudentGraduationPlanAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationDescription : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentGraduationPlanAssociationDescription, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentGraduationPlanAssociationDescription()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }

        Entities.Common.Sample.IStudentGraduationPlanAssociation IStudentGraduationPlanAssociationDescription.StudentGraduationPlanAssociation
        {
            get { return StudentGraduationPlanAssociation; }
            set { StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(1024, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string Description  { get; set; }
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
                { "GraduationPlanTypeDescriptor", new LookupColumnDetails { PropertyName = "GraduationPlanTypeDescriptorId", LookupTypeName = "GraduationPlanTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentGraduationPlanAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("Description", Description);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentGraduationPlanAssociationDescription)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentGraduationPlanAssociationDescription) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationDesignatedBy table of the StudentGraduationPlanAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationDesignatedBy : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentGraduationPlanAssociationDesignatedBy()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }

        Entities.Common.Sample.IStudentGraduationPlanAssociation IStudentGraduationPlanAssociationDesignatedBy.StudentGraduationPlanAssociation
        {
            get { return StudentGraduationPlanAssociation; }
            set { StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(60, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string DesignatedBy  { get; set; }
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
                { "GraduationPlanTypeDescriptor", new LookupColumnDetails { PropertyName = "GraduationPlanTypeDescriptorId", LookupTypeName = "GraduationPlanTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentGraduationPlanAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("DesignatedBy", DesignatedBy);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationIndustryCredential table of the StudentGraduationPlanAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationIndustryCredential : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentGraduationPlanAssociationIndustryCredential()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }

        Entities.Common.Sample.IStudentGraduationPlanAssociation IStudentGraduationPlanAssociationIndustryCredential.StudentGraduationPlanAssociation
        {
            get { return StudentGraduationPlanAssociation; }
            set { StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(100, MinimumLength=0), NoDangerousText, NoWhitespace]
        public virtual string IndustryCredential  { get; set; }
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
                { "GraduationPlanTypeDescriptor", new LookupColumnDetails { PropertyName = "GraduationPlanTypeDescriptorId", LookupTypeName = "GraduationPlanTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentGraduationPlanAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("IndustryCredential", IndustryCredential);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationStudentParentAssociation table of the StudentGraduationPlanAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationStudentParentAssociation : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentGraduationPlanAssociationStudentParentAssociation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }

        Entities.Common.Sample.IStudentGraduationPlanAssociation IStudentGraduationPlanAssociationStudentParentAssociation.StudentGraduationPlanAssociation
        {
            get { return StudentGraduationPlanAssociation; }
            set { StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value; }
        }

        [Display(Name="ParentUniqueId")]
        [DomainSignature, RequiredWithNonDefault("Parent")]
        public virtual int ParentUSI 
        {
            get
            {
                if (_parentUSI == default(int))
                    _parentUSI = PersonUniqueIdToUsiCache.GetCache().GetUsi("Parent", _parentUniqueId);

                return _parentUSI;
            } 
            set
            {
                _parentUSI = value;
            }
        }

        private int _parentUSI;
        private string _parentUniqueId;

        [RequiredWithNonDefault]
        public virtual string ParentUniqueId
        {
            get
            {
                if (_parentUniqueId == null)
                    _parentUniqueId = PersonUniqueIdToUsiCache.GetCache().GetUniqueId("Parent", _parentUSI);
                    
                return _parentUniqueId;
            }
            set
            {
                if (_parentUniqueId != value)
                        _parentUSI = default(int);

                _parentUniqueId = value;
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
        public virtual NHibernate.StudentParentAssociationAggregate.EdFi.StudentParentAssociationReferenceData StudentParentAssociationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the StudentParentAssociation discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation.StudentParentAssociationDiscriminator
        {
            get { return StudentParentAssociationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the StudentParentAssociation resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation.StudentParentAssociationResourceId
        {
            get { return StudentParentAssociationReferenceData?.Id; }
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
                { "GraduationPlanTypeDescriptor", new LookupColumnDetails { PropertyName = "GraduationPlanTypeDescriptorId", LookupTypeName = "GraduationPlanTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentGraduationPlanAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("ParentUSI", ParentUSI);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationYearsAttended table of the StudentGraduationPlanAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationYearsAttended : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentGraduationPlanAssociationYearsAttended()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual StudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }

        Entities.Common.Sample.IStudentGraduationPlanAssociation IStudentGraduationPlanAssociationYearsAttended.StudentGraduationPlanAssociation
        {
            get { return StudentGraduationPlanAssociation; }
            set { StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value; }
        }

        [DomainSignature]
        public virtual short YearsAttended  { get; set; }
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
                { "GraduationPlanTypeDescriptor", new LookupColumnDetails { PropertyName = "GraduationPlanTypeDescriptorId", LookupTypeName = "GraduationPlanTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentGraduationPlanAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("YearsAttended", YearsAttended);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentGraduationPlanAssociation = (StudentGraduationPlanAssociation) value;
        }
    }
}
// Aggregate: StudentParentAssociation

namespace EdFi.Ods.Entities.NHibernate.StudentParentAssociationAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationDiscipline table of the StudentParentAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationDiscipline : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentParentAssociationDiscipline, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentParentAssociationDiscipline()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentParentAssociation StudentParentAssociation { get; set; }

        Entities.Common.Sample.IStudentParentAssociationExtension IStudentParentAssociationDiscipline.StudentParentAssociationExtension
        {
            get { return (IStudentParentAssociationExtension) StudentParentAssociation.Extensions["Sample"]; }
            set { StudentParentAssociation.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int DisciplineDescriptorId 
        {
            get
            {
                if (_disciplineDescriptorId == default(int))
                    _disciplineDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("DisciplineDescriptor", _disciplineDescriptor);

                return _disciplineDescriptorId;
            } 
            set
            {
                _disciplineDescriptorId = value;
                _disciplineDescriptor = null;
            }
        }

        private int _disciplineDescriptorId;
        private string _disciplineDescriptor;

        public virtual string DisciplineDescriptor
        {
            get
            {
                if (_disciplineDescriptor == null)
                    _disciplineDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("DisciplineDescriptor", _disciplineDescriptorId);
                    
                return _disciplineDescriptor;
            }
            set
            {
                _disciplineDescriptor = value;
                _disciplineDescriptorId = default(int);
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
                { "DisciplineDescriptor", new LookupColumnDetails { PropertyName = "DisciplineDescriptorId", LookupTypeName = "DisciplineDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentParentAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("DisciplineDescriptorId", DisciplineDescriptorId);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentParentAssociationDiscipline)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentParentAssociationDiscipline) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentParentAssociation = (EdFi.StudentParentAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationFavoriteBookTitle table of the StudentParentAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationFavoriteBookTitle : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentParentAssociationFavoriteBookTitle()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentParentAssociation StudentParentAssociation { get; set; }

        Entities.Common.Sample.IStudentParentAssociationExtension IStudentParentAssociationFavoriteBookTitle.StudentParentAssociationExtension
        {
            get { return (IStudentParentAssociationExtension) StudentParentAssociation.Extensions["Sample"]; }
            set { StudentParentAssociation.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault, StringLength(100, MinimumLength=0), NoDangerousText, NoWhitespace]
        public virtual string FavoriteBookTitle  { get; set; }
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
            var keyValues = (StudentParentAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("FavoriteBookTitle", FavoriteBookTitle);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentParentAssociation = (EdFi.StudentParentAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationHoursPerWeek table of the StudentParentAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationHoursPerWeek : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentParentAssociationHoursPerWeek, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentParentAssociationHoursPerWeek()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentParentAssociation StudentParentAssociation { get; set; }

        Entities.Common.Sample.IStudentParentAssociationExtension IStudentParentAssociationHoursPerWeek.StudentParentAssociationExtension
        {
            get { return (IStudentParentAssociationExtension) StudentParentAssociation.Extensions["Sample"]; }
            set { StudentParentAssociation.Extensions["Sample"] = value; }
        }

        [DomainSignature][Range(typeof(decimal), "-999.99", "999.99")]
        public virtual decimal HoursPerWeek  { get; set; }
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
            var keyValues = (StudentParentAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("HoursPerWeek", HoursPerWeek);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentParentAssociationHoursPerWeek)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentParentAssociationHoursPerWeek) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentParentAssociation = (EdFi.StudentParentAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationPagesRead table of the StudentParentAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationPagesRead : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentParentAssociationPagesRead, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentParentAssociationPagesRead()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentParentAssociation StudentParentAssociation { get; set; }

        Entities.Common.Sample.IStudentParentAssociationExtension IStudentParentAssociationPagesRead.StudentParentAssociationExtension
        {
            get { return (IStudentParentAssociationExtension) StudentParentAssociation.Extensions["Sample"]; }
            set { StudentParentAssociation.Extensions["Sample"] = value; }
        }

        [DomainSignature][Range(typeof(decimal), "-9999999999999999.99", "9999999999999999.99")]
        public virtual decimal PagesRead  { get; set; }
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
            var keyValues = (StudentParentAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("PagesRead", PagesRead);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentParentAssociationPagesRead)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentParentAssociationPagesRead) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentParentAssociation = (EdFi.StudentParentAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationStaffEducationOrganizationEmploymentAssociation table of the StudentParentAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationStaffEducationOrganizationEmploymentAssociation : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentParentAssociationStaffEducationOrganizationEmploymentAssociation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentParentAssociation StudentParentAssociation { get; set; }

        Entities.Common.Sample.IStudentParentAssociationExtension IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation.StudentParentAssociationExtension
        {
            get { return (IStudentParentAssociationExtension) StudentParentAssociation.Extensions["Sample"]; }
            set { StudentParentAssociation.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EmploymentStatusDescriptorId 
        {
            get
            {
                if (_employmentStatusDescriptorId == default(int))
                    _employmentStatusDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("EmploymentStatusDescriptor", _employmentStatusDescriptor);

                return _employmentStatusDescriptorId;
            } 
            set
            {
                _employmentStatusDescriptorId = value;
                _employmentStatusDescriptor = null;
            }
        }

        private int _employmentStatusDescriptorId;
        private string _employmentStatusDescriptor;

        public virtual string EmploymentStatusDescriptor
        {
            get
            {
                if (_employmentStatusDescriptor == null)
                    _employmentStatusDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("EmploymentStatusDescriptor", _employmentStatusDescriptorId);
                    
                return _employmentStatusDescriptor;
            }
            set
            {
                _employmentStatusDescriptor = value;
                _employmentStatusDescriptorId = default(int);
            }
        }
        [DomainSignature, RequiredWithNonDefault]
        public virtual DateTime HireDate 
        {
            get { return _hireDate; }
            //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
            set { _hireDate = new DateTime(value.Year, value.Month, value.Day); }
        }

        private DateTime _hireDate;
        
        [Display(Name="StaffUniqueId")]
        [DomainSignature, RequiredWithNonDefault("Staff")]
        public virtual int StaffUSI 
        {
            get
            {
                if (_staffUSI == default(int))
                    _staffUSI = PersonUniqueIdToUsiCache.GetCache().GetUsi("Staff", _staffUniqueId);

                return _staffUSI;
            } 
            set
            {
                _staffUSI = value;
            }
        }

        private int _staffUSI;
        private string _staffUniqueId;

        [RequiredWithNonDefault]
        public virtual string StaffUniqueId
        {
            get
            {
                if (_staffUniqueId == null)
                    _staffUniqueId = PersonUniqueIdToUsiCache.GetCache().GetUniqueId("Staff", _staffUSI);
                    
                return _staffUniqueId;
            }
            set
            {
                if (_staffUniqueId != value)
                        _staffUSI = default(int);

                _staffUniqueId = value;
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
        public virtual NHibernate.StaffEducationOrganizationEmploymentAssociationAggregate.EdFi.StaffEducationOrganizationEmploymentAssociationReferenceData StaffEducationOrganizationEmploymentAssociationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the StaffEducationOrganizationEmploymentAssociation discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation.StaffEducationOrganizationEmploymentAssociationDiscriminator
        {
            get { return StaffEducationOrganizationEmploymentAssociationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the StaffEducationOrganizationEmploymentAssociation resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation.StaffEducationOrganizationEmploymentAssociationResourceId
        {
            get { return StaffEducationOrganizationEmploymentAssociationReferenceData?.Id; }
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
                { "EmploymentStatusDescriptor", new LookupColumnDetails { PropertyName = "EmploymentStatusDescriptorId", LookupTypeName = "EmploymentStatusDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentParentAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);
            keyValues.Add("EmploymentStatusDescriptorId", EmploymentStatusDescriptorId);
            keyValues.Add("HireDate", HireDate);
            keyValues.Add("StaffUSI", StaffUSI);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentParentAssociation = (EdFi.StudentParentAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationTelephone table of the StudentParentAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationTelephone : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentParentAssociationTelephone, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentParentAssociationTelephone()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentParentAssociation StudentParentAssociation { get; set; }

        Entities.Common.Sample.IStudentParentAssociationExtension IStudentParentAssociationTelephone.StudentParentAssociationExtension
        {
            get { return (IStudentParentAssociationExtension) StudentParentAssociation.Extensions["Sample"]; }
            set { StudentParentAssociation.Extensions["Sample"] = value; }
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
        [Range(1, 2147483647)]
        public virtual int? OrderOfPriority  { get; set; }
        [RequiredWithNonDefault, StringLength(24, MinimumLength=1), NoDangerousText]
        public virtual string TelephoneNumber  { get; set; }
        [RequiredWithNonDefault]
        public virtual int TelephoneNumberTypeDescriptorId 
        {
            get
            {
                if (_telephoneNumberTypeDescriptorId == default(int))
                    _telephoneNumberTypeDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("TelephoneNumberTypeDescriptor", _telephoneNumberTypeDescriptor);

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
                    _telephoneNumberTypeDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("TelephoneNumberTypeDescriptor", _telephoneNumberTypeDescriptorId);
                    
                return _telephoneNumberTypeDescriptor;
            }
            set
            {
                _telephoneNumberTypeDescriptor = value;
                _telephoneNumberTypeDescriptorId = default(int);
            }
        }
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
            var keyValues = (StudentParentAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentParentAssociationTelephone)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentParentAssociationTelephone) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentParentAssociation = (EdFi.StudentParentAssociation) value;
        }
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationExtension table of the StudentParentAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentParentAssociationExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentParentAssociationExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentParentAssociation StudentParentAssociation { get; set; }

        Entities.Common.EdFi.IStudentParentAssociation IStudentParentAssociationExtension.StudentParentAssociation
        {
            get { return StudentParentAssociation; }
            set { StudentParentAssociation = (EdFi.StudentParentAssociation) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual bool BedtimeReader  { get; set; }
        [Range(typeof(decimal), "-9.9999", "9.9999")]
        public virtual decimal? BedtimeReadingRate  { get; set; }
        [Range(typeof(decimal), "-922337203685477.5808", "922337203685477.5807")]
        public virtual decimal? BookBudget  { get; set; }
        public virtual int? BooksBorrowed  { get; set; }
        public virtual int? EducationOrganizationId  { get; set; }
        [StringLength(60, MinimumLength=1), NoDangerousText]
        public virtual string InterventionStudyIdentificationCode  { get; set; }
        [Range(1, 2147483647)]
        public virtual int? LibraryDuration  { get; set; }
        public virtual TimeSpan? LibraryTime  { get; set; }
        public virtual short? LibraryVisits  { get; set; }
        [StringLength(250, MinimumLength=1), NoDangerousText]
        public virtual string PriorContactRestrictions  { get; set; }
        public virtual DateTime? ReadGreenEggsAndHamDate 
        {
            get { return _readGreenEggsAndHamDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _readGreenEggsAndHamDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _readGreenEggsAndHamDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _readGreenEggsAndHamDate;
        
        [StringLength(30, MinimumLength=0), NoDangerousText]
        public virtual string ReadingTimeSpent  { get; set; }
        public virtual short? StudentRead  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // This property implementation exists to provide the mapper with reflection-based access to the target instance's .NET type (for creating new instances)
        public Entities.NHibernate.StudentParentAssociationAggregate.Sample.StudentParentAssociationTelephone StudentParentAssociationTelephone
        {
            get { return (Entities.NHibernate.StudentParentAssociationAggregate.Sample.StudentParentAssociationTelephone) (this as Entities.Common.Sample.IStudentParentAssociationExtension).StudentParentAssociationTelephone;  }
            set { (this as Entities.Common.Sample.IStudentParentAssociationExtension).StudentParentAssociationTelephone = value;  }
        }

        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        Entities.Common.Sample.IStudentParentAssociationTelephone Entities.Common.Sample.IStudentParentAssociationExtension.StudentParentAssociationTelephone
        {
            get
            {
                var list = (IList) StudentParentAssociation.AggregateExtensions["Sample_StudentParentAssociationTelephone"];

                if (list != null && list.Count > 0)
                    return (Entities.Common.Sample.IStudentParentAssociationTelephone) list[0];

                return null;
            }
            set
            {
                // Delete the existing object
                var list = (IList) StudentParentAssociation.AggregateExtensions["Sample_StudentParentAssociationTelephone"] ?? new List<object>();
                list.Clear();

                // If we're setting a value, add it to the list now
                if (value != null)
                {
                    list.Add(value);

                    // Set the parent reference
                    (value as IChildEntity).SetParent(StudentParentAssociation);
                }
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
        public virtual NHibernate.InterventionStudyAggregate.EdFi.InterventionStudyReferenceData InterventionStudyReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the InterventionStudy discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Sample.IStudentParentAssociationExtension.InterventionStudyDiscriminator
        {
            get { return InterventionStudyReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the InterventionStudy resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.IStudentParentAssociationExtension.InterventionStudyResourceId
        {
            get { return InterventionStudyReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<Entities.Common.Sample.IStudentParentAssociationDiscipline> _studentParentAssociationDisciplines;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IStudentParentAssociationDiscipline> IStudentParentAssociationExtension.StudentParentAssociationDisciplines
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StudentParentAssociationDiscipline>((IList<object>) StudentParentAssociation.AggregateExtensions["Sample_StudentParentAssociationDisciplines"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StudentParentAssociationDiscipline item in sourceList)
                    if (item.StudentParentAssociation == null)
                        item.StudentParentAssociation = this.StudentParentAssociation;
                // -------------------------------------------------------------

                if (_studentParentAssociationDisciplines == null)
                    _studentParentAssociationDisciplines = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentParentAssociationDiscipline, StudentParentAssociationDiscipline>(sourceList);

                return _studentParentAssociationDisciplines;
            }
            set
            {
                StudentParentAssociation.AggregateExtensions["Sample_StudentParentAssociationDisciplines"] = value;
            }
        }
        [RequiredCollection]
        private ICollection<Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle> _studentParentAssociationFavoriteBookTitles;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle> IStudentParentAssociationExtension.StudentParentAssociationFavoriteBookTitles
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StudentParentAssociationFavoriteBookTitle>((IList<object>) StudentParentAssociation.AggregateExtensions["Sample_StudentParentAssociationFavoriteBookTitles"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StudentParentAssociationFavoriteBookTitle item in sourceList)
                    if (item.StudentParentAssociation == null)
                        item.StudentParentAssociation = this.StudentParentAssociation;
                // -------------------------------------------------------------

                if (_studentParentAssociationFavoriteBookTitles == null)
                    _studentParentAssociationFavoriteBookTitles = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle, StudentParentAssociationFavoriteBookTitle>(sourceList);

                return _studentParentAssociationFavoriteBookTitles;
            }
            set
            {
                StudentParentAssociation.AggregateExtensions["Sample_StudentParentAssociationFavoriteBookTitles"] = value;
            }
        }
        private ICollection<Entities.Common.Sample.IStudentParentAssociationHoursPerWeek> _studentParentAssociationHoursPerWeeks;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IStudentParentAssociationHoursPerWeek> IStudentParentAssociationExtension.StudentParentAssociationHoursPerWeeks
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StudentParentAssociationHoursPerWeek>((IList<object>) StudentParentAssociation.AggregateExtensions["Sample_StudentParentAssociationHoursPerWeeks"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StudentParentAssociationHoursPerWeek item in sourceList)
                    if (item.StudentParentAssociation == null)
                        item.StudentParentAssociation = this.StudentParentAssociation;
                // -------------------------------------------------------------

                if (_studentParentAssociationHoursPerWeeks == null)
                    _studentParentAssociationHoursPerWeeks = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentParentAssociationHoursPerWeek, StudentParentAssociationHoursPerWeek>(sourceList);

                return _studentParentAssociationHoursPerWeeks;
            }
            set
            {
                StudentParentAssociation.AggregateExtensions["Sample_StudentParentAssociationHoursPerWeeks"] = value;
            }
        }
        private ICollection<Entities.Common.Sample.IStudentParentAssociationPagesRead> _studentParentAssociationPagesReads;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IStudentParentAssociationPagesRead> IStudentParentAssociationExtension.StudentParentAssociationPagesReads
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StudentParentAssociationPagesRead>((IList<object>) StudentParentAssociation.AggregateExtensions["Sample_StudentParentAssociationPagesReads"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StudentParentAssociationPagesRead item in sourceList)
                    if (item.StudentParentAssociation == null)
                        item.StudentParentAssociation = this.StudentParentAssociation;
                // -------------------------------------------------------------

                if (_studentParentAssociationPagesReads == null)
                    _studentParentAssociationPagesReads = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentParentAssociationPagesRead, StudentParentAssociationPagesRead>(sourceList);

                return _studentParentAssociationPagesReads;
            }
            set
            {
                StudentParentAssociation.AggregateExtensions["Sample_StudentParentAssociationPagesReads"] = value;
            }
        }
        private ICollection<Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation> _studentParentAssociationStaffEducationOrganizationEmploymentAssociations;
        // Aggregate extension explicit implementation to redirect model abstraction to the persistent entity location
        ICollection<Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation> IStudentParentAssociationExtension.StudentParentAssociationStaffEducationOrganizationEmploymentAssociations
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StudentParentAssociationStaffEducationOrganizationEmploymentAssociation>((IList<object>) StudentParentAssociation.AggregateExtensions["Sample_StudentParentAssociationStaffEducationOrganizationEmploymentAssociations"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StudentParentAssociationStaffEducationOrganizationEmploymentAssociation item in sourceList)
                    if (item.StudentParentAssociation == null)
                        item.StudentParentAssociation = this.StudentParentAssociation;
                // -------------------------------------------------------------

                if (_studentParentAssociationStaffEducationOrganizationEmploymentAssociations == null)
                    _studentParentAssociationStaffEducationOrganizationEmploymentAssociations = new CovariantCollectionAdapter<Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation, StudentParentAssociationStaffEducationOrganizationEmploymentAssociation>(sourceList);

                return _studentParentAssociationStaffEducationOrganizationEmploymentAssociations;
            }
            set
            {
                StudentParentAssociation.AggregateExtensions["Sample_StudentParentAssociationStaffEducationOrganizationEmploymentAssociations"] = value;
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
            // Get parent key values
            var keyValues = (StudentParentAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentParentAssociationExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentParentAssociationExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentParentAssociation = (EdFi.StudentParentAssociation) value;
        }
    }
}
// Aggregate: StudentSchoolAssociation

namespace EdFi.Ods.Entities.NHibernate.StudentSchoolAssociationAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentSchoolAssociationExtension table of the StudentSchoolAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentSchoolAssociationExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentSchoolAssociationExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentSchoolAssociation StudentSchoolAssociation { get; set; }

        Entities.Common.EdFi.IStudentSchoolAssociation IStudentSchoolAssociationExtension.StudentSchoolAssociation
        {
            get { return StudentSchoolAssociation; }
            set { StudentSchoolAssociation = (EdFi.StudentSchoolAssociation) value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual int? MembershipTypeDescriptorId 
        {
            get
            {
                if (_membershipTypeDescriptorId == default(int?))
                    _membershipTypeDescriptorId = string.IsNullOrWhiteSpace(_membershipTypeDescriptor) ? default(int?) : GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("MembershipTypeDescriptor", _membershipTypeDescriptor);

                return _membershipTypeDescriptorId;
            } 
            set
            {
                _membershipTypeDescriptorId = value;
                _membershipTypeDescriptor = null;
            }
        }

        private int? _membershipTypeDescriptorId;
        private string _membershipTypeDescriptor;

        public virtual string MembershipTypeDescriptor
        {
            get
            {
                if (_membershipTypeDescriptor == null)
                    _membershipTypeDescriptor = _membershipTypeDescriptorId == null ? null : GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("MembershipTypeDescriptor", _membershipTypeDescriptorId.Value);
                    
                return _membershipTypeDescriptor;
            }
            set
            {
                _membershipTypeDescriptor = value;
                _membershipTypeDescriptorId = default(int?);
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
                { "MembershipTypeDescriptor", new LookupColumnDetails { PropertyName = "MembershipTypeDescriptorId", LookupTypeName = "MembershipTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentSchoolAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentSchoolAssociationExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentSchoolAssociationExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentSchoolAssociation = (EdFi.StudentSchoolAssociation) value;
        }
    }
}
// Aggregate: StudentSectionAssociation

namespace EdFi.Ods.Entities.NHibernate.StudentSectionAssociationAggregate.Sample
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the sample.StudentSectionAssociationRelatedGeneralStudentProgramAssociation table of the StudentSectionAssociation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("sample")]
    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationRelatedGeneralStudentProgramAssociation : EntityWithCompositeKey, IChildEntity,
        Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentSectionAssociationRelatedGeneralStudentProgramAssociation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.StudentSectionAssociation StudentSectionAssociation { get; set; }

        Entities.Common.Sample.IStudentSectionAssociationExtension IStudentSectionAssociationRelatedGeneralStudentProgramAssociation.StudentSectionAssociationExtension
        {
            get { return (IStudentSectionAssociationExtension) StudentSectionAssociation.Extensions["Sample"]; }
            set { StudentSectionAssociation.Extensions["Sample"] = value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual DateTime RelatedBeginDate 
        {
            get { return _relatedBeginDate; }
            //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
            set { _relatedBeginDate = new DateTime(value.Year, value.Month, value.Day); }
        }

        private DateTime _relatedBeginDate;
        
        [DomainSignature, RequiredWithNonDefault]
        public virtual int RelatedEducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int RelatedProgramEducationOrganizationId  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(60, MinimumLength=1), NoDangerousText, NoWhitespace]
        public virtual string RelatedProgramName  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int RelatedProgramTypeDescriptorId 
        {
            get
            {
                if (_relatedProgramTypeDescriptorId == default(int))
                    _relatedProgramTypeDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("ProgramTypeDescriptor", _relatedProgramTypeDescriptor);

                return _relatedProgramTypeDescriptorId;
            } 
            set
            {
                _relatedProgramTypeDescriptorId = value;
                _relatedProgramTypeDescriptor = null;
            }
        }

        private int _relatedProgramTypeDescriptorId;
        private string _relatedProgramTypeDescriptor;

        public virtual string RelatedProgramTypeDescriptor
        {
            get
            {
                if (_relatedProgramTypeDescriptor == null)
                    _relatedProgramTypeDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("ProgramTypeDescriptor", _relatedProgramTypeDescriptorId);
                    
                return _relatedProgramTypeDescriptor;
            }
            set
            {
                _relatedProgramTypeDescriptor = value;
                _relatedProgramTypeDescriptorId = default(int);
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
        public virtual NHibernate.GeneralStudentProgramAssociationAggregate.EdFi.GeneralStudentProgramAssociationReferenceData RelatedGeneralStudentProgramAssociationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the RelatedGeneralStudentProgramAssociation discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation.RelatedGeneralStudentProgramAssociationDiscriminator
        {
            get { return RelatedGeneralStudentProgramAssociationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the RelatedGeneralStudentProgramAssociation resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation.RelatedGeneralStudentProgramAssociationResourceId
        {
            get { return RelatedGeneralStudentProgramAssociationReferenceData?.Id; }
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
                { "RelatedProgramTypeDescriptor", new LookupColumnDetails { PropertyName = "RelatedProgramTypeDescriptorId", LookupTypeName = "ProgramTypeDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (StudentSectionAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("RelatedBeginDate", RelatedBeginDate);
            keyValues.Add("RelatedEducationOrganizationId", RelatedEducationOrganizationId);
            keyValues.Add("RelatedProgramEducationOrganizationId", RelatedProgramEducationOrganizationId);
            keyValues.Add("RelatedProgramName", RelatedProgramName);
            keyValues.Add("RelatedProgramTypeDescriptorId", RelatedProgramTypeDescriptorId);

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
            return this.SynchronizeTo((Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentSectionAssociation = (EdFi.StudentSectionAssociation) value;
        }
    }

    /// <summary>
    /// An implicitly created entity extension class to enable entity mapping and sychronization behavior for the StudentSectionAssociation entity's aggregate extensions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationExtension : IStudentSectionAssociationExtension, IChildEntity, IImplicitEntityExtension, IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private EdFi.StudentSectionAssociation _studentSectionAssociation;

        Common.EdFi.IStudentSectionAssociation IStudentSectionAssociationExtension.StudentSectionAssociation
        {
            get { return _studentSectionAssociation; }
            set { _studentSectionAssociation = (EdFi.StudentSectionAssociation) value; }
        }

        private EdFi.StudentSectionAssociation StudentSectionAssociation
        {
            get { return (this as IStudentSectionAssociationExtension).StudentSectionAssociation as EdFi.StudentSectionAssociation; }
        }

        bool IImplicitEntityExtension.IsEmpty()
        {
            return (true
                && ((IList<object>) _studentSectionAssociation.AggregateExtensions["Sample_StudentSectionAssociationRelatedGeneralStudentProgramAssociations"]).Count == 0
            );
        }

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        ICollection<IStudentSectionAssociationRelatedGeneralStudentProgramAssociation> IStudentSectionAssociationExtension.StudentSectionAssociationRelatedGeneralStudentProgramAssociations
        {
            get
            {
                var sourceList =  new ContravariantCollectionAdapter<object, StudentSectionAssociationRelatedGeneralStudentProgramAssociation>((IList<object>) _studentSectionAssociation.AggregateExtensions["Sample_StudentSectionAssociationRelatedGeneralStudentProgramAssociations"]);

                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (StudentSectionAssociationRelatedGeneralStudentProgramAssociation item in sourceList)
                    if (item.StudentSectionAssociation == null)
                        item.StudentSectionAssociation = this.StudentSectionAssociation;
                // -------------------------------------------------------------

                var adaptedList = new CovariantCollectionAdapter<IStudentSectionAssociationRelatedGeneralStudentProgramAssociation, StudentSectionAssociationRelatedGeneralStudentProgramAssociation>(sourceList);

                return adaptedList;
            }
            set
            {
                _studentSectionAssociation.AggregateExtensions["Sample_StudentSectionAssociationRelatedGeneralStudentProgramAssociations"] = value;
            }
        }
        // -------------------------------------------------------------

        void IMappable.Map(object target)
        {
            this.MapTo((IStudentSectionAssociationExtension) target, null);
        }

        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((IStudentSectionAssociationExtension) target);
        }

        void IChildEntity.SetParent(object value)
        {
            _studentSectionAssociation = (EdFi.StudentSectionAssociation)value;
        }

        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            return (_studentSectionAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();
        }

        void IGetByExample.SuspendReferenceAssignmentCheck() { }
    }
}

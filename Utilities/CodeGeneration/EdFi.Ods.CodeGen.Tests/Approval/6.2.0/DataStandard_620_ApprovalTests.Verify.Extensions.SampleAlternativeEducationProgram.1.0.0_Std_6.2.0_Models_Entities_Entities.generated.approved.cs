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
using EdFi.Ods.Entities.Common.SampleAlternativeEducationProgram;
using Newtonsoft.Json;
using MessagePack;
using KeyAttribute = MessagePack.KeyAttribute;

// Aggregate: AlternativeEducationEligibilityReasonDescriptor

namespace EdFi.Ods.Entities.NHibernate.AlternativeEducationEligibilityReasonDescriptorAggregate.SampleAlternativeEducationProgram
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the samplealternativeeducationprogram.AlternativeEducationEligibilityReasonDescriptor table of the AlternativeEducationEligibilityReasonDescriptor aggregate in the ODS database.
    /// </summary>
    [Schema("samplealternativeeducationprogram")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class AlternativeEducationEligibilityReasonDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.SampleAlternativeEducationProgram.IAlternativeEducationEligibilityReasonDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
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
        public virtual int AlternativeEducationEligibilityReasonDescriptorId 
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
            keyValues.Add("AlternativeEducationEligibilityReasonDescriptorId", AlternativeEducationEligibilityReasonDescriptorId);

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
            return this.SynchronizeTo((Entities.Common.SampleAlternativeEducationProgram.IAlternativeEducationEligibilityReasonDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.SampleAlternativeEducationProgram.IAlternativeEducationEligibilityReasonDescriptor) target, null);
        }

    }
}
// Aggregate: StudentAlternativeEducationProgramAssociation

namespace EdFi.Ods.Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation table of the StudentAlternativeEducationProgramAssociation aggregate in the ODS database.
    /// </summary>
    [Schema("samplealternativeeducationprogram")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class StudentAlternativeEducationProgramAssociation : GeneralStudentProgramAssociationAggregate.EdFi.GeneralStudentProgramAssociation,
        Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public StudentAlternativeEducationProgramAssociation()
        {
            StudentAlternativeEducationProgramAssociationMeetingTimes = new HashSet<StudentAlternativeEducationProgramAssociationMeetingTime>();
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
        [IgnoreMember]
        public override DateTime BeginDate { get => base.BeginDate; set => base.BeginDate = value; }

        [DomainSignature]
        [IgnoreMember]
        public override long EducationOrganizationId { get => base.EducationOrganizationId; set => base.EducationOrganizationId = value; }

        [DomainSignature]
        [IgnoreMember]
        public override long ProgramEducationOrganizationId { get => base.ProgramEducationOrganizationId; set => base.ProgramEducationOrganizationId = value; }

        [DomainSignature]
        [IgnoreMember]
        public override string ProgramName { get => base.ProgramName; set => base.ProgramName = value; }

        [DomainSignature]
        [IgnoreMember]
        public override int ProgramTypeDescriptorId { get => base.ProgramTypeDescriptorId; set => base.ProgramTypeDescriptorId = value; }

        [Display(Name="StudentUniqueId")][DomainSignature]
        [IgnoreMember]
        public override int StudentUSI { get => base.StudentUSI; set => base.StudentUSI = value; }

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
        [Key(19)]
        public virtual int AlternativeEducationEligibilityReasonDescriptorId 
        {
            get
            {
                if (_alternativeEducationEligibilityReasonDescriptorId == default(int))
                {
                    _alternativeEducationEligibilityReasonDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("AlternativeEducationEligibilityReasonDescriptor", _alternativeEducationEligibilityReasonDescriptor);
                }

                return _alternativeEducationEligibilityReasonDescriptorId;
            } 
            set
            {
                _alternativeEducationEligibilityReasonDescriptorId = value;
                _alternativeEducationEligibilityReasonDescriptor = null;
            }
        }

        private int _alternativeEducationEligibilityReasonDescriptorId;
        private string _alternativeEducationEligibilityReasonDescriptor;

        [IgnoreMember]
        public virtual string AlternativeEducationEligibilityReasonDescriptor
        {
            get
            {
                if (_alternativeEducationEligibilityReasonDescriptor == null)
                    _alternativeEducationEligibilityReasonDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("AlternativeEducationEligibilityReasonDescriptor", _alternativeEducationEligibilityReasonDescriptorId);
                    
                return _alternativeEducationEligibilityReasonDescriptor;
            }
            set
            {
                _alternativeEducationEligibilityReasonDescriptor = value;
                _alternativeEducationEligibilityReasonDescriptorId = default(int);
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

        private ICollection<Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMeetingTime> _studentAlternativeEducationProgramAssociationMeetingTimes;
        private ICollection<Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime> _studentAlternativeEducationProgramAssociationMeetingTimesCovariant;
        [Key(20)]
        [MessagePackFormatter(typeof(PersistentCollectionFormatter<Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMeetingTime>))]
        public virtual ICollection<Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMeetingTime> StudentAlternativeEducationProgramAssociationMeetingTimes
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                if (_studentAlternativeEducationProgramAssociationMeetingTimes is DeserializedPersistentGenericSet<Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMeetingTime> set)
                {
                    set.Reattach(this, "StudentAlternativeEducationProgramAssociationMeetingTimes");
                }
            
                foreach (var item in _studentAlternativeEducationProgramAssociationMeetingTimes)
                    if (item.StudentAlternativeEducationProgramAssociation == null)
                        item.StudentAlternativeEducationProgramAssociation = this;
                // -------------------------------------------------------------

                return _studentAlternativeEducationProgramAssociationMeetingTimes;
            }
            set
            {
                _studentAlternativeEducationProgramAssociationMeetingTimes = value;
                _studentAlternativeEducationProgramAssociationMeetingTimesCovariant = new CovariantCollectionAdapter<Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime, Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMeetingTime>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime> Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation.StudentAlternativeEducationProgramAssociationMeetingTimes
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _studentAlternativeEducationProgramAssociationMeetingTimes)
                    if (item.StudentAlternativeEducationProgramAssociation == null)
                        item.StudentAlternativeEducationProgramAssociation = this;
                // -------------------------------------------------------------

                return _studentAlternativeEducationProgramAssociationMeetingTimesCovariant;
            }
            set
            {
                StudentAlternativeEducationProgramAssociationMeetingTimes = new HashSet<Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMeetingTime>(value.Cast<Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMeetingTime>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "AlternativeEducationEligibilityReasonDescriptor", new LookupColumnDetails { PropertyName = "AlternativeEducationEligibilityReasonDescriptorId", LookupTypeName = "AlternativeEducationEligibilityReasonDescriptor"} },
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
            return this.SynchronizeTo((Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapDerivedTo((Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation) target, null);
        }

    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime table of the StudentAlternativeEducationProgramAssociation aggregate in the ODS database.
    /// </summary>
    [Schema("samplealternativeeducationprogram")]
    [ExcludeFromCodeCoverage]
    [MessagePackObject]
    public class StudentAlternativeEducationProgramAssociationMeetingTime : EntityWithCompositeKey, IChildEntity,
        Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentAlternativeEducationProgramAssociationMeetingTime()
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
        public virtual StudentAlternativeEducationProgramAssociation StudentAlternativeEducationProgramAssociation { get; set; }

        Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation IStudentAlternativeEducationProgramAssociationMeetingTime.StudentAlternativeEducationProgramAssociation
        {
            get { return StudentAlternativeEducationProgramAssociation; }
            set { StudentAlternativeEducationProgramAssociation = (StudentAlternativeEducationProgramAssociation) value; }
        }

        [DomainSignature]
        [Key(1)]
        public virtual TimeSpan EndTime { get => _endTime; set { _endTime = value; } }
        private TimeSpan _endTime;

        [DomainSignature]
        [Key(2)]
        public virtual TimeSpan StartTime { get => _startTime; set { _startTime = value; } }
        private TimeSpan _startTime;

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
            var keyValues = (StudentAlternativeEducationProgramAssociation as IHasPrimaryKeyValues)?.GetPrimaryKeyValues() ?? new OrderedDictionary();

            // Add current key values
            keyValues.Add("EndTime", EndTime);
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
            return this.SynchronizeTo((Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            StudentAlternativeEducationProgramAssociation = (StudentAlternativeEducationProgramAssociation) value;
        }
    }
}

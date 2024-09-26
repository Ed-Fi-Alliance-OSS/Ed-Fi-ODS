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
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Entities.Common.SampleAlternativeEducationProgram;
using Newtonsoft.Json;

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
    public class AlternativeEducationEligibilityReasonDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.SampleAlternativeEducationProgram.IAlternativeEducationEligibilityReasonDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
    {

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
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
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
        public override DateTime BeginDate  { get; set; }
        [DomainSignature]
        public override long EducationOrganizationId  { get; set; }
        [DomainSignature]
        public override long ProgramEducationOrganizationId  { get; set; }
        [DomainSignature]
        public override string ProgramName  { get; set; }
        [DomainSignature]
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
        [Display(Name="StudentUniqueId")][DomainSignature]
        public override int StudentUSI 
        {
            get
            {
                if (_studentUSI == default(int) && _studentUniqueId != null)
                {
                    if (GeneratedArtifactStaticDependencies.UsiLookupsByUniqueIdContextProvider.Get().UsiByUniqueIdByPersonType.TryGetValue("Student", out var usiByUniqueId)
                        && usiByUniqueId.TryGetValue(_studentUniqueId, out var usi))
                    {
                        _studentUSI = usi;
                    }
                }

                return _studentUSI;
            } 
            set
            {
                _studentUSI = value;
                GeneratedArtifactStaticDependencies.UniqueIdLookupsByUsiContextProvider.Get().AddLookup("Student", value);
            }
        }

        private int _studentUSI;
        private string _studentUniqueId;

        public override string StudentUniqueId
        {
            get
            {
                if (_studentUniqueId == null)
                {
                    if (GeneratedArtifactStaticDependencies.UniqueIdLookupsByUsiContextProvider.Get().UniqueIdByUsiByPersonType.TryGetValue("Student", out var uniqueIdByUsi)
                        && uniqueIdByUsi.TryGetValue(_studentUSI, out var uniqueId))
                    {
                        _studentUniqueId = uniqueId;
                    }
                }

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
        public virtual int AlternativeEducationEligibilityReasonDescriptorId 
        {
            get
            {
                if (_alternativeEducationEligibilityReasonDescriptorId == default(int))
                    _alternativeEducationEligibilityReasonDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("AlternativeEducationEligibilityReasonDescriptor", _alternativeEducationEligibilityReasonDescriptor);

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

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMeetingTime> _studentAlternativeEducationProgramAssociationMeetingTimes;
        private ICollection<Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime> _studentAlternativeEducationProgramAssociationMeetingTimesCovariant;
        public virtual ICollection<Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMeetingTime> StudentAlternativeEducationProgramAssociationMeetingTimes
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
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
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore]
        public virtual StudentAlternativeEducationProgramAssociation StudentAlternativeEducationProgramAssociation { get; set; }

        Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation IStudentAlternativeEducationProgramAssociationMeetingTime.StudentAlternativeEducationProgramAssociation
        {
            get { return StudentAlternativeEducationProgramAssociation; }
            set { StudentAlternativeEducationProgramAssociation = (StudentAlternativeEducationProgramAssociation) value; }
        }

        [DomainSignature]
        public virtual TimeSpan EndTime  { get; set; }
        [DomainSignature]
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
            var keyValues = (StudentAlternativeEducationProgramAssociation as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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

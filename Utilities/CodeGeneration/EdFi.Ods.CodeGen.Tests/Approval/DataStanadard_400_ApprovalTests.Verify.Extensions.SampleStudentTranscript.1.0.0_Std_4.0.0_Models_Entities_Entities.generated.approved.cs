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
using EdFi.Ods.Entities.Common.SampleStudentTranscript;
using Newtonsoft.Json;

// Aggregate: InstitutionControlDescriptor

namespace EdFi.Ods.Entities.NHibernate.InstitutionControlDescriptorAggregate.SampleStudentTranscript
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the samplestudenttranscript.InstitutionControlDescriptor table of the InstitutionControlDescriptor aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    public class InstitutionControlDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.SampleStudentTranscript.IInstitutionControlDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
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
    [Serializable, Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    public class InstitutionLevelDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.SampleStudentTranscript.IInstitutionLevelDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
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
    public class PostSecondaryOrganizationReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string NameOfInstitution { get; set; }
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
    [Serializable, Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    public class PostSecondaryOrganization : AggregateRootWithCompositeKey,
        Entities.Common.SampleStudentTranscript.IPostSecondaryOrganization, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public PostSecondaryOrganization()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(75, MinimumLength=0), NoDangerousText, NoWhitespace]
        public virtual string NameOfInstitution  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        public virtual bool AcceptanceIndicator  { get; set; }
        [RequiredWithNonDefault]
        public virtual int InstitutionControlDescriptorId 
        {
            get
            {
                if (_institutionControlDescriptorId == default(int))
                    _institutionControlDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("InstitutionControlDescriptor", _institutionControlDescriptor);

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
        [RequiredWithNonDefault]
        public virtual int InstitutionLevelDescriptorId 
        {
            get
            {
                if (_institutionLevelDescriptorId == default(int))
                    _institutionLevelDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("InstitutionLevelDescriptor", _institutionLevelDescriptor);

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
    [Serializable, Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    public class SpecialEducationGraduationStatusDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.SampleStudentTranscript.ISpecialEducationGraduationStatusDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
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
    [Serializable, Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    public class StudentAcademicRecordExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentAcademicRecordExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
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
        [StringLength(75, MinimumLength=0), NoDangerousText]
        public virtual string NameOfInstitution  { get; set; }
        public virtual int? SubmissionCertificationDescriptorId 
        {
            get
            {
                if (_submissionCertificationDescriptorId == default(int?))
                    _submissionCertificationDescriptorId = string.IsNullOrWhiteSpace(_submissionCertificationDescriptor) ? default(int?) : GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("SubmissionCertificationDescriptor", _submissionCertificationDescriptor);

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

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        public virtual NHibernate.PostSecondaryOrganizationAggregate.SampleStudentTranscript.PostSecondaryOrganizationReferenceData PostSecondaryOrganizationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the PostSecondaryOrganization discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension.PostSecondaryOrganizationDiscriminator
        {
            get { return PostSecondaryOrganizationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the PostSecondaryOrganization resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension.PostSecondaryOrganizationResourceId
        {
            get { return PostSecondaryOrganizationReferenceData?.Id; }
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
            var keyValues = (StudentAcademicRecord as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
    [Serializable, Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    public class StudentAcademicRecordClassRankingExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.SampleStudentTranscript.IStudentAcademicRecordClassRankingExtension, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentAcademicRecordClassRankingExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
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
        [RequiredWithNonDefault]
        public virtual int SpecialEducationGraduationStatusDescriptorId 
        {
            get
            {
                if (_specialEducationGraduationStatusDescriptorId == default(int))
                    _specialEducationGraduationStatusDescriptorId = GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("SpecialEducationGraduationStatusDescriptor", _specialEducationGraduationStatusDescriptor);

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
            var keyValues = (StudentAcademicRecordClassRanking as IHasPrimaryKeyValues).GetPrimaryKeyValues();

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
    [Serializable, Schema("samplestudenttranscript")]
    [ExcludeFromCodeCoverage]
    public class SubmissionCertificationDescriptor : DescriptorAggregate.EdFi.Descriptor,
        Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, IEdFiDescriptor
    {
        private static readonly IEqualityComparer<string> _databaseEngineSpecificStringComparer = GeneratedArtifactStaticDependencies
                                                                                                    .DatabaseEngineSpecificStringComparerProvider
                                                                                                    .GetEqualityComparer();

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature]
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
            return this.SynchronizeTo((Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor) target, null);
        }

    }
}

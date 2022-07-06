using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Entities.Common.EdFi;
// Aggregate: InstitutionControlDescriptor

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript //.InstitutionControlDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class InstitutionControlDescriptorMapper
    {
        public static bool SynchronizeTo(this IInstitutionControlDescriptor source, IInstitutionControlDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IInstitutionControlDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.InstitutionControlDescriptorId != target.InstitutionControlDescriptorId)
            {
                source.InstitutionControlDescriptorId = target.InstitutionControlDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IInstitutionControlDescriptor source, IInstitutionControlDescriptor target, Action<IInstitutionControlDescriptor, IInstitutionControlDescriptor> onMapped)
        {
            var sourceSynchSupport = source as IInstitutionControlDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IInstitutionControlDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.InstitutionControlDescriptorId = source.InstitutionControlDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IInstitutionControlDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: InstitutionLevelDescriptor

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript //.InstitutionLevelDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class InstitutionLevelDescriptorMapper
    {
        public static bool SynchronizeTo(this IInstitutionLevelDescriptor source, IInstitutionLevelDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IInstitutionLevelDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.InstitutionLevelDescriptorId != target.InstitutionLevelDescriptorId)
            {
                source.InstitutionLevelDescriptorId = target.InstitutionLevelDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IInstitutionLevelDescriptor source, IInstitutionLevelDescriptor target, Action<IInstitutionLevelDescriptor, IInstitutionLevelDescriptor> onMapped)
        {
            var sourceSynchSupport = source as IInstitutionLevelDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IInstitutionLevelDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.InstitutionLevelDescriptorId = source.InstitutionLevelDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IInstitutionLevelDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: PostSecondaryOrganization

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript //.PostSecondaryOrganizationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class PostSecondaryOrganizationMapper
    {
        public static bool SynchronizeTo(this IPostSecondaryOrganization source, IPostSecondaryOrganization target)
        {
            bool isModified = false;

            var sourceSupport = source as IPostSecondaryOrganizationSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.NameOfInstitution != target.NameOfInstitution)
            {
                source.NameOfInstitution = target.NameOfInstitution;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsAcceptanceIndicatorSupported)
                && target.AcceptanceIndicator != source.AcceptanceIndicator)
            {
                target.AcceptanceIndicator = source.AcceptanceIndicator;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsInstitutionControlDescriptorSupported)
                && target.InstitutionControlDescriptor != source.InstitutionControlDescriptor)
            {
                target.InstitutionControlDescriptor = source.InstitutionControlDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsInstitutionLevelDescriptorSupported)
                && target.InstitutionLevelDescriptor != source.InstitutionLevelDescriptor)
            {
                target.InstitutionLevelDescriptor = source.InstitutionLevelDescriptor;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IPostSecondaryOrganization source, IPostSecondaryOrganization target, Action<IPostSecondaryOrganization, IPostSecondaryOrganization> onMapped)
        {
            var sourceSynchSupport = source as IPostSecondaryOrganizationSynchronizationSourceSupport;
            var targetSynchSupport = target as IPostSecondaryOrganizationSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.NameOfInstitution = source.NameOfInstitution;

            // Copy non-PK properties

            if (sourceSynchSupport.IsAcceptanceIndicatorSupported)
                target.AcceptanceIndicator = source.AcceptanceIndicator;
            else
                targetSynchSupport.IsAcceptanceIndicatorSupported = false;

            if (sourceSynchSupport.IsInstitutionControlDescriptorSupported)
                target.InstitutionControlDescriptor = source.InstitutionControlDescriptor;
            else
                targetSynchSupport.IsInstitutionControlDescriptorSupported = false;

            if (sourceSynchSupport.IsInstitutionLevelDescriptorSupported)
                target.InstitutionLevelDescriptor = source.InstitutionLevelDescriptor;
            else
                targetSynchSupport.IsInstitutionLevelDescriptorSupported = false;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IPostSecondaryOrganizationSynchronizationSourceSupport 
    {
        bool IsAcceptanceIndicatorSupported { get; set; }
        bool IsInstitutionControlDescriptorSupported { get; set; }
        bool IsInstitutionLevelDescriptorSupported { get; set; }
    }

}
// Aggregate: SpecialEducationGraduationStatusDescriptor

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript //.SpecialEducationGraduationStatusDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SpecialEducationGraduationStatusDescriptorMapper
    {
        public static bool SynchronizeTo(this ISpecialEducationGraduationStatusDescriptor source, ISpecialEducationGraduationStatusDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as ISpecialEducationGraduationStatusDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.SpecialEducationGraduationStatusDescriptorId != target.SpecialEducationGraduationStatusDescriptorId)
            {
                source.SpecialEducationGraduationStatusDescriptorId = target.SpecialEducationGraduationStatusDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this ISpecialEducationGraduationStatusDescriptor source, ISpecialEducationGraduationStatusDescriptor target, Action<ISpecialEducationGraduationStatusDescriptor, ISpecialEducationGraduationStatusDescriptor> onMapped)
        {
            var sourceSynchSupport = source as ISpecialEducationGraduationStatusDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as ISpecialEducationGraduationStatusDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.SpecialEducationGraduationStatusDescriptorId = source.SpecialEducationGraduationStatusDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ISpecialEducationGraduationStatusDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: StudentAcademicRecord

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript //.StudentAcademicRecordAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentAcademicRecordClassRankingExtensionMapper
    {
        public static bool SynchronizeTo(this IStudentAcademicRecordClassRankingExtension source, IStudentAcademicRecordClassRankingExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentAcademicRecordClassRankingExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.StudentAcademicRecordClassRanking as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("SampleStudentTranscript"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsSpecialEducationGraduationStatusDescriptorSupported)
                && target.SpecialEducationGraduationStatusDescriptor != source.SpecialEducationGraduationStatusDescriptor)
            {
                target.SpecialEducationGraduationStatusDescriptor = source.SpecialEducationGraduationStatusDescriptor;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentAcademicRecordClassRankingExtension source, IStudentAcademicRecordClassRankingExtension target, Action<IStudentAcademicRecordClassRankingExtension, IStudentAcademicRecordClassRankingExtension> onMapped)
        {
            var sourceSynchSupport = source as IStudentAcademicRecordClassRankingExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentAcademicRecordClassRankingExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsSpecialEducationGraduationStatusDescriptorSupported)
                target.SpecialEducationGraduationStatusDescriptor = source.SpecialEducationGraduationStatusDescriptor;
            else
                targetSynchSupport.IsSpecialEducationGraduationStatusDescriptorSupported = false;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IStudentAcademicRecordClassRankingExtensionSynchronizationSourceSupport 
    {
        bool IsSpecialEducationGraduationStatusDescriptorSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentAcademicRecordExtensionMapper
    {
        public static bool SynchronizeTo(this IStudentAcademicRecordExtension source, IStudentAcademicRecordExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentAcademicRecordExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.StudentAcademicRecord as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("SampleStudentTranscript"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsNameOfInstitutionSupported)
                && target.NameOfInstitution != source.NameOfInstitution)
            {
                target.NameOfInstitution = source.NameOfInstitution;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsSubmissionCertificationDescriptorSupported)
                && target.SubmissionCertificationDescriptor != source.SubmissionCertificationDescriptor)
            {
                target.SubmissionCertificationDescriptor = source.SubmissionCertificationDescriptor;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentAcademicRecordExtension source, IStudentAcademicRecordExtension target, Action<IStudentAcademicRecordExtension, IStudentAcademicRecordExtension> onMapped)
        {
            var sourceSynchSupport = source as IStudentAcademicRecordExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentAcademicRecordExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsNameOfInstitutionSupported)
                target.NameOfInstitution = source.NameOfInstitution;
            else
                targetSynchSupport.IsNameOfInstitutionSupported = false;

            if (sourceSynchSupport.IsSubmissionCertificationDescriptorSupported)
                target.SubmissionCertificationDescriptor = source.SubmissionCertificationDescriptor;
            else
                targetSynchSupport.IsSubmissionCertificationDescriptorSupported = false;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.PostSecondaryOrganizationResourceId = source.PostSecondaryOrganizationResourceId;
                target.PostSecondaryOrganizationDiscriminator = source.PostSecondaryOrganizationDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IStudentAcademicRecordExtensionSynchronizationSourceSupport 
    {
        bool IsNameOfInstitutionSupported { get; set; }
        bool IsSubmissionCertificationDescriptorSupported { get; set; }
    }

}
// Aggregate: SubmissionCertificationDescriptor

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript //.SubmissionCertificationDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SubmissionCertificationDescriptorMapper
    {
        public static bool SynchronizeTo(this ISubmissionCertificationDescriptor source, ISubmissionCertificationDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as ISubmissionCertificationDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.SubmissionCertificationDescriptorId != target.SubmissionCertificationDescriptorId)
            {
                source.SubmissionCertificationDescriptorId = target.SubmissionCertificationDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this ISubmissionCertificationDescriptor source, ISubmissionCertificationDescriptor target, Action<ISubmissionCertificationDescriptor, ISubmissionCertificationDescriptor> onMapped)
        {
            var sourceSynchSupport = source as ISubmissionCertificationDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as ISubmissionCertificationDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.SubmissionCertificationDescriptorId = source.SubmissionCertificationDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ISubmissionCertificationDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}

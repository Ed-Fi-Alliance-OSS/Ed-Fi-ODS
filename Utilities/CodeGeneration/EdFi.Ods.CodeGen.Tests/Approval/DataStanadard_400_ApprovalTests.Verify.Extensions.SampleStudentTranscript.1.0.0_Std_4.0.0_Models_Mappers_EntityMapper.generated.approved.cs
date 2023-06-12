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
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Entities.Common.EdFi;
// Aggregate: InstitutionControlDescriptor

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript //.InstitutionControlDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class InstitutionControlDescriptorMapper
    {
        private static readonly FullName _fullName_samplestudenttranscript_InstitutionControlDescriptor = new FullName("samplestudenttranscript", "InstitutionControlDescriptor");
    
        public static bool SynchronizeTo(this IInstitutionControlDescriptor source, IInstitutionControlDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (InstitutionControlDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_InstitutionControlDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.InstitutionControlDescriptorId != target.InstitutionControlDescriptorId)
            {
                source.InstitutionControlDescriptorId = target.InstitutionControlDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (InstitutionControlDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_InstitutionControlDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.InstitutionControlDescriptorId = source.InstitutionControlDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

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

}
// Aggregate: InstitutionLevelDescriptor

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript //.InstitutionLevelDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class InstitutionLevelDescriptorMapper
    {
        private static readonly FullName _fullName_samplestudenttranscript_InstitutionLevelDescriptor = new FullName("samplestudenttranscript", "InstitutionLevelDescriptor");
    
        public static bool SynchronizeTo(this IInstitutionLevelDescriptor source, IInstitutionLevelDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (InstitutionLevelDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_InstitutionLevelDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.InstitutionLevelDescriptorId != target.InstitutionLevelDescriptorId)
            {
                source.InstitutionLevelDescriptorId = target.InstitutionLevelDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (InstitutionLevelDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_InstitutionLevelDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.InstitutionLevelDescriptorId = source.InstitutionLevelDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

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

}
// Aggregate: PostSecondaryOrganization

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript //.PostSecondaryOrganizationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class PostSecondaryOrganizationMapper
    {
        private static readonly FullName _fullName_samplestudenttranscript_PostSecondaryOrganization = new FullName("samplestudenttranscript", "PostSecondaryOrganization");
    
        public static bool SynchronizeTo(this IPostSecondaryOrganization source, IPostSecondaryOrganization target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (PostSecondaryOrganizationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_PostSecondaryOrganization);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.NameOfInstitution != target.NameOfInstitution)
            {
                source.NameOfInstitution = target.NameOfInstitution;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsAcceptanceIndicatorSupported != false)
                && target.AcceptanceIndicator != source.AcceptanceIndicator)
            {
                target.AcceptanceIndicator = source.AcceptanceIndicator;
                isModified = true;
            }

            if ((mappingContract?.IsInstitutionControlDescriptorSupported != false)
                && target.InstitutionControlDescriptor != source.InstitutionControlDescriptor)
            {
                target.InstitutionControlDescriptor = source.InstitutionControlDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsInstitutionLevelDescriptorSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (PostSecondaryOrganizationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_PostSecondaryOrganization);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.NameOfInstitution = source.NameOfInstitution;

            // Copy non-PK properties

            if (mappingContract?.IsAcceptanceIndicatorSupported != false)
                target.AcceptanceIndicator = source.AcceptanceIndicator;

            if (mappingContract?.IsInstitutionControlDescriptorSupported != false)
                target.InstitutionControlDescriptor = source.InstitutionControlDescriptor;

            if (mappingContract?.IsInstitutionLevelDescriptorSupported != false)
                target.InstitutionLevelDescriptor = source.InstitutionLevelDescriptor;

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

}
// Aggregate: SpecialEducationGraduationStatusDescriptor

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript //.SpecialEducationGraduationStatusDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SpecialEducationGraduationStatusDescriptorMapper
    {
        private static readonly FullName _fullName_samplestudenttranscript_SpecialEducationGraduationStatusDescriptor = new FullName("samplestudenttranscript", "SpecialEducationGraduationStatusDescriptor");
    
        public static bool SynchronizeTo(this ISpecialEducationGraduationStatusDescriptor source, ISpecialEducationGraduationStatusDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (SpecialEducationGraduationStatusDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_SpecialEducationGraduationStatusDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.SpecialEducationGraduationStatusDescriptorId != target.SpecialEducationGraduationStatusDescriptorId)
            {
                source.SpecialEducationGraduationStatusDescriptorId = target.SpecialEducationGraduationStatusDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (SpecialEducationGraduationStatusDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_SpecialEducationGraduationStatusDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.SpecialEducationGraduationStatusDescriptorId = source.SpecialEducationGraduationStatusDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

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

}
// Aggregate: StudentAcademicRecord

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript //.StudentAcademicRecordAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentAcademicRecordClassRankingExtensionMapper
    {
        private static readonly FullName _fullName_samplestudenttranscript_StudentAcademicRecordClassRankingExtension = new FullName("samplestudenttranscript", "StudentAcademicRecordClassRankingExtension");
    
        public static bool SynchronizeTo(this IStudentAcademicRecordClassRankingExtension source, IStudentAcademicRecordClassRankingExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentAcademicRecordClassRankingExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_StudentAcademicRecordClassRankingExtension);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((mappingContract?.IsSpecialEducationGraduationStatusDescriptorSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentAcademicRecordClassRankingExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_StudentAcademicRecordClassRankingExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsSpecialEducationGraduationStatusDescriptorSupported != false)
                target.SpecialEducationGraduationStatusDescriptor = source.SpecialEducationGraduationStatusDescriptor;

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

    [ExcludeFromCodeCoverage]
    public static class StudentAcademicRecordExtensionMapper
    {
        private static readonly FullName _fullName_samplestudenttranscript_StudentAcademicRecordExtension = new FullName("samplestudenttranscript", "StudentAcademicRecordExtension");
    
        public static bool SynchronizeTo(this IStudentAcademicRecordExtension source, IStudentAcademicRecordExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentAcademicRecordExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_StudentAcademicRecordExtension);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((mappingContract?.IsNameOfInstitutionSupported != false)
                && target.NameOfInstitution != source.NameOfInstitution)
            {
                target.NameOfInstitution = source.NameOfInstitution;
                isModified = true;
            }

            if ((mappingContract?.IsSubmissionCertificationDescriptorSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentAcademicRecordExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_StudentAcademicRecordExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsNameOfInstitutionSupported != false)
                target.NameOfInstitution = source.NameOfInstitution;

            if (mappingContract?.IsSubmissionCertificationDescriptorSupported != false)
                target.SubmissionCertificationDescriptor = source.SubmissionCertificationDescriptor;

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

}
// Aggregate: SubmissionCertificationDescriptor

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript //.SubmissionCertificationDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SubmissionCertificationDescriptorMapper
    {
        private static readonly FullName _fullName_samplestudenttranscript_SubmissionCertificationDescriptor = new FullName("samplestudenttranscript", "SubmissionCertificationDescriptor");
    
        public static bool SynchronizeTo(this ISubmissionCertificationDescriptor source, ISubmissionCertificationDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (SubmissionCertificationDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_SubmissionCertificationDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.SubmissionCertificationDescriptorId != target.SubmissionCertificationDescriptorId)
            {
                source.SubmissionCertificationDescriptorId = target.SubmissionCertificationDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (SubmissionCertificationDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttranscript_SubmissionCertificationDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.SubmissionCertificationDescriptorId = source.SubmissionCertificationDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

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

}

using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Entities.Common.EdFi;
// Aggregate: AlternativeEducationEligibilityReasonDescriptor

namespace EdFi.Ods.Entities.Common.SampleAlternativeEducationProgram //.AlternativeEducationEligibilityReasonDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class AlternativeEducationEligibilityReasonDescriptorMapper
    {
        private static readonly FullName _fullName_samplealternativeeducationprogram_AlternativeEducationEligibilityReasonDescriptor = new FullName("samplealternativeeducationprogram", "AlternativeEducationEligibilityReasonDescriptor");
    
        public static bool SynchronizeTo(this IAlternativeEducationEligibilityReasonDescriptor source, IAlternativeEducationEligibilityReasonDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (AlternativeEducationEligibilityReasonDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplealternativeeducationprogram_AlternativeEducationEligibilityReasonDescriptor);

            // Detect primary key changes
            if (
                !string.Equals(target.Namespace, source.Namespace, StringComparison.OrdinalIgnoreCase) 
                || !string.Equals(target.CodeValue, source.CodeValue, StringComparison.OrdinalIgnoreCase))
            {
                // Disallow PK column updates on AlternativeEducationEligibilityReasonDescriptor
                throw new KeyChangeNotSupportedException("AlternativeEducationEligibilityReasonDescriptor");
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

        public static void MapTo(this IAlternativeEducationEligibilityReasonDescriptor source, IAlternativeEducationEligibilityReasonDescriptor target, Action<IAlternativeEducationEligibilityReasonDescriptor, IAlternativeEducationEligibilityReasonDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (AlternativeEducationEligibilityReasonDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplealternativeeducationprogram_AlternativeEducationEligibilityReasonDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            //Copy identifier Source
            if (target is IHasIdentifierSource identifierSource)
                identifierSource.IdSource = (source as IHasIdentifierSource).IdSource;

            // Copy contextual primary key values
            target.AlternativeEducationEligibilityReasonDescriptorId = source.AlternativeEducationEligibilityReasonDescriptorId;

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
// Aggregate: StudentAlternativeEducationProgramAssociation

namespace EdFi.Ods.Entities.Common.SampleAlternativeEducationProgram //.StudentAlternativeEducationProgramAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentAlternativeEducationProgramAssociationMapper
    {
        private static readonly FullName _fullName_samplealternativeeducationprogram_StudentAlternativeEducationProgramAssociation = new FullName("samplealternativeeducationprogram", "StudentAlternativeEducationProgramAssociation");
    
        public static bool SynchronizeTo(this IStudentAlternativeEducationProgramAssociation source, IStudentAlternativeEducationProgramAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentAlternativeEducationProgramAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplealternativeeducationprogram_StudentAlternativeEducationProgramAssociation);

            var keyStringComparer = GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer;

            // Detect primary key changes
            if (
                 (target.BeginDate != source.BeginDate)
                || (target.EducationOrganizationId != source.EducationOrganizationId)
                || (target.ProgramEducationOrganizationId != source.ProgramEducationOrganizationId)
                || (!keyStringComparer.Equals(target.ProgramName, source.ProgramName))
                || !string.Equals(target.ProgramTypeDescriptor, source.ProgramTypeDescriptor, StringComparison.OrdinalIgnoreCase)
                || (target.StudentUniqueId != source.StudentUniqueId))
            {
                // Disallow PK column updates on StudentAlternativeEducationProgramAssociation
                throw new KeyChangeNotSupportedException("StudentAlternativeEducationProgramAssociation");
            }


            // Copy inherited non-PK properties


            if ((mappingContract?.IsEndDateSupported != false)
                && target.EndDate != source.EndDate)
            {
                target.EndDate = source.EndDate;
                isModified = true;
            }

            if ((mappingContract?.IsReasonExitedDescriptorSupported != false)
                && target.ReasonExitedDescriptor != source.ReasonExitedDescriptor)
            {
                target.ReasonExitedDescriptor = source.ReasonExitedDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsServedOutsideOfRegularSessionSupported != false)
                && target.ServedOutsideOfRegularSession != source.ServedOutsideOfRegularSession)
            {
                target.ServedOutsideOfRegularSession = source.ServedOutsideOfRegularSession;
                isModified = true;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsAlternativeEducationEligibilityReasonDescriptorSupported != false)
                && target.AlternativeEducationEligibilityReasonDescriptor != source.AlternativeEducationEligibilityReasonDescriptor)
            {
                target.AlternativeEducationEligibilityReasonDescriptor = source.AlternativeEducationEligibilityReasonDescriptor;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // GeneralStudentProgramAssociationParticipationStatus (GeneralStudentProgramAssociationParticipationStatus)
            if (mappingContract?.IsGeneralStudentProgramAssociationParticipationStatusSupported != false)
            {
                if (source.GeneralStudentProgramAssociationParticipationStatus == null)
                {
                    if (target.GeneralStudentProgramAssociationParticipationStatus != null)
                    {
                        target.GeneralStudentProgramAssociationParticipationStatus = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.GeneralStudentProgramAssociationParticipationStatus == null)
                    {
                        var itemType = target.GetType().GetProperty("GeneralStudentProgramAssociationParticipationStatus").PropertyType;
            
                        if (!(mappingContract?.IsGeneralStudentProgramAssociationParticipationStatusCreatable ?? true))
                        {
                            string profileName = GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;

                            throw new DataPolicyException(profileName, itemType.Name);
                        }

                        var newItem = Activator.CreateInstance(itemType);
                        target.GeneralStudentProgramAssociationParticipationStatus = (IGeneralStudentProgramAssociationParticipationStatus) newItem;
                    }

                    isModified |= source.GeneralStudentProgramAssociationParticipationStatus.Synchronize(target.GeneralStudentProgramAssociationParticipationStatus);
                }
            }

            // -------------------------------------------------------------

            // Synch inherited lists
            if (mappingContract?.IsGeneralStudentProgramAssociationProgramParticipationStatusesSupported ?? true)
            {
                isModified |= 
                    source.GeneralStudentProgramAssociationProgramParticipationStatuses.SynchronizeCollectionTo(
                        target.GeneralStudentProgramAssociationProgramParticipationStatuses, 
                        onChildAdded: child => child.GeneralStudentProgramAssociation = target,
                        itemCreatable: mappingContract?.IsGeneralStudentProgramAssociationProgramParticipationStatusesItemCreatable ?? true,
                        includeItem: item => mappingContract?.IsGeneralStudentProgramAssociationProgramParticipationStatusIncluded?.Invoke(item) ?? true);
            }


            // Sync lists
            if (mappingContract?.IsStudentAlternativeEducationProgramAssociationMeetingTimesSupported ?? true)
            {
                isModified |=
                    source.StudentAlternativeEducationProgramAssociationMeetingTimes.SynchronizeCollectionTo(
                        target.StudentAlternativeEducationProgramAssociationMeetingTimes,
                        onChildAdded: child =>
                            {
                                child.StudentAlternativeEducationProgramAssociation = target;
                            },
                        itemCreatable: mappingContract?.IsStudentAlternativeEducationProgramAssociationMeetingTimesItemCreatable ?? true,
                        includeItem: item => mappingContract?.IsStudentAlternativeEducationProgramAssociationMeetingTimeIncluded?.Invoke(item) ?? true);
            }


            // Check for enabled features, and then deal with resolving aggregate reference data where it is missing
            if (GeneratedArtifactStaticDependencies.SerializedDataEnabled && GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
            {
                // Detect an uninitialized Id and invoke the setter so that it is added to the reference data resolution context
                if (target.EducationOrganizationResourceId == null)
                {
                    target.EducationOrganizationResourceId = null;
                }
                // Detect an uninitialized Id and invoke the setter so that it is added to the reference data resolution context
                if (target.ProgramResourceId == null)
                {
                    target.ProgramResourceId = null;
                }
                // Detect an uninitialized Id and invoke the setter so that it is added to the reference data resolution context
                if (target.StudentResourceId == null)
                {
                    target.StudentResourceId = null;
                }
            }


            return isModified;
        }

        public static void MapDerivedTo(this IStudentAlternativeEducationProgramAssociation source, IStudentAlternativeEducationProgramAssociation target, Action<IStudentAlternativeEducationProgramAssociation, IStudentAlternativeEducationProgramAssociation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentAlternativeEducationProgramAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplealternativeeducationprogram_StudentAlternativeEducationProgramAssociation);
    
            // Copy resource Id
            target.Id = source.Id;

            //Copy identifier Source
            if (target is IHasIdentifierSource identifierSource)
                identifierSource.IdSource = (source as IHasIdentifierSource).IdSource;

            // Copy contextual primary key values
            target.BeginDate = source.BeginDate;
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.ProgramEducationOrganizationId = source.ProgramEducationOrganizationId;
            target.ProgramName = source.ProgramName;
            target.ProgramTypeDescriptor = source.ProgramTypeDescriptor;
            target.StudentUniqueId = source.StudentUniqueId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsEndDateSupported != false)
                target.EndDate = source.EndDate;

            if (mappingContract?.IsReasonExitedDescriptorSupported != false)
                target.ReasonExitedDescriptor = source.ReasonExitedDescriptor;

            if (mappingContract?.IsServedOutsideOfRegularSessionSupported != false)
                target.ServedOutsideOfRegularSession = source.ServedOutsideOfRegularSession;

            // Copy non-PK properties

            if (mappingContract?.IsAlternativeEducationEligibilityReasonDescriptorSupported != false)
                target.AlternativeEducationEligibilityReasonDescriptor = source.AlternativeEducationEligibilityReasonDescriptor;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.ResourceLinksEnabled)
            {
                if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                    || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
                {
                target.EducationOrganizationResourceId = source.EducationOrganizationResourceId;
                target.EducationOrganizationDiscriminator = source.EducationOrganizationDiscriminator;
                target.ProgramResourceId = source.ProgramResourceId;
                target.ProgramDiscriminator = source.ProgramDiscriminator;
                target.StudentResourceId = source.StudentResourceId;
                target.StudentDiscriminator = source.StudentDiscriminator;
                }
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // GeneralStudentProgramAssociationParticipationStatus (GeneralStudentProgramAssociationParticipationStatus) (Source)
            if (mappingContract?.IsGeneralStudentProgramAssociationParticipationStatusSupported != false)
            {
                var itemProperty = target.GetType().GetProperty("GeneralStudentProgramAssociationParticipationStatus");

                if (itemProperty != null)
                {
                    if (source.GeneralStudentProgramAssociationParticipationStatus == null)
                    {
                        target.GeneralStudentProgramAssociationParticipationStatus = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;

                        if (!(mappingContract?.IsGeneralStudentProgramAssociationParticipationStatusCreatable ?? true))
                        {
                            // If no potential data policy violation has been detected yet
                            if (GeneratedArtifactStaticDependencies.DataPolicyExceptionContextProvider.Get() == null)
                            {
                                // Make note of this potential data policy violation using context
                                string profileName = GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                                GeneratedArtifactStaticDependencies.DataPolicyExceptionContextProvider.Set(new DataPolicyException(profileName, itemType.Name));
                            }
                        }

                        object targetGeneralStudentProgramAssociationParticipationStatus = Activator.CreateInstance(itemType);
                        (targetGeneralStudentProgramAssociationParticipationStatus as IChildEntity)?.SetParent(target);
                        source.GeneralStudentProgramAssociationParticipationStatus.Map(targetGeneralStudentProgramAssociationParticipationStatus);

                        // Update the target reference appropriately
                        target.GeneralStudentProgramAssociationParticipationStatus = (IGeneralStudentProgramAssociationParticipationStatus) targetGeneralStudentProgramAssociationParticipationStatus;
                    }
                }
            }
            // -------------------------------------------------------------

            // Map inherited lists

            if (mappingContract?.IsGeneralStudentProgramAssociationProgramParticipationStatusesSupported != false)
            {
                source.GeneralStudentProgramAssociationProgramParticipationStatuses.MapCollectionTo(target.GeneralStudentProgramAssociationProgramParticipationStatuses, mappingContract?.IsGeneralStudentProgramAssociationProgramParticipationStatusesItemCreatable ?? true, target, mappingContract?.IsGeneralStudentProgramAssociationProgramParticipationStatusIncluded);
            }

            // Map lists

            if (mappingContract?.IsStudentAlternativeEducationProgramAssociationMeetingTimesSupported != false)
            {
                source.StudentAlternativeEducationProgramAssociationMeetingTimes.MapCollectionTo(target.StudentAlternativeEducationProgramAssociationMeetingTimes, mappingContract?.IsStudentAlternativeEducationProgramAssociationMeetingTimesItemCreatable ?? true, target, mappingContract?.IsStudentAlternativeEducationProgramAssociationMeetingTimeIncluded);
            }


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
    public static class StudentAlternativeEducationProgramAssociationMeetingTimeMapper
    {
        private static readonly FullName _fullName_samplealternativeeducationprogram_StudentAlternativeEducationProgramAssociationMeetingTime = new FullName("samplealternativeeducationprogram", "StudentAlternativeEducationProgramAssociationMeetingTime");
    
        public static bool SynchronizeTo(this IStudentAlternativeEducationProgramAssociationMeetingTime source, IStudentAlternativeEducationProgramAssociationMeetingTime target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentAlternativeEducationProgramAssociationMeetingTimeMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplealternativeeducationprogram_StudentAlternativeEducationProgramAssociationMeetingTime);


            // Copy non-PK properties


            // Sync lists


            return isModified;
        }

        public static void MapTo(this IStudentAlternativeEducationProgramAssociationMeetingTime source, IStudentAlternativeEducationProgramAssociationMeetingTime target, Action<IStudentAlternativeEducationProgramAssociationMeetingTime, IStudentAlternativeEducationProgramAssociationMeetingTime> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentAlternativeEducationProgramAssociationMeetingTimeMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplealternativeeducationprogram_StudentAlternativeEducationProgramAssociationMeetingTime);
    
            // Copy contextual primary key values
            target.EndTime = source.EndTime;
            target.StartTime = source.StartTime;

            // Copy non-PK properties

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

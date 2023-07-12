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
// Aggregate: StudentTransportation

namespace EdFi.Ods.Entities.Common.SampleStudentTransportation //.StudentTransportationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentTransportationMapper
    {
        private static readonly FullName _fullName_samplestudenttransportation_StudentTransportation = new FullName("samplestudenttransportation", "StudentTransportation");
    
        public static bool SynchronizeTo(this IStudentTransportation source, IStudentTransportation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentTransportationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttransportation_StudentTransportation);

            var keyStringComparer = GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer;

            // Detect primary key changes
            if (
                 (!keyStringComparer.Equals(target.AMBusNumber, source.AMBusNumber))
                || (!keyStringComparer.Equals(target.PMBusNumber, source.PMBusNumber))
                || (target.SchoolId != source.SchoolId)
                || (target.StudentUniqueId != source.StudentUniqueId))
            {
                // Disallow PK column updates on StudentTransportation
                throw new BadRequestException("Key values for this resource cannot be changed. Delete and recreate the resource item.");
            }


            // Copy non-PK properties

            if ((mappingContract?.IsEstimatedMilesFromSchoolSupported != false)
                && target.EstimatedMilesFromSchool != source.EstimatedMilesFromSchool)
            {
                target.EstimatedMilesFromSchool = source.EstimatedMilesFromSchool;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentTransportation source, IStudentTransportation target, Action<IStudentTransportation, IStudentTransportation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentTransportationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_samplestudenttransportation_StudentTransportation);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.AMBusNumber = source.AMBusNumber;
            target.PMBusNumber = source.PMBusNumber;
            target.SchoolId = source.SchoolId;
            target.StudentUniqueId = source.StudentUniqueId;

            // Copy non-PK properties

            if (mappingContract?.IsEstimatedMilesFromSchoolSupported != false)
                target.EstimatedMilesFromSchool = source.EstimatedMilesFromSchool;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.SchoolResourceId = source.SchoolResourceId;
                target.StudentResourceId = source.StudentResourceId;
                target.StudentDiscriminator = source.StudentDiscriminator;
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

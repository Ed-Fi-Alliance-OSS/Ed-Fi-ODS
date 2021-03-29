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
// Aggregate: StudentTransportation

namespace EdFi.Ods.Entities.Common.SampleStudentTransportation //.StudentTransportationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentTransportationMapper
    {
        public static bool SynchronizeTo(this IStudentTransportation source, IStudentTransportation target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentTransportationSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.AMBusNumber != target.AMBusNumber)
            {
                source.AMBusNumber = target.AMBusNumber;
            }
            if (source.PMBusNumber != target.PMBusNumber)
            {
                source.PMBusNumber = target.PMBusNumber;
            }
            if (source.SchoolId != target.SchoolId)
            {
                source.SchoolId = target.SchoolId;
            }
            if (source.StudentUniqueId != target.StudentUniqueId)
            {
                source.StudentUniqueId = target.StudentUniqueId;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsEstimatedMilesFromSchoolSupported)
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
            var sourceSynchSupport = source as IStudentTransportationSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentTransportationSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.AMBusNumber = source.AMBusNumber;
            target.PMBusNumber = source.PMBusNumber;
            target.SchoolId = source.SchoolId;
            target.StudentUniqueId = source.StudentUniqueId;

            // Copy non-PK properties

            if (sourceSynchSupport.IsEstimatedMilesFromSchoolSupported)
                target.EstimatedMilesFromSchool = source.EstimatedMilesFromSchool;
            else
                targetSynchSupport.IsEstimatedMilesFromSchoolSupported = false;

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


            var eTagProvider = new ETagProvider();

            // Convert value to ETag, if appropriate
            var entityWithETag = target as IHasETag;

            if (entityWithETag != null)
                entityWithETag.ETag = eTagProvider.GetETag(source);

            // Convert value to LastModifiedDate, if appropriate
            var dateVersionedEntity = target as IDateVersionedEntity;
            var etagSource = source as IHasETag;

            if (dateVersionedEntity != null && etagSource != null)
                dateVersionedEntity.LastModifiedDate = eTagProvider.GetDateTime(etagSource.ETag);
        }
    }

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IStudentTransportationSynchronizationSourceSupport 
    {
        bool IsEstimatedMilesFromSchoolSupported { get; set; }
    }

}

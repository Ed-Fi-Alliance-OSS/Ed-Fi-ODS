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
// Aggregate: ArtMediumDescriptor

namespace EdFi.Ods.Entities.Common.Sample //.ArtMediumDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class ArtMediumDescriptorMapper
    {
        public static bool SynchronizeTo(this IArtMediumDescriptor source, IArtMediumDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IArtMediumDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.ArtMediumDescriptorId != target.ArtMediumDescriptorId)
            {
                source.ArtMediumDescriptorId = target.ArtMediumDescriptorId;
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



        public static void MapTo(this IArtMediumDescriptor source, IArtMediumDescriptor target, Action<IArtMediumDescriptor, IArtMediumDescriptor> onMapped)
        {
            var sourceSynchSupport = source as IArtMediumDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IArtMediumDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.ArtMediumDescriptorId = source.ArtMediumDescriptorId;

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
    public interface IArtMediumDescriptorSynchronizationSourceSupport 
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
// Aggregate: Bus

namespace EdFi.Ods.Entities.Common.Sample //.BusAggregate
{
    [ExcludeFromCodeCoverage]
    public static class BusMapper
    {
        public static bool SynchronizeTo(this IBus source, IBus target)
        {
            bool isModified = false;

            var sourceSupport = source as IBusSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.BusId != target.BusId)
            {
                source.BusId = target.BusId;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IBus source, IBus target, Action<IBus, IBus> onMapped)
        {
            var sourceSynchSupport = source as IBusSynchronizationSourceSupport;
            var targetSynchSupport = target as IBusSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.BusId = source.BusId;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IBusSynchronizationSourceSupport 
    {
    }

}
// Aggregate: BusRoute

namespace EdFi.Ods.Entities.Common.Sample //.BusRouteAggregate
{
    [ExcludeFromCodeCoverage]
    public static class BusRouteMapper
    {
        public static bool SynchronizeTo(this IBusRoute source, IBusRoute target)
        {
            bool isModified = false;

            var sourceSupport = source as IBusRouteSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.BusId != target.BusId)
            {
                source.BusId = target.BusId;
            }
            if (source.BusRouteNumber != target.BusRouteNumber)
            {
                source.BusRouteNumber = target.BusRouteNumber;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsBeginDateSupported)
                && target.BeginDate != source.BeginDate)
            {
                target.BeginDate = source.BeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBusRouteDirectionSupported)
                && target.BusRouteDirection != source.BusRouteDirection)
            {
                target.BusRouteDirection = source.BusRouteDirection;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBusRouteDurationSupported)
                && target.BusRouteDuration != source.BusRouteDuration)
            {
                target.BusRouteDuration = source.BusRouteDuration;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDailySupported)
                && target.Daily != source.Daily)
            {
                target.Daily = source.Daily;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDisabilityDescriptorSupported)
                && target.DisabilityDescriptor != source.DisabilityDescriptor)
            {
                target.DisabilityDescriptor = source.DisabilityDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEducationOrganizationIdSupported)
                && target.EducationOrganizationId != source.EducationOrganizationId)
            {
                target.EducationOrganizationId = source.EducationOrganizationId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsExpectedTransitTimeSupported)
                && target.ExpectedTransitTime != source.ExpectedTransitTime)
            {
                target.ExpectedTransitTime = source.ExpectedTransitTime;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsHoursPerWeekSupported)
                && target.HoursPerWeek != source.HoursPerWeek)
            {
                target.HoursPerWeek = source.HoursPerWeek;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsOperatingCostSupported)
                && target.OperatingCost != source.OperatingCost)
            {
                target.OperatingCost = source.OperatingCost;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsOptimalCapacitySupported)
                && target.OptimalCapacity != source.OptimalCapacity)
            {
                target.OptimalCapacity = source.OptimalCapacity;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsStaffClassificationDescriptorSupported)
                && target.StaffClassificationDescriptor != source.StaffClassificationDescriptor)
            {
                target.StaffClassificationDescriptor = source.StaffClassificationDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsStaffUniqueIdSupported)
                && target.StaffUniqueId != source.StaffUniqueId)
            {
                target.StaffUniqueId = source.StaffUniqueId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsStartDateSupported)
                && target.StartDate != source.StartDate)
            {
                target.StartDate = source.StartDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsWeeklyMileageSupported)
                && target.WeeklyMileage != source.WeeklyMileage)
            {
                target.WeeklyMileage = source.WeeklyMileage;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsBusRouteBusYearsSupported)
            {
                isModified |=
                    source.BusRouteBusYears.SynchronizeCollectionTo(
                        target.BusRouteBusYears,
                        onChildAdded: child =>
                            {
                                child.BusRoute = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsBusRouteBusYearIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsBusRouteProgramsSupported)
            {
                isModified |=
                    source.BusRoutePrograms.SynchronizeCollectionTo(
                        target.BusRoutePrograms,
                        onChildAdded: child =>
                            {
                                child.BusRoute = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsBusRouteProgramIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsBusRouteServiceAreaPostalCodesSupported)
            {
                isModified |=
                    source.BusRouteServiceAreaPostalCodes.SynchronizeCollectionTo(
                        target.BusRouteServiceAreaPostalCodes,
                        onChildAdded: child =>
                            {
                                child.BusRoute = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsBusRouteServiceAreaPostalCodeIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsBusRouteStartTimesSupported)
            {
                isModified |=
                    source.BusRouteStartTimes.SynchronizeCollectionTo(
                        target.BusRouteStartTimes,
                        onChildAdded: child =>
                            {
                                child.BusRoute = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsBusRouteStartTimeIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsBusRouteTelephonesSupported)
            {
                isModified |=
                    source.BusRouteTelephones.SynchronizeCollectionTo(
                        target.BusRouteTelephones,
                        onChildAdded: child =>
                            {
                                child.BusRoute = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsBusRouteTelephoneIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IBusRoute source, IBusRoute target, Action<IBusRoute, IBusRoute> onMapped)
        {
            var sourceSynchSupport = source as IBusRouteSynchronizationSourceSupport;
            var targetSynchSupport = target as IBusRouteSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.BusId = source.BusId;
            target.BusRouteNumber = source.BusRouteNumber;

            // Copy non-PK properties

            if (sourceSynchSupport.IsBeginDateSupported)
                target.BeginDate = source.BeginDate;
            else
                targetSynchSupport.IsBeginDateSupported = false;

            if (sourceSynchSupport.IsBusRouteDirectionSupported)
                target.BusRouteDirection = source.BusRouteDirection;
            else
                targetSynchSupport.IsBusRouteDirectionSupported = false;

            if (sourceSynchSupport.IsBusRouteDurationSupported)
                target.BusRouteDuration = source.BusRouteDuration;
            else
                targetSynchSupport.IsBusRouteDurationSupported = false;

            if (sourceSynchSupport.IsDailySupported)
                target.Daily = source.Daily;
            else
                targetSynchSupport.IsDailySupported = false;

            if (sourceSynchSupport.IsDisabilityDescriptorSupported)
                target.DisabilityDescriptor = source.DisabilityDescriptor;
            else
                targetSynchSupport.IsDisabilityDescriptorSupported = false;

            if (sourceSynchSupport.IsEducationOrganizationIdSupported)
                target.EducationOrganizationId = source.EducationOrganizationId;
            else
                targetSynchSupport.IsEducationOrganizationIdSupported = false;

            if (sourceSynchSupport.IsExpectedTransitTimeSupported)
                target.ExpectedTransitTime = source.ExpectedTransitTime;
            else
                targetSynchSupport.IsExpectedTransitTimeSupported = false;

            if (sourceSynchSupport.IsHoursPerWeekSupported)
                target.HoursPerWeek = source.HoursPerWeek;
            else
                targetSynchSupport.IsHoursPerWeekSupported = false;

            if (sourceSynchSupport.IsOperatingCostSupported)
                target.OperatingCost = source.OperatingCost;
            else
                targetSynchSupport.IsOperatingCostSupported = false;

            if (sourceSynchSupport.IsOptimalCapacitySupported)
                target.OptimalCapacity = source.OptimalCapacity;
            else
                targetSynchSupport.IsOptimalCapacitySupported = false;

            if (sourceSynchSupport.IsStaffClassificationDescriptorSupported)
                target.StaffClassificationDescriptor = source.StaffClassificationDescriptor;
            else
                targetSynchSupport.IsStaffClassificationDescriptorSupported = false;

            if (sourceSynchSupport.IsStaffUniqueIdSupported)
                target.StaffUniqueId = source.StaffUniqueId;
            else
                targetSynchSupport.IsStaffUniqueIdSupported = false;

            if (sourceSynchSupport.IsStartDateSupported)
                target.StartDate = source.StartDate;
            else
                targetSynchSupport.IsStartDateSupported = false;

            if (sourceSynchSupport.IsWeeklyMileageSupported)
                target.WeeklyMileage = source.WeeklyMileage;
            else
                targetSynchSupport.IsWeeklyMileageSupported = false;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.StaffEducationOrganizationAssignmentAssociationResourceId = source.StaffEducationOrganizationAssignmentAssociationResourceId;
                target.StaffEducationOrganizationAssignmentAssociationDiscriminator = source.StaffEducationOrganizationAssignmentAssociationDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (sourceSynchSupport.IsBusRouteBusYearsSupported)
            {
                targetSynchSupport.IsBusRouteBusYearIncluded = sourceSynchSupport.IsBusRouteBusYearIncluded;
                source.BusRouteBusYears.MapCollectionTo(target.BusRouteBusYears, target);
            }
            else
            {
                targetSynchSupport.IsBusRouteBusYearsSupported = false;
            }

            if (sourceSynchSupport.IsBusRouteProgramsSupported)
            {
                targetSynchSupport.IsBusRouteProgramIncluded = sourceSynchSupport.IsBusRouteProgramIncluded;
                source.BusRoutePrograms.MapCollectionTo(target.BusRoutePrograms, target);
            }
            else
            {
                targetSynchSupport.IsBusRouteProgramsSupported = false;
            }

            if (sourceSynchSupport.IsBusRouteServiceAreaPostalCodesSupported)
            {
                targetSynchSupport.IsBusRouteServiceAreaPostalCodeIncluded = sourceSynchSupport.IsBusRouteServiceAreaPostalCodeIncluded;
                source.BusRouteServiceAreaPostalCodes.MapCollectionTo(target.BusRouteServiceAreaPostalCodes, target);
            }
            else
            {
                targetSynchSupport.IsBusRouteServiceAreaPostalCodesSupported = false;
            }

            if (sourceSynchSupport.IsBusRouteStartTimesSupported)
            {
                targetSynchSupport.IsBusRouteStartTimeIncluded = sourceSynchSupport.IsBusRouteStartTimeIncluded;
                source.BusRouteStartTimes.MapCollectionTo(target.BusRouteStartTimes, target);
            }
            else
            {
                targetSynchSupport.IsBusRouteStartTimesSupported = false;
            }

            if (sourceSynchSupport.IsBusRouteTelephonesSupported)
            {
                targetSynchSupport.IsBusRouteTelephoneIncluded = sourceSynchSupport.IsBusRouteTelephoneIncluded;
                source.BusRouteTelephones.MapCollectionTo(target.BusRouteTelephones, target);
            }
            else
            {
                targetSynchSupport.IsBusRouteTelephonesSupported = false;
            }


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
    public interface IBusRouteSynchronizationSourceSupport 
    {
        bool IsBeginDateSupported { get; set; }
        bool IsBusRouteBusYearsSupported { get; set; }
        bool IsBusRouteDirectionSupported { get; set; }
        bool IsBusRouteDurationSupported { get; set; }
        bool IsBusRouteProgramsSupported { get; set; }
        bool IsBusRouteServiceAreaPostalCodesSupported { get; set; }
        bool IsBusRouteStartTimesSupported { get; set; }
        bool IsBusRouteTelephonesSupported { get; set; }
        bool IsDailySupported { get; set; }
        bool IsDisabilityDescriptorSupported { get; set; }
        bool IsEducationOrganizationIdSupported { get; set; }
        bool IsExpectedTransitTimeSupported { get; set; }
        bool IsHoursPerWeekSupported { get; set; }
        bool IsOperatingCostSupported { get; set; }
        bool IsOptimalCapacitySupported { get; set; }
        bool IsStaffClassificationDescriptorSupported { get; set; }
        bool IsStaffUniqueIdSupported { get; set; }
        bool IsStartDateSupported { get; set; }
        bool IsWeeklyMileageSupported { get; set; }
        Func<IBusRouteBusYear, bool> IsBusRouteBusYearIncluded { get; set; }
        Func<IBusRouteProgram, bool> IsBusRouteProgramIncluded { get; set; }
        Func<IBusRouteServiceAreaPostalCode, bool> IsBusRouteServiceAreaPostalCodeIncluded { get; set; }
        Func<IBusRouteStartTime, bool> IsBusRouteStartTimeIncluded { get; set; }
        Func<IBusRouteTelephone, bool> IsBusRouteTelephoneIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class BusRouteBusYearMapper
    {
        public static bool SynchronizeTo(this IBusRouteBusYear source, IBusRouteBusYear target)
        {
            bool isModified = false;

            var sourceSupport = source as IBusRouteBusYearSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.BusYear != target.BusYear)
            {
                source.BusYear = target.BusYear;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IBusRouteBusYear source, IBusRouteBusYear target, Action<IBusRouteBusYear, IBusRouteBusYear> onMapped)
        {
            var sourceSynchSupport = source as IBusRouteBusYearSynchronizationSourceSupport;
            var targetSynchSupport = target as IBusRouteBusYearSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.BusYear = source.BusYear;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IBusRouteBusYearSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class BusRouteProgramMapper
    {
        public static bool SynchronizeTo(this IBusRouteProgram source, IBusRouteProgram target)
        {
            bool isModified = false;

            var sourceSupport = source as IBusRouteProgramSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.ProgramName != target.ProgramName)
            {
                source.ProgramName = target.ProgramName;
            }
            if (source.ProgramTypeDescriptor != target.ProgramTypeDescriptor)
            {
                source.ProgramTypeDescriptor = target.ProgramTypeDescriptor;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IBusRouteProgram source, IBusRouteProgram target, Action<IBusRouteProgram, IBusRouteProgram> onMapped)
        {
            var sourceSynchSupport = source as IBusRouteProgramSynchronizationSourceSupport;
            var targetSynchSupport = target as IBusRouteProgramSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.ProgramName = source.ProgramName;
            target.ProgramTypeDescriptor = source.ProgramTypeDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.ProgramResourceId = source.ProgramResourceId;
                target.ProgramDiscriminator = source.ProgramDiscriminator;
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
    public interface IBusRouteProgramSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class BusRouteServiceAreaPostalCodeMapper
    {
        public static bool SynchronizeTo(this IBusRouteServiceAreaPostalCode source, IBusRouteServiceAreaPostalCode target)
        {
            bool isModified = false;

            var sourceSupport = source as IBusRouteServiceAreaPostalCodeSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.ServiceAreaPostalCode != target.ServiceAreaPostalCode)
            {
                source.ServiceAreaPostalCode = target.ServiceAreaPostalCode;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IBusRouteServiceAreaPostalCode source, IBusRouteServiceAreaPostalCode target, Action<IBusRouteServiceAreaPostalCode, IBusRouteServiceAreaPostalCode> onMapped)
        {
            var sourceSynchSupport = source as IBusRouteServiceAreaPostalCodeSynchronizationSourceSupport;
            var targetSynchSupport = target as IBusRouteServiceAreaPostalCodeSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.ServiceAreaPostalCode = source.ServiceAreaPostalCode;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IBusRouteServiceAreaPostalCodeSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class BusRouteStartTimeMapper
    {
        public static bool SynchronizeTo(this IBusRouteStartTime source, IBusRouteStartTime target)
        {
            bool isModified = false;

            var sourceSupport = source as IBusRouteStartTimeSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.StartTime != target.StartTime)
            {
                source.StartTime = target.StartTime;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IBusRouteStartTime source, IBusRouteStartTime target, Action<IBusRouteStartTime, IBusRouteStartTime> onMapped)
        {
            var sourceSynchSupport = source as IBusRouteStartTimeSynchronizationSourceSupport;
            var targetSynchSupport = target as IBusRouteStartTimeSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.StartTime = source.StartTime;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IBusRouteStartTimeSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class BusRouteTelephoneMapper
    {
        public static bool SynchronizeTo(this IBusRouteTelephone source, IBusRouteTelephone target)
        {
            bool isModified = false;

            var sourceSupport = source as IBusRouteTelephoneSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.TelephoneNumber != target.TelephoneNumber)
            {
                source.TelephoneNumber = target.TelephoneNumber;
            }
            if (source.TelephoneNumberTypeDescriptor != target.TelephoneNumberTypeDescriptor)
            {
                source.TelephoneNumberTypeDescriptor = target.TelephoneNumberTypeDescriptor;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsDoNotPublishIndicatorSupported)
                && target.DoNotPublishIndicator != source.DoNotPublishIndicator)
            {
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsOrderOfPrioritySupported)
                && target.OrderOfPriority != source.OrderOfPriority)
            {
                target.OrderOfPriority = source.OrderOfPriority;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsTextMessageCapabilityIndicatorSupported)
                && target.TextMessageCapabilityIndicator != source.TextMessageCapabilityIndicator)
            {
                target.TextMessageCapabilityIndicator = source.TextMessageCapabilityIndicator;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IBusRouteTelephone source, IBusRouteTelephone target, Action<IBusRouteTelephone, IBusRouteTelephone> onMapped)
        {
            var sourceSynchSupport = source as IBusRouteTelephoneSynchronizationSourceSupport;
            var targetSynchSupport = target as IBusRouteTelephoneSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.TelephoneNumber = source.TelephoneNumber;
            target.TelephoneNumberTypeDescriptor = source.TelephoneNumberTypeDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsDoNotPublishIndicatorSupported)
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
            else
                targetSynchSupport.IsDoNotPublishIndicatorSupported = false;

            if (sourceSynchSupport.IsOrderOfPrioritySupported)
                target.OrderOfPriority = source.OrderOfPriority;
            else
                targetSynchSupport.IsOrderOfPrioritySupported = false;

            if (sourceSynchSupport.IsTextMessageCapabilityIndicatorSupported)
                target.TextMessageCapabilityIndicator = source.TextMessageCapabilityIndicator;
            else
                targetSynchSupport.IsTextMessageCapabilityIndicatorSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IBusRouteTelephoneSynchronizationSourceSupport 
    {
        bool IsDoNotPublishIndicatorSupported { get; set; }
        bool IsOrderOfPrioritySupported { get; set; }
        bool IsTextMessageCapabilityIndicatorSupported { get; set; }
    }

}
// Aggregate: FavoriteBookCategoryDescriptor

namespace EdFi.Ods.Entities.Common.Sample //.FavoriteBookCategoryDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class FavoriteBookCategoryDescriptorMapper
    {
        public static bool SynchronizeTo(this IFavoriteBookCategoryDescriptor source, IFavoriteBookCategoryDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IFavoriteBookCategoryDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.FavoriteBookCategoryDescriptorId != target.FavoriteBookCategoryDescriptorId)
            {
                source.FavoriteBookCategoryDescriptorId = target.FavoriteBookCategoryDescriptorId;
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



        public static void MapTo(this IFavoriteBookCategoryDescriptor source, IFavoriteBookCategoryDescriptor target, Action<IFavoriteBookCategoryDescriptor, IFavoriteBookCategoryDescriptor> onMapped)
        {
            var sourceSynchSupport = source as IFavoriteBookCategoryDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IFavoriteBookCategoryDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.FavoriteBookCategoryDescriptorId = source.FavoriteBookCategoryDescriptorId;

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
    public interface IFavoriteBookCategoryDescriptorSynchronizationSourceSupport 
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
// Aggregate: MembershipTypeDescriptor

namespace EdFi.Ods.Entities.Common.Sample //.MembershipTypeDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class MembershipTypeDescriptorMapper
    {
        public static bool SynchronizeTo(this IMembershipTypeDescriptor source, IMembershipTypeDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IMembershipTypeDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.MembershipTypeDescriptorId != target.MembershipTypeDescriptorId)
            {
                source.MembershipTypeDescriptorId = target.MembershipTypeDescriptorId;
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



        public static void MapTo(this IMembershipTypeDescriptor source, IMembershipTypeDescriptor target, Action<IMembershipTypeDescriptor, IMembershipTypeDescriptor> onMapped)
        {
            var sourceSynchSupport = source as IMembershipTypeDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IMembershipTypeDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.MembershipTypeDescriptorId = source.MembershipTypeDescriptorId;

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
    public interface IMembershipTypeDescriptorSynchronizationSourceSupport 
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
// Aggregate: Parent

namespace EdFi.Ods.Entities.Common.Sample //.ParentAggregate
{
    [ExcludeFromCodeCoverage]
    public static class ParentAddressExtensionMapper
    {
        public static bool SynchronizeTo(this IParentAddressExtension source, IParentAddressExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentAddressExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.ParentAddress as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("Sample"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsComplexSupported)
                && target.Complex != source.Complex)
            {
                target.Complex = source.Complex;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsOnBusRouteSupported)
                && target.OnBusRoute != source.OnBusRoute)
            {
                target.OnBusRoute = source.OnBusRoute;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsParentAddressSchoolDistrictsSupported)
            {
                isModified |=
                    source.ParentAddressSchoolDistricts.SynchronizeCollectionTo(
                        target.ParentAddressSchoolDistricts,
                        onChildAdded: child =>
                            {
                                child.ParentAddressExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.ParentAddress);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsParentAddressSchoolDistrictIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsParentAddressTermsSupported)
            {
                isModified |=
                    source.ParentAddressTerms.SynchronizeCollectionTo(
                        target.ParentAddressTerms,
                        onChildAdded: child =>
                            {
                                child.ParentAddressExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.ParentAddress);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsParentAddressTermIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IParentAddressExtension source, IParentAddressExtension target, Action<IParentAddressExtension, IParentAddressExtension> onMapped)
        {
            var sourceSynchSupport = source as IParentAddressExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentAddressExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsComplexSupported)
                target.Complex = source.Complex;
            else
                targetSynchSupport.IsComplexSupported = false;

            if (sourceSynchSupport.IsOnBusRouteSupported)
                target.OnBusRoute = source.OnBusRoute;
            else
                targetSynchSupport.IsOnBusRouteSupported = false;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (sourceSynchSupport.IsParentAddressSchoolDistrictsSupported)
            {
                targetSynchSupport.IsParentAddressSchoolDistrictIncluded = sourceSynchSupport.IsParentAddressSchoolDistrictIncluded;
                source.ParentAddressSchoolDistricts.MapCollectionTo(target.ParentAddressSchoolDistricts, target.ParentAddress);
            }
            else
            {
                targetSynchSupport.IsParentAddressSchoolDistrictsSupported = false;
            }

            if (sourceSynchSupport.IsParentAddressTermsSupported)
            {
                targetSynchSupport.IsParentAddressTermIncluded = sourceSynchSupport.IsParentAddressTermIncluded;
                source.ParentAddressTerms.MapCollectionTo(target.ParentAddressTerms, target.ParentAddress);
            }
            else
            {
                targetSynchSupport.IsParentAddressTermsSupported = false;
            }


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
    public interface IParentAddressExtensionSynchronizationSourceSupport 
    {
        bool IsComplexSupported { get; set; }
        bool IsOnBusRouteSupported { get; set; }
        bool IsParentAddressSchoolDistrictsSupported { get; set; }
        bool IsParentAddressTermsSupported { get; set; }
        Func<IParentAddressSchoolDistrict, bool> IsParentAddressSchoolDistrictIncluded { get; set; }
        Func<IParentAddressTerm, bool> IsParentAddressTermIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class ParentAddressSchoolDistrictMapper
    {
        public static bool SynchronizeTo(this IParentAddressSchoolDistrict source, IParentAddressSchoolDistrict target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentAddressSchoolDistrictSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.SchoolDistrict != target.SchoolDistrict)
            {
                source.SchoolDistrict = target.SchoolDistrict;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IParentAddressSchoolDistrict source, IParentAddressSchoolDistrict target, Action<IParentAddressSchoolDistrict, IParentAddressSchoolDistrict> onMapped)
        {
            var sourceSynchSupport = source as IParentAddressSchoolDistrictSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentAddressSchoolDistrictSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.SchoolDistrict = source.SchoolDistrict;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IParentAddressSchoolDistrictSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class ParentAddressTermMapper
    {
        public static bool SynchronizeTo(this IParentAddressTerm source, IParentAddressTerm target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentAddressTermSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.TermDescriptor != target.TermDescriptor)
            {
                source.TermDescriptor = target.TermDescriptor;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IParentAddressTerm source, IParentAddressTerm target, Action<IParentAddressTerm, IParentAddressTerm> onMapped)
        {
            var sourceSynchSupport = source as IParentAddressTermSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentAddressTermSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.TermDescriptor = source.TermDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IParentAddressTermSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class ParentAuthorMapper
    {
        public static bool SynchronizeTo(this IParentAuthor source, IParentAuthor target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentAuthorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.Author != target.Author)
            {
                source.Author = target.Author;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IParentAuthor source, IParentAuthor target, Action<IParentAuthor, IParentAuthor> onMapped)
        {
            var sourceSynchSupport = source as IParentAuthorSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentAuthorSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.Author = source.Author;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IParentAuthorSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class ParentCeilingHeightMapper
    {
        public static bool SynchronizeTo(this IParentCeilingHeight source, IParentCeilingHeight target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentCeilingHeightSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.CeilingHeight != target.CeilingHeight)
            {
                source.CeilingHeight = target.CeilingHeight;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IParentCeilingHeight source, IParentCeilingHeight target, Action<IParentCeilingHeight, IParentCeilingHeight> onMapped)
        {
            var sourceSynchSupport = source as IParentCeilingHeightSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentCeilingHeightSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.CeilingHeight = source.CeilingHeight;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IParentCeilingHeightSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class ParentCTEProgramMapper
    {
        public static bool SynchronizeTo(this IParentCTEProgram source, IParentCTEProgram target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentCTEProgramSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsCareerPathwayDescriptorSupported)
                && target.CareerPathwayDescriptor != source.CareerPathwayDescriptor)
            {
                target.CareerPathwayDescriptor = source.CareerPathwayDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCIPCodeSupported)
                && target.CIPCode != source.CIPCode)
            {
                target.CIPCode = source.CIPCode;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCTEProgramCompletionIndicatorSupported)
                && target.CTEProgramCompletionIndicator != source.CTEProgramCompletionIndicator)
            {
                target.CTEProgramCompletionIndicator = source.CTEProgramCompletionIndicator;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPrimaryCTEProgramIndicatorSupported)
                && target.PrimaryCTEProgramIndicator != source.PrimaryCTEProgramIndicator)
            {
                target.PrimaryCTEProgramIndicator = source.PrimaryCTEProgramIndicator;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IParentCTEProgram source, IParentCTEProgram target, Action<IParentCTEProgram, IParentCTEProgram> onMapped)
        {
            var sourceSynchSupport = source as IParentCTEProgramSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentCTEProgramSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsCareerPathwayDescriptorSupported)
                target.CareerPathwayDescriptor = source.CareerPathwayDescriptor;
            else
                targetSynchSupport.IsCareerPathwayDescriptorSupported = false;

            if (sourceSynchSupport.IsCIPCodeSupported)
                target.CIPCode = source.CIPCode;
            else
                targetSynchSupport.IsCIPCodeSupported = false;

            if (sourceSynchSupport.IsCTEProgramCompletionIndicatorSupported)
                target.CTEProgramCompletionIndicator = source.CTEProgramCompletionIndicator;
            else
                targetSynchSupport.IsCTEProgramCompletionIndicatorSupported = false;

            if (sourceSynchSupport.IsPrimaryCTEProgramIndicatorSupported)
                target.PrimaryCTEProgramIndicator = source.PrimaryCTEProgramIndicator;
            else
                targetSynchSupport.IsPrimaryCTEProgramIndicatorSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IParentCTEProgramSynchronizationSourceSupport 
    {
        bool IsCareerPathwayDescriptorSupported { get; set; }
        bool IsCIPCodeSupported { get; set; }
        bool IsCTEProgramCompletionIndicatorSupported { get; set; }
        bool IsPrimaryCTEProgramIndicatorSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class ParentEducationContentMapper
    {
        public static bool SynchronizeTo(this IParentEducationContent source, IParentEducationContent target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentEducationContentSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.ContentIdentifier != target.ContentIdentifier)
            {
                source.ContentIdentifier = target.ContentIdentifier;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IParentEducationContent source, IParentEducationContent target, Action<IParentEducationContent, IParentEducationContent> onMapped)
        {
            var sourceSynchSupport = source as IParentEducationContentSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentEducationContentSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.ContentIdentifier = source.ContentIdentifier;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.EducationContentResourceId = source.EducationContentResourceId;
                target.EducationContentDiscriminator = source.EducationContentDiscriminator;
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
    public interface IParentEducationContentSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class ParentExtensionMapper
    {
        public static bool SynchronizeTo(this IParentExtension source, IParentExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.Parent as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("Sample"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsAverageCarLineWaitSupported)
                && target.AverageCarLineWait != source.AverageCarLineWait)
            {
                target.AverageCarLineWait = source.AverageCarLineWait;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBecameParentSupported)
                && target.BecameParent != source.BecameParent)
            {
                target.BecameParent = source.BecameParent;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCoffeeSpendSupported)
                && target.CoffeeSpend != source.CoffeeSpend)
            {
                target.CoffeeSpend = source.CoffeeSpend;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCredentialFieldDescriptorSupported)
                && target.CredentialFieldDescriptor != source.CredentialFieldDescriptor)
            {
                target.CredentialFieldDescriptor = source.CredentialFieldDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDurationSupported)
                && target.Duration != source.Duration)
            {
                target.Duration = source.Duration;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsGPASupported)
                && target.GPA != source.GPA)
            {
                target.GPA = source.GPA;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsGraduationDateSupported)
                && target.GraduationDate != source.GraduationDate)
            {
                target.GraduationDate = source.GraduationDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsIsSportsFanSupported)
                && target.IsSportsFan != source.IsSportsFan)
            {
                target.IsSportsFan = source.IsSportsFan;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLuckyNumberSupported)
                && target.LuckyNumber != source.LuckyNumber)
            {
                target.LuckyNumber = source.LuckyNumber;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPreferredWakeUpTimeSupported)
                && target.PreferredWakeUpTime != source.PreferredWakeUpTime)
            {
                target.PreferredWakeUpTime = source.PreferredWakeUpTime;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsRainCertaintySupported)
                && target.RainCertainty != source.RainCertainty)
            {
                target.RainCertainty = source.RainCertainty;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // ParentCTEProgram
            if (sourceSupport == null || sourceSupport.IsParentCTEProgramSupported)
            {
                if (source.ParentCTEProgram == null)
                {
                    if (target.ParentCTEProgram != null)
                    {
                        target.ParentCTEProgram = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.ParentCTEProgram == null)
                    {
                        var itemType = target.GetType().GetProperty("ParentCTEProgram").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.ParentCTEProgram = (IParentCTEProgram) newItem;
                    }

                    isModified |= source.ParentCTEProgram.Synchronize(target.ParentCTEProgram);
                }
            }
            // ParentTeacherConference
            if (sourceSupport == null || sourceSupport.IsParentTeacherConferenceSupported)
            {
                if (source.ParentTeacherConference == null)
                {
                    if (target.ParentTeacherConference != null)
                    {
                        target.ParentTeacherConference = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.ParentTeacherConference == null)
                    {
                        var itemType = target.GetType().GetProperty("ParentTeacherConference").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.ParentTeacherConference = (IParentTeacherConference) newItem;
                    }

                    isModified |= source.ParentTeacherConference.Synchronize(target.ParentTeacherConference);
                }
            }

            // -------------------------------------------------------------

            // Sync lists
            if (sourceSupport == null || sourceSupport.IsParentAuthorsSupported)
            {
                isModified |=
                    source.ParentAuthors.SynchronizeCollectionTo(
                        target.ParentAuthors,
                        onChildAdded: child =>
                            {
                                child.ParentExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Parent);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsParentAuthorIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsParentCeilingHeightsSupported)
            {
                isModified |=
                    source.ParentCeilingHeights.SynchronizeCollectionTo(
                        target.ParentCeilingHeights,
                        onChildAdded: child =>
                            {
                                child.ParentExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Parent);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsParentCeilingHeightIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsParentEducationContentsSupported)
            {
                isModified |=
                    source.ParentEducationContents.SynchronizeCollectionTo(
                        target.ParentEducationContents,
                        onChildAdded: child =>
                            {
                                child.ParentExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Parent);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsParentEducationContentIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsParentFavoriteBookTitlesSupported)
            {
                isModified |=
                    source.ParentFavoriteBookTitles.SynchronizeCollectionTo(
                        target.ParentFavoriteBookTitles,
                        onChildAdded: child =>
                            {
                                child.ParentExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Parent);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsParentFavoriteBookTitleIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsParentStudentProgramAssociationsSupported)
            {
                isModified |=
                    source.ParentStudentProgramAssociations.SynchronizeCollectionTo(
                        target.ParentStudentProgramAssociations,
                        onChildAdded: child =>
                            {
                                child.ParentExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Parent);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsParentStudentProgramAssociationIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IParentExtension source, IParentExtension target, Action<IParentExtension, IParentExtension> onMapped)
        {
            var sourceSynchSupport = source as IParentExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsAverageCarLineWaitSupported)
                target.AverageCarLineWait = source.AverageCarLineWait;
            else
                targetSynchSupport.IsAverageCarLineWaitSupported = false;

            if (sourceSynchSupport.IsBecameParentSupported)
                target.BecameParent = source.BecameParent;
            else
                targetSynchSupport.IsBecameParentSupported = false;

            if (sourceSynchSupport.IsCoffeeSpendSupported)
                target.CoffeeSpend = source.CoffeeSpend;
            else
                targetSynchSupport.IsCoffeeSpendSupported = false;

            if (sourceSynchSupport.IsCredentialFieldDescriptorSupported)
                target.CredentialFieldDescriptor = source.CredentialFieldDescriptor;
            else
                targetSynchSupport.IsCredentialFieldDescriptorSupported = false;

            if (sourceSynchSupport.IsDurationSupported)
                target.Duration = source.Duration;
            else
                targetSynchSupport.IsDurationSupported = false;

            if (sourceSynchSupport.IsGPASupported)
                target.GPA = source.GPA;
            else
                targetSynchSupport.IsGPASupported = false;

            if (sourceSynchSupport.IsGraduationDateSupported)
                target.GraduationDate = source.GraduationDate;
            else
                targetSynchSupport.IsGraduationDateSupported = false;

            if (sourceSynchSupport.IsIsSportsFanSupported)
                target.IsSportsFan = source.IsSportsFan;
            else
                targetSynchSupport.IsIsSportsFanSupported = false;

            if (sourceSynchSupport.IsLuckyNumberSupported)
                target.LuckyNumber = source.LuckyNumber;
            else
                targetSynchSupport.IsLuckyNumberSupported = false;

            if (sourceSynchSupport.IsPreferredWakeUpTimeSupported)
                target.PreferredWakeUpTime = source.PreferredWakeUpTime;
            else
                targetSynchSupport.IsPreferredWakeUpTimeSupported = false;

            if (sourceSynchSupport.IsRainCertaintySupported)
                target.RainCertainty = source.RainCertainty;
            else
                targetSynchSupport.IsRainCertaintySupported = false;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // ParentCTEProgram (Source)
            if (sourceSynchSupport.IsParentCTEProgramSupported)
            {
                var itemProperty = target.GetType().GetProperty("ParentCTEProgram");

                if (itemProperty != null)
                {
                    if (source.ParentCTEProgram == null)
                    {
                        target.ParentCTEProgram = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetParentCTEProgram = Activator.CreateInstance(itemType);
                        (targetParentCTEProgram as IChildEntity)?.SetParent(target.Parent);
                        source.ParentCTEProgram.Map(targetParentCTEProgram);

                        // Update the target reference appropriately
                        target.ParentCTEProgram = (IParentCTEProgram) targetParentCTEProgram;
                    }
                }
            }
            else
            {
                targetSynchSupport.IsParentCTEProgramSupported = false;
            }
            // ParentTeacherConference (Source)
            if (sourceSynchSupport.IsParentTeacherConferenceSupported)
            {
                var itemProperty = target.GetType().GetProperty("ParentTeacherConference");

                if (itemProperty != null)
                {
                    if (source.ParentTeacherConference == null)
                    {
                        target.ParentTeacherConference = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetParentTeacherConference = Activator.CreateInstance(itemType);
                        (targetParentTeacherConference as IChildEntity)?.SetParent(target.Parent);
                        source.ParentTeacherConference.Map(targetParentTeacherConference);

                        // Update the target reference appropriately
                        target.ParentTeacherConference = (IParentTeacherConference) targetParentTeacherConference;
                    }
                }
            }
            else
            {
                targetSynchSupport.IsParentTeacherConferenceSupported = false;
            }
            // -------------------------------------------------------------

            // Map lists

            if (sourceSynchSupport.IsParentAuthorsSupported)
            {
                targetSynchSupport.IsParentAuthorIncluded = sourceSynchSupport.IsParentAuthorIncluded;
                source.ParentAuthors.MapCollectionTo(target.ParentAuthors, target.Parent);
            }
            else
            {
                targetSynchSupport.IsParentAuthorsSupported = false;
            }

            if (sourceSynchSupport.IsParentCeilingHeightsSupported)
            {
                targetSynchSupport.IsParentCeilingHeightIncluded = sourceSynchSupport.IsParentCeilingHeightIncluded;
                source.ParentCeilingHeights.MapCollectionTo(target.ParentCeilingHeights, target.Parent);
            }
            else
            {
                targetSynchSupport.IsParentCeilingHeightsSupported = false;
            }

            if (sourceSynchSupport.IsParentEducationContentsSupported)
            {
                targetSynchSupport.IsParentEducationContentIncluded = sourceSynchSupport.IsParentEducationContentIncluded;
                source.ParentEducationContents.MapCollectionTo(target.ParentEducationContents, target.Parent);
            }
            else
            {
                targetSynchSupport.IsParentEducationContentsSupported = false;
            }

            if (sourceSynchSupport.IsParentFavoriteBookTitlesSupported)
            {
                targetSynchSupport.IsParentFavoriteBookTitleIncluded = sourceSynchSupport.IsParentFavoriteBookTitleIncluded;
                source.ParentFavoriteBookTitles.MapCollectionTo(target.ParentFavoriteBookTitles, target.Parent);
            }
            else
            {
                targetSynchSupport.IsParentFavoriteBookTitlesSupported = false;
            }

            if (sourceSynchSupport.IsParentStudentProgramAssociationsSupported)
            {
                targetSynchSupport.IsParentStudentProgramAssociationIncluded = sourceSynchSupport.IsParentStudentProgramAssociationIncluded;
                source.ParentStudentProgramAssociations.MapCollectionTo(target.ParentStudentProgramAssociations, target.Parent);
            }
            else
            {
                targetSynchSupport.IsParentStudentProgramAssociationsSupported = false;
            }


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
    public interface IParentExtensionSynchronizationSourceSupport 
    {
        bool IsAverageCarLineWaitSupported { get; set; }
        bool IsBecameParentSupported { get; set; }
        bool IsCoffeeSpendSupported { get; set; }
        bool IsCredentialFieldDescriptorSupported { get; set; }
        bool IsDurationSupported { get; set; }
        bool IsGPASupported { get; set; }
        bool IsGraduationDateSupported { get; set; }
        bool IsIsSportsFanSupported { get; set; }
        bool IsLuckyNumberSupported { get; set; }
        bool IsParentAuthorsSupported { get; set; }
        bool IsParentCeilingHeightsSupported { get; set; }
        bool IsParentCTEProgramSupported { get; set; }
        bool IsParentEducationContentsSupported { get; set; }
        bool IsParentFavoriteBookTitlesSupported { get; set; }
        bool IsParentStudentProgramAssociationsSupported { get; set; }
        bool IsParentTeacherConferenceSupported { get; set; }
        bool IsPreferredWakeUpTimeSupported { get; set; }
        bool IsRainCertaintySupported { get; set; }
        Func<IParentAuthor, bool> IsParentAuthorIncluded { get; set; }
        Func<IParentCeilingHeight, bool> IsParentCeilingHeightIncluded { get; set; }
        Func<IParentEducationContent, bool> IsParentEducationContentIncluded { get; set; }
        Func<IParentFavoriteBookTitle, bool> IsParentFavoriteBookTitleIncluded { get; set; }
        Func<IParentStudentProgramAssociation, bool> IsParentStudentProgramAssociationIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class ParentFavoriteBookTitleMapper
    {
        public static bool SynchronizeTo(this IParentFavoriteBookTitle source, IParentFavoriteBookTitle target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentFavoriteBookTitleSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.FavoriteBookTitle != target.FavoriteBookTitle)
            {
                source.FavoriteBookTitle = target.FavoriteBookTitle;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IParentFavoriteBookTitle source, IParentFavoriteBookTitle target, Action<IParentFavoriteBookTitle, IParentFavoriteBookTitle> onMapped)
        {
            var sourceSynchSupport = source as IParentFavoriteBookTitleSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentFavoriteBookTitleSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.FavoriteBookTitle = source.FavoriteBookTitle;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IParentFavoriteBookTitleSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class ParentStudentProgramAssociationMapper
    {
        public static bool SynchronizeTo(this IParentStudentProgramAssociation source, IParentStudentProgramAssociation target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentStudentProgramAssociationSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.BeginDate != target.BeginDate)
            {
                source.BeginDate = target.BeginDate;
            }
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.ProgramEducationOrganizationId != target.ProgramEducationOrganizationId)
            {
                source.ProgramEducationOrganizationId = target.ProgramEducationOrganizationId;
            }
            if (source.ProgramName != target.ProgramName)
            {
                source.ProgramName = target.ProgramName;
            }
            if (source.ProgramTypeDescriptor != target.ProgramTypeDescriptor)
            {
                source.ProgramTypeDescriptor = target.ProgramTypeDescriptor;
            }
            if (source.StudentUniqueId != target.StudentUniqueId)
            {
                source.StudentUniqueId = target.StudentUniqueId;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IParentStudentProgramAssociation source, IParentStudentProgramAssociation target, Action<IParentStudentProgramAssociation, IParentStudentProgramAssociation> onMapped)
        {
            var sourceSynchSupport = source as IParentStudentProgramAssociationSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentStudentProgramAssociationSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.BeginDate = source.BeginDate;
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.ProgramEducationOrganizationId = source.ProgramEducationOrganizationId;
            target.ProgramName = source.ProgramName;
            target.ProgramTypeDescriptor = source.ProgramTypeDescriptor;
            target.StudentUniqueId = source.StudentUniqueId;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.StudentProgramAssociationResourceId = source.StudentProgramAssociationResourceId;
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
    public interface IParentStudentProgramAssociationSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class ParentTeacherConferenceMapper
    {
        public static bool SynchronizeTo(this IParentTeacherConference source, IParentTeacherConference target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentTeacherConferenceSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsDayOfWeekSupported)
                && target.DayOfWeek != source.DayOfWeek)
            {
                target.DayOfWeek = source.DayOfWeek;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEndTimeSupported)
                && target.EndTime != source.EndTime)
            {
                target.EndTime = source.EndTime;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsStartTimeSupported)
                && target.StartTime != source.StartTime)
            {
                target.StartTime = source.StartTime;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IParentTeacherConference source, IParentTeacherConference target, Action<IParentTeacherConference, IParentTeacherConference> onMapped)
        {
            var sourceSynchSupport = source as IParentTeacherConferenceSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentTeacherConferenceSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsDayOfWeekSupported)
                target.DayOfWeek = source.DayOfWeek;
            else
                targetSynchSupport.IsDayOfWeekSupported = false;

            if (sourceSynchSupport.IsEndTimeSupported)
                target.EndTime = source.EndTime;
            else
                targetSynchSupport.IsEndTimeSupported = false;

            if (sourceSynchSupport.IsStartTimeSupported)
                target.StartTime = source.StartTime;
            else
                targetSynchSupport.IsStartTimeSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IParentTeacherConferenceSynchronizationSourceSupport 
    {
        bool IsDayOfWeekSupported { get; set; }
        bool IsEndTimeSupported { get; set; }
        bool IsStartTimeSupported { get; set; }
    }

}
// Aggregate: School

namespace EdFi.Ods.Entities.Common.Sample //.SchoolAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SchoolCTEProgramMapper
    {
        public static bool SynchronizeTo(this ISchoolCTEProgram source, ISchoolCTEProgram target)
        {
            bool isModified = false;

            var sourceSupport = source as ISchoolCTEProgramSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsCareerPathwayDescriptorSupported)
                && target.CareerPathwayDescriptor != source.CareerPathwayDescriptor)
            {
                target.CareerPathwayDescriptor = source.CareerPathwayDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCIPCodeSupported)
                && target.CIPCode != source.CIPCode)
            {
                target.CIPCode = source.CIPCode;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCTEProgramCompletionIndicatorSupported)
                && target.CTEProgramCompletionIndicator != source.CTEProgramCompletionIndicator)
            {
                target.CTEProgramCompletionIndicator = source.CTEProgramCompletionIndicator;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPrimaryCTEProgramIndicatorSupported)
                && target.PrimaryCTEProgramIndicator != source.PrimaryCTEProgramIndicator)
            {
                target.PrimaryCTEProgramIndicator = source.PrimaryCTEProgramIndicator;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ISchoolCTEProgram source, ISchoolCTEProgram target, Action<ISchoolCTEProgram, ISchoolCTEProgram> onMapped)
        {
            var sourceSynchSupport = source as ISchoolCTEProgramSynchronizationSourceSupport;
            var targetSynchSupport = target as ISchoolCTEProgramSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsCareerPathwayDescriptorSupported)
                target.CareerPathwayDescriptor = source.CareerPathwayDescriptor;
            else
                targetSynchSupport.IsCareerPathwayDescriptorSupported = false;

            if (sourceSynchSupport.IsCIPCodeSupported)
                target.CIPCode = source.CIPCode;
            else
                targetSynchSupport.IsCIPCodeSupported = false;

            if (sourceSynchSupport.IsCTEProgramCompletionIndicatorSupported)
                target.CTEProgramCompletionIndicator = source.CTEProgramCompletionIndicator;
            else
                targetSynchSupport.IsCTEProgramCompletionIndicatorSupported = false;

            if (sourceSynchSupport.IsPrimaryCTEProgramIndicatorSupported)
                target.PrimaryCTEProgramIndicator = source.PrimaryCTEProgramIndicator;
            else
                targetSynchSupport.IsPrimaryCTEProgramIndicatorSupported = false;

            // Copy Aggregate Reference Data


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
    public interface ISchoolCTEProgramSynchronizationSourceSupport 
    {
        bool IsCareerPathwayDescriptorSupported { get; set; }
        bool IsCIPCodeSupported { get; set; }
        bool IsCTEProgramCompletionIndicatorSupported { get; set; }
        bool IsPrimaryCTEProgramIndicatorSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class SchoolDirectlyOwnedBusMapper
    {
        public static bool SynchronizeTo(this ISchoolDirectlyOwnedBus source, ISchoolDirectlyOwnedBus target)
        {
            bool isModified = false;

            var sourceSupport = source as ISchoolDirectlyOwnedBusSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.DirectlyOwnedBusId != target.DirectlyOwnedBusId)
            {
                source.DirectlyOwnedBusId = target.DirectlyOwnedBusId;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ISchoolDirectlyOwnedBus source, ISchoolDirectlyOwnedBus target, Action<ISchoolDirectlyOwnedBus, ISchoolDirectlyOwnedBus> onMapped)
        {
            var sourceSynchSupport = source as ISchoolDirectlyOwnedBusSynchronizationSourceSupport;
            var targetSynchSupport = target as ISchoolDirectlyOwnedBusSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.DirectlyOwnedBusId = source.DirectlyOwnedBusId;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.DirectlyOwnedBusResourceId = source.DirectlyOwnedBusResourceId;
                target.DirectlyOwnedBusDiscriminator = source.DirectlyOwnedBusDiscriminator;
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
    public interface ISchoolDirectlyOwnedBusSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class SchoolExtensionMapper
    {
        public static bool SynchronizeTo(this ISchoolExtension source, ISchoolExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as ISchoolExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.School as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("Sample"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsIsExemplarySupported)
                && target.IsExemplary != source.IsExemplary)
            {
                target.IsExemplary = source.IsExemplary;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // SchoolCTEProgram
            if (sourceSupport == null || sourceSupport.IsSchoolCTEProgramSupported)
            {
                if (source.SchoolCTEProgram == null)
                {
                    if (target.SchoolCTEProgram != null)
                    {
                        target.SchoolCTEProgram = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.SchoolCTEProgram == null)
                    {
                        var itemType = target.GetType().GetProperty("SchoolCTEProgram").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.SchoolCTEProgram = (ISchoolCTEProgram) newItem;
                    }

                    isModified |= source.SchoolCTEProgram.Synchronize(target.SchoolCTEProgram);
                }
            }

            // -------------------------------------------------------------

            // Sync lists
            if (sourceSupport == null || sourceSupport.IsSchoolDirectlyOwnedBusesSupported)
            {
                isModified |=
                    source.SchoolDirectlyOwnedBuses.SynchronizeCollectionTo(
                        target.SchoolDirectlyOwnedBuses,
                        onChildAdded: child =>
                            {
                                child.SchoolExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.School);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsSchoolDirectlyOwnedBusIncluded);
            }


            return isModified;
        }



        public static void MapTo(this ISchoolExtension source, ISchoolExtension target, Action<ISchoolExtension, ISchoolExtension> onMapped)
        {
            var sourceSynchSupport = source as ISchoolExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as ISchoolExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsIsExemplarySupported)
                target.IsExemplary = source.IsExemplary;
            else
                targetSynchSupport.IsIsExemplarySupported = false;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // SchoolCTEProgram (Source)
            if (sourceSynchSupport.IsSchoolCTEProgramSupported)
            {
                var itemProperty = target.GetType().GetProperty("SchoolCTEProgram");

                if (itemProperty != null)
                {
                    if (source.SchoolCTEProgram == null)
                    {
                        target.SchoolCTEProgram = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetSchoolCTEProgram = Activator.CreateInstance(itemType);
                        (targetSchoolCTEProgram as IChildEntity)?.SetParent(target.School);
                        source.SchoolCTEProgram.Map(targetSchoolCTEProgram);

                        // Update the target reference appropriately
                        target.SchoolCTEProgram = (ISchoolCTEProgram) targetSchoolCTEProgram;
                    }
                }
            }
            else
            {
                targetSynchSupport.IsSchoolCTEProgramSupported = false;
            }
            // -------------------------------------------------------------

            // Map lists

            if (sourceSynchSupport.IsSchoolDirectlyOwnedBusesSupported)
            {
                targetSynchSupport.IsSchoolDirectlyOwnedBusIncluded = sourceSynchSupport.IsSchoolDirectlyOwnedBusIncluded;
                source.SchoolDirectlyOwnedBuses.MapCollectionTo(target.SchoolDirectlyOwnedBuses, target.School);
            }
            else
            {
                targetSynchSupport.IsSchoolDirectlyOwnedBusesSupported = false;
            }


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
    public interface ISchoolExtensionSynchronizationSourceSupport 
    {
        bool IsIsExemplarySupported { get; set; }
        bool IsSchoolCTEProgramSupported { get; set; }
        bool IsSchoolDirectlyOwnedBusesSupported { get; set; }
        Func<ISchoolDirectlyOwnedBus, bool> IsSchoolDirectlyOwnedBusIncluded { get; set; }
    }

}
// Aggregate: Staff

namespace EdFi.Ods.Entities.Common.Sample //.StaffAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StaffExtensionMapper
    {
        public static bool SynchronizeTo(this IStaffExtension source, IStaffExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as IStaffExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.Staff as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("Sample"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsFirstPetOwnedDateSupported)
                && target.FirstPetOwnedDate != source.FirstPetOwnedDate)
            {
                target.FirstPetOwnedDate = source.FirstPetOwnedDate;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // StaffPetPreference
            if (sourceSupport == null || sourceSupport.IsStaffPetPreferenceSupported)
            {
                if (source.StaffPetPreference == null)
                {
                    if (target.StaffPetPreference != null)
                    {
                        target.StaffPetPreference = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.StaffPetPreference == null)
                    {
                        var itemType = target.GetType().GetProperty("StaffPetPreference").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.StaffPetPreference = (IStaffPetPreference) newItem;
                    }

                    isModified |= source.StaffPetPreference.Synchronize(target.StaffPetPreference);
                }
            }

            // -------------------------------------------------------------

            // Sync lists
            if (sourceSupport == null || sourceSupport.IsStaffPetsSupported)
            {
                isModified |=
                    source.StaffPets.SynchronizeCollectionTo(
                        target.StaffPets,
                        onChildAdded: child =>
                            {
                                child.StaffExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Staff);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStaffPetIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IStaffExtension source, IStaffExtension target, Action<IStaffExtension, IStaffExtension> onMapped)
        {
            var sourceSynchSupport = source as IStaffExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IStaffExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsFirstPetOwnedDateSupported)
                target.FirstPetOwnedDate = source.FirstPetOwnedDate;
            else
                targetSynchSupport.IsFirstPetOwnedDateSupported = false;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // StaffPetPreference (Source)
            if (sourceSynchSupport.IsStaffPetPreferenceSupported)
            {
                var itemProperty = target.GetType().GetProperty("StaffPetPreference");

                if (itemProperty != null)
                {
                    if (source.StaffPetPreference == null)
                    {
                        target.StaffPetPreference = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetStaffPetPreference = Activator.CreateInstance(itemType);
                        (targetStaffPetPreference as IChildEntity)?.SetParent(target.Staff);
                        source.StaffPetPreference.Map(targetStaffPetPreference);

                        // Update the target reference appropriately
                        target.StaffPetPreference = (IStaffPetPreference) targetStaffPetPreference;
                    }
                }
            }
            else
            {
                targetSynchSupport.IsStaffPetPreferenceSupported = false;
            }
            // -------------------------------------------------------------

            // Map lists

            if (sourceSynchSupport.IsStaffPetsSupported)
            {
                targetSynchSupport.IsStaffPetIncluded = sourceSynchSupport.IsStaffPetIncluded;
                source.StaffPets.MapCollectionTo(target.StaffPets, target.Staff);
            }
            else
            {
                targetSynchSupport.IsStaffPetsSupported = false;
            }


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
    public interface IStaffExtensionSynchronizationSourceSupport 
    {
        bool IsFirstPetOwnedDateSupported { get; set; }
        bool IsStaffPetPreferenceSupported { get; set; }
        bool IsStaffPetsSupported { get; set; }
        Func<IStaffPet, bool> IsStaffPetIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StaffPetMapper
    {
        public static bool SynchronizeTo(this IStaffPet source, IStaffPet target)
        {
            bool isModified = false;

            var sourceSupport = source as IStaffPetSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.PetName != target.PetName)
            {
                source.PetName = target.PetName;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsIsFixedSupported)
                && target.IsFixed != source.IsFixed)
            {
                target.IsFixed = source.IsFixed;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStaffPet source, IStaffPet target, Action<IStaffPet, IStaffPet> onMapped)
        {
            var sourceSynchSupport = source as IStaffPetSynchronizationSourceSupport;
            var targetSynchSupport = target as IStaffPetSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.PetName = source.PetName;

            // Copy non-PK properties

            if (sourceSynchSupport.IsIsFixedSupported)
                target.IsFixed = source.IsFixed;
            else
                targetSynchSupport.IsIsFixedSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IStaffPetSynchronizationSourceSupport 
    {
        bool IsIsFixedSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StaffPetPreferenceMapper
    {
        public static bool SynchronizeTo(this IStaffPetPreference source, IStaffPetPreference target)
        {
            bool isModified = false;

            var sourceSupport = source as IStaffPetPreferenceSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsMaximumWeightSupported)
                && target.MaximumWeight != source.MaximumWeight)
            {
                target.MaximumWeight = source.MaximumWeight;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMinimumWeightSupported)
                && target.MinimumWeight != source.MinimumWeight)
            {
                target.MinimumWeight = source.MinimumWeight;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStaffPetPreference source, IStaffPetPreference target, Action<IStaffPetPreference, IStaffPetPreference> onMapped)
        {
            var sourceSynchSupport = source as IStaffPetPreferenceSynchronizationSourceSupport;
            var targetSynchSupport = target as IStaffPetPreferenceSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsMaximumWeightSupported)
                target.MaximumWeight = source.MaximumWeight;
            else
                targetSynchSupport.IsMaximumWeightSupported = false;

            if (sourceSynchSupport.IsMinimumWeightSupported)
                target.MinimumWeight = source.MinimumWeight;
            else
                targetSynchSupport.IsMinimumWeightSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IStaffPetPreferenceSynchronizationSourceSupport 
    {
        bool IsMaximumWeightSupported { get; set; }
        bool IsMinimumWeightSupported { get; set; }
    }

}
// Aggregate: Student

namespace EdFi.Ods.Entities.Common.Sample //.StudentAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentAquaticPetMapper
    {
        public static bool SynchronizeTo(this IStudentAquaticPet source, IStudentAquaticPet target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentAquaticPetSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.MimimumTankVolume != target.MimimumTankVolume)
            {
                source.MimimumTankVolume = target.MimimumTankVolume;
            }
            if (source.PetName != target.PetName)
            {
                source.PetName = target.PetName;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsIsFixedSupported)
                && target.IsFixed != source.IsFixed)
            {
                target.IsFixed = source.IsFixed;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentAquaticPet source, IStudentAquaticPet target, Action<IStudentAquaticPet, IStudentAquaticPet> onMapped)
        {
            var sourceSynchSupport = source as IStudentAquaticPetSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentAquaticPetSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.MimimumTankVolume = source.MimimumTankVolume;
            target.PetName = source.PetName;

            // Copy non-PK properties

            if (sourceSynchSupport.IsIsFixedSupported)
                target.IsFixed = source.IsFixed;
            else
                targetSynchSupport.IsIsFixedSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IStudentAquaticPetSynchronizationSourceSupport 
    {
        bool IsIsFixedSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentExtensionMapper
    {
        public static bool SynchronizeTo(this IStudentExtension source, IStudentExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.Student as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("Sample"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // StudentPetPreference
            if (sourceSupport == null || sourceSupport.IsStudentPetPreferenceSupported)
            {
                if (source.StudentPetPreference == null)
                {
                    if (target.StudentPetPreference != null)
                    {
                        target.StudentPetPreference = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.StudentPetPreference == null)
                    {
                        var itemType = target.GetType().GetProperty("StudentPetPreference").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.StudentPetPreference = (IStudentPetPreference) newItem;
                    }

                    isModified |= source.StudentPetPreference.Synchronize(target.StudentPetPreference);
                }
            }

            // -------------------------------------------------------------

            // Sync lists
            if (sourceSupport == null || sourceSupport.IsStudentAquaticPetsSupported)
            {
                isModified |=
                    source.StudentAquaticPets.SynchronizeCollectionTo(
                        target.StudentAquaticPets,
                        onChildAdded: child =>
                            {
                                child.StudentExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Student);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentAquaticPetIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentFavoriteBooksSupported)
            {
                isModified |=
                    source.StudentFavoriteBooks.SynchronizeCollectionTo(
                        target.StudentFavoriteBooks,
                        onChildAdded: child =>
                            {
                                child.StudentExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Student);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentFavoriteBookIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentPetsSupported)
            {
                isModified |=
                    source.StudentPets.SynchronizeCollectionTo(
                        target.StudentPets,
                        onChildAdded: child =>
                            {
                                child.StudentExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Student);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentPetIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IStudentExtension source, IStudentExtension target, Action<IStudentExtension, IStudentExtension> onMapped)
        {
            var sourceSynchSupport = source as IStudentExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // StudentPetPreference (Source)
            if (sourceSynchSupport.IsStudentPetPreferenceSupported)
            {
                var itemProperty = target.GetType().GetProperty("StudentPetPreference");

                if (itemProperty != null)
                {
                    if (source.StudentPetPreference == null)
                    {
                        target.StudentPetPreference = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetStudentPetPreference = Activator.CreateInstance(itemType);
                        (targetStudentPetPreference as IChildEntity)?.SetParent(target.Student);
                        source.StudentPetPreference.Map(targetStudentPetPreference);

                        // Update the target reference appropriately
                        target.StudentPetPreference = (IStudentPetPreference) targetStudentPetPreference;
                    }
                }
            }
            else
            {
                targetSynchSupport.IsStudentPetPreferenceSupported = false;
            }
            // -------------------------------------------------------------

            // Map lists

            if (sourceSynchSupport.IsStudentAquaticPetsSupported)
            {
                targetSynchSupport.IsStudentAquaticPetIncluded = sourceSynchSupport.IsStudentAquaticPetIncluded;
                source.StudentAquaticPets.MapCollectionTo(target.StudentAquaticPets, target.Student);
            }
            else
            {
                targetSynchSupport.IsStudentAquaticPetsSupported = false;
            }

            if (sourceSynchSupport.IsStudentFavoriteBooksSupported)
            {
                targetSynchSupport.IsStudentFavoriteBookIncluded = sourceSynchSupport.IsStudentFavoriteBookIncluded;
                source.StudentFavoriteBooks.MapCollectionTo(target.StudentFavoriteBooks, target.Student);
            }
            else
            {
                targetSynchSupport.IsStudentFavoriteBooksSupported = false;
            }

            if (sourceSynchSupport.IsStudentPetsSupported)
            {
                targetSynchSupport.IsStudentPetIncluded = sourceSynchSupport.IsStudentPetIncluded;
                source.StudentPets.MapCollectionTo(target.StudentPets, target.Student);
            }
            else
            {
                targetSynchSupport.IsStudentPetsSupported = false;
            }


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
    public interface IStudentExtensionSynchronizationSourceSupport 
    {
        bool IsStudentAquaticPetsSupported { get; set; }
        bool IsStudentFavoriteBooksSupported { get; set; }
        bool IsStudentPetPreferenceSupported { get; set; }
        bool IsStudentPetsSupported { get; set; }
        Func<IStudentAquaticPet, bool> IsStudentAquaticPetIncluded { get; set; }
        Func<IStudentFavoriteBook, bool> IsStudentFavoriteBookIncluded { get; set; }
        Func<IStudentPet, bool> IsStudentPetIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentFavoriteBookMapper
    {
        public static bool SynchronizeTo(this IStudentFavoriteBook source, IStudentFavoriteBook target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentFavoriteBookSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.FavoriteBookCategoryDescriptor != target.FavoriteBookCategoryDescriptor)
            {
                source.FavoriteBookCategoryDescriptor = target.FavoriteBookCategoryDescriptor;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsBookTitleSupported)
                && target.BookTitle != source.BookTitle)
            {
                target.BookTitle = source.BookTitle;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsStudentFavoriteBookArtMediaSupported)
            {
                isModified |=
                    source.StudentFavoriteBookArtMedia.SynchronizeCollectionTo(
                        target.StudentFavoriteBookArtMedia,
                        onChildAdded: child =>
                            {
                                child.StudentFavoriteBook = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentFavoriteBookArtMediumIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IStudentFavoriteBook source, IStudentFavoriteBook target, Action<IStudentFavoriteBook, IStudentFavoriteBook> onMapped)
        {
            var sourceSynchSupport = source as IStudentFavoriteBookSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentFavoriteBookSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.FavoriteBookCategoryDescriptor = source.FavoriteBookCategoryDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsBookTitleSupported)
                target.BookTitle = source.BookTitle;
            else
                targetSynchSupport.IsBookTitleSupported = false;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (sourceSynchSupport.IsStudentFavoriteBookArtMediaSupported)
            {
                targetSynchSupport.IsStudentFavoriteBookArtMediumIncluded = sourceSynchSupport.IsStudentFavoriteBookArtMediumIncluded;
                source.StudentFavoriteBookArtMedia.MapCollectionTo(target.StudentFavoriteBookArtMedia, target);
            }
            else
            {
                targetSynchSupport.IsStudentFavoriteBookArtMediaSupported = false;
            }


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
    public interface IStudentFavoriteBookSynchronizationSourceSupport 
    {
        bool IsBookTitleSupported { get; set; }
        bool IsStudentFavoriteBookArtMediaSupported { get; set; }
        Func<IStudentFavoriteBookArtMedium, bool> IsStudentFavoriteBookArtMediumIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentFavoriteBookArtMediumMapper
    {
        public static bool SynchronizeTo(this IStudentFavoriteBookArtMedium source, IStudentFavoriteBookArtMedium target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentFavoriteBookArtMediumSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.ArtMediumDescriptor != target.ArtMediumDescriptor)
            {
                source.ArtMediumDescriptor = target.ArtMediumDescriptor;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsArtPiecesSupported)
                && target.ArtPieces != source.ArtPieces)
            {
                target.ArtPieces = source.ArtPieces;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentFavoriteBookArtMedium source, IStudentFavoriteBookArtMedium target, Action<IStudentFavoriteBookArtMedium, IStudentFavoriteBookArtMedium> onMapped)
        {
            var sourceSynchSupport = source as IStudentFavoriteBookArtMediumSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentFavoriteBookArtMediumSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.ArtMediumDescriptor = source.ArtMediumDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsArtPiecesSupported)
                target.ArtPieces = source.ArtPieces;
            else
                targetSynchSupport.IsArtPiecesSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IStudentFavoriteBookArtMediumSynchronizationSourceSupport 
    {
        bool IsArtPiecesSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentPetMapper
    {
        public static bool SynchronizeTo(this IStudentPet source, IStudentPet target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentPetSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.PetName != target.PetName)
            {
                source.PetName = target.PetName;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsIsFixedSupported)
                && target.IsFixed != source.IsFixed)
            {
                target.IsFixed = source.IsFixed;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentPet source, IStudentPet target, Action<IStudentPet, IStudentPet> onMapped)
        {
            var sourceSynchSupport = source as IStudentPetSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentPetSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.PetName = source.PetName;

            // Copy non-PK properties

            if (sourceSynchSupport.IsIsFixedSupported)
                target.IsFixed = source.IsFixed;
            else
                targetSynchSupport.IsIsFixedSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IStudentPetSynchronizationSourceSupport 
    {
        bool IsIsFixedSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentPetPreferenceMapper
    {
        public static bool SynchronizeTo(this IStudentPetPreference source, IStudentPetPreference target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentPetPreferenceSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsMaximumWeightSupported)
                && target.MaximumWeight != source.MaximumWeight)
            {
                target.MaximumWeight = source.MaximumWeight;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMinimumWeightSupported)
                && target.MinimumWeight != source.MinimumWeight)
            {
                target.MinimumWeight = source.MinimumWeight;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentPetPreference source, IStudentPetPreference target, Action<IStudentPetPreference, IStudentPetPreference> onMapped)
        {
            var sourceSynchSupport = source as IStudentPetPreferenceSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentPetPreferenceSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsMaximumWeightSupported)
                target.MaximumWeight = source.MaximumWeight;
            else
                targetSynchSupport.IsMaximumWeightSupported = false;

            if (sourceSynchSupport.IsMinimumWeightSupported)
                target.MinimumWeight = source.MinimumWeight;
            else
                targetSynchSupport.IsMinimumWeightSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IStudentPetPreferenceSynchronizationSourceSupport 
    {
        bool IsMaximumWeightSupported { get; set; }
        bool IsMinimumWeightSupported { get; set; }
    }

}
// Aggregate: StudentArtProgramAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentArtProgramAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentArtProgramAssociationMapper
    {
        public static bool SynchronizeTo(this IStudentArtProgramAssociation source, IStudentArtProgramAssociation target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentArtProgramAssociationSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.BeginDate != target.BeginDate)
            {
                source.BeginDate = target.BeginDate;
            }
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.ProgramEducationOrganizationId != target.ProgramEducationOrganizationId)
            {
                source.ProgramEducationOrganizationId = target.ProgramEducationOrganizationId;
            }
            if (source.ProgramName != target.ProgramName)
            {
                source.ProgramName = target.ProgramName;
            }
            if (source.ProgramTypeDescriptor != target.ProgramTypeDescriptor)
            {
                source.ProgramTypeDescriptor = target.ProgramTypeDescriptor;
            }
            if (source.StudentUniqueId != target.StudentUniqueId)
            {
                source.StudentUniqueId = target.StudentUniqueId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsEndDateSupported)
                && target.EndDate != source.EndDate)
            {
                target.EndDate = source.EndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsReasonExitedDescriptorSupported)
                && target.ReasonExitedDescriptor != source.ReasonExitedDescriptor)
            {
                target.ReasonExitedDescriptor = source.ReasonExitedDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsServedOutsideOfRegularSessionSupported)
                && target.ServedOutsideOfRegularSession != source.ServedOutsideOfRegularSession)
            {
                target.ServedOutsideOfRegularSession = source.ServedOutsideOfRegularSession;
                isModified = true;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsArtPiecesSupported)
                && target.ArtPieces != source.ArtPieces)
            {
                target.ArtPieces = source.ArtPieces;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsExhibitDateSupported)
                && target.ExhibitDate != source.ExhibitDate)
            {
                target.ExhibitDate = source.ExhibitDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsHoursPerDaySupported)
                && target.HoursPerDay != source.HoursPerDay)
            {
                target.HoursPerDay = source.HoursPerDay;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsIdentificationCodeSupported)
                && target.IdentificationCode != source.IdentificationCode)
            {
                target.IdentificationCode = source.IdentificationCode;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsKilnReservationSupported)
                && target.KilnReservation != source.KilnReservation)
            {
                target.KilnReservation = source.KilnReservation;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsKilnReservationLengthSupported)
                && target.KilnReservationLength != source.KilnReservationLength)
            {
                target.KilnReservationLength = source.KilnReservationLength;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMasteredMediumsSupported)
                && target.MasteredMediums != source.MasteredMediums)
            {
                target.MasteredMediums = source.MasteredMediums;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNumberOfDaysInAttendanceSupported)
                && target.NumberOfDaysInAttendance != source.NumberOfDaysInAttendance)
            {
                target.NumberOfDaysInAttendance = source.NumberOfDaysInAttendance;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPortfolioPiecesSupported)
                && target.PortfolioPieces != source.PortfolioPieces)
            {
                target.PortfolioPieces = source.PortfolioPieces;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPrivateArtProgramSupported)
                && target.PrivateArtProgram != source.PrivateArtProgram)
            {
                target.PrivateArtProgram = source.PrivateArtProgram;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsProgramFeesSupported)
                && target.ProgramFees != source.ProgramFees)
            {
                target.ProgramFees = source.ProgramFees;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // GeneralStudentProgramAssociationParticipationStatus
            if (sourceSupport == null || sourceSupport.IsGeneralStudentProgramAssociationParticipationStatusSupported)
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
                        var newItem = Activator.CreateInstance(itemType);
                        target.GeneralStudentProgramAssociationParticipationStatus = (IGeneralStudentProgramAssociationParticipationStatus) newItem;
                    }

                    isModified |= source.GeneralStudentProgramAssociationParticipationStatus.Synchronize(target.GeneralStudentProgramAssociationParticipationStatus);
                }
            }

            // -------------------------------------------------------------

            // Synch inherited lists

            // Sync lists
            if (sourceSupport == null || sourceSupport.IsStudentArtProgramAssociationArtMediaSupported)
            {
                isModified |=
                    source.StudentArtProgramAssociationArtMedia.SynchronizeCollectionTo(
                        target.StudentArtProgramAssociationArtMedia,
                        onChildAdded: child =>
                            {
                                child.StudentArtProgramAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentArtProgramAssociationArtMediumIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentArtProgramAssociationPortfolioYearsSupported)
            {
                isModified |=
                    source.StudentArtProgramAssociationPortfolioYears.SynchronizeCollectionTo(
                        target.StudentArtProgramAssociationPortfolioYears,
                        onChildAdded: child =>
                            {
                                child.StudentArtProgramAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentArtProgramAssociationPortfolioYearsIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentArtProgramAssociationServicesSupported)
            {
                isModified |=
                    source.StudentArtProgramAssociationServices.SynchronizeCollectionTo(
                        target.StudentArtProgramAssociationServices,
                        onChildAdded: child =>
                            {
                                child.StudentArtProgramAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentArtProgramAssociationServiceIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentArtProgramAssociationStylesSupported)
            {
                isModified |=
                    source.StudentArtProgramAssociationStyles.SynchronizeCollectionTo(
                        target.StudentArtProgramAssociationStyles,
                        onChildAdded: child =>
                            {
                                child.StudentArtProgramAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentArtProgramAssociationStyleIncluded);
            }


            return isModified;
        }



        public static void MapDerivedTo(this IStudentArtProgramAssociation source, IStudentArtProgramAssociation target, Action<IStudentArtProgramAssociation, IStudentArtProgramAssociation> onMapped)
        {
            var sourceSynchSupport = source as IStudentArtProgramAssociationSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentArtProgramAssociationSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.BeginDate = source.BeginDate;
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.ProgramEducationOrganizationId = source.ProgramEducationOrganizationId;
            target.ProgramName = source.ProgramName;
            target.ProgramTypeDescriptor = source.ProgramTypeDescriptor;
            target.StudentUniqueId = source.StudentUniqueId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsEndDateSupported)
                target.EndDate = source.EndDate;
            else
                targetSynchSupport.IsEndDateSupported = false;

            if (sourceSynchSupport.IsReasonExitedDescriptorSupported)
                target.ReasonExitedDescriptor = source.ReasonExitedDescriptor;
            else
                targetSynchSupport.IsReasonExitedDescriptorSupported = false;

            if (sourceSynchSupport.IsServedOutsideOfRegularSessionSupported)
                target.ServedOutsideOfRegularSession = source.ServedOutsideOfRegularSession;
            else
                targetSynchSupport.IsServedOutsideOfRegularSessionSupported = false;

            // Copy non-PK properties

            if (sourceSynchSupport.IsArtPiecesSupported)
                target.ArtPieces = source.ArtPieces;
            else
                targetSynchSupport.IsArtPiecesSupported = false;

            if (sourceSynchSupport.IsExhibitDateSupported)
                target.ExhibitDate = source.ExhibitDate;
            else
                targetSynchSupport.IsExhibitDateSupported = false;

            if (sourceSynchSupport.IsHoursPerDaySupported)
                target.HoursPerDay = source.HoursPerDay;
            else
                targetSynchSupport.IsHoursPerDaySupported = false;

            if (sourceSynchSupport.IsIdentificationCodeSupported)
                target.IdentificationCode = source.IdentificationCode;
            else
                targetSynchSupport.IsIdentificationCodeSupported = false;

            if (sourceSynchSupport.IsKilnReservationSupported)
                target.KilnReservation = source.KilnReservation;
            else
                targetSynchSupport.IsKilnReservationSupported = false;

            if (sourceSynchSupport.IsKilnReservationLengthSupported)
                target.KilnReservationLength = source.KilnReservationLength;
            else
                targetSynchSupport.IsKilnReservationLengthSupported = false;

            if (sourceSynchSupport.IsMasteredMediumsSupported)
                target.MasteredMediums = source.MasteredMediums;
            else
                targetSynchSupport.IsMasteredMediumsSupported = false;

            if (sourceSynchSupport.IsNumberOfDaysInAttendanceSupported)
                target.NumberOfDaysInAttendance = source.NumberOfDaysInAttendance;
            else
                targetSynchSupport.IsNumberOfDaysInAttendanceSupported = false;

            if (sourceSynchSupport.IsPortfolioPiecesSupported)
                target.PortfolioPieces = source.PortfolioPieces;
            else
                targetSynchSupport.IsPortfolioPiecesSupported = false;

            if (sourceSynchSupport.IsPrivateArtProgramSupported)
                target.PrivateArtProgram = source.PrivateArtProgram;
            else
                targetSynchSupport.IsPrivateArtProgramSupported = false;

            if (sourceSynchSupport.IsProgramFeesSupported)
                target.ProgramFees = source.ProgramFees;
            else
                targetSynchSupport.IsProgramFeesSupported = false;

            // Copy Aggregate Reference Data
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



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // GeneralStudentProgramAssociationParticipationStatus (Source)
            if (sourceSynchSupport.IsGeneralStudentProgramAssociationParticipationStatusSupported)
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
                        object targetGeneralStudentProgramAssociationParticipationStatus = Activator.CreateInstance(itemType);
                        (targetGeneralStudentProgramAssociationParticipationStatus as IChildEntity)?.SetParent(target);
                        source.GeneralStudentProgramAssociationParticipationStatus.Map(targetGeneralStudentProgramAssociationParticipationStatus);

                        // Update the target reference appropriately
                        target.GeneralStudentProgramAssociationParticipationStatus = (IGeneralStudentProgramAssociationParticipationStatus) targetGeneralStudentProgramAssociationParticipationStatus;
                    }
                }
            }
            else
            {
                targetSynchSupport.IsGeneralStudentProgramAssociationParticipationStatusSupported = false;
            }
            // -------------------------------------------------------------

            // Map inherited lists

            // Map lists

            if (sourceSynchSupport.IsStudentArtProgramAssociationArtMediaSupported)
            {
                targetSynchSupport.IsStudentArtProgramAssociationArtMediumIncluded = sourceSynchSupport.IsStudentArtProgramAssociationArtMediumIncluded;
                source.StudentArtProgramAssociationArtMedia.MapCollectionTo(target.StudentArtProgramAssociationArtMedia, target);
            }
            else
            {
                targetSynchSupport.IsStudentArtProgramAssociationArtMediaSupported = false;
            }

            if (sourceSynchSupport.IsStudentArtProgramAssociationPortfolioYearsSupported)
            {
                targetSynchSupport.IsStudentArtProgramAssociationPortfolioYearsIncluded = sourceSynchSupport.IsStudentArtProgramAssociationPortfolioYearsIncluded;
                source.StudentArtProgramAssociationPortfolioYears.MapCollectionTo(target.StudentArtProgramAssociationPortfolioYears, target);
            }
            else
            {
                targetSynchSupport.IsStudentArtProgramAssociationPortfolioYearsSupported = false;
            }

            if (sourceSynchSupport.IsStudentArtProgramAssociationServicesSupported)
            {
                targetSynchSupport.IsStudentArtProgramAssociationServiceIncluded = sourceSynchSupport.IsStudentArtProgramAssociationServiceIncluded;
                source.StudentArtProgramAssociationServices.MapCollectionTo(target.StudentArtProgramAssociationServices, target);
            }
            else
            {
                targetSynchSupport.IsStudentArtProgramAssociationServicesSupported = false;
            }

            if (sourceSynchSupport.IsStudentArtProgramAssociationStylesSupported)
            {
                targetSynchSupport.IsStudentArtProgramAssociationStyleIncluded = sourceSynchSupport.IsStudentArtProgramAssociationStyleIncluded;
                source.StudentArtProgramAssociationStyles.MapCollectionTo(target.StudentArtProgramAssociationStyles, target);
            }
            else
            {
                targetSynchSupport.IsStudentArtProgramAssociationStylesSupported = false;
            }


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
    public interface IStudentArtProgramAssociationSynchronizationSourceSupport 
    {
        bool IsArtPiecesSupported { get; set; }
        bool IsEndDateSupported { get; set; }
        bool IsExhibitDateSupported { get; set; }
        bool IsGeneralStudentProgramAssociationParticipationStatusSupported { get; set; }
        bool IsHoursPerDaySupported { get; set; }
        bool IsIdentificationCodeSupported { get; set; }
        bool IsKilnReservationSupported { get; set; }
        bool IsKilnReservationLengthSupported { get; set; }
        bool IsMasteredMediumsSupported { get; set; }
        bool IsNumberOfDaysInAttendanceSupported { get; set; }
        bool IsPortfolioPiecesSupported { get; set; }
        bool IsPrivateArtProgramSupported { get; set; }
        bool IsProgramFeesSupported { get; set; }
        bool IsReasonExitedDescriptorSupported { get; set; }
        bool IsServedOutsideOfRegularSessionSupported { get; set; }
        bool IsStudentArtProgramAssociationArtMediaSupported { get; set; }
        bool IsStudentArtProgramAssociationPortfolioYearsSupported { get; set; }
        bool IsStudentArtProgramAssociationServicesSupported { get; set; }
        bool IsStudentArtProgramAssociationStylesSupported { get; set; }
        Func<IStudentArtProgramAssociationArtMedium, bool> IsStudentArtProgramAssociationArtMediumIncluded { get; set; }
        Func<IStudentArtProgramAssociationPortfolioYears, bool> IsStudentArtProgramAssociationPortfolioYearsIncluded { get; set; }
        Func<IStudentArtProgramAssociationService, bool> IsStudentArtProgramAssociationServiceIncluded { get; set; }
        Func<IStudentArtProgramAssociationStyle, bool> IsStudentArtProgramAssociationStyleIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentArtProgramAssociationArtMediumMapper
    {
        public static bool SynchronizeTo(this IStudentArtProgramAssociationArtMedium source, IStudentArtProgramAssociationArtMedium target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentArtProgramAssociationArtMediumSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.ArtMediumDescriptor != target.ArtMediumDescriptor)
            {
                source.ArtMediumDescriptor = target.ArtMediumDescriptor;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentArtProgramAssociationArtMedium source, IStudentArtProgramAssociationArtMedium target, Action<IStudentArtProgramAssociationArtMedium, IStudentArtProgramAssociationArtMedium> onMapped)
        {
            var sourceSynchSupport = source as IStudentArtProgramAssociationArtMediumSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentArtProgramAssociationArtMediumSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.ArtMediumDescriptor = source.ArtMediumDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentArtProgramAssociationArtMediumSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentArtProgramAssociationPortfolioYearsMapper
    {
        public static bool SynchronizeTo(this IStudentArtProgramAssociationPortfolioYears source, IStudentArtProgramAssociationPortfolioYears target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentArtProgramAssociationPortfolioYearsSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.PortfolioYears != target.PortfolioYears)
            {
                source.PortfolioYears = target.PortfolioYears;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentArtProgramAssociationPortfolioYears source, IStudentArtProgramAssociationPortfolioYears target, Action<IStudentArtProgramAssociationPortfolioYears, IStudentArtProgramAssociationPortfolioYears> onMapped)
        {
            var sourceSynchSupport = source as IStudentArtProgramAssociationPortfolioYearsSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentArtProgramAssociationPortfolioYearsSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.PortfolioYears = source.PortfolioYears;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentArtProgramAssociationPortfolioYearsSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentArtProgramAssociationServiceMapper
    {
        public static bool SynchronizeTo(this IStudentArtProgramAssociationService source, IStudentArtProgramAssociationService target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentArtProgramAssociationServiceSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.ServiceDescriptor != target.ServiceDescriptor)
            {
                source.ServiceDescriptor = target.ServiceDescriptor;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsPrimaryIndicatorSupported)
                && target.PrimaryIndicator != source.PrimaryIndicator)
            {
                target.PrimaryIndicator = source.PrimaryIndicator;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsServiceBeginDateSupported)
                && target.ServiceBeginDate != source.ServiceBeginDate)
            {
                target.ServiceBeginDate = source.ServiceBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsServiceEndDateSupported)
                && target.ServiceEndDate != source.ServiceEndDate)
            {
                target.ServiceEndDate = source.ServiceEndDate;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentArtProgramAssociationService source, IStudentArtProgramAssociationService target, Action<IStudentArtProgramAssociationService, IStudentArtProgramAssociationService> onMapped)
        {
            var sourceSynchSupport = source as IStudentArtProgramAssociationServiceSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentArtProgramAssociationServiceSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.ServiceDescriptor = source.ServiceDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsPrimaryIndicatorSupported)
                target.PrimaryIndicator = source.PrimaryIndicator;
            else
                targetSynchSupport.IsPrimaryIndicatorSupported = false;

            if (sourceSynchSupport.IsServiceBeginDateSupported)
                target.ServiceBeginDate = source.ServiceBeginDate;
            else
                targetSynchSupport.IsServiceBeginDateSupported = false;

            if (sourceSynchSupport.IsServiceEndDateSupported)
                target.ServiceEndDate = source.ServiceEndDate;
            else
                targetSynchSupport.IsServiceEndDateSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IStudentArtProgramAssociationServiceSynchronizationSourceSupport 
    {
        bool IsPrimaryIndicatorSupported { get; set; }
        bool IsServiceBeginDateSupported { get; set; }
        bool IsServiceEndDateSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentArtProgramAssociationStyleMapper
    {
        public static bool SynchronizeTo(this IStudentArtProgramAssociationStyle source, IStudentArtProgramAssociationStyle target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentArtProgramAssociationStyleSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.Style != target.Style)
            {
                source.Style = target.Style;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentArtProgramAssociationStyle source, IStudentArtProgramAssociationStyle target, Action<IStudentArtProgramAssociationStyle, IStudentArtProgramAssociationStyle> onMapped)
        {
            var sourceSynchSupport = source as IStudentArtProgramAssociationStyleSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentArtProgramAssociationStyleSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.Style = source.Style;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentArtProgramAssociationStyleSynchronizationSourceSupport 
    {
    }

}
// Aggregate: StudentCTEProgramAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentCTEProgramAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentCTEProgramAssociationExtensionMapper
    {
        public static bool SynchronizeTo(this IStudentCTEProgramAssociationExtension source, IStudentCTEProgramAssociationExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentCTEProgramAssociationExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.StudentCTEProgramAssociation as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("Sample"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsAnalysisCompletedSupported)
                && target.AnalysisCompleted != source.AnalysisCompleted)
            {
                target.AnalysisCompleted = source.AnalysisCompleted;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsAnalysisDateSupported)
                && target.AnalysisDate != source.AnalysisDate)
            {
                target.AnalysisDate = source.AnalysisDate;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentCTEProgramAssociationExtension source, IStudentCTEProgramAssociationExtension target, Action<IStudentCTEProgramAssociationExtension, IStudentCTEProgramAssociationExtension> onMapped)
        {
            var sourceSynchSupport = source as IStudentCTEProgramAssociationExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentCTEProgramAssociationExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsAnalysisCompletedSupported)
                target.AnalysisCompleted = source.AnalysisCompleted;
            else
                targetSynchSupport.IsAnalysisCompletedSupported = false;

            if (sourceSynchSupport.IsAnalysisDateSupported)
                target.AnalysisDate = source.AnalysisDate;
            else
                targetSynchSupport.IsAnalysisDateSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IStudentCTEProgramAssociationExtensionSynchronizationSourceSupport 
    {
        bool IsAnalysisCompletedSupported { get; set; }
        bool IsAnalysisDateSupported { get; set; }
    }

}
// Aggregate: StudentEducationOrganizationAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentEducationOrganizationAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentEducationOrganizationAssociationAddressExtensionMapper
    {
        public static bool SynchronizeTo(this IStudentEducationOrganizationAssociationAddressExtension source, IStudentEducationOrganizationAssociationAddressExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentEducationOrganizationAssociationAddressExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.StudentEducationOrganizationAssociationAddress as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("Sample"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsComplexSupported)
                && target.Complex != source.Complex)
            {
                target.Complex = source.Complex;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsOnBusRouteSupported)
                && target.OnBusRoute != source.OnBusRoute)
            {
                target.OnBusRoute = source.OnBusRoute;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsStudentEducationOrganizationAssociationAddressSchoolDistrictsSupported)
            {
                isModified |=
                    source.StudentEducationOrganizationAssociationAddressSchoolDistricts.SynchronizeCollectionTo(
                        target.StudentEducationOrganizationAssociationAddressSchoolDistricts,
                        onChildAdded: child =>
                            {
                                child.StudentEducationOrganizationAssociationAddressExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentEducationOrganizationAssociationAddress);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentEducationOrganizationAssociationAddressTermsSupported)
            {
                isModified |=
                    source.StudentEducationOrganizationAssociationAddressTerms.SynchronizeCollectionTo(
                        target.StudentEducationOrganizationAssociationAddressTerms,
                        onChildAdded: child =>
                            {
                                child.StudentEducationOrganizationAssociationAddressExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentEducationOrganizationAssociationAddress);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentEducationOrganizationAssociationAddressTermIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IStudentEducationOrganizationAssociationAddressExtension source, IStudentEducationOrganizationAssociationAddressExtension target, Action<IStudentEducationOrganizationAssociationAddressExtension, IStudentEducationOrganizationAssociationAddressExtension> onMapped)
        {
            var sourceSynchSupport = source as IStudentEducationOrganizationAssociationAddressExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentEducationOrganizationAssociationAddressExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsComplexSupported)
                target.Complex = source.Complex;
            else
                targetSynchSupport.IsComplexSupported = false;

            if (sourceSynchSupport.IsOnBusRouteSupported)
                target.OnBusRoute = source.OnBusRoute;
            else
                targetSynchSupport.IsOnBusRouteSupported = false;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (sourceSynchSupport.IsStudentEducationOrganizationAssociationAddressSchoolDistrictsSupported)
            {
                targetSynchSupport.IsStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded = sourceSynchSupport.IsStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded;
                source.StudentEducationOrganizationAssociationAddressSchoolDistricts.MapCollectionTo(target.StudentEducationOrganizationAssociationAddressSchoolDistricts, target.StudentEducationOrganizationAssociationAddress);
            }
            else
            {
                targetSynchSupport.IsStudentEducationOrganizationAssociationAddressSchoolDistrictsSupported = false;
            }

            if (sourceSynchSupport.IsStudentEducationOrganizationAssociationAddressTermsSupported)
            {
                targetSynchSupport.IsStudentEducationOrganizationAssociationAddressTermIncluded = sourceSynchSupport.IsStudentEducationOrganizationAssociationAddressTermIncluded;
                source.StudentEducationOrganizationAssociationAddressTerms.MapCollectionTo(target.StudentEducationOrganizationAssociationAddressTerms, target.StudentEducationOrganizationAssociationAddress);
            }
            else
            {
                targetSynchSupport.IsStudentEducationOrganizationAssociationAddressTermsSupported = false;
            }


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
    public interface IStudentEducationOrganizationAssociationAddressExtensionSynchronizationSourceSupport 
    {
        bool IsComplexSupported { get; set; }
        bool IsOnBusRouteSupported { get; set; }
        bool IsStudentEducationOrganizationAssociationAddressSchoolDistrictsSupported { get; set; }
        bool IsStudentEducationOrganizationAssociationAddressTermsSupported { get; set; }
        Func<IStudentEducationOrganizationAssociationAddressSchoolDistrict, bool> IsStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded { get; set; }
        Func<IStudentEducationOrganizationAssociationAddressTerm, bool> IsStudentEducationOrganizationAssociationAddressTermIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentEducationOrganizationAssociationAddressSchoolDistrictMapper
    {
        public static bool SynchronizeTo(this IStudentEducationOrganizationAssociationAddressSchoolDistrict source, IStudentEducationOrganizationAssociationAddressSchoolDistrict target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentEducationOrganizationAssociationAddressSchoolDistrictSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.SchoolDistrict != target.SchoolDistrict)
            {
                source.SchoolDistrict = target.SchoolDistrict;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentEducationOrganizationAssociationAddressSchoolDistrict source, IStudentEducationOrganizationAssociationAddressSchoolDistrict target, Action<IStudentEducationOrganizationAssociationAddressSchoolDistrict, IStudentEducationOrganizationAssociationAddressSchoolDistrict> onMapped)
        {
            var sourceSynchSupport = source as IStudentEducationOrganizationAssociationAddressSchoolDistrictSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentEducationOrganizationAssociationAddressSchoolDistrictSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.SchoolDistrict = source.SchoolDistrict;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentEducationOrganizationAssociationAddressSchoolDistrictSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentEducationOrganizationAssociationAddressTermMapper
    {
        public static bool SynchronizeTo(this IStudentEducationOrganizationAssociationAddressTerm source, IStudentEducationOrganizationAssociationAddressTerm target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentEducationOrganizationAssociationAddressTermSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.TermDescriptor != target.TermDescriptor)
            {
                source.TermDescriptor = target.TermDescriptor;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentEducationOrganizationAssociationAddressTerm source, IStudentEducationOrganizationAssociationAddressTerm target, Action<IStudentEducationOrganizationAssociationAddressTerm, IStudentEducationOrganizationAssociationAddressTerm> onMapped)
        {
            var sourceSynchSupport = source as IStudentEducationOrganizationAssociationAddressTermSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentEducationOrganizationAssociationAddressTermSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.TermDescriptor = source.TermDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentEducationOrganizationAssociationAddressTermSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentEducationOrganizationAssociationStudentCharacteristicExtensionMapper
    {
        public static bool SynchronizeTo(this IStudentEducationOrganizationAssociationStudentCharacteristicExtension source, IStudentEducationOrganizationAssociationStudentCharacteristicExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentEducationOrganizationAssociationStudentCharacteristicExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.StudentEducationOrganizationAssociationStudentCharacteristic as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("Sample"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsSupported)
            {
                isModified |=
                    source.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds.SynchronizeCollectionTo(
                        target.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds,
                        onChildAdded: child =>
                            {
                                child.StudentEducationOrganizationAssociationStudentCharacteristicExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentEducationOrganizationAssociationStudentCharacteristic);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IStudentEducationOrganizationAssociationStudentCharacteristicExtension source, IStudentEducationOrganizationAssociationStudentCharacteristicExtension target, Action<IStudentEducationOrganizationAssociationStudentCharacteristicExtension, IStudentEducationOrganizationAssociationStudentCharacteristicExtension> onMapped)
        {
            var sourceSynchSupport = source as IStudentEducationOrganizationAssociationStudentCharacteristicExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentEducationOrganizationAssociationStudentCharacteristicExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (sourceSynchSupport.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsSupported)
            {
                targetSynchSupport.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded = sourceSynchSupport.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded;
                source.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds.MapCollectionTo(target.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds, target.StudentEducationOrganizationAssociationStudentCharacteristic);
            }
            else
            {
                targetSynchSupport.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsSupported = false;
            }


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
    public interface IStudentEducationOrganizationAssociationStudentCharacteristicExtensionSynchronizationSourceSupport 
    {
        bool IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsSupported { get; set; }
        Func<IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed, bool> IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentEducationOrganizationAssociationStudentCharacteristicStudentNeedMapper
    {
        public static bool SynchronizeTo(this IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed source, IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.BeginDate != target.BeginDate)
            {
                source.BeginDate = target.BeginDate;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsEndDateSupported)
                && target.EndDate != source.EndDate)
            {
                target.EndDate = source.EndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPrimaryStudentNeedIndicatorSupported)
                && target.PrimaryStudentNeedIndicator != source.PrimaryStudentNeedIndicator)
            {
                target.PrimaryStudentNeedIndicator = source.PrimaryStudentNeedIndicator;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed source, IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed target, Action<IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed, IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed> onMapped)
        {
            var sourceSynchSupport = source as IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.BeginDate = source.BeginDate;

            // Copy non-PK properties

            if (sourceSynchSupport.IsEndDateSupported)
                target.EndDate = source.EndDate;
            else
                targetSynchSupport.IsEndDateSupported = false;

            if (sourceSynchSupport.IsPrimaryStudentNeedIndicatorSupported)
                target.PrimaryStudentNeedIndicator = source.PrimaryStudentNeedIndicator;
            else
                targetSynchSupport.IsPrimaryStudentNeedIndicatorSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedSynchronizationSourceSupport 
    {
        bool IsEndDateSupported { get; set; }
        bool IsPrimaryStudentNeedIndicatorSupported { get; set; }
    }

}
// Aggregate: StudentGraduationPlanAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentGraduationPlanAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationMapper
    {
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociation source, IStudentGraduationPlanAssociation target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentGraduationPlanAssociationSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.GraduationPlanTypeDescriptor != target.GraduationPlanTypeDescriptor)
            {
                source.GraduationPlanTypeDescriptor = target.GraduationPlanTypeDescriptor;
            }
            if (source.GraduationSchoolYear != target.GraduationSchoolYear)
            {
                source.GraduationSchoolYear = target.GraduationSchoolYear;
            }
            if (source.StudentUniqueId != target.StudentUniqueId)
            {
                source.StudentUniqueId = target.StudentUniqueId;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsCommencementTimeSupported)
                && target.CommencementTime != source.CommencementTime)
            {
                target.CommencementTime = source.CommencementTime;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveDateSupported)
                && target.EffectiveDate != source.EffectiveDate)
            {
                target.EffectiveDate = source.EffectiveDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsGraduationFeeSupported)
                && target.GraduationFee != source.GraduationFee)
            {
                target.GraduationFee = source.GraduationFee;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsHighSchoolDurationSupported)
                && target.HighSchoolDuration != source.HighSchoolDuration)
            {
                target.HighSchoolDuration = source.HighSchoolDuration;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsHoursPerWeekSupported)
                && target.HoursPerWeek != source.HoursPerWeek)
            {
                target.HoursPerWeek = source.HoursPerWeek;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsIsActivePlanSupported)
                && target.IsActivePlan != source.IsActivePlan)
            {
                target.IsActivePlan = source.IsActivePlan;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsRequiredAttendanceSupported)
                && target.RequiredAttendance != source.RequiredAttendance)
            {
                target.RequiredAttendance = source.RequiredAttendance;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsStaffUniqueIdSupported)
                && target.StaffUniqueId != source.StaffUniqueId)
            {
                target.StaffUniqueId = source.StaffUniqueId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsTargetGPASupported)
                && target.TargetGPA != source.TargetGPA)
            {
                target.TargetGPA = source.TargetGPA;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // StudentGraduationPlanAssociationCTEProgram
            if (sourceSupport == null || sourceSupport.IsStudentGraduationPlanAssociationCTEProgramSupported)
            {
                if (source.StudentGraduationPlanAssociationCTEProgram == null)
                {
                    if (target.StudentGraduationPlanAssociationCTEProgram != null)
                    {
                        target.StudentGraduationPlanAssociationCTEProgram = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.StudentGraduationPlanAssociationCTEProgram == null)
                    {
                        var itemType = target.GetType().GetProperty("StudentGraduationPlanAssociationCTEProgram").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.StudentGraduationPlanAssociationCTEProgram = (IStudentGraduationPlanAssociationCTEProgram) newItem;
                    }

                    isModified |= source.StudentGraduationPlanAssociationCTEProgram.Synchronize(target.StudentGraduationPlanAssociationCTEProgram);
                }
            }

            // -------------------------------------------------------------

            // Sync lists
            if (sourceSupport == null || sourceSupport.IsStudentGraduationPlanAssociationAcademicSubjectsSupported)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationAcademicSubjects.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationAcademicSubjects,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentGraduationPlanAssociationAcademicSubjectIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentGraduationPlanAssociationCareerPathwayCodesSupported)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationCareerPathwayCodes.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationCareerPathwayCodes,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentGraduationPlanAssociationCareerPathwayCodeIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentGraduationPlanAssociationDescriptionsSupported)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationDescriptions.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationDescriptions,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentGraduationPlanAssociationDescriptionIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentGraduationPlanAssociationDesignatedBiesSupported)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationDesignatedBies.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationDesignatedBies,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentGraduationPlanAssociationDesignatedByIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentGraduationPlanAssociationIndustryCredentialsSupported)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationIndustryCredentials.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationIndustryCredentials,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentGraduationPlanAssociationIndustryCredentialIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentGraduationPlanAssociationStudentParentAssociationsSupported)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationStudentParentAssociations.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationStudentParentAssociations,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentGraduationPlanAssociationStudentParentAssociationIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentGraduationPlanAssociationYearsAttendedsSupported)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationYearsAttendeds.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationYearsAttendeds,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentGraduationPlanAssociationYearsAttendedIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IStudentGraduationPlanAssociation source, IStudentGraduationPlanAssociation target, Action<IStudentGraduationPlanAssociation, IStudentGraduationPlanAssociation> onMapped)
        {
            var sourceSynchSupport = source as IStudentGraduationPlanAssociationSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentGraduationPlanAssociationSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.GraduationPlanTypeDescriptor = source.GraduationPlanTypeDescriptor;
            target.GraduationSchoolYear = source.GraduationSchoolYear;
            target.StudentUniqueId = source.StudentUniqueId;

            // Copy non-PK properties

            if (sourceSynchSupport.IsCommencementTimeSupported)
                target.CommencementTime = source.CommencementTime;
            else
                targetSynchSupport.IsCommencementTimeSupported = false;

            if (sourceSynchSupport.IsEffectiveDateSupported)
                target.EffectiveDate = source.EffectiveDate;
            else
                targetSynchSupport.IsEffectiveDateSupported = false;

            if (sourceSynchSupport.IsGraduationFeeSupported)
                target.GraduationFee = source.GraduationFee;
            else
                targetSynchSupport.IsGraduationFeeSupported = false;

            if (sourceSynchSupport.IsHighSchoolDurationSupported)
                target.HighSchoolDuration = source.HighSchoolDuration;
            else
                targetSynchSupport.IsHighSchoolDurationSupported = false;

            if (sourceSynchSupport.IsHoursPerWeekSupported)
                target.HoursPerWeek = source.HoursPerWeek;
            else
                targetSynchSupport.IsHoursPerWeekSupported = false;

            if (sourceSynchSupport.IsIsActivePlanSupported)
                target.IsActivePlan = source.IsActivePlan;
            else
                targetSynchSupport.IsIsActivePlanSupported = false;

            if (sourceSynchSupport.IsRequiredAttendanceSupported)
                target.RequiredAttendance = source.RequiredAttendance;
            else
                targetSynchSupport.IsRequiredAttendanceSupported = false;

            if (sourceSynchSupport.IsStaffUniqueIdSupported)
                target.StaffUniqueId = source.StaffUniqueId;
            else
                targetSynchSupport.IsStaffUniqueIdSupported = false;

            if (sourceSynchSupport.IsTargetGPASupported)
                target.TargetGPA = source.TargetGPA;
            else
                targetSynchSupport.IsTargetGPASupported = false;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.GraduationPlanResourceId = source.GraduationPlanResourceId;
                target.GraduationPlanDiscriminator = source.GraduationPlanDiscriminator;
                target.StaffResourceId = source.StaffResourceId;
                target.StaffDiscriminator = source.StaffDiscriminator;
                target.StudentResourceId = source.StudentResourceId;
                target.StudentDiscriminator = source.StudentDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // StudentGraduationPlanAssociationCTEProgram (Source)
            if (sourceSynchSupport.IsStudentGraduationPlanAssociationCTEProgramSupported)
            {
                var itemProperty = target.GetType().GetProperty("StudentGraduationPlanAssociationCTEProgram");

                if (itemProperty != null)
                {
                    if (source.StudentGraduationPlanAssociationCTEProgram == null)
                    {
                        target.StudentGraduationPlanAssociationCTEProgram = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetStudentGraduationPlanAssociationCTEProgram = Activator.CreateInstance(itemType);
                        (targetStudentGraduationPlanAssociationCTEProgram as IChildEntity)?.SetParent(target);
                        source.StudentGraduationPlanAssociationCTEProgram.Map(targetStudentGraduationPlanAssociationCTEProgram);

                        // Update the target reference appropriately
                        target.StudentGraduationPlanAssociationCTEProgram = (IStudentGraduationPlanAssociationCTEProgram) targetStudentGraduationPlanAssociationCTEProgram;
                    }
                }
            }
            else
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationCTEProgramSupported = false;
            }
            // -------------------------------------------------------------

            // Map lists

            if (sourceSynchSupport.IsStudentGraduationPlanAssociationAcademicSubjectsSupported)
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationAcademicSubjectIncluded = sourceSynchSupport.IsStudentGraduationPlanAssociationAcademicSubjectIncluded;
                source.StudentGraduationPlanAssociationAcademicSubjects.MapCollectionTo(target.StudentGraduationPlanAssociationAcademicSubjects, target);
            }
            else
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationAcademicSubjectsSupported = false;
            }

            if (sourceSynchSupport.IsStudentGraduationPlanAssociationCareerPathwayCodesSupported)
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationCareerPathwayCodeIncluded = sourceSynchSupport.IsStudentGraduationPlanAssociationCareerPathwayCodeIncluded;
                source.StudentGraduationPlanAssociationCareerPathwayCodes.MapCollectionTo(target.StudentGraduationPlanAssociationCareerPathwayCodes, target);
            }
            else
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationCareerPathwayCodesSupported = false;
            }

            if (sourceSynchSupport.IsStudentGraduationPlanAssociationDescriptionsSupported)
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationDescriptionIncluded = sourceSynchSupport.IsStudentGraduationPlanAssociationDescriptionIncluded;
                source.StudentGraduationPlanAssociationDescriptions.MapCollectionTo(target.StudentGraduationPlanAssociationDescriptions, target);
            }
            else
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationDescriptionsSupported = false;
            }

            if (sourceSynchSupport.IsStudentGraduationPlanAssociationDesignatedBiesSupported)
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationDesignatedByIncluded = sourceSynchSupport.IsStudentGraduationPlanAssociationDesignatedByIncluded;
                source.StudentGraduationPlanAssociationDesignatedBies.MapCollectionTo(target.StudentGraduationPlanAssociationDesignatedBies, target);
            }
            else
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationDesignatedBiesSupported = false;
            }

            if (sourceSynchSupport.IsStudentGraduationPlanAssociationIndustryCredentialsSupported)
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationIndustryCredentialIncluded = sourceSynchSupport.IsStudentGraduationPlanAssociationIndustryCredentialIncluded;
                source.StudentGraduationPlanAssociationIndustryCredentials.MapCollectionTo(target.StudentGraduationPlanAssociationIndustryCredentials, target);
            }
            else
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationIndustryCredentialsSupported = false;
            }

            if (sourceSynchSupport.IsStudentGraduationPlanAssociationStudentParentAssociationsSupported)
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationStudentParentAssociationIncluded = sourceSynchSupport.IsStudentGraduationPlanAssociationStudentParentAssociationIncluded;
                source.StudentGraduationPlanAssociationStudentParentAssociations.MapCollectionTo(target.StudentGraduationPlanAssociationStudentParentAssociations, target);
            }
            else
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationStudentParentAssociationsSupported = false;
            }

            if (sourceSynchSupport.IsStudentGraduationPlanAssociationYearsAttendedsSupported)
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationYearsAttendedIncluded = sourceSynchSupport.IsStudentGraduationPlanAssociationYearsAttendedIncluded;
                source.StudentGraduationPlanAssociationYearsAttendeds.MapCollectionTo(target.StudentGraduationPlanAssociationYearsAttendeds, target);
            }
            else
            {
                targetSynchSupport.IsStudentGraduationPlanAssociationYearsAttendedsSupported = false;
            }


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
    public interface IStudentGraduationPlanAssociationSynchronizationSourceSupport 
    {
        bool IsCommencementTimeSupported { get; set; }
        bool IsEffectiveDateSupported { get; set; }
        bool IsGraduationFeeSupported { get; set; }
        bool IsHighSchoolDurationSupported { get; set; }
        bool IsHoursPerWeekSupported { get; set; }
        bool IsIsActivePlanSupported { get; set; }
        bool IsRequiredAttendanceSupported { get; set; }
        bool IsStaffUniqueIdSupported { get; set; }
        bool IsStudentGraduationPlanAssociationAcademicSubjectsSupported { get; set; }
        bool IsStudentGraduationPlanAssociationCareerPathwayCodesSupported { get; set; }
        bool IsStudentGraduationPlanAssociationCTEProgramSupported { get; set; }
        bool IsStudentGraduationPlanAssociationDescriptionsSupported { get; set; }
        bool IsStudentGraduationPlanAssociationDesignatedBiesSupported { get; set; }
        bool IsStudentGraduationPlanAssociationIndustryCredentialsSupported { get; set; }
        bool IsStudentGraduationPlanAssociationStudentParentAssociationsSupported { get; set; }
        bool IsStudentGraduationPlanAssociationYearsAttendedsSupported { get; set; }
        bool IsTargetGPASupported { get; set; }
        Func<IStudentGraduationPlanAssociationAcademicSubject, bool> IsStudentGraduationPlanAssociationAcademicSubjectIncluded { get; set; }
        Func<IStudentGraduationPlanAssociationCareerPathwayCode, bool> IsStudentGraduationPlanAssociationCareerPathwayCodeIncluded { get; set; }
        Func<IStudentGraduationPlanAssociationDescription, bool> IsStudentGraduationPlanAssociationDescriptionIncluded { get; set; }
        Func<IStudentGraduationPlanAssociationDesignatedBy, bool> IsStudentGraduationPlanAssociationDesignatedByIncluded { get; set; }
        Func<IStudentGraduationPlanAssociationIndustryCredential, bool> IsStudentGraduationPlanAssociationIndustryCredentialIncluded { get; set; }
        Func<IStudentGraduationPlanAssociationStudentParentAssociation, bool> IsStudentGraduationPlanAssociationStudentParentAssociationIncluded { get; set; }
        Func<IStudentGraduationPlanAssociationYearsAttended, bool> IsStudentGraduationPlanAssociationYearsAttendedIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationAcademicSubjectMapper
    {
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationAcademicSubject source, IStudentGraduationPlanAssociationAcademicSubject target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentGraduationPlanAssociationAcademicSubjectSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.AcademicSubjectDescriptor != target.AcademicSubjectDescriptor)
            {
                source.AcademicSubjectDescriptor = target.AcademicSubjectDescriptor;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentGraduationPlanAssociationAcademicSubject source, IStudentGraduationPlanAssociationAcademicSubject target, Action<IStudentGraduationPlanAssociationAcademicSubject, IStudentGraduationPlanAssociationAcademicSubject> onMapped)
        {
            var sourceSynchSupport = source as IStudentGraduationPlanAssociationAcademicSubjectSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentGraduationPlanAssociationAcademicSubjectSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.AcademicSubjectDescriptor = source.AcademicSubjectDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentGraduationPlanAssociationAcademicSubjectSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationCareerPathwayCodeMapper
    {
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationCareerPathwayCode source, IStudentGraduationPlanAssociationCareerPathwayCode target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentGraduationPlanAssociationCareerPathwayCodeSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.CareerPathwayCode != target.CareerPathwayCode)
            {
                source.CareerPathwayCode = target.CareerPathwayCode;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentGraduationPlanAssociationCareerPathwayCode source, IStudentGraduationPlanAssociationCareerPathwayCode target, Action<IStudentGraduationPlanAssociationCareerPathwayCode, IStudentGraduationPlanAssociationCareerPathwayCode> onMapped)
        {
            var sourceSynchSupport = source as IStudentGraduationPlanAssociationCareerPathwayCodeSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentGraduationPlanAssociationCareerPathwayCodeSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.CareerPathwayCode = source.CareerPathwayCode;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentGraduationPlanAssociationCareerPathwayCodeSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationCTEProgramMapper
    {
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationCTEProgram source, IStudentGraduationPlanAssociationCTEProgram target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentGraduationPlanAssociationCTEProgramSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsCareerPathwayDescriptorSupported)
                && target.CareerPathwayDescriptor != source.CareerPathwayDescriptor)
            {
                target.CareerPathwayDescriptor = source.CareerPathwayDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCIPCodeSupported)
                && target.CIPCode != source.CIPCode)
            {
                target.CIPCode = source.CIPCode;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCTEProgramCompletionIndicatorSupported)
                && target.CTEProgramCompletionIndicator != source.CTEProgramCompletionIndicator)
            {
                target.CTEProgramCompletionIndicator = source.CTEProgramCompletionIndicator;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPrimaryCTEProgramIndicatorSupported)
                && target.PrimaryCTEProgramIndicator != source.PrimaryCTEProgramIndicator)
            {
                target.PrimaryCTEProgramIndicator = source.PrimaryCTEProgramIndicator;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentGraduationPlanAssociationCTEProgram source, IStudentGraduationPlanAssociationCTEProgram target, Action<IStudentGraduationPlanAssociationCTEProgram, IStudentGraduationPlanAssociationCTEProgram> onMapped)
        {
            var sourceSynchSupport = source as IStudentGraduationPlanAssociationCTEProgramSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentGraduationPlanAssociationCTEProgramSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsCareerPathwayDescriptorSupported)
                target.CareerPathwayDescriptor = source.CareerPathwayDescriptor;
            else
                targetSynchSupport.IsCareerPathwayDescriptorSupported = false;

            if (sourceSynchSupport.IsCIPCodeSupported)
                target.CIPCode = source.CIPCode;
            else
                targetSynchSupport.IsCIPCodeSupported = false;

            if (sourceSynchSupport.IsCTEProgramCompletionIndicatorSupported)
                target.CTEProgramCompletionIndicator = source.CTEProgramCompletionIndicator;
            else
                targetSynchSupport.IsCTEProgramCompletionIndicatorSupported = false;

            if (sourceSynchSupport.IsPrimaryCTEProgramIndicatorSupported)
                target.PrimaryCTEProgramIndicator = source.PrimaryCTEProgramIndicator;
            else
                targetSynchSupport.IsPrimaryCTEProgramIndicatorSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IStudentGraduationPlanAssociationCTEProgramSynchronizationSourceSupport 
    {
        bool IsCareerPathwayDescriptorSupported { get; set; }
        bool IsCIPCodeSupported { get; set; }
        bool IsCTEProgramCompletionIndicatorSupported { get; set; }
        bool IsPrimaryCTEProgramIndicatorSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationDescriptionMapper
    {
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationDescription source, IStudentGraduationPlanAssociationDescription target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentGraduationPlanAssociationDescriptionSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.Description != target.Description)
            {
                source.Description = target.Description;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentGraduationPlanAssociationDescription source, IStudentGraduationPlanAssociationDescription target, Action<IStudentGraduationPlanAssociationDescription, IStudentGraduationPlanAssociationDescription> onMapped)
        {
            var sourceSynchSupport = source as IStudentGraduationPlanAssociationDescriptionSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentGraduationPlanAssociationDescriptionSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.Description = source.Description;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentGraduationPlanAssociationDescriptionSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationDesignatedByMapper
    {
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationDesignatedBy source, IStudentGraduationPlanAssociationDesignatedBy target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentGraduationPlanAssociationDesignatedBySynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.DesignatedBy != target.DesignatedBy)
            {
                source.DesignatedBy = target.DesignatedBy;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentGraduationPlanAssociationDesignatedBy source, IStudentGraduationPlanAssociationDesignatedBy target, Action<IStudentGraduationPlanAssociationDesignatedBy, IStudentGraduationPlanAssociationDesignatedBy> onMapped)
        {
            var sourceSynchSupport = source as IStudentGraduationPlanAssociationDesignatedBySynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentGraduationPlanAssociationDesignatedBySynchronizationSourceSupport;

            // Copy contextual primary key values
            target.DesignatedBy = source.DesignatedBy;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentGraduationPlanAssociationDesignatedBySynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationIndustryCredentialMapper
    {
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationIndustryCredential source, IStudentGraduationPlanAssociationIndustryCredential target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentGraduationPlanAssociationIndustryCredentialSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.IndustryCredential != target.IndustryCredential)
            {
                source.IndustryCredential = target.IndustryCredential;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentGraduationPlanAssociationIndustryCredential source, IStudentGraduationPlanAssociationIndustryCredential target, Action<IStudentGraduationPlanAssociationIndustryCredential, IStudentGraduationPlanAssociationIndustryCredential> onMapped)
        {
            var sourceSynchSupport = source as IStudentGraduationPlanAssociationIndustryCredentialSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentGraduationPlanAssociationIndustryCredentialSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.IndustryCredential = source.IndustryCredential;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentGraduationPlanAssociationIndustryCredentialSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationStudentParentAssociationMapper
    {
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationStudentParentAssociation source, IStudentGraduationPlanAssociationStudentParentAssociation target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentGraduationPlanAssociationStudentParentAssociationSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.ParentUniqueId != target.ParentUniqueId)
            {
                source.ParentUniqueId = target.ParentUniqueId;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentGraduationPlanAssociationStudentParentAssociation source, IStudentGraduationPlanAssociationStudentParentAssociation target, Action<IStudentGraduationPlanAssociationStudentParentAssociation, IStudentGraduationPlanAssociationStudentParentAssociation> onMapped)
        {
            var sourceSynchSupport = source as IStudentGraduationPlanAssociationStudentParentAssociationSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentGraduationPlanAssociationStudentParentAssociationSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.ParentUniqueId = source.ParentUniqueId;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.StudentParentAssociationResourceId = source.StudentParentAssociationResourceId;
                target.StudentParentAssociationDiscriminator = source.StudentParentAssociationDiscriminator;
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
    public interface IStudentGraduationPlanAssociationStudentParentAssociationSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationYearsAttendedMapper
    {
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationYearsAttended source, IStudentGraduationPlanAssociationYearsAttended target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentGraduationPlanAssociationYearsAttendedSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.YearsAttended != target.YearsAttended)
            {
                source.YearsAttended = target.YearsAttended;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentGraduationPlanAssociationYearsAttended source, IStudentGraduationPlanAssociationYearsAttended target, Action<IStudentGraduationPlanAssociationYearsAttended, IStudentGraduationPlanAssociationYearsAttended> onMapped)
        {
            var sourceSynchSupport = source as IStudentGraduationPlanAssociationYearsAttendedSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentGraduationPlanAssociationYearsAttendedSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.YearsAttended = source.YearsAttended;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentGraduationPlanAssociationYearsAttendedSynchronizationSourceSupport 
    {
    }

}
// Aggregate: StudentParentAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentParentAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentParentAssociationDisciplineMapper
    {
        public static bool SynchronizeTo(this IStudentParentAssociationDiscipline source, IStudentParentAssociationDiscipline target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentParentAssociationDisciplineSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.DisciplineDescriptor != target.DisciplineDescriptor)
            {
                source.DisciplineDescriptor = target.DisciplineDescriptor;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentParentAssociationDiscipline source, IStudentParentAssociationDiscipline target, Action<IStudentParentAssociationDiscipline, IStudentParentAssociationDiscipline> onMapped)
        {
            var sourceSynchSupport = source as IStudentParentAssociationDisciplineSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentParentAssociationDisciplineSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.DisciplineDescriptor = source.DisciplineDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentParentAssociationDisciplineSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentParentAssociationExtensionMapper
    {
        public static bool SynchronizeTo(this IStudentParentAssociationExtension source, IStudentParentAssociationExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentParentAssociationExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.StudentParentAssociation as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("Sample"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsBedtimeReaderSupported)
                && target.BedtimeReader != source.BedtimeReader)
            {
                target.BedtimeReader = source.BedtimeReader;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBedtimeReadingRateSupported)
                && target.BedtimeReadingRate != source.BedtimeReadingRate)
            {
                target.BedtimeReadingRate = source.BedtimeReadingRate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBookBudgetSupported)
                && target.BookBudget != source.BookBudget)
            {
                target.BookBudget = source.BookBudget;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBooksBorrowedSupported)
                && target.BooksBorrowed != source.BooksBorrowed)
            {
                target.BooksBorrowed = source.BooksBorrowed;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEducationOrganizationIdSupported)
                && target.EducationOrganizationId != source.EducationOrganizationId)
            {
                target.EducationOrganizationId = source.EducationOrganizationId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsInterventionStudyIdentificationCodeSupported)
                && target.InterventionStudyIdentificationCode != source.InterventionStudyIdentificationCode)
            {
                target.InterventionStudyIdentificationCode = source.InterventionStudyIdentificationCode;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLibraryDurationSupported)
                && target.LibraryDuration != source.LibraryDuration)
            {
                target.LibraryDuration = source.LibraryDuration;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLibraryTimeSupported)
                && target.LibraryTime != source.LibraryTime)
            {
                target.LibraryTime = source.LibraryTime;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLibraryVisitsSupported)
                && target.LibraryVisits != source.LibraryVisits)
            {
                target.LibraryVisits = source.LibraryVisits;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorContactRestrictionsSupported)
                && target.PriorContactRestrictions != source.PriorContactRestrictions)
            {
                target.PriorContactRestrictions = source.PriorContactRestrictions;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsReadGreenEggsAndHamDateSupported)
                && target.ReadGreenEggsAndHamDate != source.ReadGreenEggsAndHamDate)
            {
                target.ReadGreenEggsAndHamDate = source.ReadGreenEggsAndHamDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsReadingTimeSpentSupported)
                && target.ReadingTimeSpent != source.ReadingTimeSpent)
            {
                target.ReadingTimeSpent = source.ReadingTimeSpent;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsStudentReadSupported)
                && target.StudentRead != source.StudentRead)
            {
                target.StudentRead = source.StudentRead;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // StudentParentAssociationTelephone
            if (sourceSupport == null || sourceSupport.IsStudentParentAssociationTelephoneSupported)
            {
                if (source.StudentParentAssociationTelephone == null)
                {
                    if (target.StudentParentAssociationTelephone != null)
                    {
                        target.StudentParentAssociationTelephone = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.StudentParentAssociationTelephone == null)
                    {
                        var itemType = target.GetType().GetProperty("StudentParentAssociationTelephone").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.StudentParentAssociationTelephone = (IStudentParentAssociationTelephone) newItem;
                    }

                    isModified |= source.StudentParentAssociationTelephone.Synchronize(target.StudentParentAssociationTelephone);
                }
            }

            // -------------------------------------------------------------

            // Sync lists
            if (sourceSupport == null || sourceSupport.IsStudentParentAssociationDisciplinesSupported)
            {
                isModified |=
                    source.StudentParentAssociationDisciplines.SynchronizeCollectionTo(
                        target.StudentParentAssociationDisciplines,
                        onChildAdded: child =>
                            {
                                child.StudentParentAssociationExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentParentAssociation);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentParentAssociationDisciplineIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentParentAssociationFavoriteBookTitlesSupported)
            {
                isModified |=
                    source.StudentParentAssociationFavoriteBookTitles.SynchronizeCollectionTo(
                        target.StudentParentAssociationFavoriteBookTitles,
                        onChildAdded: child =>
                            {
                                child.StudentParentAssociationExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentParentAssociation);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentParentAssociationFavoriteBookTitleIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentParentAssociationHoursPerWeeksSupported)
            {
                isModified |=
                    source.StudentParentAssociationHoursPerWeeks.SynchronizeCollectionTo(
                        target.StudentParentAssociationHoursPerWeeks,
                        onChildAdded: child =>
                            {
                                child.StudentParentAssociationExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentParentAssociation);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentParentAssociationHoursPerWeekIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentParentAssociationPagesReadsSupported)
            {
                isModified |=
                    source.StudentParentAssociationPagesReads.SynchronizeCollectionTo(
                        target.StudentParentAssociationPagesReads,
                        onChildAdded: child =>
                            {
                                child.StudentParentAssociationExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentParentAssociation);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentParentAssociationPagesReadIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStudentParentAssociationStaffEducationOrganizationEmploymentAssociationsSupported)
            {
                isModified |=
                    source.StudentParentAssociationStaffEducationOrganizationEmploymentAssociations.SynchronizeCollectionTo(
                        target.StudentParentAssociationStaffEducationOrganizationEmploymentAssociations,
                        onChildAdded: child =>
                            {
                                child.StudentParentAssociationExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentParentAssociation);
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentParentAssociationStaffEducationOrganizationEmploymentAssociationIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IStudentParentAssociationExtension source, IStudentParentAssociationExtension target, Action<IStudentParentAssociationExtension, IStudentParentAssociationExtension> onMapped)
        {
            var sourceSynchSupport = source as IStudentParentAssociationExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentParentAssociationExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsBedtimeReaderSupported)
                target.BedtimeReader = source.BedtimeReader;
            else
                targetSynchSupport.IsBedtimeReaderSupported = false;

            if (sourceSynchSupport.IsBedtimeReadingRateSupported)
                target.BedtimeReadingRate = source.BedtimeReadingRate;
            else
                targetSynchSupport.IsBedtimeReadingRateSupported = false;

            if (sourceSynchSupport.IsBookBudgetSupported)
                target.BookBudget = source.BookBudget;
            else
                targetSynchSupport.IsBookBudgetSupported = false;

            if (sourceSynchSupport.IsBooksBorrowedSupported)
                target.BooksBorrowed = source.BooksBorrowed;
            else
                targetSynchSupport.IsBooksBorrowedSupported = false;

            if (sourceSynchSupport.IsEducationOrganizationIdSupported)
                target.EducationOrganizationId = source.EducationOrganizationId;
            else
                targetSynchSupport.IsEducationOrganizationIdSupported = false;

            if (sourceSynchSupport.IsInterventionStudyIdentificationCodeSupported)
                target.InterventionStudyIdentificationCode = source.InterventionStudyIdentificationCode;
            else
                targetSynchSupport.IsInterventionStudyIdentificationCodeSupported = false;

            if (sourceSynchSupport.IsLibraryDurationSupported)
                target.LibraryDuration = source.LibraryDuration;
            else
                targetSynchSupport.IsLibraryDurationSupported = false;

            if (sourceSynchSupport.IsLibraryTimeSupported)
                target.LibraryTime = source.LibraryTime;
            else
                targetSynchSupport.IsLibraryTimeSupported = false;

            if (sourceSynchSupport.IsLibraryVisitsSupported)
                target.LibraryVisits = source.LibraryVisits;
            else
                targetSynchSupport.IsLibraryVisitsSupported = false;

            if (sourceSynchSupport.IsPriorContactRestrictionsSupported)
                target.PriorContactRestrictions = source.PriorContactRestrictions;
            else
                targetSynchSupport.IsPriorContactRestrictionsSupported = false;

            if (sourceSynchSupport.IsReadGreenEggsAndHamDateSupported)
                target.ReadGreenEggsAndHamDate = source.ReadGreenEggsAndHamDate;
            else
                targetSynchSupport.IsReadGreenEggsAndHamDateSupported = false;

            if (sourceSynchSupport.IsReadingTimeSpentSupported)
                target.ReadingTimeSpent = source.ReadingTimeSpent;
            else
                targetSynchSupport.IsReadingTimeSpentSupported = false;

            if (sourceSynchSupport.IsStudentReadSupported)
                target.StudentRead = source.StudentRead;
            else
                targetSynchSupport.IsStudentReadSupported = false;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.InterventionStudyResourceId = source.InterventionStudyResourceId;
                target.InterventionStudyDiscriminator = source.InterventionStudyDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // StudentParentAssociationTelephone (Source)
            if (sourceSynchSupport.IsStudentParentAssociationTelephoneSupported)
            {
                var itemProperty = target.GetType().GetProperty("StudentParentAssociationTelephone");

                if (itemProperty != null)
                {
                    if (source.StudentParentAssociationTelephone == null)
                    {
                        target.StudentParentAssociationTelephone = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetStudentParentAssociationTelephone = Activator.CreateInstance(itemType);
                        (targetStudentParentAssociationTelephone as IChildEntity)?.SetParent(target.StudentParentAssociation);
                        source.StudentParentAssociationTelephone.Map(targetStudentParentAssociationTelephone);

                        // Update the target reference appropriately
                        target.StudentParentAssociationTelephone = (IStudentParentAssociationTelephone) targetStudentParentAssociationTelephone;
                    }
                }
            }
            else
            {
                targetSynchSupport.IsStudentParentAssociationTelephoneSupported = false;
            }
            // -------------------------------------------------------------

            // Map lists

            if (sourceSynchSupport.IsStudentParentAssociationDisciplinesSupported)
            {
                targetSynchSupport.IsStudentParentAssociationDisciplineIncluded = sourceSynchSupport.IsStudentParentAssociationDisciplineIncluded;
                source.StudentParentAssociationDisciplines.MapCollectionTo(target.StudentParentAssociationDisciplines, target.StudentParentAssociation);
            }
            else
            {
                targetSynchSupport.IsStudentParentAssociationDisciplinesSupported = false;
            }

            if (sourceSynchSupport.IsStudentParentAssociationFavoriteBookTitlesSupported)
            {
                targetSynchSupport.IsStudentParentAssociationFavoriteBookTitleIncluded = sourceSynchSupport.IsStudentParentAssociationFavoriteBookTitleIncluded;
                source.StudentParentAssociationFavoriteBookTitles.MapCollectionTo(target.StudentParentAssociationFavoriteBookTitles, target.StudentParentAssociation);
            }
            else
            {
                targetSynchSupport.IsStudentParentAssociationFavoriteBookTitlesSupported = false;
            }

            if (sourceSynchSupport.IsStudentParentAssociationHoursPerWeeksSupported)
            {
                targetSynchSupport.IsStudentParentAssociationHoursPerWeekIncluded = sourceSynchSupport.IsStudentParentAssociationHoursPerWeekIncluded;
                source.StudentParentAssociationHoursPerWeeks.MapCollectionTo(target.StudentParentAssociationHoursPerWeeks, target.StudentParentAssociation);
            }
            else
            {
                targetSynchSupport.IsStudentParentAssociationHoursPerWeeksSupported = false;
            }

            if (sourceSynchSupport.IsStudentParentAssociationPagesReadsSupported)
            {
                targetSynchSupport.IsStudentParentAssociationPagesReadIncluded = sourceSynchSupport.IsStudentParentAssociationPagesReadIncluded;
                source.StudentParentAssociationPagesReads.MapCollectionTo(target.StudentParentAssociationPagesReads, target.StudentParentAssociation);
            }
            else
            {
                targetSynchSupport.IsStudentParentAssociationPagesReadsSupported = false;
            }

            if (sourceSynchSupport.IsStudentParentAssociationStaffEducationOrganizationEmploymentAssociationsSupported)
            {
                targetSynchSupport.IsStudentParentAssociationStaffEducationOrganizationEmploymentAssociationIncluded = sourceSynchSupport.IsStudentParentAssociationStaffEducationOrganizationEmploymentAssociationIncluded;
                source.StudentParentAssociationStaffEducationOrganizationEmploymentAssociations.MapCollectionTo(target.StudentParentAssociationStaffEducationOrganizationEmploymentAssociations, target.StudentParentAssociation);
            }
            else
            {
                targetSynchSupport.IsStudentParentAssociationStaffEducationOrganizationEmploymentAssociationsSupported = false;
            }


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
    public interface IStudentParentAssociationExtensionSynchronizationSourceSupport 
    {
        bool IsBedtimeReaderSupported { get; set; }
        bool IsBedtimeReadingRateSupported { get; set; }
        bool IsBookBudgetSupported { get; set; }
        bool IsBooksBorrowedSupported { get; set; }
        bool IsEducationOrganizationIdSupported { get; set; }
        bool IsInterventionStudyIdentificationCodeSupported { get; set; }
        bool IsLibraryDurationSupported { get; set; }
        bool IsLibraryTimeSupported { get; set; }
        bool IsLibraryVisitsSupported { get; set; }
        bool IsPriorContactRestrictionsSupported { get; set; }
        bool IsReadGreenEggsAndHamDateSupported { get; set; }
        bool IsReadingTimeSpentSupported { get; set; }
        bool IsStudentParentAssociationDisciplinesSupported { get; set; }
        bool IsStudentParentAssociationFavoriteBookTitlesSupported { get; set; }
        bool IsStudentParentAssociationHoursPerWeeksSupported { get; set; }
        bool IsStudentParentAssociationPagesReadsSupported { get; set; }
        bool IsStudentParentAssociationStaffEducationOrganizationEmploymentAssociationsSupported { get; set; }
        bool IsStudentParentAssociationTelephoneSupported { get; set; }
        bool IsStudentReadSupported { get; set; }
        Func<IStudentParentAssociationDiscipline, bool> IsStudentParentAssociationDisciplineIncluded { get; set; }
        Func<IStudentParentAssociationFavoriteBookTitle, bool> IsStudentParentAssociationFavoriteBookTitleIncluded { get; set; }
        Func<IStudentParentAssociationHoursPerWeek, bool> IsStudentParentAssociationHoursPerWeekIncluded { get; set; }
        Func<IStudentParentAssociationPagesRead, bool> IsStudentParentAssociationPagesReadIncluded { get; set; }
        Func<IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation, bool> IsStudentParentAssociationStaffEducationOrganizationEmploymentAssociationIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentParentAssociationFavoriteBookTitleMapper
    {
        public static bool SynchronizeTo(this IStudentParentAssociationFavoriteBookTitle source, IStudentParentAssociationFavoriteBookTitle target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentParentAssociationFavoriteBookTitleSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.FavoriteBookTitle != target.FavoriteBookTitle)
            {
                source.FavoriteBookTitle = target.FavoriteBookTitle;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentParentAssociationFavoriteBookTitle source, IStudentParentAssociationFavoriteBookTitle target, Action<IStudentParentAssociationFavoriteBookTitle, IStudentParentAssociationFavoriteBookTitle> onMapped)
        {
            var sourceSynchSupport = source as IStudentParentAssociationFavoriteBookTitleSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentParentAssociationFavoriteBookTitleSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.FavoriteBookTitle = source.FavoriteBookTitle;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentParentAssociationFavoriteBookTitleSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentParentAssociationHoursPerWeekMapper
    {
        public static bool SynchronizeTo(this IStudentParentAssociationHoursPerWeek source, IStudentParentAssociationHoursPerWeek target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentParentAssociationHoursPerWeekSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.HoursPerWeek != target.HoursPerWeek)
            {
                source.HoursPerWeek = target.HoursPerWeek;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentParentAssociationHoursPerWeek source, IStudentParentAssociationHoursPerWeek target, Action<IStudentParentAssociationHoursPerWeek, IStudentParentAssociationHoursPerWeek> onMapped)
        {
            var sourceSynchSupport = source as IStudentParentAssociationHoursPerWeekSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentParentAssociationHoursPerWeekSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.HoursPerWeek = source.HoursPerWeek;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentParentAssociationHoursPerWeekSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentParentAssociationPagesReadMapper
    {
        public static bool SynchronizeTo(this IStudentParentAssociationPagesRead source, IStudentParentAssociationPagesRead target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentParentAssociationPagesReadSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.PagesRead != target.PagesRead)
            {
                source.PagesRead = target.PagesRead;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentParentAssociationPagesRead source, IStudentParentAssociationPagesRead target, Action<IStudentParentAssociationPagesRead, IStudentParentAssociationPagesRead> onMapped)
        {
            var sourceSynchSupport = source as IStudentParentAssociationPagesReadSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentParentAssociationPagesReadSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.PagesRead = source.PagesRead;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


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
    public interface IStudentParentAssociationPagesReadSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentParentAssociationStaffEducationOrganizationEmploymentAssociationMapper
    {
        public static bool SynchronizeTo(this IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation source, IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentParentAssociationStaffEducationOrganizationEmploymentAssociationSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.EmploymentStatusDescriptor != target.EmploymentStatusDescriptor)
            {
                source.EmploymentStatusDescriptor = target.EmploymentStatusDescriptor;
            }
            if (source.HireDate != target.HireDate)
            {
                source.HireDate = target.HireDate;
            }
            if (source.StaffUniqueId != target.StaffUniqueId)
            {
                source.StaffUniqueId = target.StaffUniqueId;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation source, IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation target, Action<IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation, IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation> onMapped)
        {
            var sourceSynchSupport = source as IStudentParentAssociationStaffEducationOrganizationEmploymentAssociationSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentParentAssociationStaffEducationOrganizationEmploymentAssociationSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.EmploymentStatusDescriptor = source.EmploymentStatusDescriptor;
            target.HireDate = source.HireDate;
            target.StaffUniqueId = source.StaffUniqueId;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.StaffEducationOrganizationEmploymentAssociationResourceId = source.StaffEducationOrganizationEmploymentAssociationResourceId;
                target.StaffEducationOrganizationEmploymentAssociationDiscriminator = source.StaffEducationOrganizationEmploymentAssociationDiscriminator;
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
    public interface IStudentParentAssociationStaffEducationOrganizationEmploymentAssociationSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StudentParentAssociationTelephoneMapper
    {
        public static bool SynchronizeTo(this IStudentParentAssociationTelephone source, IStudentParentAssociationTelephone target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentParentAssociationTelephoneSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsDoNotPublishIndicatorSupported)
                && target.DoNotPublishIndicator != source.DoNotPublishIndicator)
            {
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsOrderOfPrioritySupported)
                && target.OrderOfPriority != source.OrderOfPriority)
            {
                target.OrderOfPriority = source.OrderOfPriority;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsTelephoneNumberSupported)
                && target.TelephoneNumber != source.TelephoneNumber)
            {
                target.TelephoneNumber = source.TelephoneNumber;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsTelephoneNumberTypeDescriptorSupported)
                && target.TelephoneNumberTypeDescriptor != source.TelephoneNumberTypeDescriptor)
            {
                target.TelephoneNumberTypeDescriptor = source.TelephoneNumberTypeDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsTextMessageCapabilityIndicatorSupported)
                && target.TextMessageCapabilityIndicator != source.TextMessageCapabilityIndicator)
            {
                target.TextMessageCapabilityIndicator = source.TextMessageCapabilityIndicator;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentParentAssociationTelephone source, IStudentParentAssociationTelephone target, Action<IStudentParentAssociationTelephone, IStudentParentAssociationTelephone> onMapped)
        {
            var sourceSynchSupport = source as IStudentParentAssociationTelephoneSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentParentAssociationTelephoneSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsDoNotPublishIndicatorSupported)
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
            else
                targetSynchSupport.IsDoNotPublishIndicatorSupported = false;

            if (sourceSynchSupport.IsOrderOfPrioritySupported)
                target.OrderOfPriority = source.OrderOfPriority;
            else
                targetSynchSupport.IsOrderOfPrioritySupported = false;

            if (sourceSynchSupport.IsTelephoneNumberSupported)
                target.TelephoneNumber = source.TelephoneNumber;
            else
                targetSynchSupport.IsTelephoneNumberSupported = false;

            if (sourceSynchSupport.IsTelephoneNumberTypeDescriptorSupported)
                target.TelephoneNumberTypeDescriptor = source.TelephoneNumberTypeDescriptor;
            else
                targetSynchSupport.IsTelephoneNumberTypeDescriptorSupported = false;

            if (sourceSynchSupport.IsTextMessageCapabilityIndicatorSupported)
                target.TextMessageCapabilityIndicator = source.TextMessageCapabilityIndicator;
            else
                targetSynchSupport.IsTextMessageCapabilityIndicatorSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IStudentParentAssociationTelephoneSynchronizationSourceSupport 
    {
        bool IsDoNotPublishIndicatorSupported { get; set; }
        bool IsOrderOfPrioritySupported { get; set; }
        bool IsTelephoneNumberSupported { get; set; }
        bool IsTelephoneNumberTypeDescriptorSupported { get; set; }
        bool IsTextMessageCapabilityIndicatorSupported { get; set; }
    }

}
// Aggregate: StudentSchoolAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentSchoolAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentSchoolAssociationExtensionMapper
    {
        public static bool SynchronizeTo(this IStudentSchoolAssociationExtension source, IStudentSchoolAssociationExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentSchoolAssociationExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.StudentSchoolAssociation as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("Sample"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsMembershipTypeDescriptorSupported)
                && target.MembershipTypeDescriptor != source.MembershipTypeDescriptor)
            {
                target.MembershipTypeDescriptor = source.MembershipTypeDescriptor;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentSchoolAssociationExtension source, IStudentSchoolAssociationExtension target, Action<IStudentSchoolAssociationExtension, IStudentSchoolAssociationExtension> onMapped)
        {
            var sourceSynchSupport = source as IStudentSchoolAssociationExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentSchoolAssociationExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsMembershipTypeDescriptorSupported)
                target.MembershipTypeDescriptor = source.MembershipTypeDescriptor;
            else
                targetSynchSupport.IsMembershipTypeDescriptorSupported = false;

            // Copy Aggregate Reference Data


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
    public interface IStudentSchoolAssociationExtensionSynchronizationSourceSupport 
    {
        bool IsMembershipTypeDescriptorSupported { get; set; }
    }

}

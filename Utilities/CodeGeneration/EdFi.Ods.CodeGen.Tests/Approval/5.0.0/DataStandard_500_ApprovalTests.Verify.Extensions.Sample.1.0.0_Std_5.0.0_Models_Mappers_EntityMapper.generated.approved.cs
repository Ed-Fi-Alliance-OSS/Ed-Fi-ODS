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
// Aggregate: ArtMediumDescriptor

namespace EdFi.Ods.Entities.Common.Sample //.ArtMediumDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class ArtMediumDescriptorMapper
    {
        private static readonly FullName _fullName_sample_ArtMediumDescriptor = new FullName("sample", "ArtMediumDescriptor");
    
        public static bool SynchronizeTo(this IArtMediumDescriptor source, IArtMediumDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ArtMediumDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ArtMediumDescriptor);

            // Detect primary key changes
            if (
                 (target.ArtMediumDescriptorId != source.ArtMediumDescriptorId))
            {
                // Disallow PK column updates on ArtMediumDescriptor
                throw new BadRequestException("Key values for this resource cannot be changed. Delete and recreate the resource item.");
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

        public static void MapTo(this IArtMediumDescriptor source, IArtMediumDescriptor target, Action<IArtMediumDescriptor, IArtMediumDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ArtMediumDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ArtMediumDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.ArtMediumDescriptorId = source.ArtMediumDescriptorId;

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
// Aggregate: Bus

namespace EdFi.Ods.Entities.Common.Sample //.BusAggregate
{
    [ExcludeFromCodeCoverage]
    public static class BusMapper
    {
        private static readonly FullName _fullName_sample_Bus = new FullName("sample", "Bus");
    
        public static bool SynchronizeTo(this IBus source, IBus target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (BusMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_Bus);

            var keyStringComparer = GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer;

            // Detect primary key changes
            if (
                 (!keyStringComparer.Equals(target.BusId, source.BusId)))
            {
                // Disallow PK column updates on Bus
                throw new BadRequestException("Key values for this resource cannot be changed. Delete and recreate the resource item.");
            }


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IBus source, IBus target, Action<IBus, IBus> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (BusMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_Bus);
    
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
// Aggregate: BusRoute

namespace EdFi.Ods.Entities.Common.Sample //.BusRouteAggregate
{
    [ExcludeFromCodeCoverage]
    public static class BusRouteMapper
    {
        private static readonly FullName _fullName_sample_BusRoute = new FullName("sample", "BusRoute");
    
        public static bool SynchronizeTo(this IBusRoute source, IBusRoute target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (BusRouteMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRoute);

            var keyStringComparer = GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer;

            // Detect primary key changes
            if (
                 (!keyStringComparer.Equals(target.BusId, source.BusId))
                || (target.BusRouteNumber != source.BusRouteNumber))
            {
                // Disallow PK column updates on BusRoute
                throw new BadRequestException("Key values for this resource cannot be changed. Delete and recreate the resource item.");
            }


            // Copy non-PK properties

            if ((mappingContract?.IsBeginDateSupported != false)
                && target.BeginDate != source.BeginDate)
            {
                target.BeginDate = source.BeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsBusRouteDirectionSupported != false)
                && target.BusRouteDirection != source.BusRouteDirection)
            {
                target.BusRouteDirection = source.BusRouteDirection;
                isModified = true;
            }

            if ((mappingContract?.IsBusRouteDurationSupported != false)
                && target.BusRouteDuration != source.BusRouteDuration)
            {
                target.BusRouteDuration = source.BusRouteDuration;
                isModified = true;
            }

            if ((mappingContract?.IsDailySupported != false)
                && target.Daily != source.Daily)
            {
                target.Daily = source.Daily;
                isModified = true;
            }

            if ((mappingContract?.IsDisabilityDescriptorSupported != false)
                && target.DisabilityDescriptor != source.DisabilityDescriptor)
            {
                target.DisabilityDescriptor = source.DisabilityDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsEducationOrganizationIdSupported != false)
                && target.EducationOrganizationId != source.EducationOrganizationId)
            {
                target.EducationOrganizationId = source.EducationOrganizationId;
                isModified = true;
            }

            if ((mappingContract?.IsExpectedTransitTimeSupported != false)
                && target.ExpectedTransitTime != source.ExpectedTransitTime)
            {
                target.ExpectedTransitTime = source.ExpectedTransitTime;
                isModified = true;
            }

            if ((mappingContract?.IsHoursPerWeekSupported != false)
                && target.HoursPerWeek != source.HoursPerWeek)
            {
                target.HoursPerWeek = source.HoursPerWeek;
                isModified = true;
            }

            if ((mappingContract?.IsOperatingCostSupported != false)
                && target.OperatingCost != source.OperatingCost)
            {
                target.OperatingCost = source.OperatingCost;
                isModified = true;
            }

            if ((mappingContract?.IsOptimalCapacitySupported != false)
                && target.OptimalCapacity != source.OptimalCapacity)
            {
                target.OptimalCapacity = source.OptimalCapacity;
                isModified = true;
            }

            if ((mappingContract?.IsStaffClassificationDescriptorSupported != false)
                && target.StaffClassificationDescriptor != source.StaffClassificationDescriptor)
            {
                target.StaffClassificationDescriptor = source.StaffClassificationDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsStaffUniqueIdSupported != false)
                && target.StaffUniqueId != source.StaffUniqueId)
            {
                target.StaffUniqueId = source.StaffUniqueId;
                isModified = true;
            }

            if ((mappingContract?.IsStartDateSupported != false)
                && target.StartDate != source.StartDate)
            {
                target.StartDate = source.StartDate;
                isModified = true;
            }

            if ((mappingContract?.IsWeeklyMileageSupported != false)
                && target.WeeklyMileage != source.WeeklyMileage)
            {
                target.WeeklyMileage = source.WeeklyMileage;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsBusRouteBusYearsSupported ?? true)
            {
                isModified |=
                    source.BusRouteBusYears.SynchronizeCollectionTo(
                        target.BusRouteBusYears,
                        onChildAdded: child =>
                            {
                                child.BusRoute = target;
                            },
                        includeItem: item => mappingContract?.IsBusRouteBusYearIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsBusRouteProgramsSupported ?? true)
            {
                isModified |=
                    source.BusRoutePrograms.SynchronizeCollectionTo(
                        target.BusRoutePrograms,
                        onChildAdded: child =>
                            {
                                child.BusRoute = target;
                            },
                        includeItem: item => mappingContract?.IsBusRouteProgramIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsBusRouteServiceAreaPostalCodesSupported ?? true)
            {
                isModified |=
                    source.BusRouteServiceAreaPostalCodes.SynchronizeCollectionTo(
                        target.BusRouteServiceAreaPostalCodes,
                        onChildAdded: child =>
                            {
                                child.BusRoute = target;
                            },
                        includeItem: item => mappingContract?.IsBusRouteServiceAreaPostalCodeIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsBusRouteStartTimesSupported ?? true)
            {
                isModified |=
                    source.BusRouteStartTimes.SynchronizeCollectionTo(
                        target.BusRouteStartTimes,
                        onChildAdded: child =>
                            {
                                child.BusRoute = target;
                            },
                        includeItem: item => mappingContract?.IsBusRouteStartTimeIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsBusRouteTelephonesSupported ?? true)
            {
                isModified |=
                    source.BusRouteTelephones.SynchronizeCollectionTo(
                        target.BusRouteTelephones,
                        onChildAdded: child =>
                            {
                                child.BusRoute = target;
                            },
                        includeItem: item => mappingContract?.IsBusRouteTelephoneIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapTo(this IBusRoute source, IBusRoute target, Action<IBusRoute, IBusRoute> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (BusRouteMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRoute);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.BusId = source.BusId;
            target.BusRouteNumber = source.BusRouteNumber;

            // Copy non-PK properties

            if (mappingContract?.IsBeginDateSupported != false)
                target.BeginDate = source.BeginDate;

            if (mappingContract?.IsBusRouteDirectionSupported != false)
                target.BusRouteDirection = source.BusRouteDirection;

            if (mappingContract?.IsBusRouteDurationSupported != false)
                target.BusRouteDuration = source.BusRouteDuration;

            if (mappingContract?.IsDailySupported != false)
                target.Daily = source.Daily;

            if (mappingContract?.IsDisabilityDescriptorSupported != false)
                target.DisabilityDescriptor = source.DisabilityDescriptor;

            if (mappingContract?.IsEducationOrganizationIdSupported != false)
                target.EducationOrganizationId = source.EducationOrganizationId;

            if (mappingContract?.IsExpectedTransitTimeSupported != false)
                target.ExpectedTransitTime = source.ExpectedTransitTime;

            if (mappingContract?.IsHoursPerWeekSupported != false)
                target.HoursPerWeek = source.HoursPerWeek;

            if (mappingContract?.IsOperatingCostSupported != false)
                target.OperatingCost = source.OperatingCost;

            if (mappingContract?.IsOptimalCapacitySupported != false)
                target.OptimalCapacity = source.OptimalCapacity;

            if (mappingContract?.IsStaffClassificationDescriptorSupported != false)
                target.StaffClassificationDescriptor = source.StaffClassificationDescriptor;

            if (mappingContract?.IsStaffUniqueIdSupported != false)
                target.StaffUniqueId = source.StaffUniqueId;

            if (mappingContract?.IsStartDateSupported != false)
                target.StartDate = source.StartDate;

            if (mappingContract?.IsWeeklyMileageSupported != false)
                target.WeeklyMileage = source.WeeklyMileage;

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

            if (mappingContract?.IsBusRouteBusYearsSupported != false)
            {
                source.BusRouteBusYears.MapCollectionTo(target.BusRouteBusYears, target, mappingContract?.IsBusRouteBusYearIncluded);
            }

            if (mappingContract?.IsBusRouteProgramsSupported != false)
            {
                source.BusRoutePrograms.MapCollectionTo(target.BusRoutePrograms, target, mappingContract?.IsBusRouteProgramIncluded);
            }

            if (mappingContract?.IsBusRouteServiceAreaPostalCodesSupported != false)
            {
                source.BusRouteServiceAreaPostalCodes.MapCollectionTo(target.BusRouteServiceAreaPostalCodes, target, mappingContract?.IsBusRouteServiceAreaPostalCodeIncluded);
            }

            if (mappingContract?.IsBusRouteStartTimesSupported != false)
            {
                source.BusRouteStartTimes.MapCollectionTo(target.BusRouteStartTimes, target, mappingContract?.IsBusRouteStartTimeIncluded);
            }

            if (mappingContract?.IsBusRouteTelephonesSupported != false)
            {
                source.BusRouteTelephones.MapCollectionTo(target.BusRouteTelephones, target, mappingContract?.IsBusRouteTelephoneIncluded);
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
    public static class BusRouteBusYearMapper
    {
        private static readonly FullName _fullName_sample_BusRouteBusYear = new FullName("sample", "BusRouteBusYear");
    
        public static bool SynchronizeTo(this IBusRouteBusYear source, IBusRouteBusYear target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (BusRouteBusYearMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRouteBusYear);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IBusRouteBusYear source, IBusRouteBusYear target, Action<IBusRouteBusYear, IBusRouteBusYear> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (BusRouteBusYearMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRouteBusYear);
    
            // Copy contextual primary key values
            target.BusYear = source.BusYear;

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

    [ExcludeFromCodeCoverage]
    public static class BusRouteProgramMapper
    {
        private static readonly FullName _fullName_sample_BusRouteProgram = new FullName("sample", "BusRouteProgram");
    
        public static bool SynchronizeTo(this IBusRouteProgram source, IBusRouteProgram target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (BusRouteProgramMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRouteProgram);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IBusRouteProgram source, IBusRouteProgram target, Action<IBusRouteProgram, IBusRouteProgram> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (BusRouteProgramMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRouteProgram);
    
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
    public static class BusRouteServiceAreaPostalCodeMapper
    {
        private static readonly FullName _fullName_sample_BusRouteServiceAreaPostalCode = new FullName("sample", "BusRouteServiceAreaPostalCode");
    
        public static bool SynchronizeTo(this IBusRouteServiceAreaPostalCode source, IBusRouteServiceAreaPostalCode target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (BusRouteServiceAreaPostalCodeMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRouteServiceAreaPostalCode);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IBusRouteServiceAreaPostalCode source, IBusRouteServiceAreaPostalCode target, Action<IBusRouteServiceAreaPostalCode, IBusRouteServiceAreaPostalCode> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (BusRouteServiceAreaPostalCodeMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRouteServiceAreaPostalCode);
    
            // Copy contextual primary key values
            target.ServiceAreaPostalCode = source.ServiceAreaPostalCode;

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

    [ExcludeFromCodeCoverage]
    public static class BusRouteStartTimeMapper
    {
        private static readonly FullName _fullName_sample_BusRouteStartTime = new FullName("sample", "BusRouteStartTime");
    
        public static bool SynchronizeTo(this IBusRouteStartTime source, IBusRouteStartTime target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (BusRouteStartTimeMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRouteStartTime);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IBusRouteStartTime source, IBusRouteStartTime target, Action<IBusRouteStartTime, IBusRouteStartTime> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (BusRouteStartTimeMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRouteStartTime);
    
            // Copy contextual primary key values
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

    [ExcludeFromCodeCoverage]
    public static class BusRouteTelephoneMapper
    {
        private static readonly FullName _fullName_sample_BusRouteTelephone = new FullName("sample", "BusRouteTelephone");
    
        public static bool SynchronizeTo(this IBusRouteTelephone source, IBusRouteTelephone target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (BusRouteTelephoneMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRouteTelephone);


            // Copy non-PK properties

            if ((mappingContract?.IsDoNotPublishIndicatorSupported != false)
                && target.DoNotPublishIndicator != source.DoNotPublishIndicator)
            {
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
                isModified = true;
            }

            if ((mappingContract?.IsOrderOfPrioritySupported != false)
                && target.OrderOfPriority != source.OrderOfPriority)
            {
                target.OrderOfPriority = source.OrderOfPriority;
                isModified = true;
            }

            if ((mappingContract?.IsTextMessageCapabilityIndicatorSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (BusRouteTelephoneMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRouteTelephone);
    
            // Copy contextual primary key values
            target.TelephoneNumber = source.TelephoneNumber;
            target.TelephoneNumberTypeDescriptor = source.TelephoneNumberTypeDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsDoNotPublishIndicatorSupported != false)
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;

            if (mappingContract?.IsOrderOfPrioritySupported != false)
                target.OrderOfPriority = source.OrderOfPriority;

            if (mappingContract?.IsTextMessageCapabilityIndicatorSupported != false)
                target.TextMessageCapabilityIndicator = source.TextMessageCapabilityIndicator;

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
// Aggregate: Contact

namespace EdFi.Ods.Entities.Common.Sample //.ContactAggregate
{
    [ExcludeFromCodeCoverage]
    public static class ContactAddressExtensionMapper
    {
        private static readonly FullName _fullName_sample_ContactAddressExtension = new FullName("sample", "ContactAddressExtension");
    
        public static bool SynchronizeTo(this IContactAddressExtension source, IContactAddressExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ContactAddressExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactAddressExtension);


            // Copy non-PK properties

            if ((mappingContract?.IsComplexSupported != false)
                && target.Complex != source.Complex)
            {
                target.Complex = source.Complex;
                isModified = true;
            }

            if ((mappingContract?.IsOnBusRouteSupported != false)
                && target.OnBusRoute != source.OnBusRoute)
            {
                target.OnBusRoute = source.OnBusRoute;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsContactAddressSchoolDistrictsSupported ?? true)
            {
                isModified |=
                    source.ContactAddressSchoolDistricts.SynchronizeCollectionTo(
                        target.ContactAddressSchoolDistricts,
                        onChildAdded: child =>
                            {
                                child.ContactAddressExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.ContactAddress);
                            },
                        includeItem: item => mappingContract?.IsContactAddressSchoolDistrictIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsContactAddressTermsSupported ?? true)
            {
                isModified |=
                    source.ContactAddressTerms.SynchronizeCollectionTo(
                        target.ContactAddressTerms,
                        onChildAdded: child =>
                            {
                                child.ContactAddressExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.ContactAddress);
                            },
                        includeItem: item => mappingContract?.IsContactAddressTermIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapTo(this IContactAddressExtension source, IContactAddressExtension target, Action<IContactAddressExtension, IContactAddressExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ContactAddressExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactAddressExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsComplexSupported != false)
                target.Complex = source.Complex;

            if (mappingContract?.IsOnBusRouteSupported != false)
                target.OnBusRoute = source.OnBusRoute;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsContactAddressSchoolDistrictsSupported != false)
            {
                source.ContactAddressSchoolDistricts.MapCollectionTo(target.ContactAddressSchoolDistricts, target.ContactAddress, mappingContract?.IsContactAddressSchoolDistrictIncluded);
            }

            if (mappingContract?.IsContactAddressTermsSupported != false)
            {
                source.ContactAddressTerms.MapCollectionTo(target.ContactAddressTerms, target.ContactAddress, mappingContract?.IsContactAddressTermIncluded);
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
    public static class ContactAddressSchoolDistrictMapper
    {
        private static readonly FullName _fullName_sample_ContactAddressSchoolDistrict = new FullName("sample", "ContactAddressSchoolDistrict");
    
        public static bool SynchronizeTo(this IContactAddressSchoolDistrict source, IContactAddressSchoolDistrict target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ContactAddressSchoolDistrictMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactAddressSchoolDistrict);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IContactAddressSchoolDistrict source, IContactAddressSchoolDistrict target, Action<IContactAddressSchoolDistrict, IContactAddressSchoolDistrict> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ContactAddressSchoolDistrictMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactAddressSchoolDistrict);
    
            // Copy contextual primary key values
            target.SchoolDistrict = source.SchoolDistrict;

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

    [ExcludeFromCodeCoverage]
    public static class ContactAddressTermMapper
    {
        private static readonly FullName _fullName_sample_ContactAddressTerm = new FullName("sample", "ContactAddressTerm");
    
        public static bool SynchronizeTo(this IContactAddressTerm source, IContactAddressTerm target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ContactAddressTermMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactAddressTerm);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IContactAddressTerm source, IContactAddressTerm target, Action<IContactAddressTerm, IContactAddressTerm> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ContactAddressTermMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactAddressTerm);
    
            // Copy contextual primary key values
            target.TermDescriptor = source.TermDescriptor;

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

    [ExcludeFromCodeCoverage]
    public static class ContactAuthorMapper
    {
        private static readonly FullName _fullName_sample_ContactAuthor = new FullName("sample", "ContactAuthor");
    
        public static bool SynchronizeTo(this IContactAuthor source, IContactAuthor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ContactAuthorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactAuthor);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IContactAuthor source, IContactAuthor target, Action<IContactAuthor, IContactAuthor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ContactAuthorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactAuthor);
    
            // Copy contextual primary key values
            target.Author = source.Author;

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

    [ExcludeFromCodeCoverage]
    public static class ContactCeilingHeightMapper
    {
        private static readonly FullName _fullName_sample_ContactCeilingHeight = new FullName("sample", "ContactCeilingHeight");
    
        public static bool SynchronizeTo(this IContactCeilingHeight source, IContactCeilingHeight target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ContactCeilingHeightMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactCeilingHeight);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IContactCeilingHeight source, IContactCeilingHeight target, Action<IContactCeilingHeight, IContactCeilingHeight> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ContactCeilingHeightMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactCeilingHeight);
    
            // Copy contextual primary key values
            target.CeilingHeight = source.CeilingHeight;

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

    [ExcludeFromCodeCoverage]
    public static class ContactCTEProgramMapper
    {
        private static readonly FullName _fullName_sample_ContactCTEProgram = new FullName("sample", "ContactCTEProgram");
    
        public static bool SynchronizeTo(this IContactCTEProgram source, IContactCTEProgram target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ContactCTEProgramMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactCTEProgram);


            // Copy non-PK properties

            if ((mappingContract?.IsCareerPathwayDescriptorSupported != false)
                && target.CareerPathwayDescriptor != source.CareerPathwayDescriptor)
            {
                target.CareerPathwayDescriptor = source.CareerPathwayDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsCIPCodeSupported != false)
                && target.CIPCode != source.CIPCode)
            {
                target.CIPCode = source.CIPCode;
                isModified = true;
            }

            if ((mappingContract?.IsCTEProgramCompletionIndicatorSupported != false)
                && target.CTEProgramCompletionIndicator != source.CTEProgramCompletionIndicator)
            {
                target.CTEProgramCompletionIndicator = source.CTEProgramCompletionIndicator;
                isModified = true;
            }

            if ((mappingContract?.IsPrimaryCTEProgramIndicatorSupported != false)
                && target.PrimaryCTEProgramIndicator != source.PrimaryCTEProgramIndicator)
            {
                target.PrimaryCTEProgramIndicator = source.PrimaryCTEProgramIndicator;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IContactCTEProgram source, IContactCTEProgram target, Action<IContactCTEProgram, IContactCTEProgram> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ContactCTEProgramMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactCTEProgram);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsCareerPathwayDescriptorSupported != false)
                target.CareerPathwayDescriptor = source.CareerPathwayDescriptor;

            if (mappingContract?.IsCIPCodeSupported != false)
                target.CIPCode = source.CIPCode;

            if (mappingContract?.IsCTEProgramCompletionIndicatorSupported != false)
                target.CTEProgramCompletionIndicator = source.CTEProgramCompletionIndicator;

            if (mappingContract?.IsPrimaryCTEProgramIndicatorSupported != false)
                target.PrimaryCTEProgramIndicator = source.PrimaryCTEProgramIndicator;

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
    public static class ContactEducationContentMapper
    {
        private static readonly FullName _fullName_sample_ContactEducationContent = new FullName("sample", "ContactEducationContent");
    
        public static bool SynchronizeTo(this IContactEducationContent source, IContactEducationContent target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ContactEducationContentMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactEducationContent);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IContactEducationContent source, IContactEducationContent target, Action<IContactEducationContent, IContactEducationContent> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ContactEducationContentMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactEducationContent);
    
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
    public static class ContactExtensionMapper
    {
        private static readonly FullName _fullName_sample_ContactExtension = new FullName("sample", "ContactExtension");
    
        public static bool SynchronizeTo(this IContactExtension source, IContactExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ContactExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactExtension);


            // Copy non-PK properties

            if ((mappingContract?.IsAverageCarLineWaitSupported != false)
                && target.AverageCarLineWait != source.AverageCarLineWait)
            {
                target.AverageCarLineWait = source.AverageCarLineWait;
                isModified = true;
            }

            if ((mappingContract?.IsBecameParentSupported != false)
                && target.BecameParent != source.BecameParent)
            {
                target.BecameParent = source.BecameParent;
                isModified = true;
            }

            if ((mappingContract?.IsCoffeeSpendSupported != false)
                && target.CoffeeSpend != source.CoffeeSpend)
            {
                target.CoffeeSpend = source.CoffeeSpend;
                isModified = true;
            }

            if ((mappingContract?.IsCredentialFieldDescriptorSupported != false)
                && target.CredentialFieldDescriptor != source.CredentialFieldDescriptor)
            {
                target.CredentialFieldDescriptor = source.CredentialFieldDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsDurationSupported != false)
                && target.Duration != source.Duration)
            {
                target.Duration = source.Duration;
                isModified = true;
            }

            if ((mappingContract?.IsGPASupported != false)
                && target.GPA != source.GPA)
            {
                target.GPA = source.GPA;
                isModified = true;
            }

            if ((mappingContract?.IsGraduationDateSupported != false)
                && target.GraduationDate != source.GraduationDate)
            {
                target.GraduationDate = source.GraduationDate;
                isModified = true;
            }

            if ((mappingContract?.IsIsSportsFanSupported != false)
                && target.IsSportsFan != source.IsSportsFan)
            {
                target.IsSportsFan = source.IsSportsFan;
                isModified = true;
            }

            if ((mappingContract?.IsLuckyNumberSupported != false)
                && target.LuckyNumber != source.LuckyNumber)
            {
                target.LuckyNumber = source.LuckyNumber;
                isModified = true;
            }

            if ((mappingContract?.IsPreferredWakeUpTimeSupported != false)
                && target.PreferredWakeUpTime != source.PreferredWakeUpTime)
            {
                target.PreferredWakeUpTime = source.PreferredWakeUpTime;
                isModified = true;
            }

            if ((mappingContract?.IsRainCertaintySupported != false)
                && target.RainCertainty != source.RainCertainty)
            {
                target.RainCertainty = source.RainCertainty;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // ContactCTEProgram (ContactCTEProgram)
            if (mappingContract?.IsContactCTEProgramSupported != false)
            {
                if (source.ContactCTEProgram == null)
                {
                    if (target.ContactCTEProgram != null)
                    {
                        target.ContactCTEProgram = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.ContactCTEProgram == null)
                    {
                        var itemType = target.GetType().GetProperty("ContactCTEProgram").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.ContactCTEProgram = (IContactCTEProgram) newItem;
                    }

                    isModified |= source.ContactCTEProgram.Synchronize(target.ContactCTEProgram);
                }
            }
            // ContactTeacherConference (ContactTeacherConference)
            if (mappingContract?.IsContactTeacherConferenceSupported != false)
            {
                if (source.ContactTeacherConference == null)
                {
                    if (target.ContactTeacherConference != null)
                    {
                        target.ContactTeacherConference = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.ContactTeacherConference == null)
                    {
                        var itemType = target.GetType().GetProperty("ContactTeacherConference").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.ContactTeacherConference = (IContactTeacherConference) newItem;
                    }

                    isModified |= source.ContactTeacherConference.Synchronize(target.ContactTeacherConference);
                }
            }

            // -------------------------------------------------------------

            // Sync lists
            if (mappingContract?.IsContactAuthorsSupported ?? true)
            {
                isModified |=
                    source.ContactAuthors.SynchronizeCollectionTo(
                        target.ContactAuthors,
                        onChildAdded: child =>
                            {
                                child.ContactExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Contact);
                            },
                        includeItem: item => mappingContract?.IsContactAuthorIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsContactCeilingHeightsSupported ?? true)
            {
                isModified |=
                    source.ContactCeilingHeights.SynchronizeCollectionTo(
                        target.ContactCeilingHeights,
                        onChildAdded: child =>
                            {
                                child.ContactExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Contact);
                            },
                        includeItem: item => mappingContract?.IsContactCeilingHeightIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsContactEducationContentsSupported ?? true)
            {
                isModified |=
                    source.ContactEducationContents.SynchronizeCollectionTo(
                        target.ContactEducationContents,
                        onChildAdded: child =>
                            {
                                child.ContactExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Contact);
                            },
                        includeItem: item => mappingContract?.IsContactEducationContentIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsContactFavoriteBookTitlesSupported ?? true)
            {
                isModified |=
                    source.ContactFavoriteBookTitles.SynchronizeCollectionTo(
                        target.ContactFavoriteBookTitles,
                        onChildAdded: child =>
                            {
                                child.ContactExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Contact);
                            },
                        includeItem: item => mappingContract?.IsContactFavoriteBookTitleIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsContactStudentProgramAssociationsSupported ?? true)
            {
                isModified |=
                    source.ContactStudentProgramAssociations.SynchronizeCollectionTo(
                        target.ContactStudentProgramAssociations,
                        onChildAdded: child =>
                            {
                                child.ContactExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Contact);
                            },
                        includeItem: item => mappingContract?.IsContactStudentProgramAssociationIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapTo(this IContactExtension source, IContactExtension target, Action<IContactExtension, IContactExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ContactExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsAverageCarLineWaitSupported != false)
                target.AverageCarLineWait = source.AverageCarLineWait;

            if (mappingContract?.IsBecameParentSupported != false)
                target.BecameParent = source.BecameParent;

            if (mappingContract?.IsCoffeeSpendSupported != false)
                target.CoffeeSpend = source.CoffeeSpend;

            if (mappingContract?.IsCredentialFieldDescriptorSupported != false)
                target.CredentialFieldDescriptor = source.CredentialFieldDescriptor;

            if (mappingContract?.IsDurationSupported != false)
                target.Duration = source.Duration;

            if (mappingContract?.IsGPASupported != false)
                target.GPA = source.GPA;

            if (mappingContract?.IsGraduationDateSupported != false)
                target.GraduationDate = source.GraduationDate;

            if (mappingContract?.IsIsSportsFanSupported != false)
                target.IsSportsFan = source.IsSportsFan;

            if (mappingContract?.IsLuckyNumberSupported != false)
                target.LuckyNumber = source.LuckyNumber;

            if (mappingContract?.IsPreferredWakeUpTimeSupported != false)
                target.PreferredWakeUpTime = source.PreferredWakeUpTime;

            if (mappingContract?.IsRainCertaintySupported != false)
                target.RainCertainty = source.RainCertainty;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // ContactCTEProgram (ContactCTEProgram) (Source)
            if (mappingContract?.IsContactCTEProgramSupported != false)
            {
                var itemProperty = target.GetType().GetProperty("ContactCTEProgram");

                if (itemProperty != null)
                {
                    if (source.ContactCTEProgram == null)
                    {
                        target.ContactCTEProgram = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetContactCTEProgram = Activator.CreateInstance(itemType);
                        (targetContactCTEProgram as IChildEntity)?.SetParent(target.Contact);
                        source.ContactCTEProgram.Map(targetContactCTEProgram);

                        // Update the target reference appropriately
                        target.ContactCTEProgram = (IContactCTEProgram) targetContactCTEProgram;
                    }
                }
            }
            // ContactTeacherConference (ContactTeacherConference) (Source)
            if (mappingContract?.IsContactTeacherConferenceSupported != false)
            {
                var itemProperty = target.GetType().GetProperty("ContactTeacherConference");

                if (itemProperty != null)
                {
                    if (source.ContactTeacherConference == null)
                    {
                        target.ContactTeacherConference = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetContactTeacherConference = Activator.CreateInstance(itemType);
                        (targetContactTeacherConference as IChildEntity)?.SetParent(target.Contact);
                        source.ContactTeacherConference.Map(targetContactTeacherConference);

                        // Update the target reference appropriately
                        target.ContactTeacherConference = (IContactTeacherConference) targetContactTeacherConference;
                    }
                }
            }
            // -------------------------------------------------------------

            // Map lists

            if (mappingContract?.IsContactAuthorsSupported != false)
            {
                source.ContactAuthors.MapCollectionTo(target.ContactAuthors, target.Contact, mappingContract?.IsContactAuthorIncluded);
            }

            if (mappingContract?.IsContactCeilingHeightsSupported != false)
            {
                source.ContactCeilingHeights.MapCollectionTo(target.ContactCeilingHeights, target.Contact, mappingContract?.IsContactCeilingHeightIncluded);
            }

            if (mappingContract?.IsContactEducationContentsSupported != false)
            {
                source.ContactEducationContents.MapCollectionTo(target.ContactEducationContents, target.Contact, mappingContract?.IsContactEducationContentIncluded);
            }

            if (mappingContract?.IsContactFavoriteBookTitlesSupported != false)
            {
                source.ContactFavoriteBookTitles.MapCollectionTo(target.ContactFavoriteBookTitles, target.Contact, mappingContract?.IsContactFavoriteBookTitleIncluded);
            }

            if (mappingContract?.IsContactStudentProgramAssociationsSupported != false)
            {
                source.ContactStudentProgramAssociations.MapCollectionTo(target.ContactStudentProgramAssociations, target.Contact, mappingContract?.IsContactStudentProgramAssociationIncluded);
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
    public static class ContactFavoriteBookTitleMapper
    {
        private static readonly FullName _fullName_sample_ContactFavoriteBookTitle = new FullName("sample", "ContactFavoriteBookTitle");
    
        public static bool SynchronizeTo(this IContactFavoriteBookTitle source, IContactFavoriteBookTitle target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ContactFavoriteBookTitleMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactFavoriteBookTitle);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IContactFavoriteBookTitle source, IContactFavoriteBookTitle target, Action<IContactFavoriteBookTitle, IContactFavoriteBookTitle> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ContactFavoriteBookTitleMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactFavoriteBookTitle);
    
            // Copy contextual primary key values
            target.FavoriteBookTitle = source.FavoriteBookTitle;

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

    [ExcludeFromCodeCoverage]
    public static class ContactStudentProgramAssociationMapper
    {
        private static readonly FullName _fullName_sample_ContactStudentProgramAssociation = new FullName("sample", "ContactStudentProgramAssociation");
    
        public static bool SynchronizeTo(this IContactStudentProgramAssociation source, IContactStudentProgramAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ContactStudentProgramAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactStudentProgramAssociation);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IContactStudentProgramAssociation source, IContactStudentProgramAssociation target, Action<IContactStudentProgramAssociation, IContactStudentProgramAssociation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ContactStudentProgramAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactStudentProgramAssociation);
    
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
    public static class ContactTeacherConferenceMapper
    {
        private static readonly FullName _fullName_sample_ContactTeacherConference = new FullName("sample", "ContactTeacherConference");
    
        public static bool SynchronizeTo(this IContactTeacherConference source, IContactTeacherConference target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ContactTeacherConferenceMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactTeacherConference);


            // Copy non-PK properties

            if ((mappingContract?.IsDayOfWeekSupported != false)
                && target.DayOfWeek != source.DayOfWeek)
            {
                target.DayOfWeek = source.DayOfWeek;
                isModified = true;
            }

            if ((mappingContract?.IsEndTimeSupported != false)
                && target.EndTime != source.EndTime)
            {
                target.EndTime = source.EndTime;
                isModified = true;
            }

            if ((mappingContract?.IsStartTimeSupported != false)
                && target.StartTime != source.StartTime)
            {
                target.StartTime = source.StartTime;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IContactTeacherConference source, IContactTeacherConference target, Action<IContactTeacherConference, IContactTeacherConference> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ContactTeacherConferenceMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactTeacherConference);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsDayOfWeekSupported != false)
                target.DayOfWeek = source.DayOfWeek;

            if (mappingContract?.IsEndTimeSupported != false)
                target.EndTime = source.EndTime;

            if (mappingContract?.IsStartTimeSupported != false)
                target.StartTime = source.StartTime;

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
// Aggregate: FavoriteBookCategoryDescriptor

namespace EdFi.Ods.Entities.Common.Sample //.FavoriteBookCategoryDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class FavoriteBookCategoryDescriptorMapper
    {
        private static readonly FullName _fullName_sample_FavoriteBookCategoryDescriptor = new FullName("sample", "FavoriteBookCategoryDescriptor");
    
        public static bool SynchronizeTo(this IFavoriteBookCategoryDescriptor source, IFavoriteBookCategoryDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (FavoriteBookCategoryDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_FavoriteBookCategoryDescriptor);

            // Detect primary key changes
            if (
                 (target.FavoriteBookCategoryDescriptorId != source.FavoriteBookCategoryDescriptorId))
            {
                // Disallow PK column updates on FavoriteBookCategoryDescriptor
                throw new BadRequestException("Key values for this resource cannot be changed. Delete and recreate the resource item.");
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

        public static void MapTo(this IFavoriteBookCategoryDescriptor source, IFavoriteBookCategoryDescriptor target, Action<IFavoriteBookCategoryDescriptor, IFavoriteBookCategoryDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (FavoriteBookCategoryDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_FavoriteBookCategoryDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.FavoriteBookCategoryDescriptorId = source.FavoriteBookCategoryDescriptorId;

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
// Aggregate: MembershipTypeDescriptor

namespace EdFi.Ods.Entities.Common.Sample //.MembershipTypeDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class MembershipTypeDescriptorMapper
    {
        private static readonly FullName _fullName_sample_MembershipTypeDescriptor = new FullName("sample", "MembershipTypeDescriptor");
    
        public static bool SynchronizeTo(this IMembershipTypeDescriptor source, IMembershipTypeDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (MembershipTypeDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_MembershipTypeDescriptor);

            // Detect primary key changes
            if (
                 (target.MembershipTypeDescriptorId != source.MembershipTypeDescriptorId))
            {
                // Disallow PK column updates on MembershipTypeDescriptor
                throw new BadRequestException("Key values for this resource cannot be changed. Delete and recreate the resource item.");
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

        public static void MapTo(this IMembershipTypeDescriptor source, IMembershipTypeDescriptor target, Action<IMembershipTypeDescriptor, IMembershipTypeDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (MembershipTypeDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_MembershipTypeDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.MembershipTypeDescriptorId = source.MembershipTypeDescriptorId;

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
// Aggregate: School

namespace EdFi.Ods.Entities.Common.Sample //.SchoolAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SchoolCTEProgramMapper
    {
        private static readonly FullName _fullName_sample_SchoolCTEProgram = new FullName("sample", "SchoolCTEProgram");
    
        public static bool SynchronizeTo(this ISchoolCTEProgram source, ISchoolCTEProgram target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (SchoolCTEProgramMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_SchoolCTEProgram);


            // Copy non-PK properties

            if ((mappingContract?.IsCareerPathwayDescriptorSupported != false)
                && target.CareerPathwayDescriptor != source.CareerPathwayDescriptor)
            {
                target.CareerPathwayDescriptor = source.CareerPathwayDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsCIPCodeSupported != false)
                && target.CIPCode != source.CIPCode)
            {
                target.CIPCode = source.CIPCode;
                isModified = true;
            }

            if ((mappingContract?.IsCTEProgramCompletionIndicatorSupported != false)
                && target.CTEProgramCompletionIndicator != source.CTEProgramCompletionIndicator)
            {
                target.CTEProgramCompletionIndicator = source.CTEProgramCompletionIndicator;
                isModified = true;
            }

            if ((mappingContract?.IsPrimaryCTEProgramIndicatorSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (SchoolCTEProgramMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_SchoolCTEProgram);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsCareerPathwayDescriptorSupported != false)
                target.CareerPathwayDescriptor = source.CareerPathwayDescriptor;

            if (mappingContract?.IsCIPCodeSupported != false)
                target.CIPCode = source.CIPCode;

            if (mappingContract?.IsCTEProgramCompletionIndicatorSupported != false)
                target.CTEProgramCompletionIndicator = source.CTEProgramCompletionIndicator;

            if (mappingContract?.IsPrimaryCTEProgramIndicatorSupported != false)
                target.PrimaryCTEProgramIndicator = source.PrimaryCTEProgramIndicator;

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
    public static class SchoolDirectlyOwnedBusMapper
    {
        private static readonly FullName _fullName_sample_SchoolDirectlyOwnedBus = new FullName("sample", "SchoolDirectlyOwnedBus");
    
        public static bool SynchronizeTo(this ISchoolDirectlyOwnedBus source, ISchoolDirectlyOwnedBus target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (SchoolDirectlyOwnedBusMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_SchoolDirectlyOwnedBus);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this ISchoolDirectlyOwnedBus source, ISchoolDirectlyOwnedBus target, Action<ISchoolDirectlyOwnedBus, ISchoolDirectlyOwnedBus> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (SchoolDirectlyOwnedBusMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_SchoolDirectlyOwnedBus);
    
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
    public static class SchoolExtensionMapper
    {
        private static readonly FullName _fullName_sample_SchoolExtension = new FullName("sample", "SchoolExtension");
    
        public static bool SynchronizeTo(this ISchoolExtension source, ISchoolExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (SchoolExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_SchoolExtension);


            // Copy non-PK properties

            if ((mappingContract?.IsIsExemplarySupported != false)
                && target.IsExemplary != source.IsExemplary)
            {
                target.IsExemplary = source.IsExemplary;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // SchoolCTEProgram (SchoolCTEProgram)
            if (mappingContract?.IsSchoolCTEProgramSupported != false)
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
            if (mappingContract?.IsSchoolDirectlyOwnedBusesSupported ?? true)
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
                        includeItem: item => mappingContract?.IsSchoolDirectlyOwnedBusIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapTo(this ISchoolExtension source, ISchoolExtension target, Action<ISchoolExtension, ISchoolExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (SchoolExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_SchoolExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsIsExemplarySupported != false)
                target.IsExemplary = source.IsExemplary;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // SchoolCTEProgram (SchoolCTEProgram) (Source)
            if (mappingContract?.IsSchoolCTEProgramSupported != false)
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
            // -------------------------------------------------------------

            // Map lists

            if (mappingContract?.IsSchoolDirectlyOwnedBusesSupported != false)
            {
                source.SchoolDirectlyOwnedBuses.MapCollectionTo(target.SchoolDirectlyOwnedBuses, target.School, mappingContract?.IsSchoolDirectlyOwnedBusIncluded);
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

}
// Aggregate: Staff

namespace EdFi.Ods.Entities.Common.Sample //.StaffAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StaffExtensionMapper
    {
        private static readonly FullName _fullName_sample_StaffExtension = new FullName("sample", "StaffExtension");
    
        public static bool SynchronizeTo(this IStaffExtension source, IStaffExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StaffExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StaffExtension);


            // Copy non-PK properties

            if ((mappingContract?.IsFirstPetOwnedDateSupported != false)
                && target.FirstPetOwnedDate != source.FirstPetOwnedDate)
            {
                target.FirstPetOwnedDate = source.FirstPetOwnedDate;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // StaffPetPreference (StaffPetPreference)
            if (mappingContract?.IsStaffPetPreferenceSupported != false)
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
            if (mappingContract?.IsStaffPetsSupported ?? true)
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
                        includeItem: item => mappingContract?.IsStaffPetIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapTo(this IStaffExtension source, IStaffExtension target, Action<IStaffExtension, IStaffExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StaffExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StaffExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsFirstPetOwnedDateSupported != false)
                target.FirstPetOwnedDate = source.FirstPetOwnedDate;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // StaffPetPreference (StaffPetPreference) (Source)
            if (mappingContract?.IsStaffPetPreferenceSupported != false)
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
            // -------------------------------------------------------------

            // Map lists

            if (mappingContract?.IsStaffPetsSupported != false)
            {
                source.StaffPets.MapCollectionTo(target.StaffPets, target.Staff, mappingContract?.IsStaffPetIncluded);
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
    public static class StaffPetMapper
    {
        private static readonly FullName _fullName_sample_StaffPet = new FullName("sample", "StaffPet");
    
        public static bool SynchronizeTo(this IStaffPet source, IStaffPet target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StaffPetMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StaffPet);


            // Copy non-PK properties

            if ((mappingContract?.IsIsFixedSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StaffPetMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StaffPet);
    
            // Copy contextual primary key values
            target.PetName = source.PetName;

            // Copy non-PK properties

            if (mappingContract?.IsIsFixedSupported != false)
                target.IsFixed = source.IsFixed;

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
    public static class StaffPetPreferenceMapper
    {
        private static readonly FullName _fullName_sample_StaffPetPreference = new FullName("sample", "StaffPetPreference");
    
        public static bool SynchronizeTo(this IStaffPetPreference source, IStaffPetPreference target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StaffPetPreferenceMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StaffPetPreference);


            // Copy non-PK properties

            if ((mappingContract?.IsMaximumWeightSupported != false)
                && target.MaximumWeight != source.MaximumWeight)
            {
                target.MaximumWeight = source.MaximumWeight;
                isModified = true;
            }

            if ((mappingContract?.IsMinimumWeightSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StaffPetPreferenceMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StaffPetPreference);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsMaximumWeightSupported != false)
                target.MaximumWeight = source.MaximumWeight;

            if (mappingContract?.IsMinimumWeightSupported != false)
                target.MinimumWeight = source.MinimumWeight;

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
// Aggregate: Student

namespace EdFi.Ods.Entities.Common.Sample //.StudentAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentAquaticPetMapper
    {
        private static readonly FullName _fullName_sample_StudentAquaticPet = new FullName("sample", "StudentAquaticPet");
    
        public static bool SynchronizeTo(this IStudentAquaticPet source, IStudentAquaticPet target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentAquaticPetMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentAquaticPet);


            // Copy non-PK properties

            if ((mappingContract?.IsIsFixedSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentAquaticPetMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentAquaticPet);
    
            // Copy contextual primary key values
            target.MimimumTankVolume = source.MimimumTankVolume;
            target.PetName = source.PetName;

            // Copy non-PK properties

            if (mappingContract?.IsIsFixedSupported != false)
                target.IsFixed = source.IsFixed;

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
    public static class StudentExtensionMapper
    {
        private static readonly FullName _fullName_sample_StudentExtension = new FullName("sample", "StudentExtension");
    
        public static bool SynchronizeTo(this IStudentExtension source, IStudentExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentExtension);


            // Copy non-PK properties

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // StudentPetPreference (StudentPetPreference)
            if (mappingContract?.IsStudentPetPreferenceSupported != false)
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
            if (mappingContract?.IsStudentAquaticPetsSupported ?? true)
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
                        includeItem: item => mappingContract?.IsStudentAquaticPetIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentFavoriteBooksSupported ?? true)
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
                        includeItem: item => mappingContract?.IsStudentFavoriteBookIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentPetsSupported ?? true)
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
                        includeItem: item => mappingContract?.IsStudentPetIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapTo(this IStudentExtension source, IStudentExtension target, Action<IStudentExtension, IStudentExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // StudentPetPreference (StudentPetPreference) (Source)
            if (mappingContract?.IsStudentPetPreferenceSupported != false)
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
            // -------------------------------------------------------------

            // Map lists

            if (mappingContract?.IsStudentAquaticPetsSupported != false)
            {
                source.StudentAquaticPets.MapCollectionTo(target.StudentAquaticPets, target.Student, mappingContract?.IsStudentAquaticPetIncluded);
            }

            if (mappingContract?.IsStudentFavoriteBooksSupported != false)
            {
                source.StudentFavoriteBooks.MapCollectionTo(target.StudentFavoriteBooks, target.Student, mappingContract?.IsStudentFavoriteBookIncluded);
            }

            if (mappingContract?.IsStudentPetsSupported != false)
            {
                source.StudentPets.MapCollectionTo(target.StudentPets, target.Student, mappingContract?.IsStudentPetIncluded);
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
    public static class StudentFavoriteBookMapper
    {
        private static readonly FullName _fullName_sample_StudentFavoriteBook = new FullName("sample", "StudentFavoriteBook");
    
        public static bool SynchronizeTo(this IStudentFavoriteBook source, IStudentFavoriteBook target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentFavoriteBookMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentFavoriteBook);


            // Copy non-PK properties

            if ((mappingContract?.IsBookTitleSupported != false)
                && target.BookTitle != source.BookTitle)
            {
                target.BookTitle = source.BookTitle;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsStudentFavoriteBookArtMediaSupported ?? true)
            {
                isModified |=
                    source.StudentFavoriteBookArtMedia.SynchronizeCollectionTo(
                        target.StudentFavoriteBookArtMedia,
                        onChildAdded: child =>
                            {
                                child.StudentFavoriteBook = target;
                            },
                        includeItem: item => mappingContract?.IsStudentFavoriteBookArtMediumIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapTo(this IStudentFavoriteBook source, IStudentFavoriteBook target, Action<IStudentFavoriteBook, IStudentFavoriteBook> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentFavoriteBookMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentFavoriteBook);
    
            // Copy contextual primary key values
            target.FavoriteBookCategoryDescriptor = source.FavoriteBookCategoryDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsBookTitleSupported != false)
                target.BookTitle = source.BookTitle;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsStudentFavoriteBookArtMediaSupported != false)
            {
                source.StudentFavoriteBookArtMedia.MapCollectionTo(target.StudentFavoriteBookArtMedia, target, mappingContract?.IsStudentFavoriteBookArtMediumIncluded);
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
    public static class StudentFavoriteBookArtMediumMapper
    {
        private static readonly FullName _fullName_sample_StudentFavoriteBookArtMedium = new FullName("sample", "StudentFavoriteBookArtMedium");
    
        public static bool SynchronizeTo(this IStudentFavoriteBookArtMedium source, IStudentFavoriteBookArtMedium target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentFavoriteBookArtMediumMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentFavoriteBookArtMedium);


            // Copy non-PK properties

            if ((mappingContract?.IsArtPiecesSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentFavoriteBookArtMediumMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentFavoriteBookArtMedium);
    
            // Copy contextual primary key values
            target.ArtMediumDescriptor = source.ArtMediumDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsArtPiecesSupported != false)
                target.ArtPieces = source.ArtPieces;

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
    public static class StudentPetMapper
    {
        private static readonly FullName _fullName_sample_StudentPet = new FullName("sample", "StudentPet");
    
        public static bool SynchronizeTo(this IStudentPet source, IStudentPet target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentPetMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentPet);


            // Copy non-PK properties

            if ((mappingContract?.IsIsFixedSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentPetMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentPet);
    
            // Copy contextual primary key values
            target.PetName = source.PetName;

            // Copy non-PK properties

            if (mappingContract?.IsIsFixedSupported != false)
                target.IsFixed = source.IsFixed;

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
    public static class StudentPetPreferenceMapper
    {
        private static readonly FullName _fullName_sample_StudentPetPreference = new FullName("sample", "StudentPetPreference");
    
        public static bool SynchronizeTo(this IStudentPetPreference source, IStudentPetPreference target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentPetPreferenceMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentPetPreference);


            // Copy non-PK properties

            if ((mappingContract?.IsMaximumWeightSupported != false)
                && target.MaximumWeight != source.MaximumWeight)
            {
                target.MaximumWeight = source.MaximumWeight;
                isModified = true;
            }

            if ((mappingContract?.IsMinimumWeightSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentPetPreferenceMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentPetPreference);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsMaximumWeightSupported != false)
                target.MaximumWeight = source.MaximumWeight;

            if (mappingContract?.IsMinimumWeightSupported != false)
                target.MinimumWeight = source.MinimumWeight;

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
// Aggregate: StudentArtProgramAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentArtProgramAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentArtProgramAssociationMapper
    {
        private static readonly FullName _fullName_sample_StudentArtProgramAssociation = new FullName("sample", "StudentArtProgramAssociation");
    
        public static bool SynchronizeTo(this IStudentArtProgramAssociation source, IStudentArtProgramAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentArtProgramAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentArtProgramAssociation);

            var keyStringComparer = GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer;

            // Detect primary key changes
            if (
                 (target.BeginDate != source.BeginDate)
                || (target.EducationOrganizationId != source.EducationOrganizationId)
                || (target.ProgramEducationOrganizationId != source.ProgramEducationOrganizationId)
                || (!keyStringComparer.Equals(target.ProgramName, source.ProgramName))
                || (target.ProgramTypeDescriptor != source.ProgramTypeDescriptor)
                || (target.StudentUniqueId != source.StudentUniqueId))
            {
                // Disallow PK column updates on StudentArtProgramAssociation
                throw new BadRequestException("Key values for this resource cannot be changed. Delete and recreate the resource item.");
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

            if ((mappingContract?.IsArtPiecesSupported != false)
                && target.ArtPieces != source.ArtPieces)
            {
                target.ArtPieces = source.ArtPieces;
                isModified = true;
            }

            if ((mappingContract?.IsExhibitDateSupported != false)
                && target.ExhibitDate != source.ExhibitDate)
            {
                target.ExhibitDate = source.ExhibitDate;
                isModified = true;
            }

            if ((mappingContract?.IsHoursPerDaySupported != false)
                && target.HoursPerDay != source.HoursPerDay)
            {
                target.HoursPerDay = source.HoursPerDay;
                isModified = true;
            }

            if ((mappingContract?.IsIdentificationCodeSupported != false)
                && target.IdentificationCode != source.IdentificationCode)
            {
                target.IdentificationCode = source.IdentificationCode;
                isModified = true;
            }

            if ((mappingContract?.IsKilnReservationSupported != false)
                && target.KilnReservation != source.KilnReservation)
            {
                target.KilnReservation = source.KilnReservation;
                isModified = true;
            }

            if ((mappingContract?.IsKilnReservationLengthSupported != false)
                && target.KilnReservationLength != source.KilnReservationLength)
            {
                target.KilnReservationLength = source.KilnReservationLength;
                isModified = true;
            }

            if ((mappingContract?.IsMasteredMediumsSupported != false)
                && target.MasteredMediums != source.MasteredMediums)
            {
                target.MasteredMediums = source.MasteredMediums;
                isModified = true;
            }

            if ((mappingContract?.IsNumberOfDaysInAttendanceSupported != false)
                && target.NumberOfDaysInAttendance != source.NumberOfDaysInAttendance)
            {
                target.NumberOfDaysInAttendance = source.NumberOfDaysInAttendance;
                isModified = true;
            }

            if ((mappingContract?.IsPortfolioPiecesSupported != false)
                && target.PortfolioPieces != source.PortfolioPieces)
            {
                target.PortfolioPieces = source.PortfolioPieces;
                isModified = true;
            }

            if ((mappingContract?.IsPrivateArtProgramSupported != false)
                && target.PrivateArtProgram != source.PrivateArtProgram)
            {
                target.PrivateArtProgram = source.PrivateArtProgram;
                isModified = true;
            }

            if ((mappingContract?.IsProgramFeesSupported != false)
                && target.ProgramFees != source.ProgramFees)
            {
                target.ProgramFees = source.ProgramFees;
                isModified = true;
            }


            // Synch inherited lists
            if (mappingContract?.IsGeneralStudentProgramAssociationProgramParticipationStatusesSupported ?? true)
            {
                isModified |= 
                    source.GeneralStudentProgramAssociationProgramParticipationStatuses.SynchronizeCollectionTo(
                        target.GeneralStudentProgramAssociationProgramParticipationStatuses, 
                        onChildAdded: child => child.GeneralStudentProgramAssociation = target,
                        includeItem: item => mappingContract?.IsGeneralStudentProgramAssociationProgramParticipationStatusIncluded?.Invoke(item) ?? true);
            }


            // Sync lists
            if (mappingContract?.IsStudentArtProgramAssociationArtMediaSupported ?? true)
            {
                isModified |=
                    source.StudentArtProgramAssociationArtMedia.SynchronizeCollectionTo(
                        target.StudentArtProgramAssociationArtMedia,
                        onChildAdded: child =>
                            {
                                child.StudentArtProgramAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsStudentArtProgramAssociationArtMediumIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentArtProgramAssociationPortfolioYearsSupported ?? true)
            {
                isModified |=
                    source.StudentArtProgramAssociationPortfolioYears.SynchronizeCollectionTo(
                        target.StudentArtProgramAssociationPortfolioYears,
                        onChildAdded: child =>
                            {
                                child.StudentArtProgramAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsStudentArtProgramAssociationPortfolioYearsIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentArtProgramAssociationServicesSupported ?? true)
            {
                isModified |=
                    source.StudentArtProgramAssociationServices.SynchronizeCollectionTo(
                        target.StudentArtProgramAssociationServices,
                        onChildAdded: child =>
                            {
                                child.StudentArtProgramAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsStudentArtProgramAssociationServiceIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentArtProgramAssociationStylesSupported ?? true)
            {
                isModified |=
                    source.StudentArtProgramAssociationStyles.SynchronizeCollectionTo(
                        target.StudentArtProgramAssociationStyles,
                        onChildAdded: child =>
                            {
                                child.StudentArtProgramAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsStudentArtProgramAssociationStyleIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapDerivedTo(this IStudentArtProgramAssociation source, IStudentArtProgramAssociation target, Action<IStudentArtProgramAssociation, IStudentArtProgramAssociation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentArtProgramAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentArtProgramAssociation);
    
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

            if (mappingContract?.IsEndDateSupported != false)
                target.EndDate = source.EndDate;

            if (mappingContract?.IsReasonExitedDescriptorSupported != false)
                target.ReasonExitedDescriptor = source.ReasonExitedDescriptor;

            if (mappingContract?.IsServedOutsideOfRegularSessionSupported != false)
                target.ServedOutsideOfRegularSession = source.ServedOutsideOfRegularSession;

            // Copy non-PK properties

            if (mappingContract?.IsArtPiecesSupported != false)
                target.ArtPieces = source.ArtPieces;

            if (mappingContract?.IsExhibitDateSupported != false)
                target.ExhibitDate = source.ExhibitDate;

            if (mappingContract?.IsHoursPerDaySupported != false)
                target.HoursPerDay = source.HoursPerDay;

            if (mappingContract?.IsIdentificationCodeSupported != false)
                target.IdentificationCode = source.IdentificationCode;

            if (mappingContract?.IsKilnReservationSupported != false)
                target.KilnReservation = source.KilnReservation;

            if (mappingContract?.IsKilnReservationLengthSupported != false)
                target.KilnReservationLength = source.KilnReservationLength;

            if (mappingContract?.IsMasteredMediumsSupported != false)
                target.MasteredMediums = source.MasteredMediums;

            if (mappingContract?.IsNumberOfDaysInAttendanceSupported != false)
                target.NumberOfDaysInAttendance = source.NumberOfDaysInAttendance;

            if (mappingContract?.IsPortfolioPiecesSupported != false)
                target.PortfolioPieces = source.PortfolioPieces;

            if (mappingContract?.IsPrivateArtProgramSupported != false)
                target.PrivateArtProgram = source.PrivateArtProgram;

            if (mappingContract?.IsProgramFeesSupported != false)
                target.ProgramFees = source.ProgramFees;

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

            // Map inherited lists

            if (mappingContract?.IsGeneralStudentProgramAssociationProgramParticipationStatusesSupported != false)
            {
                source.GeneralStudentProgramAssociationProgramParticipationStatuses.MapCollectionTo(target.GeneralStudentProgramAssociationProgramParticipationStatuses, target, mappingContract?.IsGeneralStudentProgramAssociationProgramParticipationStatusIncluded);
            }

            // Map lists

            if (mappingContract?.IsStudentArtProgramAssociationArtMediaSupported != false)
            {
                source.StudentArtProgramAssociationArtMedia.MapCollectionTo(target.StudentArtProgramAssociationArtMedia, target, mappingContract?.IsStudentArtProgramAssociationArtMediumIncluded);
            }

            if (mappingContract?.IsStudentArtProgramAssociationPortfolioYearsSupported != false)
            {
                source.StudentArtProgramAssociationPortfolioYears.MapCollectionTo(target.StudentArtProgramAssociationPortfolioYears, target, mappingContract?.IsStudentArtProgramAssociationPortfolioYearsIncluded);
            }

            if (mappingContract?.IsStudentArtProgramAssociationServicesSupported != false)
            {
                source.StudentArtProgramAssociationServices.MapCollectionTo(target.StudentArtProgramAssociationServices, target, mappingContract?.IsStudentArtProgramAssociationServiceIncluded);
            }

            if (mappingContract?.IsStudentArtProgramAssociationStylesSupported != false)
            {
                source.StudentArtProgramAssociationStyles.MapCollectionTo(target.StudentArtProgramAssociationStyles, target, mappingContract?.IsStudentArtProgramAssociationStyleIncluded);
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
    public static class StudentArtProgramAssociationArtMediumMapper
    {
        private static readonly FullName _fullName_sample_StudentArtProgramAssociationArtMedium = new FullName("sample", "StudentArtProgramAssociationArtMedium");
    
        public static bool SynchronizeTo(this IStudentArtProgramAssociationArtMedium source, IStudentArtProgramAssociationArtMedium target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentArtProgramAssociationArtMediumMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentArtProgramAssociationArtMedium);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentArtProgramAssociationArtMedium source, IStudentArtProgramAssociationArtMedium target, Action<IStudentArtProgramAssociationArtMedium, IStudentArtProgramAssociationArtMedium> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentArtProgramAssociationArtMediumMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentArtProgramAssociationArtMedium);
    
            // Copy contextual primary key values
            target.ArtMediumDescriptor = source.ArtMediumDescriptor;

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

    [ExcludeFromCodeCoverage]
    public static class StudentArtProgramAssociationPortfolioYearsMapper
    {
        private static readonly FullName _fullName_sample_StudentArtProgramAssociationPortfolioYears = new FullName("sample", "StudentArtProgramAssociationPortfolioYears");
    
        public static bool SynchronizeTo(this IStudentArtProgramAssociationPortfolioYears source, IStudentArtProgramAssociationPortfolioYears target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentArtProgramAssociationPortfolioYearsMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentArtProgramAssociationPortfolioYears);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentArtProgramAssociationPortfolioYears source, IStudentArtProgramAssociationPortfolioYears target, Action<IStudentArtProgramAssociationPortfolioYears, IStudentArtProgramAssociationPortfolioYears> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentArtProgramAssociationPortfolioYearsMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentArtProgramAssociationPortfolioYears);
    
            // Copy contextual primary key values
            target.PortfolioYears = source.PortfolioYears;

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

    [ExcludeFromCodeCoverage]
    public static class StudentArtProgramAssociationServiceMapper
    {
        private static readonly FullName _fullName_sample_StudentArtProgramAssociationService = new FullName("sample", "StudentArtProgramAssociationService");
    
        public static bool SynchronizeTo(this IStudentArtProgramAssociationService source, IStudentArtProgramAssociationService target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentArtProgramAssociationServiceMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentArtProgramAssociationService);


            // Copy non-PK properties

            if ((mappingContract?.IsPrimaryIndicatorSupported != false)
                && target.PrimaryIndicator != source.PrimaryIndicator)
            {
                target.PrimaryIndicator = source.PrimaryIndicator;
                isModified = true;
            }

            if ((mappingContract?.IsServiceBeginDateSupported != false)
                && target.ServiceBeginDate != source.ServiceBeginDate)
            {
                target.ServiceBeginDate = source.ServiceBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsServiceEndDateSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentArtProgramAssociationServiceMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentArtProgramAssociationService);
    
            // Copy contextual primary key values
            target.ServiceDescriptor = source.ServiceDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsPrimaryIndicatorSupported != false)
                target.PrimaryIndicator = source.PrimaryIndicator;

            if (mappingContract?.IsServiceBeginDateSupported != false)
                target.ServiceBeginDate = source.ServiceBeginDate;

            if (mappingContract?.IsServiceEndDateSupported != false)
                target.ServiceEndDate = source.ServiceEndDate;

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
    public static class StudentArtProgramAssociationStyleMapper
    {
        private static readonly FullName _fullName_sample_StudentArtProgramAssociationStyle = new FullName("sample", "StudentArtProgramAssociationStyle");
    
        public static bool SynchronizeTo(this IStudentArtProgramAssociationStyle source, IStudentArtProgramAssociationStyle target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentArtProgramAssociationStyleMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentArtProgramAssociationStyle);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentArtProgramAssociationStyle source, IStudentArtProgramAssociationStyle target, Action<IStudentArtProgramAssociationStyle, IStudentArtProgramAssociationStyle> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentArtProgramAssociationStyleMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentArtProgramAssociationStyle);
    
            // Copy contextual primary key values
            target.Style = source.Style;

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
// Aggregate: StudentContactAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentContactAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentContactAssociationDisciplineMapper
    {
        private static readonly FullName _fullName_sample_StudentContactAssociationDiscipline = new FullName("sample", "StudentContactAssociationDiscipline");
    
        public static bool SynchronizeTo(this IStudentContactAssociationDiscipline source, IStudentContactAssociationDiscipline target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentContactAssociationDisciplineMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationDiscipline);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentContactAssociationDiscipline source, IStudentContactAssociationDiscipline target, Action<IStudentContactAssociationDiscipline, IStudentContactAssociationDiscipline> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentContactAssociationDisciplineMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationDiscipline);
    
            // Copy contextual primary key values
            target.DisciplineDescriptor = source.DisciplineDescriptor;

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

    [ExcludeFromCodeCoverage]
    public static class StudentContactAssociationExtensionMapper
    {
        private static readonly FullName _fullName_sample_StudentContactAssociationExtension = new FullName("sample", "StudentContactAssociationExtension");
    
        public static bool SynchronizeTo(this IStudentContactAssociationExtension source, IStudentContactAssociationExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentContactAssociationExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationExtension);


            // Copy non-PK properties

            if ((mappingContract?.IsBedtimeReaderSupported != false)
                && target.BedtimeReader != source.BedtimeReader)
            {
                target.BedtimeReader = source.BedtimeReader;
                isModified = true;
            }

            if ((mappingContract?.IsBedtimeReadingRateSupported != false)
                && target.BedtimeReadingRate != source.BedtimeReadingRate)
            {
                target.BedtimeReadingRate = source.BedtimeReadingRate;
                isModified = true;
            }

            if ((mappingContract?.IsBookBudgetSupported != false)
                && target.BookBudget != source.BookBudget)
            {
                target.BookBudget = source.BookBudget;
                isModified = true;
            }

            if ((mappingContract?.IsBooksBorrowedSupported != false)
                && target.BooksBorrowed != source.BooksBorrowed)
            {
                target.BooksBorrowed = source.BooksBorrowed;
                isModified = true;
            }

            if ((mappingContract?.IsEducationOrganizationIdSupported != false)
                && target.EducationOrganizationId != source.EducationOrganizationId)
            {
                target.EducationOrganizationId = source.EducationOrganizationId;
                isModified = true;
            }

            if ((mappingContract?.IsInterventionStudyIdentificationCodeSupported != false)
                && target.InterventionStudyIdentificationCode != source.InterventionStudyIdentificationCode)
            {
                target.InterventionStudyIdentificationCode = source.InterventionStudyIdentificationCode;
                isModified = true;
            }

            if ((mappingContract?.IsLibraryDurationSupported != false)
                && target.LibraryDuration != source.LibraryDuration)
            {
                target.LibraryDuration = source.LibraryDuration;
                isModified = true;
            }

            if ((mappingContract?.IsLibraryTimeSupported != false)
                && target.LibraryTime != source.LibraryTime)
            {
                target.LibraryTime = source.LibraryTime;
                isModified = true;
            }

            if ((mappingContract?.IsLibraryVisitsSupported != false)
                && target.LibraryVisits != source.LibraryVisits)
            {
                target.LibraryVisits = source.LibraryVisits;
                isModified = true;
            }

            if ((mappingContract?.IsPriorContactRestrictionsSupported != false)
                && target.PriorContactRestrictions != source.PriorContactRestrictions)
            {
                target.PriorContactRestrictions = source.PriorContactRestrictions;
                isModified = true;
            }

            if ((mappingContract?.IsReadGreenEggsAndHamDateSupported != false)
                && target.ReadGreenEggsAndHamDate != source.ReadGreenEggsAndHamDate)
            {
                target.ReadGreenEggsAndHamDate = source.ReadGreenEggsAndHamDate;
                isModified = true;
            }

            if ((mappingContract?.IsReadingTimeSpentSupported != false)
                && target.ReadingTimeSpent != source.ReadingTimeSpent)
            {
                target.ReadingTimeSpent = source.ReadingTimeSpent;
                isModified = true;
            }

            if ((mappingContract?.IsStudentReadSupported != false)
                && target.StudentRead != source.StudentRead)
            {
                target.StudentRead = source.StudentRead;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // StudentContactAssociationTelephone (StudentContactAssociationTelephone)
            if (mappingContract?.IsStudentContactAssociationTelephoneSupported != false)
            {
                if (source.StudentContactAssociationTelephone == null)
                {
                    if (target.StudentContactAssociationTelephone != null)
                    {
                        target.StudentContactAssociationTelephone = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.StudentContactAssociationTelephone == null)
                    {
                        var itemType = target.GetType().GetProperty("StudentContactAssociationTelephone").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.StudentContactAssociationTelephone = (IStudentContactAssociationTelephone) newItem;
                    }

                    isModified |= source.StudentContactAssociationTelephone.Synchronize(target.StudentContactAssociationTelephone);
                }
            }

            // -------------------------------------------------------------

            // Sync lists
            if (mappingContract?.IsStudentContactAssociationDisciplinesSupported ?? true)
            {
                isModified |=
                    source.StudentContactAssociationDisciplines.SynchronizeCollectionTo(
                        target.StudentContactAssociationDisciplines,
                        onChildAdded: child =>
                            {
                                child.StudentContactAssociationExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentContactAssociation);
                            },
                        includeItem: item => mappingContract?.IsStudentContactAssociationDisciplineIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentContactAssociationFavoriteBookTitlesSupported ?? true)
            {
                isModified |=
                    source.StudentContactAssociationFavoriteBookTitles.SynchronizeCollectionTo(
                        target.StudentContactAssociationFavoriteBookTitles,
                        onChildAdded: child =>
                            {
                                child.StudentContactAssociationExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentContactAssociation);
                            },
                        includeItem: item => mappingContract?.IsStudentContactAssociationFavoriteBookTitleIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentContactAssociationHoursPerWeeksSupported ?? true)
            {
                isModified |=
                    source.StudentContactAssociationHoursPerWeeks.SynchronizeCollectionTo(
                        target.StudentContactAssociationHoursPerWeeks,
                        onChildAdded: child =>
                            {
                                child.StudentContactAssociationExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentContactAssociation);
                            },
                        includeItem: item => mappingContract?.IsStudentContactAssociationHoursPerWeekIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentContactAssociationPagesReadsSupported ?? true)
            {
                isModified |=
                    source.StudentContactAssociationPagesReads.SynchronizeCollectionTo(
                        target.StudentContactAssociationPagesReads,
                        onChildAdded: child =>
                            {
                                child.StudentContactAssociationExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentContactAssociation);
                            },
                        includeItem: item => mappingContract?.IsStudentContactAssociationPagesReadIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsSupported ?? true)
            {
                isModified |=
                    source.StudentContactAssociationStaffEducationOrganizationEmploymentAssociations.SynchronizeCollectionTo(
                        target.StudentContactAssociationStaffEducationOrganizationEmploymentAssociations,
                        onChildAdded: child =>
                            {
                                child.StudentContactAssociationExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentContactAssociation);
                            },
                        includeItem: item => mappingContract?.IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapTo(this IStudentContactAssociationExtension source, IStudentContactAssociationExtension target, Action<IStudentContactAssociationExtension, IStudentContactAssociationExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentContactAssociationExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsBedtimeReaderSupported != false)
                target.BedtimeReader = source.BedtimeReader;

            if (mappingContract?.IsBedtimeReadingRateSupported != false)
                target.BedtimeReadingRate = source.BedtimeReadingRate;

            if (mappingContract?.IsBookBudgetSupported != false)
                target.BookBudget = source.BookBudget;

            if (mappingContract?.IsBooksBorrowedSupported != false)
                target.BooksBorrowed = source.BooksBorrowed;

            if (mappingContract?.IsEducationOrganizationIdSupported != false)
                target.EducationOrganizationId = source.EducationOrganizationId;

            if (mappingContract?.IsInterventionStudyIdentificationCodeSupported != false)
                target.InterventionStudyIdentificationCode = source.InterventionStudyIdentificationCode;

            if (mappingContract?.IsLibraryDurationSupported != false)
                target.LibraryDuration = source.LibraryDuration;

            if (mappingContract?.IsLibraryTimeSupported != false)
                target.LibraryTime = source.LibraryTime;

            if (mappingContract?.IsLibraryVisitsSupported != false)
                target.LibraryVisits = source.LibraryVisits;

            if (mappingContract?.IsPriorContactRestrictionsSupported != false)
                target.PriorContactRestrictions = source.PriorContactRestrictions;

            if (mappingContract?.IsReadGreenEggsAndHamDateSupported != false)
                target.ReadGreenEggsAndHamDate = source.ReadGreenEggsAndHamDate;

            if (mappingContract?.IsReadingTimeSpentSupported != false)
                target.ReadingTimeSpent = source.ReadingTimeSpent;

            if (mappingContract?.IsStudentReadSupported != false)
                target.StudentRead = source.StudentRead;

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
            // StudentContactAssociationTelephone (StudentContactAssociationTelephone) (Source)
            if (mappingContract?.IsStudentContactAssociationTelephoneSupported != false)
            {
                var itemProperty = target.GetType().GetProperty("StudentContactAssociationTelephone");

                if (itemProperty != null)
                {
                    if (source.StudentContactAssociationTelephone == null)
                    {
                        target.StudentContactAssociationTelephone = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetStudentContactAssociationTelephone = Activator.CreateInstance(itemType);
                        (targetStudentContactAssociationTelephone as IChildEntity)?.SetParent(target.StudentContactAssociation);
                        source.StudentContactAssociationTelephone.Map(targetStudentContactAssociationTelephone);

                        // Update the target reference appropriately
                        target.StudentContactAssociationTelephone = (IStudentContactAssociationTelephone) targetStudentContactAssociationTelephone;
                    }
                }
            }
            // -------------------------------------------------------------

            // Map lists

            if (mappingContract?.IsStudentContactAssociationDisciplinesSupported != false)
            {
                source.StudentContactAssociationDisciplines.MapCollectionTo(target.StudentContactAssociationDisciplines, target.StudentContactAssociation, mappingContract?.IsStudentContactAssociationDisciplineIncluded);
            }

            if (mappingContract?.IsStudentContactAssociationFavoriteBookTitlesSupported != false)
            {
                source.StudentContactAssociationFavoriteBookTitles.MapCollectionTo(target.StudentContactAssociationFavoriteBookTitles, target.StudentContactAssociation, mappingContract?.IsStudentContactAssociationFavoriteBookTitleIncluded);
            }

            if (mappingContract?.IsStudentContactAssociationHoursPerWeeksSupported != false)
            {
                source.StudentContactAssociationHoursPerWeeks.MapCollectionTo(target.StudentContactAssociationHoursPerWeeks, target.StudentContactAssociation, mappingContract?.IsStudentContactAssociationHoursPerWeekIncluded);
            }

            if (mappingContract?.IsStudentContactAssociationPagesReadsSupported != false)
            {
                source.StudentContactAssociationPagesReads.MapCollectionTo(target.StudentContactAssociationPagesReads, target.StudentContactAssociation, mappingContract?.IsStudentContactAssociationPagesReadIncluded);
            }

            if (mappingContract?.IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsSupported != false)
            {
                source.StudentContactAssociationStaffEducationOrganizationEmploymentAssociations.MapCollectionTo(target.StudentContactAssociationStaffEducationOrganizationEmploymentAssociations, target.StudentContactAssociation, mappingContract?.IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationIncluded);
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
    public static class StudentContactAssociationFavoriteBookTitleMapper
    {
        private static readonly FullName _fullName_sample_StudentContactAssociationFavoriteBookTitle = new FullName("sample", "StudentContactAssociationFavoriteBookTitle");
    
        public static bool SynchronizeTo(this IStudentContactAssociationFavoriteBookTitle source, IStudentContactAssociationFavoriteBookTitle target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentContactAssociationFavoriteBookTitleMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationFavoriteBookTitle);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentContactAssociationFavoriteBookTitle source, IStudentContactAssociationFavoriteBookTitle target, Action<IStudentContactAssociationFavoriteBookTitle, IStudentContactAssociationFavoriteBookTitle> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentContactAssociationFavoriteBookTitleMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationFavoriteBookTitle);
    
            // Copy contextual primary key values
            target.FavoriteBookTitle = source.FavoriteBookTitle;

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

    [ExcludeFromCodeCoverage]
    public static class StudentContactAssociationHoursPerWeekMapper
    {
        private static readonly FullName _fullName_sample_StudentContactAssociationHoursPerWeek = new FullName("sample", "StudentContactAssociationHoursPerWeek");
    
        public static bool SynchronizeTo(this IStudentContactAssociationHoursPerWeek source, IStudentContactAssociationHoursPerWeek target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentContactAssociationHoursPerWeekMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationHoursPerWeek);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentContactAssociationHoursPerWeek source, IStudentContactAssociationHoursPerWeek target, Action<IStudentContactAssociationHoursPerWeek, IStudentContactAssociationHoursPerWeek> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentContactAssociationHoursPerWeekMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationHoursPerWeek);
    
            // Copy contextual primary key values
            target.HoursPerWeek = source.HoursPerWeek;

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

    [ExcludeFromCodeCoverage]
    public static class StudentContactAssociationPagesReadMapper
    {
        private static readonly FullName _fullName_sample_StudentContactAssociationPagesRead = new FullName("sample", "StudentContactAssociationPagesRead");
    
        public static bool SynchronizeTo(this IStudentContactAssociationPagesRead source, IStudentContactAssociationPagesRead target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentContactAssociationPagesReadMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationPagesRead);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentContactAssociationPagesRead source, IStudentContactAssociationPagesRead target, Action<IStudentContactAssociationPagesRead, IStudentContactAssociationPagesRead> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentContactAssociationPagesReadMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationPagesRead);
    
            // Copy contextual primary key values
            target.PagesRead = source.PagesRead;

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

    [ExcludeFromCodeCoverage]
    public static class StudentContactAssociationStaffEducationOrganizationEmploymentAssociationMapper
    {
        private static readonly FullName _fullName_sample_StudentContactAssociationStaffEducationOrganizationEmploymentAssociation = new FullName("sample", "StudentContactAssociationStaffEducationOrganizationEmploymentAssociation");
    
        public static bool SynchronizeTo(this IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation source, IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentContactAssociationStaffEducationOrganizationEmploymentAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationStaffEducationOrganizationEmploymentAssociation);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation source, IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation target, Action<IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation, IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentContactAssociationStaffEducationOrganizationEmploymentAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationStaffEducationOrganizationEmploymentAssociation);
    
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
    public static class StudentContactAssociationTelephoneMapper
    {
        private static readonly FullName _fullName_sample_StudentContactAssociationTelephone = new FullName("sample", "StudentContactAssociationTelephone");
    
        public static bool SynchronizeTo(this IStudentContactAssociationTelephone source, IStudentContactAssociationTelephone target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentContactAssociationTelephoneMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationTelephone);


            // Copy non-PK properties

            if ((mappingContract?.IsDoNotPublishIndicatorSupported != false)
                && target.DoNotPublishIndicator != source.DoNotPublishIndicator)
            {
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
                isModified = true;
            }

            if ((mappingContract?.IsOrderOfPrioritySupported != false)
                && target.OrderOfPriority != source.OrderOfPriority)
            {
                target.OrderOfPriority = source.OrderOfPriority;
                isModified = true;
            }

            if ((mappingContract?.IsTelephoneNumberSupported != false)
                && target.TelephoneNumber != source.TelephoneNumber)
            {
                target.TelephoneNumber = source.TelephoneNumber;
                isModified = true;
            }

            if ((mappingContract?.IsTelephoneNumberTypeDescriptorSupported != false)
                && target.TelephoneNumberTypeDescriptor != source.TelephoneNumberTypeDescriptor)
            {
                target.TelephoneNumberTypeDescriptor = source.TelephoneNumberTypeDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsTextMessageCapabilityIndicatorSupported != false)
                && target.TextMessageCapabilityIndicator != source.TextMessageCapabilityIndicator)
            {
                target.TextMessageCapabilityIndicator = source.TextMessageCapabilityIndicator;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentContactAssociationTelephone source, IStudentContactAssociationTelephone target, Action<IStudentContactAssociationTelephone, IStudentContactAssociationTelephone> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentContactAssociationTelephoneMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationTelephone);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsDoNotPublishIndicatorSupported != false)
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;

            if (mappingContract?.IsOrderOfPrioritySupported != false)
                target.OrderOfPriority = source.OrderOfPriority;

            if (mappingContract?.IsTelephoneNumberSupported != false)
                target.TelephoneNumber = source.TelephoneNumber;

            if (mappingContract?.IsTelephoneNumberTypeDescriptorSupported != false)
                target.TelephoneNumberTypeDescriptor = source.TelephoneNumberTypeDescriptor;

            if (mappingContract?.IsTextMessageCapabilityIndicatorSupported != false)
                target.TextMessageCapabilityIndicator = source.TextMessageCapabilityIndicator;

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
// Aggregate: StudentCTEProgramAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentCTEProgramAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentCTEProgramAssociationExtensionMapper
    {
        private static readonly FullName _fullName_sample_StudentCTEProgramAssociationExtension = new FullName("sample", "StudentCTEProgramAssociationExtension");
    
        public static bool SynchronizeTo(this IStudentCTEProgramAssociationExtension source, IStudentCTEProgramAssociationExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentCTEProgramAssociationExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentCTEProgramAssociationExtension);


            // Copy non-PK properties

            if ((mappingContract?.IsAnalysisCompletedSupported != false)
                && target.AnalysisCompleted != source.AnalysisCompleted)
            {
                target.AnalysisCompleted = source.AnalysisCompleted;
                isModified = true;
            }

            if ((mappingContract?.IsAnalysisDateSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentCTEProgramAssociationExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentCTEProgramAssociationExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsAnalysisCompletedSupported != false)
                target.AnalysisCompleted = source.AnalysisCompleted;

            if (mappingContract?.IsAnalysisDateSupported != false)
                target.AnalysisDate = source.AnalysisDate;

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
// Aggregate: StudentEducationOrganizationAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentEducationOrganizationAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentEducationOrganizationAssociationAddressExtensionMapper
    {
        private static readonly FullName _fullName_sample_StudentEducationOrganizationAssociationAddressExtension = new FullName("sample", "StudentEducationOrganizationAssociationAddressExtension");
    
        public static bool SynchronizeTo(this IStudentEducationOrganizationAssociationAddressExtension source, IStudentEducationOrganizationAssociationAddressExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentEducationOrganizationAssociationAddressExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationAddressExtension);


            // Copy non-PK properties

            if ((mappingContract?.IsComplexSupported != false)
                && target.Complex != source.Complex)
            {
                target.Complex = source.Complex;
                isModified = true;
            }

            if ((mappingContract?.IsOnBusRouteSupported != false)
                && target.OnBusRoute != source.OnBusRoute)
            {
                target.OnBusRoute = source.OnBusRoute;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsStudentEducationOrganizationAssociationAddressSchoolDistrictsSupported ?? true)
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
                        includeItem: item => mappingContract?.IsStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentEducationOrganizationAssociationAddressTermsSupported ?? true)
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
                        includeItem: item => mappingContract?.IsStudentEducationOrganizationAssociationAddressTermIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapTo(this IStudentEducationOrganizationAssociationAddressExtension source, IStudentEducationOrganizationAssociationAddressExtension target, Action<IStudentEducationOrganizationAssociationAddressExtension, IStudentEducationOrganizationAssociationAddressExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentEducationOrganizationAssociationAddressExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationAddressExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsComplexSupported != false)
                target.Complex = source.Complex;

            if (mappingContract?.IsOnBusRouteSupported != false)
                target.OnBusRoute = source.OnBusRoute;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsStudentEducationOrganizationAssociationAddressSchoolDistrictsSupported != false)
            {
                source.StudentEducationOrganizationAssociationAddressSchoolDistricts.MapCollectionTo(target.StudentEducationOrganizationAssociationAddressSchoolDistricts, target.StudentEducationOrganizationAssociationAddress, mappingContract?.IsStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded);
            }

            if (mappingContract?.IsStudentEducationOrganizationAssociationAddressTermsSupported != false)
            {
                source.StudentEducationOrganizationAssociationAddressTerms.MapCollectionTo(target.StudentEducationOrganizationAssociationAddressTerms, target.StudentEducationOrganizationAssociationAddress, mappingContract?.IsStudentEducationOrganizationAssociationAddressTermIncluded);
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
    public static class StudentEducationOrganizationAssociationAddressSchoolDistrictMapper
    {
        private static readonly FullName _fullName_sample_StudentEducationOrganizationAssociationAddressSchoolDistrict = new FullName("sample", "StudentEducationOrganizationAssociationAddressSchoolDistrict");
    
        public static bool SynchronizeTo(this IStudentEducationOrganizationAssociationAddressSchoolDistrict source, IStudentEducationOrganizationAssociationAddressSchoolDistrict target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentEducationOrganizationAssociationAddressSchoolDistrictMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationAddressSchoolDistrict);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentEducationOrganizationAssociationAddressSchoolDistrict source, IStudentEducationOrganizationAssociationAddressSchoolDistrict target, Action<IStudentEducationOrganizationAssociationAddressSchoolDistrict, IStudentEducationOrganizationAssociationAddressSchoolDistrict> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentEducationOrganizationAssociationAddressSchoolDistrictMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationAddressSchoolDistrict);
    
            // Copy contextual primary key values
            target.SchoolDistrict = source.SchoolDistrict;

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

    [ExcludeFromCodeCoverage]
    public static class StudentEducationOrganizationAssociationAddressTermMapper
    {
        private static readonly FullName _fullName_sample_StudentEducationOrganizationAssociationAddressTerm = new FullName("sample", "StudentEducationOrganizationAssociationAddressTerm");
    
        public static bool SynchronizeTo(this IStudentEducationOrganizationAssociationAddressTerm source, IStudentEducationOrganizationAssociationAddressTerm target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentEducationOrganizationAssociationAddressTermMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationAddressTerm);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentEducationOrganizationAssociationAddressTerm source, IStudentEducationOrganizationAssociationAddressTerm target, Action<IStudentEducationOrganizationAssociationAddressTerm, IStudentEducationOrganizationAssociationAddressTerm> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentEducationOrganizationAssociationAddressTermMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationAddressTerm);
    
            // Copy contextual primary key values
            target.TermDescriptor = source.TermDescriptor;

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

    [ExcludeFromCodeCoverage]
    public static class StudentEducationOrganizationAssociationExtensionMapper
    {
        private static readonly FullName _fullName_sample_StudentEducationOrganizationAssociationExtension = new FullName("sample", "StudentEducationOrganizationAssociationExtension");
    
        public static bool SynchronizeTo(this IStudentEducationOrganizationAssociationExtension source, IStudentEducationOrganizationAssociationExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentEducationOrganizationAssociationExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationExtension);


            // Copy non-PK properties

            if ((mappingContract?.IsFavoriteProgramNameSupported != false)
                && target.FavoriteProgramName != source.FavoriteProgramName)
            {
                target.FavoriteProgramName = source.FavoriteProgramName;
                isModified = true;
            }

            if ((mappingContract?.IsFavoriteProgramTypeDescriptorSupported != false)
                && target.FavoriteProgramTypeDescriptor != source.FavoriteProgramTypeDescriptor)
            {
                target.FavoriteProgramTypeDescriptor = source.FavoriteProgramTypeDescriptor;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentEducationOrganizationAssociationExtension source, IStudentEducationOrganizationAssociationExtension target, Action<IStudentEducationOrganizationAssociationExtension, IStudentEducationOrganizationAssociationExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentEducationOrganizationAssociationExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsFavoriteProgramNameSupported != false)
                target.FavoriteProgramName = source.FavoriteProgramName;

            if (mappingContract?.IsFavoriteProgramTypeDescriptorSupported != false)
                target.FavoriteProgramTypeDescriptor = source.FavoriteProgramTypeDescriptor;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.FavoriteProgramResourceId = source.FavoriteProgramResourceId;
                target.FavoriteProgramDiscriminator = source.FavoriteProgramDiscriminator;
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

    [ExcludeFromCodeCoverage]
    public static class StudentEducationOrganizationAssociationStudentCharacteristicExtensionMapper
    {
        private static readonly FullName _fullName_sample_StudentEducationOrganizationAssociationStudentCharacteristicExtension = new FullName("sample", "StudentEducationOrganizationAssociationStudentCharacteristicExtension");
    
        public static bool SynchronizeTo(this IStudentEducationOrganizationAssociationStudentCharacteristicExtension source, IStudentEducationOrganizationAssociationStudentCharacteristicExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentEducationOrganizationAssociationStudentCharacteristicExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationStudentCharacteristicExtension);


            // Copy non-PK properties


            // Sync lists
            if (mappingContract?.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsSupported ?? true)
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
                        includeItem: item => mappingContract?.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapTo(this IStudentEducationOrganizationAssociationStudentCharacteristicExtension source, IStudentEducationOrganizationAssociationStudentCharacteristicExtension target, Action<IStudentEducationOrganizationAssociationStudentCharacteristicExtension, IStudentEducationOrganizationAssociationStudentCharacteristicExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentEducationOrganizationAssociationStudentCharacteristicExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationStudentCharacteristicExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsSupported != false)
            {
                source.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds.MapCollectionTo(target.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds, target.StudentEducationOrganizationAssociationStudentCharacteristic, mappingContract?.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded);
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
    public static class StudentEducationOrganizationAssociationStudentCharacteristicStudentNeedMapper
    {
        private static readonly FullName _fullName_sample_StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed = new FullName("sample", "StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed");
    
        public static bool SynchronizeTo(this IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed source, IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentEducationOrganizationAssociationStudentCharacteristicStudentNeedMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed);


            // Copy non-PK properties

            if ((mappingContract?.IsEndDateSupported != false)
                && target.EndDate != source.EndDate)
            {
                target.EndDate = source.EndDate;
                isModified = true;
            }

            if ((mappingContract?.IsPrimaryStudentNeedIndicatorSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentEducationOrganizationAssociationStudentCharacteristicStudentNeedMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed);
    
            // Copy contextual primary key values
            target.BeginDate = source.BeginDate;

            // Copy non-PK properties

            if (mappingContract?.IsEndDateSupported != false)
                target.EndDate = source.EndDate;

            if (mappingContract?.IsPrimaryStudentNeedIndicatorSupported != false)
                target.PrimaryStudentNeedIndicator = source.PrimaryStudentNeedIndicator;

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
// Aggregate: StudentGraduationPlanAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentGraduationPlanAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationMapper
    {
        private static readonly FullName _fullName_sample_StudentGraduationPlanAssociation = new FullName("sample", "StudentGraduationPlanAssociation");
    
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociation source, IStudentGraduationPlanAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentGraduationPlanAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociation);

            // Detect primary key changes
            if (
                 (target.EducationOrganizationId != source.EducationOrganizationId)
                || (target.GraduationPlanTypeDescriptor != source.GraduationPlanTypeDescriptor)
                || (target.GraduationSchoolYear != source.GraduationSchoolYear)
                || (target.StudentUniqueId != source.StudentUniqueId))
            {
                // Disallow PK column updates on StudentGraduationPlanAssociation
                throw new BadRequestException("Key values for this resource cannot be changed. Delete and recreate the resource item.");
            }


            // Copy non-PK properties

            if ((mappingContract?.IsCommencementTimeSupported != false)
                && target.CommencementTime != source.CommencementTime)
            {
                target.CommencementTime = source.CommencementTime;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveDateSupported != false)
                && target.EffectiveDate != source.EffectiveDate)
            {
                target.EffectiveDate = source.EffectiveDate;
                isModified = true;
            }

            if ((mappingContract?.IsGraduationFeeSupported != false)
                && target.GraduationFee != source.GraduationFee)
            {
                target.GraduationFee = source.GraduationFee;
                isModified = true;
            }

            if ((mappingContract?.IsHighSchoolDurationSupported != false)
                && target.HighSchoolDuration != source.HighSchoolDuration)
            {
                target.HighSchoolDuration = source.HighSchoolDuration;
                isModified = true;
            }

            if ((mappingContract?.IsHoursPerWeekSupported != false)
                && target.HoursPerWeek != source.HoursPerWeek)
            {
                target.HoursPerWeek = source.HoursPerWeek;
                isModified = true;
            }

            if ((mappingContract?.IsIsActivePlanSupported != false)
                && target.IsActivePlan != source.IsActivePlan)
            {
                target.IsActivePlan = source.IsActivePlan;
                isModified = true;
            }

            if ((mappingContract?.IsRequiredAttendanceSupported != false)
                && target.RequiredAttendance != source.RequiredAttendance)
            {
                target.RequiredAttendance = source.RequiredAttendance;
                isModified = true;
            }

            if ((mappingContract?.IsStaffUniqueIdSupported != false)
                && target.StaffUniqueId != source.StaffUniqueId)
            {
                target.StaffUniqueId = source.StaffUniqueId;
                isModified = true;
            }

            if ((mappingContract?.IsTargetGPASupported != false)
                && target.TargetGPA != source.TargetGPA)
            {
                target.TargetGPA = source.TargetGPA;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // StudentGraduationPlanAssociationCTEProgram (StudentGraduationPlanAssociationCTEProgram)
            if (mappingContract?.IsStudentGraduationPlanAssociationCTEProgramSupported != false)
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
            if (mappingContract?.IsStudentGraduationPlanAssociationAcademicSubjectsSupported ?? true)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationAcademicSubjects.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationAcademicSubjects,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsStudentGraduationPlanAssociationAcademicSubjectIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentGraduationPlanAssociationCareerPathwayCodesSupported ?? true)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationCareerPathwayCodes.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationCareerPathwayCodes,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsStudentGraduationPlanAssociationCareerPathwayCodeIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentGraduationPlanAssociationDescriptionsSupported ?? true)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationDescriptions.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationDescriptions,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsStudentGraduationPlanAssociationDescriptionIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentGraduationPlanAssociationDesignatedBiesSupported ?? true)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationDesignatedBies.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationDesignatedBies,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsStudentGraduationPlanAssociationDesignatedByIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentGraduationPlanAssociationIndustryCredentialsSupported ?? true)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationIndustryCredentials.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationIndustryCredentials,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsStudentGraduationPlanAssociationIndustryCredentialIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentGraduationPlanAssociationStudentContactAssociationsSupported ?? true)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationStudentContactAssociations.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationStudentContactAssociations,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsStudentGraduationPlanAssociationStudentContactAssociationIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStudentGraduationPlanAssociationYearsAttendedsSupported ?? true)
            {
                isModified |=
                    source.StudentGraduationPlanAssociationYearsAttendeds.SynchronizeCollectionTo(
                        target.StudentGraduationPlanAssociationYearsAttendeds,
                        onChildAdded: child =>
                            {
                                child.StudentGraduationPlanAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsStudentGraduationPlanAssociationYearsAttendedIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapTo(this IStudentGraduationPlanAssociation source, IStudentGraduationPlanAssociation target, Action<IStudentGraduationPlanAssociation, IStudentGraduationPlanAssociation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentGraduationPlanAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociation);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.GraduationPlanTypeDescriptor = source.GraduationPlanTypeDescriptor;
            target.GraduationSchoolYear = source.GraduationSchoolYear;
            target.StudentUniqueId = source.StudentUniqueId;

            // Copy non-PK properties

            if (mappingContract?.IsCommencementTimeSupported != false)
                target.CommencementTime = source.CommencementTime;

            if (mappingContract?.IsEffectiveDateSupported != false)
                target.EffectiveDate = source.EffectiveDate;

            if (mappingContract?.IsGraduationFeeSupported != false)
                target.GraduationFee = source.GraduationFee;

            if (mappingContract?.IsHighSchoolDurationSupported != false)
                target.HighSchoolDuration = source.HighSchoolDuration;

            if (mappingContract?.IsHoursPerWeekSupported != false)
                target.HoursPerWeek = source.HoursPerWeek;

            if (mappingContract?.IsIsActivePlanSupported != false)
                target.IsActivePlan = source.IsActivePlan;

            if (mappingContract?.IsRequiredAttendanceSupported != false)
                target.RequiredAttendance = source.RequiredAttendance;

            if (mappingContract?.IsStaffUniqueIdSupported != false)
                target.StaffUniqueId = source.StaffUniqueId;

            if (mappingContract?.IsTargetGPASupported != false)
                target.TargetGPA = source.TargetGPA;

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
            // StudentGraduationPlanAssociationCTEProgram (StudentGraduationPlanAssociationCTEProgram) (Source)
            if (mappingContract?.IsStudentGraduationPlanAssociationCTEProgramSupported != false)
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
            // -------------------------------------------------------------

            // Map lists

            if (mappingContract?.IsStudentGraduationPlanAssociationAcademicSubjectsSupported != false)
            {
                source.StudentGraduationPlanAssociationAcademicSubjects.MapCollectionTo(target.StudentGraduationPlanAssociationAcademicSubjects, target, mappingContract?.IsStudentGraduationPlanAssociationAcademicSubjectIncluded);
            }

            if (mappingContract?.IsStudentGraduationPlanAssociationCareerPathwayCodesSupported != false)
            {
                source.StudentGraduationPlanAssociationCareerPathwayCodes.MapCollectionTo(target.StudentGraduationPlanAssociationCareerPathwayCodes, target, mappingContract?.IsStudentGraduationPlanAssociationCareerPathwayCodeIncluded);
            }

            if (mappingContract?.IsStudentGraduationPlanAssociationDescriptionsSupported != false)
            {
                source.StudentGraduationPlanAssociationDescriptions.MapCollectionTo(target.StudentGraduationPlanAssociationDescriptions, target, mappingContract?.IsStudentGraduationPlanAssociationDescriptionIncluded);
            }

            if (mappingContract?.IsStudentGraduationPlanAssociationDesignatedBiesSupported != false)
            {
                source.StudentGraduationPlanAssociationDesignatedBies.MapCollectionTo(target.StudentGraduationPlanAssociationDesignatedBies, target, mappingContract?.IsStudentGraduationPlanAssociationDesignatedByIncluded);
            }

            if (mappingContract?.IsStudentGraduationPlanAssociationIndustryCredentialsSupported != false)
            {
                source.StudentGraduationPlanAssociationIndustryCredentials.MapCollectionTo(target.StudentGraduationPlanAssociationIndustryCredentials, target, mappingContract?.IsStudentGraduationPlanAssociationIndustryCredentialIncluded);
            }

            if (mappingContract?.IsStudentGraduationPlanAssociationStudentContactAssociationsSupported != false)
            {
                source.StudentGraduationPlanAssociationStudentContactAssociations.MapCollectionTo(target.StudentGraduationPlanAssociationStudentContactAssociations, target, mappingContract?.IsStudentGraduationPlanAssociationStudentContactAssociationIncluded);
            }

            if (mappingContract?.IsStudentGraduationPlanAssociationYearsAttendedsSupported != false)
            {
                source.StudentGraduationPlanAssociationYearsAttendeds.MapCollectionTo(target.StudentGraduationPlanAssociationYearsAttendeds, target, mappingContract?.IsStudentGraduationPlanAssociationYearsAttendedIncluded);
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
    public static class StudentGraduationPlanAssociationAcademicSubjectMapper
    {
        private static readonly FullName _fullName_sample_StudentGraduationPlanAssociationAcademicSubject = new FullName("sample", "StudentGraduationPlanAssociationAcademicSubject");
    
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationAcademicSubject source, IStudentGraduationPlanAssociationAcademicSubject target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentGraduationPlanAssociationAcademicSubjectMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationAcademicSubject);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentGraduationPlanAssociationAcademicSubject source, IStudentGraduationPlanAssociationAcademicSubject target, Action<IStudentGraduationPlanAssociationAcademicSubject, IStudentGraduationPlanAssociationAcademicSubject> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentGraduationPlanAssociationAcademicSubjectMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationAcademicSubject);
    
            // Copy contextual primary key values
            target.AcademicSubjectDescriptor = source.AcademicSubjectDescriptor;

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

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationCareerPathwayCodeMapper
    {
        private static readonly FullName _fullName_sample_StudentGraduationPlanAssociationCareerPathwayCode = new FullName("sample", "StudentGraduationPlanAssociationCareerPathwayCode");
    
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationCareerPathwayCode source, IStudentGraduationPlanAssociationCareerPathwayCode target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentGraduationPlanAssociationCareerPathwayCodeMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationCareerPathwayCode);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentGraduationPlanAssociationCareerPathwayCode source, IStudentGraduationPlanAssociationCareerPathwayCode target, Action<IStudentGraduationPlanAssociationCareerPathwayCode, IStudentGraduationPlanAssociationCareerPathwayCode> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentGraduationPlanAssociationCareerPathwayCodeMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationCareerPathwayCode);
    
            // Copy contextual primary key values
            target.CareerPathwayCode = source.CareerPathwayCode;

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

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationCTEProgramMapper
    {
        private static readonly FullName _fullName_sample_StudentGraduationPlanAssociationCTEProgram = new FullName("sample", "StudentGraduationPlanAssociationCTEProgram");
    
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationCTEProgram source, IStudentGraduationPlanAssociationCTEProgram target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentGraduationPlanAssociationCTEProgramMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationCTEProgram);


            // Copy non-PK properties

            if ((mappingContract?.IsCareerPathwayDescriptorSupported != false)
                && target.CareerPathwayDescriptor != source.CareerPathwayDescriptor)
            {
                target.CareerPathwayDescriptor = source.CareerPathwayDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsCIPCodeSupported != false)
                && target.CIPCode != source.CIPCode)
            {
                target.CIPCode = source.CIPCode;
                isModified = true;
            }

            if ((mappingContract?.IsCTEProgramCompletionIndicatorSupported != false)
                && target.CTEProgramCompletionIndicator != source.CTEProgramCompletionIndicator)
            {
                target.CTEProgramCompletionIndicator = source.CTEProgramCompletionIndicator;
                isModified = true;
            }

            if ((mappingContract?.IsPrimaryCTEProgramIndicatorSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentGraduationPlanAssociationCTEProgramMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationCTEProgram);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsCareerPathwayDescriptorSupported != false)
                target.CareerPathwayDescriptor = source.CareerPathwayDescriptor;

            if (mappingContract?.IsCIPCodeSupported != false)
                target.CIPCode = source.CIPCode;

            if (mappingContract?.IsCTEProgramCompletionIndicatorSupported != false)
                target.CTEProgramCompletionIndicator = source.CTEProgramCompletionIndicator;

            if (mappingContract?.IsPrimaryCTEProgramIndicatorSupported != false)
                target.PrimaryCTEProgramIndicator = source.PrimaryCTEProgramIndicator;

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
    public static class StudentGraduationPlanAssociationDescriptionMapper
    {
        private static readonly FullName _fullName_sample_StudentGraduationPlanAssociationDescription = new FullName("sample", "StudentGraduationPlanAssociationDescription");
    
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationDescription source, IStudentGraduationPlanAssociationDescription target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentGraduationPlanAssociationDescriptionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationDescription);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentGraduationPlanAssociationDescription source, IStudentGraduationPlanAssociationDescription target, Action<IStudentGraduationPlanAssociationDescription, IStudentGraduationPlanAssociationDescription> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentGraduationPlanAssociationDescriptionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationDescription);
    
            // Copy contextual primary key values
            target.Description = source.Description;

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

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationDesignatedByMapper
    {
        private static readonly FullName _fullName_sample_StudentGraduationPlanAssociationDesignatedBy = new FullName("sample", "StudentGraduationPlanAssociationDesignatedBy");
    
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationDesignatedBy source, IStudentGraduationPlanAssociationDesignatedBy target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentGraduationPlanAssociationDesignatedByMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationDesignatedBy);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentGraduationPlanAssociationDesignatedBy source, IStudentGraduationPlanAssociationDesignatedBy target, Action<IStudentGraduationPlanAssociationDesignatedBy, IStudentGraduationPlanAssociationDesignatedBy> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentGraduationPlanAssociationDesignatedByMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationDesignatedBy);
    
            // Copy contextual primary key values
            target.DesignatedBy = source.DesignatedBy;

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

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationIndustryCredentialMapper
    {
        private static readonly FullName _fullName_sample_StudentGraduationPlanAssociationIndustryCredential = new FullName("sample", "StudentGraduationPlanAssociationIndustryCredential");
    
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationIndustryCredential source, IStudentGraduationPlanAssociationIndustryCredential target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentGraduationPlanAssociationIndustryCredentialMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationIndustryCredential);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentGraduationPlanAssociationIndustryCredential source, IStudentGraduationPlanAssociationIndustryCredential target, Action<IStudentGraduationPlanAssociationIndustryCredential, IStudentGraduationPlanAssociationIndustryCredential> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentGraduationPlanAssociationIndustryCredentialMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationIndustryCredential);
    
            // Copy contextual primary key values
            target.IndustryCredential = source.IndustryCredential;

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

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationStudentContactAssociationMapper
    {
        private static readonly FullName _fullName_sample_StudentGraduationPlanAssociationStudentContactAssociation = new FullName("sample", "StudentGraduationPlanAssociationStudentContactAssociation");
    
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationStudentContactAssociation source, IStudentGraduationPlanAssociationStudentContactAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentGraduationPlanAssociationStudentContactAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationStudentContactAssociation);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentGraduationPlanAssociationStudentContactAssociation source, IStudentGraduationPlanAssociationStudentContactAssociation target, Action<IStudentGraduationPlanAssociationStudentContactAssociation, IStudentGraduationPlanAssociationStudentContactAssociation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentGraduationPlanAssociationStudentContactAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationStudentContactAssociation);
    
            // Copy contextual primary key values
            target.ContactUniqueId = source.ContactUniqueId;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.StudentContactAssociationResourceId = source.StudentContactAssociationResourceId;
                target.StudentContactAssociationDiscriminator = source.StudentContactAssociationDiscriminator;
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

    [ExcludeFromCodeCoverage]
    public static class StudentGraduationPlanAssociationYearsAttendedMapper
    {
        private static readonly FullName _fullName_sample_StudentGraduationPlanAssociationYearsAttended = new FullName("sample", "StudentGraduationPlanAssociationYearsAttended");
    
        public static bool SynchronizeTo(this IStudentGraduationPlanAssociationYearsAttended source, IStudentGraduationPlanAssociationYearsAttended target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentGraduationPlanAssociationYearsAttendedMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationYearsAttended);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentGraduationPlanAssociationYearsAttended source, IStudentGraduationPlanAssociationYearsAttended target, Action<IStudentGraduationPlanAssociationYearsAttended, IStudentGraduationPlanAssociationYearsAttended> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentGraduationPlanAssociationYearsAttendedMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociationYearsAttended);
    
            // Copy contextual primary key values
            target.YearsAttended = source.YearsAttended;

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
// Aggregate: StudentSchoolAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentSchoolAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentSchoolAssociationExtensionMapper
    {
        private static readonly FullName _fullName_sample_StudentSchoolAssociationExtension = new FullName("sample", "StudentSchoolAssociationExtension");
    
        public static bool SynchronizeTo(this IStudentSchoolAssociationExtension source, IStudentSchoolAssociationExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentSchoolAssociationExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentSchoolAssociationExtension);


            // Copy non-PK properties

            if ((mappingContract?.IsMembershipTypeDescriptorSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentSchoolAssociationExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentSchoolAssociationExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsMembershipTypeDescriptorSupported != false)
                target.MembershipTypeDescriptor = source.MembershipTypeDescriptor;

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
// Aggregate: StudentSectionAssociation

namespace EdFi.Ods.Entities.Common.Sample //.StudentSectionAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentSectionAssociationExtensionMapper
    {
        private static readonly FullName _fullName_sample_StudentSectionAssociationExtension = new FullName("sample", "StudentSectionAssociationExtension");
    
        public static bool SynchronizeTo(this IStudentSectionAssociationExtension source, IStudentSectionAssociationExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentSectionAssociationExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentSectionAssociationExtension);


            // Copy non-PK properties


            // Sync lists
            if (mappingContract?.IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationsSupported ?? true)
            {
                isModified |=
                    source.StudentSectionAssociationRelatedGeneralStudentProgramAssociations.SynchronizeCollectionTo(
                        target.StudentSectionAssociationRelatedGeneralStudentProgramAssociations,
                        onChildAdded: child =>
                            {
                                child.StudentSectionAssociationExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.StudentSectionAssociation);
                            },
                        includeItem: item => mappingContract?.IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }

        public static void MapTo(this IStudentSectionAssociationExtension source, IStudentSectionAssociationExtension target, Action<IStudentSectionAssociationExtension, IStudentSectionAssociationExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentSectionAssociationExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentSectionAssociationExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationsSupported != false)
            {
                source.StudentSectionAssociationRelatedGeneralStudentProgramAssociations.MapCollectionTo(target.StudentSectionAssociationRelatedGeneralStudentProgramAssociations, target.StudentSectionAssociation, mappingContract?.IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationIncluded);
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
    public static class StudentSectionAssociationRelatedGeneralStudentProgramAssociationMapper
    {
        private static readonly FullName _fullName_sample_StudentSectionAssociationRelatedGeneralStudentProgramAssociation = new FullName("sample", "StudentSectionAssociationRelatedGeneralStudentProgramAssociation");
    
        public static bool SynchronizeTo(this IStudentSectionAssociationRelatedGeneralStudentProgramAssociation source, IStudentSectionAssociationRelatedGeneralStudentProgramAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentSectionAssociationRelatedGeneralStudentProgramAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentSectionAssociationRelatedGeneralStudentProgramAssociation);


            // Copy non-PK properties


            // Sync lists

            return isModified;
        }

        public static void MapTo(this IStudentSectionAssociationRelatedGeneralStudentProgramAssociation source, IStudentSectionAssociationRelatedGeneralStudentProgramAssociation target, Action<IStudentSectionAssociationRelatedGeneralStudentProgramAssociation, IStudentSectionAssociationRelatedGeneralStudentProgramAssociation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentSectionAssociationRelatedGeneralStudentProgramAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentSectionAssociationRelatedGeneralStudentProgramAssociation);
    
            // Copy contextual primary key values
            target.RelatedBeginDate = source.RelatedBeginDate;
            target.RelatedEducationOrganizationId = source.RelatedEducationOrganizationId;
            target.RelatedProgramEducationOrganizationId = source.RelatedProgramEducationOrganizationId;
            target.RelatedProgramName = source.RelatedProgramName;
            target.RelatedProgramTypeDescriptor = source.RelatedProgramTypeDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.RelatedGeneralStudentProgramAssociationResourceId = source.RelatedGeneralStudentProgramAssociationResourceId;
                target.RelatedGeneralStudentProgramAssociationDiscriminator = source.RelatedGeneralStudentProgramAssociationDiscriminator;
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

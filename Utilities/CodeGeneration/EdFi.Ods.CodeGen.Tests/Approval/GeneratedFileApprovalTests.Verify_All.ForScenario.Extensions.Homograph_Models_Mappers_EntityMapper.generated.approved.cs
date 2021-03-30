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
// Aggregate: Name

namespace EdFi.Ods.Entities.Common.Homograph //.NameAggregate
{
    [ExcludeFromCodeCoverage]
    public static class NameMapper
    {
        public static bool SynchronizeTo(this IName source, IName target)
        {
            bool isModified = false;

            var sourceSupport = source as INameSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.FirstName != target.FirstName)
            {
                source.FirstName = target.FirstName;
            }
            if (source.LastSurname != target.LastSurname)
            {
                source.LastSurname = target.LastSurname;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IName source, IName target, Action<IName, IName> onMapped)
        {
            var sourceSynchSupport = source as INameSynchronizationSourceSupport;
            var targetSynchSupport = target as INameSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastSurname;

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
    public interface INameSynchronizationSourceSupport 
    {
    }

}
// Aggregate: Parent

namespace EdFi.Ods.Entities.Common.Homograph //.ParentAggregate
{
    [ExcludeFromCodeCoverage]
    public static class ParentMapper
    {
        public static bool SynchronizeTo(this IParent source, IParent target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.ParentFirstName != target.ParentFirstName)
            {
                source.ParentFirstName = target.ParentFirstName;
            }
            if (source.ParentLastSurname != target.ParentLastSurname)
            {
                source.ParentLastSurname = target.ParentLastSurname;
            }

            // Copy non-PK properties


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsParentAddressesSupported)
            {
                isModified |=
                    source.ParentAddresses.SynchronizeCollectionTo(
                        target.ParentAddresses,
                        onChildAdded: child =>
                            {
                                child.Parent = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsParentAddressIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsParentStudentSchoolAssociationsSupported)
            {
                isModified |=
                    source.ParentStudentSchoolAssociations.SynchronizeCollectionTo(
                        target.ParentStudentSchoolAssociations,
                        onChildAdded: child =>
                            {
                                child.Parent = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsParentStudentSchoolAssociationIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IParent source, IParent target, Action<IParent, IParent> onMapped)
        {
            var sourceSynchSupport = source as IParentSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.ParentFirstName = source.ParentFirstName;
            target.ParentLastSurname = source.ParentLastSurname;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.ParentNameResourceId = source.ParentNameResourceId;
                target.ParentNameDiscriminator = source.ParentNameDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (sourceSynchSupport.IsParentAddressesSupported)
            {
                targetSynchSupport.IsParentAddressIncluded = sourceSynchSupport.IsParentAddressIncluded;
                source.ParentAddresses.MapCollectionTo(target.ParentAddresses, target);
            }
            else
            {
                targetSynchSupport.IsParentAddressesSupported = false;
            }

            if (sourceSynchSupport.IsParentStudentSchoolAssociationsSupported)
            {
                targetSynchSupport.IsParentStudentSchoolAssociationIncluded = sourceSynchSupport.IsParentStudentSchoolAssociationIncluded;
                source.ParentStudentSchoolAssociations.MapCollectionTo(target.ParentStudentSchoolAssociations, target);
            }
            else
            {
                targetSynchSupport.IsParentStudentSchoolAssociationsSupported = false;
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
    public interface IParentSynchronizationSourceSupport 
    {
        bool IsParentAddressesSupported { get; set; }
        bool IsParentStudentSchoolAssociationsSupported { get; set; }
        Func<IParentAddress, bool> IsParentAddressIncluded { get; set; }
        Func<IParentStudentSchoolAssociation, bool> IsParentStudentSchoolAssociationIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class ParentAddressMapper
    {
        public static bool SynchronizeTo(this IParentAddress source, IParentAddress target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentAddressSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.City != target.City)
            {
                source.City = target.City;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IParentAddress source, IParentAddress target, Action<IParentAddress, IParentAddress> onMapped)
        {
            var sourceSynchSupport = source as IParentAddressSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentAddressSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.City = source.City;

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
    public interface IParentAddressSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class ParentStudentSchoolAssociationMapper
    {
        public static bool SynchronizeTo(this IParentStudentSchoolAssociation source, IParentStudentSchoolAssociation target)
        {
            bool isModified = false;

            var sourceSupport = source as IParentStudentSchoolAssociationSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.SchoolName != target.SchoolName)
            {
                source.SchoolName = target.SchoolName;
            }
            if (source.StudentFirstName != target.StudentFirstName)
            {
                source.StudentFirstName = target.StudentFirstName;
            }
            if (source.StudentLastSurname != target.StudentLastSurname)
            {
                source.StudentLastSurname = target.StudentLastSurname;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IParentStudentSchoolAssociation source, IParentStudentSchoolAssociation target, Action<IParentStudentSchoolAssociation, IParentStudentSchoolAssociation> onMapped)
        {
            var sourceSynchSupport = source as IParentStudentSchoolAssociationSynchronizationSourceSupport;
            var targetSynchSupport = target as IParentStudentSchoolAssociationSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.SchoolName = source.SchoolName;
            target.StudentFirstName = source.StudentFirstName;
            target.StudentLastSurname = source.StudentLastSurname;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.StudentSchoolAssociationResourceId = source.StudentSchoolAssociationResourceId;
                target.StudentSchoolAssociationDiscriminator = source.StudentSchoolAssociationDiscriminator;
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
    public interface IParentStudentSchoolAssociationSynchronizationSourceSupport 
    {
    }

}
// Aggregate: School

namespace EdFi.Ods.Entities.Common.Homograph //.SchoolAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SchoolMapper
    {
        public static bool SynchronizeTo(this ISchool source, ISchool target)
        {
            bool isModified = false;

            var sourceSupport = source as ISchoolSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.SchoolName != target.SchoolName)
            {
                source.SchoolName = target.SchoolName;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsSchoolYearSupported)
                && target.SchoolYear != source.SchoolYear)
            {
                target.SchoolYear = source.SchoolYear;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // SchoolAddress
            if (sourceSupport == null || sourceSupport.IsSchoolAddressSupported)
            {
                if (source.SchoolAddress == null)
                {
                    if (target.SchoolAddress != null)
                    {
                        target.SchoolAddress = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.SchoolAddress == null)
                    {
                        var itemType = target.GetType().GetProperty("SchoolAddress").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.SchoolAddress = (ISchoolAddress) newItem;
                    }

                    isModified |= source.SchoolAddress.Synchronize(target.SchoolAddress);
                }
            }

            // -------------------------------------------------------------

            // Sync lists

            return isModified;
        }



        public static void MapTo(this ISchool source, ISchool target, Action<ISchool, ISchool> onMapped)
        {
            var sourceSynchSupport = source as ISchoolSynchronizationSourceSupport;
            var targetSynchSupport = target as ISchoolSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.SchoolName = source.SchoolName;

            // Copy non-PK properties

            if (sourceSynchSupport.IsSchoolYearSupported)
                target.SchoolYear = source.SchoolYear;
            else
                targetSynchSupport.IsSchoolYearSupported = false;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.SchoolYearTypeResourceId = source.SchoolYearTypeResourceId;
                target.SchoolYearTypeDiscriminator = source.SchoolYearTypeDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // SchoolAddress (Source)
            if (sourceSynchSupport.IsSchoolAddressSupported)
            {
                var itemProperty = target.GetType().GetProperty("SchoolAddress");

                if (itemProperty != null)
                {
                    if (source.SchoolAddress == null)
                    {
                        target.SchoolAddress = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetSchoolAddress = Activator.CreateInstance(itemType);
                        (targetSchoolAddress as IChildEntity)?.SetParent(target);
                        source.SchoolAddress.Map(targetSchoolAddress);

                        // Update the target reference appropriately
                        target.SchoolAddress = (ISchoolAddress) targetSchoolAddress;
                    }
                }
            }
            else
            {
                targetSynchSupport.IsSchoolAddressSupported = false;
            }
            // -------------------------------------------------------------

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
    public interface ISchoolSynchronizationSourceSupport 
    {
        bool IsSchoolAddressSupported { get; set; }
        bool IsSchoolYearSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class SchoolAddressMapper
    {
        public static bool SynchronizeTo(this ISchoolAddress source, ISchoolAddress target)
        {
            bool isModified = false;

            var sourceSupport = source as ISchoolAddressSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsCitySupported)
                && target.City != source.City)
            {
                target.City = source.City;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ISchoolAddress source, ISchoolAddress target, Action<ISchoolAddress, ISchoolAddress> onMapped)
        {
            var sourceSynchSupport = source as ISchoolAddressSynchronizationSourceSupport;
            var targetSynchSupport = target as ISchoolAddressSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsCitySupported)
                target.City = source.City;
            else
                targetSynchSupport.IsCitySupported = false;

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
    public interface ISchoolAddressSynchronizationSourceSupport 
    {
        bool IsCitySupported { get; set; }
    }

}
// Aggregate: SchoolYearType

namespace EdFi.Ods.Entities.Common.Homograph //.SchoolYearTypeAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SchoolYearTypeMapper
    {
        public static bool SynchronizeTo(this ISchoolYearType source, ISchoolYearType target)
        {
            bool isModified = false;

            var sourceSupport = source as ISchoolYearTypeSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.SchoolYear != target.SchoolYear)
            {
                source.SchoolYear = target.SchoolYear;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ISchoolYearType source, ISchoolYearType target, Action<ISchoolYearType, ISchoolYearType> onMapped)
        {
            var sourceSynchSupport = source as ISchoolYearTypeSynchronizationSourceSupport;
            var targetSynchSupport = target as ISchoolYearTypeSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.SchoolYear = source.SchoolYear;

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
    public interface ISchoolYearTypeSynchronizationSourceSupport 
    {
    }

}
// Aggregate: Staff

namespace EdFi.Ods.Entities.Common.Homograph //.StaffAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StaffMapper
    {
        public static bool SynchronizeTo(this IStaff source, IStaff target)
        {
            bool isModified = false;

            var sourceSupport = source as IStaffSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.StaffFirstName != target.StaffFirstName)
            {
                source.StaffFirstName = target.StaffFirstName;
            }
            if (source.StaffLastSurname != target.StaffLastSurname)
            {
                source.StaffLastSurname = target.StaffLastSurname;
            }

            // Copy non-PK properties


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsStaffAddressesSupported)
            {
                isModified |=
                    source.StaffAddresses.SynchronizeCollectionTo(
                        target.StaffAddresses,
                        onChildAdded: child =>
                            {
                                child.Staff = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStaffAddressIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsStaffStudentSchoolAssociationsSupported)
            {
                isModified |=
                    source.StaffStudentSchoolAssociations.SynchronizeCollectionTo(
                        target.StaffStudentSchoolAssociations,
                        onChildAdded: child =>
                            {
                                child.Staff = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStaffStudentSchoolAssociationIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IStaff source, IStaff target, Action<IStaff, IStaff> onMapped)
        {
            var sourceSynchSupport = source as IStaffSynchronizationSourceSupport;
            var targetSynchSupport = target as IStaffSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.StaffFirstName = source.StaffFirstName;
            target.StaffLastSurname = source.StaffLastSurname;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.StaffNameResourceId = source.StaffNameResourceId;
                target.StaffNameDiscriminator = source.StaffNameDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (sourceSynchSupport.IsStaffAddressesSupported)
            {
                targetSynchSupport.IsStaffAddressIncluded = sourceSynchSupport.IsStaffAddressIncluded;
                source.StaffAddresses.MapCollectionTo(target.StaffAddresses, target);
            }
            else
            {
                targetSynchSupport.IsStaffAddressesSupported = false;
            }

            if (sourceSynchSupport.IsStaffStudentSchoolAssociationsSupported)
            {
                targetSynchSupport.IsStaffStudentSchoolAssociationIncluded = sourceSynchSupport.IsStaffStudentSchoolAssociationIncluded;
                source.StaffStudentSchoolAssociations.MapCollectionTo(target.StaffStudentSchoolAssociations, target);
            }
            else
            {
                targetSynchSupport.IsStaffStudentSchoolAssociationsSupported = false;
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
    public interface IStaffSynchronizationSourceSupport 
    {
        bool IsStaffAddressesSupported { get; set; }
        bool IsStaffStudentSchoolAssociationsSupported { get; set; }
        Func<IStaffAddress, bool> IsStaffAddressIncluded { get; set; }
        Func<IStaffStudentSchoolAssociation, bool> IsStaffStudentSchoolAssociationIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StaffAddressMapper
    {
        public static bool SynchronizeTo(this IStaffAddress source, IStaffAddress target)
        {
            bool isModified = false;

            var sourceSupport = source as IStaffAddressSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.City != target.City)
            {
                source.City = target.City;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStaffAddress source, IStaffAddress target, Action<IStaffAddress, IStaffAddress> onMapped)
        {
            var sourceSynchSupport = source as IStaffAddressSynchronizationSourceSupport;
            var targetSynchSupport = target as IStaffAddressSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.City = source.City;

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
    public interface IStaffAddressSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class StaffStudentSchoolAssociationMapper
    {
        public static bool SynchronizeTo(this IStaffStudentSchoolAssociation source, IStaffStudentSchoolAssociation target)
        {
            bool isModified = false;

            var sourceSupport = source as IStaffStudentSchoolAssociationSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.SchoolName != target.SchoolName)
            {
                source.SchoolName = target.SchoolName;
            }
            if (source.StudentFirstName != target.StudentFirstName)
            {
                source.StudentFirstName = target.StudentFirstName;
            }
            if (source.StudentLastSurname != target.StudentLastSurname)
            {
                source.StudentLastSurname = target.StudentLastSurname;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStaffStudentSchoolAssociation source, IStaffStudentSchoolAssociation target, Action<IStaffStudentSchoolAssociation, IStaffStudentSchoolAssociation> onMapped)
        {
            var sourceSynchSupport = source as IStaffStudentSchoolAssociationSynchronizationSourceSupport;
            var targetSynchSupport = target as IStaffStudentSchoolAssociationSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.SchoolName = source.SchoolName;
            target.StudentFirstName = source.StudentFirstName;
            target.StudentLastSurname = source.StudentLastSurname;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.StudentSchoolAssociationResourceId = source.StudentSchoolAssociationResourceId;
                target.StudentSchoolAssociationDiscriminator = source.StudentSchoolAssociationDiscriminator;
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
    public interface IStaffStudentSchoolAssociationSynchronizationSourceSupport 
    {
    }

}
// Aggregate: Student

namespace EdFi.Ods.Entities.Common.Homograph //.StudentAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentMapper
    {
        public static bool SynchronizeTo(this IStudent source, IStudent target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.StudentFirstName != target.StudentFirstName)
            {
                source.StudentFirstName = target.StudentFirstName;
            }
            if (source.StudentLastSurname != target.StudentLastSurname)
            {
                source.StudentLastSurname = target.StudentLastSurname;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsSchoolYearSupported)
                && target.SchoolYear != source.SchoolYear)
            {
                target.SchoolYear = source.SchoolYear;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsStudentAddressesSupported)
            {
                isModified |=
                    source.StudentAddresses.SynchronizeCollectionTo(
                        target.StudentAddresses,
                        onChildAdded: child =>
                            {
                                child.Student = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsStudentAddressIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IStudent source, IStudent target, Action<IStudent, IStudent> onMapped)
        {
            var sourceSynchSupport = source as IStudentSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.StudentFirstName = source.StudentFirstName;
            target.StudentLastSurname = source.StudentLastSurname;

            // Copy non-PK properties

            if (sourceSynchSupport.IsSchoolYearSupported)
                target.SchoolYear = source.SchoolYear;
            else
                targetSynchSupport.IsSchoolYearSupported = false;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.SchoolYearTypeResourceId = source.SchoolYearTypeResourceId;
                target.SchoolYearTypeDiscriminator = source.SchoolYearTypeDiscriminator;
                target.StudentNameResourceId = source.StudentNameResourceId;
                target.StudentNameDiscriminator = source.StudentNameDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (sourceSynchSupport.IsStudentAddressesSupported)
            {
                targetSynchSupport.IsStudentAddressIncluded = sourceSynchSupport.IsStudentAddressIncluded;
                source.StudentAddresses.MapCollectionTo(target.StudentAddresses, target);
            }
            else
            {
                targetSynchSupport.IsStudentAddressesSupported = false;
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
    public interface IStudentSynchronizationSourceSupport 
    {
        bool IsSchoolYearSupported { get; set; }
        bool IsStudentAddressesSupported { get; set; }
        Func<IStudentAddress, bool> IsStudentAddressIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class StudentAddressMapper
    {
        public static bool SynchronizeTo(this IStudentAddress source, IStudentAddress target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentAddressSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.City != target.City)
            {
                source.City = target.City;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentAddress source, IStudentAddress target, Action<IStudentAddress, IStudentAddress> onMapped)
        {
            var sourceSynchSupport = source as IStudentAddressSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentAddressSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.City = source.City;

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
    public interface IStudentAddressSynchronizationSourceSupport 
    {
    }

}
// Aggregate: StudentSchoolAssociation

namespace EdFi.Ods.Entities.Common.Homograph //.StudentSchoolAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentSchoolAssociationMapper
    {
        public static bool SynchronizeTo(this IStudentSchoolAssociation source, IStudentSchoolAssociation target)
        {
            bool isModified = false;

            var sourceSupport = source as IStudentSchoolAssociationSynchronizationSourceSupport;

            // Allow PK column updates on StudentSchoolAssociation
            if (
                 (target.SchoolName != source.SchoolName)
                || (target.StudentFirstName != source.StudentFirstName)
                || (target.StudentLastSurname != source.StudentLastSurname))
            {
                isModified = true;

                var sourceWithPrimaryKeyValues = (source as IHasPrimaryKeyValues);

                if (sourceWithPrimaryKeyValues != null)
                {
                    var targetWithNewKeyValues = target as IHasCascadableKeyValues;

                    if (targetWithNewKeyValues != null)
                        targetWithNewKeyValues.NewKeyValues = sourceWithPrimaryKeyValues.GetPrimaryKeyValues();
                }
            }

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.SchoolName != target.SchoolName)
            {
                source.SchoolName = target.SchoolName;
            }
            if (source.StudentFirstName != target.StudentFirstName)
            {
                source.StudentFirstName = target.StudentFirstName;
            }
            if (source.StudentLastSurname != target.StudentLastSurname)
            {
                source.StudentLastSurname = target.StudentLastSurname;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudentSchoolAssociation source, IStudentSchoolAssociation target, Action<IStudentSchoolAssociation, IStudentSchoolAssociation> onMapped)
        {
            var sourceSynchSupport = source as IStudentSchoolAssociationSynchronizationSourceSupport;
            var targetSynchSupport = target as IStudentSchoolAssociationSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.SchoolName = source.SchoolName;
            target.StudentFirstName = source.StudentFirstName;
            target.StudentLastSurname = source.StudentLastSurname;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.SchoolResourceId = source.SchoolResourceId;
                target.SchoolDiscriminator = source.SchoolDiscriminator;
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
    public interface IStudentSchoolAssociationSynchronizationSourceSupport 
    {
    }

}

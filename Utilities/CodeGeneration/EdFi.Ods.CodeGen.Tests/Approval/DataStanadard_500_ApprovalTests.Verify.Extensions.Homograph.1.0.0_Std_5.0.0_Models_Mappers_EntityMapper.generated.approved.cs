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
// Aggregate: Name

namespace EdFi.Ods.Entities.Common.Homograph //.NameAggregate
{
    [ExcludeFromCodeCoverage]
    public static class NameMapper
    {
        private static readonly FullName _fullName_homograph_Name = new FullName("homograph", "Name");
    
        public static bool SynchronizeTo(this IName source, IName target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (NameMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_Name);
            

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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (NameMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_Name);
    
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
// Aggregate: Parent

namespace EdFi.Ods.Entities.Common.Homograph //.ParentAggregate
{
    [ExcludeFromCodeCoverage]
    public static class ParentMapper
    {
        private static readonly FullName _fullName_homograph_Parent = new FullName("homograph", "Parent");
    
        public static bool SynchronizeTo(this IParent source, IParent target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ParentMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_Parent);
            

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
            if (mappingContract?.IsParentAddressesSupported ?? true)
            {
                isModified |=
                    source.ParentAddresses.SynchronizeCollectionTo(
                        target.ParentAddresses,
                        onChildAdded: child =>
                            {
                                child.Parent = target;
                            },
                        includeItem: item => mappingContract?.IsParentAddressIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsParentStudentSchoolAssociationsSupported ?? true)
            {
                isModified |=
                    source.ParentStudentSchoolAssociations.SynchronizeCollectionTo(
                        target.ParentStudentSchoolAssociations,
                        onChildAdded: child =>
                            {
                                child.Parent = target;
                            },
                        includeItem: item => mappingContract?.IsParentStudentSchoolAssociationIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this IParent source, IParent target, Action<IParent, IParent> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ParentMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_Parent);
    
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

            if (mappingContract?.IsParentAddressesSupported != false)
            {
                source.ParentAddresses.MapCollectionTo(target.ParentAddresses, target, mappingContract?.IsParentAddressIncluded);
            }

            if (mappingContract?.IsParentStudentSchoolAssociationsSupported != false)
            {
                source.ParentStudentSchoolAssociations.MapCollectionTo(target.ParentStudentSchoolAssociations, target, mappingContract?.IsParentStudentSchoolAssociationIncluded);
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
    public static class ParentAddressMapper
    {
        private static readonly FullName _fullName_homograph_ParentAddress = new FullName("homograph", "ParentAddress");
    
        public static bool SynchronizeTo(this IParentAddress source, IParentAddress target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ParentAddressMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_ParentAddress);
            

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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ParentAddressMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_ParentAddress);
    
            // Copy contextual primary key values
            target.City = source.City;

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
    public static class ParentStudentSchoolAssociationMapper
    {
        private static readonly FullName _fullName_homograph_ParentStudentSchoolAssociation = new FullName("homograph", "ParentStudentSchoolAssociation");
    
        public static bool SynchronizeTo(this IParentStudentSchoolAssociation source, IParentStudentSchoolAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ParentStudentSchoolAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_ParentStudentSchoolAssociation);
            

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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ParentStudentSchoolAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_ParentStudentSchoolAssociation);
    
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

namespace EdFi.Ods.Entities.Common.Homograph //.SchoolAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SchoolMapper
    {
        private static readonly FullName _fullName_homograph_School = new FullName("homograph", "School");
    
        public static bool SynchronizeTo(this ISchool source, ISchool target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (SchoolMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_School);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.SchoolName != target.SchoolName)
            {
                source.SchoolName = target.SchoolName;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsSchoolYearSupported != false)
                && target.SchoolYear != source.SchoolYear)
            {
                target.SchoolYear = source.SchoolYear;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // SchoolAddress (SchoolAddress)
            if (mappingContract?.IsSchoolAddressSupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (SchoolMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_School);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.SchoolName = source.SchoolName;

            // Copy non-PK properties

            if (mappingContract?.IsSchoolYearSupported != false)
                target.SchoolYear = source.SchoolYear;

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
            // SchoolAddress (SchoolAddress) (Source)
            if (mappingContract?.IsSchoolAddressSupported != false)
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
            // -------------------------------------------------------------

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
    public static class SchoolAddressMapper
    {
        private static readonly FullName _fullName_homograph_SchoolAddress = new FullName("homograph", "SchoolAddress");
    
        public static bool SynchronizeTo(this ISchoolAddress source, ISchoolAddress target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (SchoolAddressMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_SchoolAddress);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((mappingContract?.IsCitySupported != false)
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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (SchoolAddressMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_SchoolAddress);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsCitySupported != false)
                target.City = source.City;

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
// Aggregate: SchoolYearType

namespace EdFi.Ods.Entities.Common.Homograph //.SchoolYearTypeAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SchoolYearTypeMapper
    {
        private static readonly FullName _fullName_homograph_SchoolYearType = new FullName("homograph", "SchoolYearType");
    
        public static bool SynchronizeTo(this ISchoolYearType source, ISchoolYearType target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (SchoolYearTypeMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_SchoolYearType);
            

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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (SchoolYearTypeMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_SchoolYearType);
    
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

namespace EdFi.Ods.Entities.Common.Homograph //.StaffAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StaffMapper
    {
        private static readonly FullName _fullName_homograph_Staff = new FullName("homograph", "Staff");
    
        public static bool SynchronizeTo(this IStaff source, IStaff target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StaffMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_Staff);
            

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
            if (mappingContract?.IsStaffAddressesSupported ?? true)
            {
                isModified |=
                    source.StaffAddresses.SynchronizeCollectionTo(
                        target.StaffAddresses,
                        onChildAdded: child =>
                            {
                                child.Staff = target;
                            },
                        includeItem: item => mappingContract?.IsStaffAddressIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsStaffStudentSchoolAssociationsSupported ?? true)
            {
                isModified |=
                    source.StaffStudentSchoolAssociations.SynchronizeCollectionTo(
                        target.StaffStudentSchoolAssociations,
                        onChildAdded: child =>
                            {
                                child.Staff = target;
                            },
                        includeItem: item => mappingContract?.IsStaffStudentSchoolAssociationIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this IStaff source, IStaff target, Action<IStaff, IStaff> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StaffMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_Staff);
    
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

            if (mappingContract?.IsStaffAddressesSupported != false)
            {
                source.StaffAddresses.MapCollectionTo(target.StaffAddresses, target, mappingContract?.IsStaffAddressIncluded);
            }

            if (mappingContract?.IsStaffStudentSchoolAssociationsSupported != false)
            {
                source.StaffStudentSchoolAssociations.MapCollectionTo(target.StaffStudentSchoolAssociations, target, mappingContract?.IsStaffStudentSchoolAssociationIncluded);
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
    public static class StaffAddressMapper
    {
        private static readonly FullName _fullName_homograph_StaffAddress = new FullName("homograph", "StaffAddress");
    
        public static bool SynchronizeTo(this IStaffAddress source, IStaffAddress target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StaffAddressMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_StaffAddress);
            

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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StaffAddressMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_StaffAddress);
    
            // Copy contextual primary key values
            target.City = source.City;

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
    public static class StaffStudentSchoolAssociationMapper
    {
        private static readonly FullName _fullName_homograph_StaffStudentSchoolAssociation = new FullName("homograph", "StaffStudentSchoolAssociation");
    
        public static bool SynchronizeTo(this IStaffStudentSchoolAssociation source, IStaffStudentSchoolAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StaffStudentSchoolAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_StaffStudentSchoolAssociation);
            

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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StaffStudentSchoolAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_StaffStudentSchoolAssociation);
    
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

namespace EdFi.Ods.Entities.Common.Homograph //.StudentAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentMapper
    {
        private static readonly FullName _fullName_homograph_Student = new FullName("homograph", "Student");
    
        public static bool SynchronizeTo(this IStudent source, IStudent target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_Student);
            

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

            if ((mappingContract?.IsSchoolYearSupported != false)
                && target.SchoolYear != source.SchoolYear)
            {
                target.SchoolYear = source.SchoolYear;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // StudentAddress (StudentAddress)
            if (mappingContract?.IsStudentAddressSupported != false)
            {
                if (source.StudentAddress == null)
                {
                    if (target.StudentAddress != null)
                    {
                        target.StudentAddress = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.StudentAddress == null)
                    {
                        var itemType = target.GetType().GetProperty("StudentAddress").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.StudentAddress = (IStudentAddress) newItem;
                    }

                    isModified |= source.StudentAddress.Synchronize(target.StudentAddress);
                }
            }

            // -------------------------------------------------------------

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStudent source, IStudent target, Action<IStudent, IStudent> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_Student);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.StudentFirstName = source.StudentFirstName;
            target.StudentLastSurname = source.StudentLastSurname;

            // Copy non-PK properties

            if (mappingContract?.IsSchoolYearSupported != false)
                target.SchoolYear = source.SchoolYear;

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
            // StudentAddress (StudentAddress) (Source)
            if (mappingContract?.IsStudentAddressSupported != false)
            {
                var itemProperty = target.GetType().GetProperty("StudentAddress");

                if (itemProperty != null)
                {
                    if (source.StudentAddress == null)
                    {
                        target.StudentAddress = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetStudentAddress = Activator.CreateInstance(itemType);
                        (targetStudentAddress as IChildEntity)?.SetParent(target);
                        source.StudentAddress.Map(targetStudentAddress);

                        // Update the target reference appropriately
                        target.StudentAddress = (IStudentAddress) targetStudentAddress;
                    }
                }
            }
            // -------------------------------------------------------------

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
    public static class StudentAddressMapper
    {
        private static readonly FullName _fullName_homograph_StudentAddress = new FullName("homograph", "StudentAddress");
    
        public static bool SynchronizeTo(this IStudentAddress source, IStudentAddress target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentAddressMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_StudentAddress);
            

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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentAddressMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_StudentAddress);
    
            // Copy contextual primary key values
            target.City = source.City;

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

namespace EdFi.Ods.Entities.Common.Homograph //.StudentSchoolAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class StudentSchoolAssociationMapper
    {
        private static readonly FullName _fullName_homograph_StudentSchoolAssociation = new FullName("homograph", "StudentSchoolAssociation");
    
        public static bool SynchronizeTo(this IStudentSchoolAssociation source, IStudentSchoolAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (StudentSchoolAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_StudentSchoolAssociation);
            

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
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (StudentSchoolAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_homograph_StudentSchoolAssociation);
    
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

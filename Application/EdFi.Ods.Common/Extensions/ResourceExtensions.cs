// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Extensions
{
    public static class ResourceExtensions
    {
        private static readonly ConcurrentDictionary<Resource, IReadOnlyDictionary<string, ResourcePropertyMapping>>
            _resourceOtherPropertyMappingsByResource
                = new ConcurrentDictionary<Resource, IReadOnlyDictionary<string, ResourcePropertyMapping>>(
                    ModelComparers.Resource);

        private static readonly ConcurrentDictionary<Resource, IReadOnlyDictionary<string, ResourcePropertyMapping>>
            _resourceThisPropertyMappingsByResource
                = new ConcurrentDictionary<Resource, IReadOnlyDictionary<string, ResourcePropertyMapping>>(
                    ModelComparers.Resource);

        public static string GetPhysicalNameForLogicalName(this IResourceModel resourceModel, string logicalName)
        {
            return resourceModel.SchemaNameMapProvider
                                .GetSchemaMapByLogicalName(logicalName)
                                .PhysicalName;
        }

        /// <summary>
        /// Check if resource collection is derived from another resource.
        /// </summary>
        /// <param name="collection">Collection object</param>
        /// <param name="resource">Resource object</param>
        /// <returns></returns>
        public static bool IsDerivedFrom(this Collection collection, ResourceClassBase resource)
        {
            return collection.Association.OtherEntity.IncomingAssociations.Any(
                a => (a.OtherEntity.IsBase || a.OtherEntity.IsAbstract)
                     && resource.Entity?.BaseEntity != null
                     && ModelComparers.Entity.Equals(a.OtherEntity, resource.Entity.BaseEntity));
        }

        /// <summary>
        /// Check if property is a unified key
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsUnified(this ResourceProperty property)
        {
            return property?.EntityProperty?.IsUnified ?? false;
        }

        /// <summary>
        /// Contains all the request properties for the resource.
        /// </summary>
        /// <param name="resourceClassBase">Resource object</param>
        /// <returns></returns>
        public static IEnumerable<ResourceProperty> AllRequestProperties(this ResourceClassBase resourceClassBase)
        {
            return resourceClassBase.IsDerived
                ? resourceClassBase.LocalProperties()
                                   .Union(
                                        resourceClassBase.IdentifyingProperties.Where(
                                            x => x.IsIdentifyingAndHasAssociations()),
                                        ModelComparers.ResourcePropertyNameOnly)
                : resourceClassBase.AllProperties;
        }

        /// <summary>
        /// Contains all the locally defined properties for the resource including extension properties.
        /// </summary>
        /// <param name="resourceClassBase">Resource object</param>
        /// <returns></returns>
        public static IEnumerable<ResourceProperty> LocalProperties(this ResourceClassBase resourceClassBase)
        {
            return resourceClassBase.AllProperties
                                    .Where(
                                         x =>
                                             ModelComparers.Entity.Equals(
                                                 resourceClassBase.Entity,
                                                 x.EntityProperty.Entity));
        }

        /// <summary>
        /// Contains all the properties for the resource including a unified key property if one exists.
        /// </summary>
        /// <param name="resourceClassBase">Resource object</param>
        /// <returns></returns>
        public static IEnumerable<ResourceProperty> UnifiedKeyAllProperties(this ResourceClassBase resourceClassBase)
        {
            return resourceClassBase.AllProperties
                                    .Union(
                                         resourceClassBase.IdentifyingProperties
                                                          .Where(x => x.IsUnified()),
                                         ModelComparers.ResourcePropertyNameOnly)
                                    .Where(
                                         p => !resourceClassBase.References
                                                                .SelectMany(r => r.Properties)
                                                                .Select(r => r.PropertyName)
                                                                .Contains(p.PropertyName));
        }

        /// <summary>
        /// Determines if the derived resource collection is actually a type entity
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsDerivedEntityATypeEntity(this Collection collection)
        {
            // this is required to augment the data member name for entities that are derived but their underlying entity is a type entity
            // this is required for template matching
            return collection.Association
                             .OtherEntity
                             .IncomingAssociations
                             .Any(
                                  p =>
                                      p.OtherProperties.Any(
                                          y =>
                                              y.PropertyName.Equals(
                                                  collection.Association.OtherEntity.Name + "TypeId")));
        }

        /// <summary>
        /// Check if resource is a descriptor entity.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static bool IsDescriptorEntity(this ResourceClassBase resource)
        {
            return resource.Entity?.IsDescriptorEntity == true;
        }

        /// <summary>
        /// Check if resource child item is derived from another resource.
        /// </summary>
        /// <param name="resourceChildItem">ResourceChildItem object</param>
        /// <param name="resource">Resource object</param>
        /// <returns></returns>
        public static bool IsDerivedFrom(this ResourceChildItem resourceChildItem, ResourceClassBase resource)
        {
            return resourceChildItem.Entity != null
                   && resourceChildItem.Entity.IncomingAssociations.Any(
                       a => (a.OtherEntity.IsBase || a.OtherEntity.IsAbstract)
                            && resource.Entity != null
                            && resource.Entity.BaseEntity != null
                            && ModelComparers.Entity.Equals(
                                a.OtherEntity,
                                resource.Entity.BaseEntity));
        }

        /// <summary>
        /// Check if resource is a base entity.
        /// </summary>
        /// <param name="resourceClassBase">Resource object</param>
        /// <returns></returns>
        public static bool IsBase(this ResourceClassBase resourceClassBase)
        {
            return resourceClassBase.Entity != null && resourceClassBase.Entity.IsBase;
        }

        /// <summary>
        /// Check if resource is derived from another resource.
        /// </summary>
        /// <param name="resourceClassBase">Resource object</param>
        /// <param name="baseResourceClassBase">Resource object</param>
        /// <returns></returns>
        public static bool IsDerivedFrom(
            this ResourceClassBase resourceClassBase,
            ResourceClassBase baseResourceClassBase)
        {
            return resourceClassBase.Entity != null
                   && resourceClassBase.Entity.IncomingAssociations
                                       .Any(
                                            a => a.AssociationType == AssociationViewType.FromBase
                                                 && ModelComparers.Entity.Equals(
                                                     a.OtherEntity,
                                                     baseResourceClassBase.Entity));
        }

        public static IEnumerable<AssociationView> ResourceReferenceAssociations(this ResourceClassBase resourceClassBase)
            => resourceClassBase.Entity == null
                ? Enumerable.Empty<AssociationView>()
                : resourceClassBase.Entity.NonNavigableParents;

        /// <summary>
        /// Gets the URI segment representation of the associated schema of the resource.
        /// </summary>
        public static string SchemaUriSegment(this Resource resource) => resource
                                                                        .ResourceModel?.SchemaNameMapProvider
                                                                       ?.GetSchemaMapByPhysicalName(resource.FullName.Schema)
                                                                        .UriSegment;

        /// <summary>
        /// Indicates whether the supplied <see cref="ResourceClassBase"/> has a discriminator.
        /// </summary>
        /// <param name="resourceClass">The resource class that is being inspected.</param>
        /// <returns><b>true</b> if the resource class has a discriminator; otherwise <b>false</b>.</returns>
        [Obsolete("This extension method doesn't make sense in the context of a resource that is derived and combines multiple entities. The Discriminator is an Entity-specific concept. Be explicit, and use the Entity's HasDiscriminator extension method instead.")]
        public static bool HasDiscriminator(this ResourceClassBase resourceClass)
        {
            // NOTE: This returns unexpected values for resources that are derived.
            return resourceClass.Entity?.HasDiscriminator() == true;
        }

        /// <summary>
        /// Check if resource is abstract.
        /// </summary>
        /// <param name="resourceClass">Resource object</param>
        /// <returns></returns>
        public static bool IsAbstract(this ResourceClassBase resourceClass) => resourceClass.Entity?.IsAbstract == true;

        /// <summary>
        /// Checks if the property is an inherited property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsInheritedProperty(this ResourceProperty property) => property.Parent.InheritedProperties()
                                                                                          .Contains(property);

        /// <summary>
        /// Finds the inherited properties for a resource
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static IEnumerable<ResourceProperty> InheritedProperties(this ResourceClassBase resource)
        {
            return resource.AllProperties
                           .Where(x => !ModelComparers.Entity.Equals(resource.Entity, x.EntityProperty.Entity));
        }
    }
}

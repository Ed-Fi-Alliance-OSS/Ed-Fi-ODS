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
        /// Contains all the request properties for the resource, including inherited key properties.
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
                                   .Union(
                                        resourceClassBase.InheritedKeyProperties(),
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
        /// Contains all the properties on the resource (excludes properties in references).
        /// </summary>
        /// <param name="resourceClassBase">Resource object</param>
        /// <returns></returns>
        public static IEnumerable<ResourceProperty> NonReferencedProperties(this ResourceClassBase resourceClassBase)
        {
            var properties = resourceClassBase.Properties
                .Where(p => p.IsLocallyDefined || p.IsDirectDescriptorUsage
                    || (p.EntityProperty.IsInheritedIdentifying
                        && (p.EntityProperty.BaseProperty.IsLocallyDefined || p.EntityProperty.BaseProperty.IsDirectDescriptorUsage)));

            return properties;
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

        /// <summary>
        /// Gets the URI segment representation of the associated schema of the resource.
        /// </summary>
        public static string SchemaUriSegment(this Resource resource) => resource
                                                                        .ResourceModel?.SchemaNameMapProvider
                                                                       ?.GetSchemaMapByPhysicalName(resource.FullName.Schema)
                                                                        .UriSegment;

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

        /// <summary>
        /// Finds the inherited key properties for a resource
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static IEnumerable<ResourceProperty> InheritedKeyProperties(this ResourceClassBase resource)
        {
            return resource.AllProperties
                           .Where(x => resource.Entity.InheritedAlternateIdentifiers
                                        .SelectMany(x => x.Properties)
                                        .Contains(x.EntityProperty));
        }
    }
}

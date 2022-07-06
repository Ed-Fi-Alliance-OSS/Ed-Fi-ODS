// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.CodeGen.Extensions
{
    public static class DomainModelExtensions
    {
        /// <summary>
        /// Check if reference is sole contributor of any primary key columns for parent resource.
        /// </summary>
        /// <param name="reference">Reference object</param>
        /// <returns></returns>
        public static bool IsExclusiveForIdentifyingColumns(this Reference reference)
        {
            var primaryKeysInReference = reference.Parent.AllProperties.Where(p => p.IsIdentifying)
                .Intersect(reference.Properties);

            var otherReferences = reference.Parent.References.Except(reference);

            var any = primaryKeysInReference
                .Any(p => otherReferences.All(r => r.Properties.All(rp => !ModelComparers.ResourceProperty.Equals(rp, p))));

            return any;
        }

        /// <summary>
        /// Helper method used to convert an EntityProperty to a ResourceProperty
        /// </summary>
        /// <param name="entityProperty">EntityProperty to convert</param>
        /// <param name="resourceClassBase">Resource object</param>
        /// <returns></returns>
        public static ResourceProperty ToResourceProperty(
            this EntityProperty entityProperty,
            ResourceClassBase resourceClassBase)
        {
            return new ResourceProperty(resourceClassBase, entityProperty);
        }

        /// <summary>
        /// Helper method used to convert an IEnumerable(EntityProperty) to a IEnumerable(ResourceProperty)
        /// </summary>
        /// <param name="entityProperties">IEnumerable of EntityProperties</param>
        /// <param name="resourceClassBase">Resource object</param>
        /// <returns></returns>
        public static IEnumerable<ResourceProperty> ToResourceProperties(
            this IEnumerable<EntityProperty> entityProperties,
            ResourceClassBase resourceClassBase)
        {
            return
                entityProperties
                    .Where(property => ResourceSpecification.IsAllowableResourceProperty(property.PropertyName))
                    .Select(property => property.ToResourceProperty(resourceClassBase));
        }

        /// <summary>
        /// Check if resource is the aggregate root.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static bool IsAggregateRoot(this ResourceClassBase resource)
        {
            return resource.Entity?.IsAggregateRoot == true;
        }

        /// <summary>
        ///     Check if resource is a lookup entity.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static bool IsLookup(this ResourceClassBase resource)
        {
            return resource.Entity?.IsLookup == true;
        }

        /// <summary>
        /// Determines if a property needs to be synchronized.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsSynchronizable(this ResourceProperty property)
        {
            if (property.PropertyName.Equals("Id"))
            {
                return false;
            }

            return !property.IsIdentifying || property.IsDefiningUniqueIdOrUsi();
        }

        /// <summary>
        /// Generates the range attribute property information for decimal and money properties.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string ToRangeAttributeCSharp(this ResourceProperty property)
        {
            //TODO SqlServer specific
            switch (property.EntityProperty.PropertyType.DbType)
            {
                case DbType.Decimal:

                    return string.Format(
                        "[Range(typeof(decimal), \"-{0}.{1}\", \"{0}.{1}\")]",
                        new string(
                            '9',
                            property.EntityProperty.PropertyType.Precision - property.EntityProperty.PropertyType.Scale),
                        new string('9', property.EntityProperty.PropertyType.Scale));

                case DbType.Currency:
                    return "[Range(typeof(decimal), \"-922337203685477.5808\", \"922337203685477.5807\")]";

                default:
                    return null;
            }
        }

        /// <summary>
        /// Get the derived base property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static AssociationView DerivedBaseProperty(this ResourceProperty property)
        {
            return property.EntityProperty
                .IncomingAssociations
                .FirstOrDefault(
                    associationView => associationView.AssociationType == AssociationViewType.FromBase);
        }

        /// <summary>
        /// Checks to see if the property is an USI property or if the property is a person entity
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsPersonOrUsi(this ResourceProperty property)
        {
            return property.Parent.Entity?.IsPersonEntity() == true || UniqueIdSpecification.IsUSI(property.PropertyName);
        }

        /// <summary>
        /// Checks to see if the property is an USI property or a UniqueId, and if the property is a person entity, similar as EntityMapper.IsDefiningUniqueId
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsDefiningUniqueIdOrUsi(this ResourceProperty property)
        {
            return property.Parent.Entity?.IsPersonEntity() == true
                   && (UniqueIdSpecification.IsUniqueId(property.PropertyName)
                       || UniqueIdSpecification.IsUSI(property.PropertyName));
        }

        /// <summary>
        /// Gets the association for a backreferenced entity
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static IEnumerable<AssociationView> ExternalReferenceAssociations(this ResourceClassBase resource)
        {
            // we are looking for inbound aggregate references outside of this entities aggregate
            // this is tied to key unification
            return resource.Entity.IncomingAssociations
                .Where(
                    x =>
                        !x.OtherEntity.IsDescriptorEntity
                        && !resource.Entity.Ancestors.Contains(x.OtherEntity)
                        && x.OtherEntity.IsAggregateRoot);
        }

        /// <summary>
        /// Gets the properties from a backreference entity.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static IEnumerable<ResourceProperty> BackReferencedProperties(this ResourceClassBase resource)
        {
            if (resource.Entity == null)
            {
                return new ResourceProperty[0];
            }

            // a backreference is required when we have a property that is associated to multiple entities.
            // this is tied to unification.
            return resource.Entity.IncomingAssociations
                .SelectMany(
                    x => x.ThisProperties
                        .Select(
                            p => new
                            {
                                p.PropertyName,
                                Association = p
                            }))
                .GroupBy(x => x.PropertyName, y => y.Association)
                .Where(x => x.Count() > 1)
                .SelectMany(x => x.Select(y => new ResourceProperty(resource, y)));
        }

        /// <summary>
        /// Checks if the resource has any back references.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static bool HasBackReferences(this ResourceClassBase resource)
        {
            if (resource.IsDescriptorEntity())
            {
                return false;
            }

            return resource.BackReferencedProperties()
                .Any();
        }

        /// <summary>
        /// Returns the incoming context for the property that can have multiple associations (ie role based)
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static AssociationView Context(this ResourceClassBase resource, ResourceProperty property)
        {
            if (!property.HasAssociations())
            {
                return null;
            }

            return property.EntityProperty
                .IncomingAssociations
                .FirstOrDefault(y => y == resource.Entity.ParentAssociation);
        }

        /// <summary>
        /// Checks if the aggregates are the same for both entities.
        /// </summary>
        /// <param name="thisEntity"></param>
        /// <param name="otherEntity"></param>
        /// <returns></returns>
        public static bool IsSameAggregate(this Entity thisEntity, Entity otherEntity)
        {
            if (thisEntity == null || otherEntity == null)
            {
                return false;
            }

            return ModelComparers.Entity.Equals(thisEntity.Aggregate.AggregateRoot, otherEntity.Aggregate.AggregateRoot);
        }

        /// <summary>
        /// Returns the incoming context for the property that can have multiple associations (ie role based)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static AssociationView Context(this Entity entity, EntityProperty property)
        {
            if (!property.IncomingAssociations.Any())
            {
                return null;
            }

            return property
                .IncomingAssociations
                .FirstOrDefault(y => y == entity.ParentAssociation);
        }

        /// <summary>
        /// Returns the base entity property.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static EntityProperty BaseEntityProperty(this ResourceProperty property)
        {
            return property.Parent.Entity.BaseEntity.Properties.FirstOrDefault(
                x => ModelComparers.EntityPropertyNameOnly.Equals(x, property.EntityProperty));
        }

        public static bool IsAggregateReference(this ResourceClassBase resource)
        {
            return resource.IsAggregateRoot() && !resource.IsDescriptorEntity();
        }

        /// <summary>
        /// Converts surrogate id property names to their publicly visible counterparts.
        /// </summary>
        /// <param name="entityProperty">The property to be evaluated.</param>
        /// <returns>The property name appropriate for use on the model abstraction.</returns>
        public static string GetModelsInterfacePropertyName(this EntityProperty entityProperty)
        {
            if (entityProperty.IsDescriptorUsage)
            {
                return entityProperty.PropertyName.TrimSuffix("Id");
            }

            if (UniqueIdSpecification.IsCoreUSI(entityProperty.PropertyName))
            {
                return UniqueIdSpecification.GetUniqueIdPropertyName(entityProperty.PropertyName);
            }

            return entityProperty.PropertyName;
        }

        public static string GetLookupValuePropertyName(this EntityProperty property)
        {
            if (!property.IsDescriptorUsage)
            {
                throw new ArgumentException(
                    $"Property '{property.PropertyName}' of entity '{property.Entity.Name}' is not a Type or Descriptor lookup property.");
            }

            return property.PropertyName.TrimSuffix("Id");
        }

        public static string GetLookupValueEntityName(this EntityProperty property)
        {
            if (!property.IsDescriptorUsage)
            {
                throw new ArgumentException(
                    string.Format(
                        "Property '{0}' of entity '{1}' is not a Type or Descriptor lookup property.",
                        property.PropertyName,
                        property.Entity.Name));
            }

            return property.DescriptorEntity.Name;
        }

        /// <summary>
        /// Will convert a USI property to a UniqueID format
        /// If the property is not a USI type property, then an exception is thrown.
        /// </summary>
        /// <param name="usiPropertyName"></param>
        /// <returns></returns>
        public static string ConvertToUniqueId(this string usiPropertyName)
        {
            if (!UniqueIdSpecification.IsUSI(usiPropertyName))
            {
                throw new ArgumentException(
                    string.Format(
                        "Supplied property '{0}' is not an USI property.",
                        usiPropertyName));
            }

            return UniqueIdSpecification.GetUniqueIdPropertyName(usiPropertyName);
        }

        /// <summary>
        /// Gets the namespace qualified full name of the NHibernate Query Entity for
        /// the given DomainModel entity.
        /// </summary>
        /// <param name="entity">A domain model entity</param>
        /// <param name="properCaseName">Proper case name associated with entity</param>
        /// <param name="classNameSuffix">And specialized suffix that should be added to the class name based on the caller's context.</param>
        /// <param name="isExtensionContext">Explicitly provided extension context</param>
        /// <returns>Namespace qualified full name of the NHibernate Query Entity</returns>
        public static string EntityForQueryFullName(
            this Entity entity,
            string properCaseName,
            string classNameSuffix = "",
            bool isExtensionContext = false)
        {
            return string.Format(
                "{0}.{1}{2}",
                entity.AggregateQueryNamespace(properCaseName, isExtensionContext),
                entity.IsEntityExtension
                    ? entity.Name
                    : entity.ResolvedEdFiEntityName(),
                classNameSuffix);
        }

        /// <summary>
        /// Provides the NHibernate Query Entity Aggregate namespace for the aggregate of the provided domain entity.
        /// </summary>
        /// <param name="entity">A domain model entity</param>
        /// <param name="properCaseName">Proper case name associated with entity</param>
        /// <param name="isExtensionContext">Explicitly provided extension context</param>
        /// <returns>NHibernate Query Entity Aggregate namespace for the aggregate of the provided domain entity</returns>
        public static string AggregateQueryNamespace(this Entity entity, string properCaseName, bool isExtensionContext = false)
        {
            return
                Namespaces.Entities.NHibernate.QueryModels.GetAggregateNamespace(
                    entity.Aggregate.Name,
                    properCaseName,
                    isExtensionContext,
                    entity.IsExtensionEntity && !entity.IsAggregateExtension);
        }

        /// <summary>
        /// Get the namespace for the entity aggregate, relative to the base namespace.
        /// Default base namespace is <see cref="Namespaces.Entities.BaseNamespace" />.
        /// </summary>
        /// <param name="entity">The entity to use for obtaining the aggregate namespace</param>
        /// <param name="properCaseName">Proper case name associated with entity</param>
        /// <param name="baseNamespace">The base namespace to trim, default is <see cref="Namespaces.Entities.BaseNamespace" /></param>
        /// <param name="isQueryModel">Indicates the aggregate's query namespace should be used.</param>
        /// <param name="isExtensionContext">Explicitly provided extension context</param>
        /// <returns></returns>
        /// <exception cref="Exception">Throws if the Entity's aggregate namespace does not contain the baseNamespace</exception>
        public static string GetRelativeAggregateNamespace(
            this Entity entity,
            string properCaseName,
            string baseNamespace = null,
            bool isQueryModel = false,
            bool isExtensionContext = false)
        {
            baseNamespace = baseNamespace ?? Namespaces.Entities.BaseNamespace;

            string fullNamespace = isQueryModel
                ? entity.AggregateQueryNamespace(properCaseName, isExtensionContext)
                : entity.AggregateNamespace(properCaseName);

            string relativeNamespace;

            if (!fullNamespace.TryTrimPrefix(baseNamespace, out relativeNamespace))
            {
                throw new Exception(
                    string.Format(
                        "'{0}' is not a valid base namespace for determining the relative namespace from '{1}' because it is not present as a prefix.",
                        baseNamespace,
                        fullNamespace));
            }

            return relativeNamespace.TrimStart('.');
        }

        public static string GetRelativeEntityNamespace(
            this Entity entity,
            string properCaseName,
            bool isQueryModel = false,
            bool isExtensionContext = false)
        {
            return entity.GetRelativeAggregateNamespace(
                       properCaseName,
                       Namespaces.Entities.NHibernate.BaseNamespace,
                       isQueryModel,
                       isExtensionContext)
                   + "." + entity.Name;
        }

        /// <summary>
        /// Is this property synchronized to the DB as a part of a write/update
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsSynchronizedProperty(this ResourceProperty property)
        {
            return IsSynchronizedProperty(property.PropertyName);
        }

        private static bool IsSynchronizedProperty(string propertyName)
        {
            return propertyName != "Id"
                   && propertyName != "CreateDate"
                   && propertyName != "LastModifiedDate";
        }

        /// <summary>
        /// Removes the trailing uniquid or usi from the property name.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string RemoveUniqueIdOrUsiFromPropertyName(this ResourceProperty property)
        {
            return UniqueIdSpecification.IsUniqueId(property.PropertyName)
                ? UniqueIdSpecification.RemoveUniqueIdSuffix(property.PropertyName)
                : UniqueIdSpecification.RemoveUsiSuffix(property.PropertyName);
        }

        /// <summary>
        /// Scrubs the string for xml documentation
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ScrubForXmlDocumentation(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            // Remove characters that break xml comments (anything outside of {space} through {tilde})
            return
                Regex.Replace(str, @"[^ -~]", " ")
                    .Replace("\"", "\\\"");
        }

        /// <summary>
        /// Check if resource is EdFi entity.
        /// </summary>
        /// <param name="resourceClassBase">Resource object</param>
        /// <returns></returns>
        public static bool IsEdFiResource(this ResourceClassBase resourceClassBase)
        {
            return resourceClassBase.Entity != null && resourceClassBase.Entity.IsEdFiStandardEntity;
        }

        /// <summary>
        /// Determines if the entity can be extended using extensions.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool IsExtendable(this Entity entity)
        {
            // We want to exclude base concrete classes, descriptors and types from extensions.
            // We can only have extensions on "core" entities.
            return entity.IsEdFiStandardEntity
                   && !entity.IsAbstract
                   && !entity.IsDescriptorEntity;
        }

        /// <summary>
        /// Determines if the entity is a derived, non-abstract base entity that can be extended using extensions
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool IsExtendableDerivedEntityWithConcreteBase(this Entity entity)
        {
            return entity.IsExtendable()
                   && entity.IsDerived
                   && entity.BaseEntity != null
                   && !entity.BaseEntity.IsAbstract;
        }

        /// <summary>
        /// Determines if the resource can be extended using extensions.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static bool IsExtendable(this ResourceClassBase resource)
        {
            return resource.Entity?.IsExtendable() == true;
        }

        public static string GetNamespacePrefix(this ResourceClassBase resource)
        {
            if (resource.ResourceModel == null)
            {
                throw new Exception($"Resource class '{resource.FullName}' doesn't have a ResourceModel assigned.");
            }

            if (resource.ResourceModel.SchemaNameMapProvider == null)
            {
                throw new Exception(
                    $"The resource model for resource '{resource.FullName}' doesn't have a SchemaNameMapProvider assigned.");
            }

            var extensionName = resource.ResourceModel.SchemaNameMapProvider
                .GetSchemaMapByPhysicalName(resource.FullName.Schema)
                .ProperCaseName;

            return $"{Namespaces.Entities.Common.RelativeNamespace}.{extensionName}.";
        }

        /// <summary>
        /// Gets the navigable children of the extended entity that are also aggregate extensions.
        /// </summary>
        /// <param name="entityExtension">The <see cref="Entity" /> that is an entity extension.</param>
        /// <returns>The the navigable children <see cref="AssociationView" /> instances for the supplied entity extension.</returns>
        public static IReadOnlyList<AssociationView> GetEntityExtensionNavigableChildren(this Entity entityExtension)
        {
            if (!entityExtension.IsEntityExtension)
            {
                return new AssociationView[0];
            }

            return entityExtension.EdFiStandardEntity.NavigableChildren
                .Where(av => av.ThisEntity.Schema != av.OtherEntity.Schema)
                .ToList();
        }

        /// <summary>
        /// Gets the navigable one-to-ones of the extended entity that are also aggregate extensions.
        /// </summary>
        /// <param name="entityExtension">The <see cref="Entity" /> that is an entity extension.</param>
        /// <returns>The the navigable children <see cref="AssociationView" /> instances for the supplied entity extension.</returns>
        public static IReadOnlyList<AssociationView> GetEntityExtensionNavigableOneToOnes(this Entity entityExtension)
        {
            if (!entityExtension.IsEntityExtension)
            {
                return new AssociationView[0];
            }

            return entityExtension.EdFiStandardEntity.NavigableOneToOnes
                .Where(av => av.ThisEntity.Schema != av.OtherEntity.Schema)
                .ToList();
        }

        /// <summary>
        /// Gets the name, by convention, that would be used for an entity extension of the entity.
        /// </summary>
        /// <param name="entity">The Entity whose entity extension class name is to be constructed, by convention.</param>
        /// <returns>The entity extension class name.</returns>
        public static string GetExtensionClassName(this Entity entity)
        {
            return ExtensionsConventions.GetExtensionClassName(entity.Name);
        }

        /// <summary>
        /// Indicates whether the supplied resource class was inherited as a child member of the resource root class' base class.
        /// </summary>
        /// <param name="resourceClass"></param>
        /// <returns></returns>
        public static bool IsInheritedChildItem(this ResourceClassBase resourceClass)
        {
            return (resourceClass as ResourceChildItem)?.IsInheritedChildItem == true;
        }
    }
}

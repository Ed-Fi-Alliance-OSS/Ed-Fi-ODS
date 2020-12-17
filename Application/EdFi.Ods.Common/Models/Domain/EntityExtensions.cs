// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Models.Domain
{
    public static class EntityExtensions
    {
        private static string[] PredefinedProperties =
        {
            "Id",
            "CreateDate",
            "LastModifiedDate"
        };

        /// <summary>
        /// Returns the core name of the domain model entity if it is a core entity extension, otherwise the entity name.
        /// </summary>
        /// <param name="entity">A domain model entity</param>
        /// <returns>The core name of the domain model entity if it is a core entity extension, otherwise the entity name.</returns>
        public static string ResolvedEdFiEntityName(this Entity entity)
        {
            return entity.ResolvedEdFiEntity()
                         .Name;
        }

        /// <summary>
        /// Returns the core name of the domain model entity if it is a core entity extension, otherwise the entity.
        /// </summary>
        /// <param name="entity">A domain model entity</param>
        /// <returns>The core domain model entity if it is a core entity extension, otherwise the entity.</returns>
        public static Entity ResolvedEdFiEntity(this Entity entity)
        {
            return entity.EdFiStandardEntity ?? entity;
        }

        /// <summary>
        /// Returns the entity's schema name represented in proper-case form.
        /// </summary>
        /// <param name="entity">The Entity to be evaluated.</param>
        /// <returns>The proper-case representation of the entity's schema.</returns>
        public static string SchemaProperCaseName(this Entity entity)
        {
            return entity.DomainModel.SchemaNameMapProvider
                         .GetSchemaMapByPhysicalName(entity.Schema)
                         .ProperCaseName;
        }

        /// <summary>
        /// Gets the URI segment representation of an aggregate root entity's schema.
        /// </summary>
        /// <param name="entity">The aggregate root <see cref="Entity" /> whose URI segment schema name is to be obtained.</param>
        /// <returns>The URI segment representation of the schema.</returns>
        public static string SchemaUriSegment(this Entity entity)
        {
            if (!entity.IsAggregateRoot)
            {
                throw new Exception("URI segments are only applicable to aggregate root entities.");
            }

            return entity.DomainModel.SchemaNameMapProvider
                         .GetSchemaMapByPhysicalName(entity.Schema)
                         .UriSegment;
        }

        /// <summary>
        /// Gets the namespace qualified full name of the NHibernate Entity for
        /// the given DomainModel entity.
        /// </summary>
        /// <param name="entity">A domain model entity</param>
        /// <param name="properCaseName">Proper case name associated with entity</param>
        /// <param name="classNameSuffix">And specialized suffix that should be added to the class name based on the caller's context.</param>
        /// <returns>Namespace qualified full name of the NHibernate Entity</returns>
        public static string EntityTypeFullName(this Entity entity, string properCaseName, string classNameSuffix = "")
        {
            return String.Format(
                "{0}.{1}{2}",
                AggregateNamespace(entity, properCaseName),
                entity.IsEntityExtension
                    ? entity.Name
                    : entity.ResolvedEdFiEntityName(),
                classNameSuffix);
        }

        /// <summary>
        /// Provides the NHibernate Entity Aggregate namespace for the aggregate of the provided domain entity.
        /// </summary>
        /// <param name="entity">A domain model entity</param>
        /// <param name="properCaseName">Proper case name associated with entity</param>
        /// <returns>NHibernate Entity Aggregate namespace for the aggregate of the provided domain entity</returns>
        public static string AggregateNamespace(this Entity entity, string properCaseName)
        {
            return Namespaces.Entities.NHibernate.GetAggregateNamespace(
                entity.Aggregate.Name,
                properCaseName,
                entity.IsExtensionEntity);
        }

        /// <summary>
        /// Provides the complete list of extensions for the provided entity.
        /// </summary>
        /// <param name="entity">A domain model entity</param>
        /// <returns>Complete list of extensions for the provided entity.</returns>
        public static IEnumerable<Entity> GetAllExtensions(this Entity entity) => entity.Extensions
                                                                                        .Concat(
                                                                                             entity.AggregateExtensionChildren.Select(
                                                                                                 a => a.OtherEntity))
                                                                                        .Concat(
                                                                                             entity.AggregateExtensionOneToOnes.Select(
                                                                                                 a => a.OtherEntity));

        /// <summary>
        /// Check if entity is abstract and requires no composite id
        /// </summary>
        /// <remarks>
        /// Classes with composite ids must not be abstract because
        /// "...a persistent object is its own identifier. There is no convenient "handle" other than the object itself.
        /// You must instantiate an instance of the persistent class itself and populate its identifier properties..."
        /// "NHibernate - Relational Persistence for Idiomatic .NET", http://nhibernate.info/doc/nh/en/index.html#mapping-declaration-compositeid
        /// </remarks>
        /// <param name="entity">A domain model entity</param>
        /// <returns></returns>
        public static bool IsAbstractRequiringNoCompositeId(this Entity entity) => entity.IsAbstract && entity.Identifier.Properties.Count == 1;

        /// <summary>
        /// Checks if the entity is a descriptor
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool IsDescriptorBaseEntity(this Entity entity)
            => entity.FullName.Equals(new FullName(EdFiConventions.PhysicalSchemaName, "Descriptor"));

        public static bool IsEducationOrganizationBaseEntity(this Entity entity)
            => entity.FullName.Equals(new FullName(EdFiConventions.PhysicalSchemaName, "EducationOrganization"));

        public static bool IsEducationOrganizationDerivedEntity(this Entity entity)
            => entity.BaseEntity?.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "EducationOrganization");

        /// <summary>
        /// Indicates whether the supplied <see cref="Entity"/> has a discriminator.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> that is being inspected.</param>
        /// <returns><b>true</b> if the type has a discriminator; otherwise <b>false</b>.</returns>
        public static bool HasDiscriminator(this Entity entity)
        {
            // Non-aggregate root entities do not have discriminators (they cannot be derived)
            if (!entity.IsAggregateRoot)
                return false;

            // The discriminator will always be on the root of the type hierarchy (derived classes will not have a discriminator)
            if (entity.IsDerived)
                return false;

            // Ed-Fi descriptors cannot be derived
            if (entity.IsDescriptorBaseEntity())
                return false;

            // SchoolYearType is also not derivable
            if (entity.FullName.Equals(new FullName(EdFiConventions.PhysicalSchemaName, "SchoolYearType")))
                return false;

            return true;
        }

        /// <summary>
        /// Indicates whether the specified entity can be the target of a reference in the API resource models.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool IsReferenceable(this Entity entity)
        {
            // Only aggregate roots can be referenced
            if (!entity.IsAggregateRoot)
                return false;

            // Descriptors cannot be referenced (they are referenced in the API using URI values)
            if (entity.IsDescriptorEntity || entity.IsDescriptorBaseEntity())
                return false;

            return true;
        }

        /// <summary>
        /// Gets the associations that reference other aggregate roots (excluding descriptors).
        /// </summary>
        /// <param name="entity">The entity whose associations are to be evaluated.</param>
        /// <param name="includeInherited">Indicates whether to include associations that are inherited from the base type.</param>
        /// <returns>The <see cref="AssociationView"/> instances that reference other aggregate roots.</returns>
        public static IEnumerable<AssociationView> GetAssociationsToReferenceableAggregateRoots(
            this Entity entity,
            bool includeInherited = false)
        {
            return entity
                  .NonNavigableParents
                  .Concat(
                       includeInherited
                           ? entity.InheritedNonNavigableParents
                           : Enumerable.Empty<AssociationView>())
                  .Where(a => a.OtherEntity.IsReferenceable());
        }

        /// <summary>
        /// Determines if a entityProperty is defined in the AggregateRootWithCompositeKey base class
        /// </summary>
        /// <param name="entityProperty"></param>
        /// <returns></returns>
        public static bool IsAlreadyDefinedInCSharpEntityBaseClasses(this EntityProperty entityProperty)
            => entityProperty.PropertyName.EqualsIgnoreCase("Id")
                || entityProperty.PropertyName.EqualsIgnoreCase("CreateDate")
                || entityProperty.PropertyName.EqualsIgnoreCase("LastModifiedDate");

        /// <summary>
        /// Returns if these properties are predefined in the base class.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsPredefinedProperty(this EntityProperty property)
            => IsPredefinedProperty(property.PropertyName);

        public static bool IsPredefinedProperty(string propertyName)
            => PredefinedProperties.Contains(propertyName);

        /// <summary>
        /// Generates the column name for a property
        /// </summary>
        /// <param name="property"></param>
        /// <param name="databaseEngine"></param>
        /// <param name="legacyColumnName"></param>
        /// <returns></returns>
        public static string ColumnName(this EntityProperty property, DatabaseEngine databaseEngine, string legacyColumnName)
        {
            return property.ColumnNameByDatabaseEngine == null || property.ColumnNameByDatabaseEngine.Count == 0
                ? legacyColumnName
                : property.ColumnNameByDatabaseEngine.TryGetValue(databaseEngine, out string columnName)
                    ? columnName
                    : legacyColumnName;
        }

        /// <summary>
        /// Gets the database-specific table name for the entity.
        /// </summary>
        /// <param name="entity">The entity for which to obtain the physical table name.</param>
        /// <param name="databaseEngine">The key representing the database engine.</param>
        /// <param name="explicitTableName">Explicit name to use instead of the <see cref="Entity.Name" /> property if no
        /// entry is found for the specified database engine.</param>
        /// <returns></returns>
        public static string TableName(this Entity entity, DatabaseEngine databaseEngine, string explicitTableName = null)
        {
            return entity.TableNameByDatabaseEngine == null || entity.TableNameByDatabaseEngine.Count == 0
                ? explicitTableName ?? entity.Name
                : entity.TableNameByDatabaseEngine.TryGetValue(databaseEngine, out string tableName)
                    ? tableName
                    : explicitTableName ?? entity.Name;
        }
    }
}

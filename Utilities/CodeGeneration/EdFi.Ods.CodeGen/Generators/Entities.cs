// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.CodeGen.Generators
{
    public class Entities : GeneratorBase
    {
        private static readonly object _notRendered = null;

        private Func<Entity, bool> _shouldRenderEntityForSchema;

        protected override void Configure()
        {
            _shouldRenderEntityForSchema = TemplateContext.ShouldRenderEntity;
        }

        protected override object Build()
        {
            var domainModel = TemplateContext.DomainModelProvider.GetDomainModel();

            var orderedAggregates =
                domainModel.Aggregates
                           .Where(
                                a => a.Members.Any(
                                    e =>
                                        _shouldRenderEntityForSchema(e)
                                        || e.Extensions.Any(ex => _shouldRenderEntityForSchema(ex))))
                           .OrderBy(x => x.FullName.Name)
                           .ToList();

            return
                new
                {
                    Aggregates =
                        orderedAggregates
                           .Select(
                                aggregate => new
                                             {
                                                 AggregateName = aggregate.Name, AggregateNamespace =
                                                     aggregate.AggregateRoot.AggregateNamespace(TemplateContext.SchemaProperCaseName),
                                                 Classes = aggregate.Members
                                                                    .Where(entity => _shouldRenderEntityForSchema(entity))

                                                                     // Add the explicit entity extensions
                                                                    .Concat(
                                                                         aggregate.Members
                                                                                  .SelectMany(m => m.Extensions)
                                                                                  .Where(ex => _shouldRenderEntityForSchema(ex)))
                                                                    .SelectMany(entity => GetClasses(aggregate, entity))

                                                                     // Add the implicit entity extensions
                                                                    .Concat(
                                                                         aggregate.Members
                                                                                  .Where(RequiresImplicitExtension)
                                                                                  .Select(e => GetImplicitExtension(aggregate, e))),
                                                 HasDiscriminator = aggregate.AggregateRoot.HasDiscriminator()
                                             }),
                    TemplateContext.SchemaProperCaseName, HasExtensionDerivedFromEdFiBaseEntity = orderedAggregates
                                                                                                 .SelectMany(a => a.Members)
                                                                                                 .Any(
                                                                                                      m => !m.IsEdFiStandardEntity && m.IsDerived &&
                                                                                                           m.BaseEntity.IsEdFiStandardEntity)
                };
        }

        private bool RequiresImplicitExtension(Entity entity)
        {
            var result =

                // No explicit entity extension defined
                !entity.Extensions.Any(e => _shouldRenderEntityForSchema(e))

                // ... but the entity has aggregate extensions
                && entity.AggregateExtensionChildren
                         .Concat(entity.AggregateExtensionOneToOnes)
                         .Any(a => _shouldRenderEntityForSchema(a.OtherEntity));

            return result;
        }

        private object GetImplicitExtension(Aggregate aggregate, Entity entity)
        {
            string parentSchemaProperCaseName = entity.DomainModel
                                                      .SchemaNameMapProvider.GetSchemaMapByPhysicalName(entity.Schema)
                                                      .ProperCaseName;

            return new
                   {
                       IsImplicitExtension = true, ClassName = entity.GetExtensionClassName(),
                       EntityParentFieldName = "_" + entity.Name.ToCamelCase(), EntityParentClassNamespacePrefix = parentSchemaProperCaseName + ".",
                       EntityParentClassName = entity.Name, ModelParentClassName = entity.Name, PrimaryKey = new
                                                                                                             {
                                                                                                                 ParentReference = new
                                                                                                                                   {
                                                                                                                                       ModelParentInterfaceNamespacePrefix
                                                                                                                                           = $"Common.{parentSchemaProperCaseName}.",
                                                                                                                                       ModelParentInterfaceName
                                                                                                                                           = "I" +
                                                                                                                                             entity
                                                                                                                                                .Name
                                                                                                                                   }
                                                                                                             },
                       OneToOnes = entity.AggregateExtensionOneToOnes
                                         .Where(a => _shouldRenderEntityForSchema(a.OtherEntity))
                                         .Select(
                                              a => new
                                                   {
                                                       OtherClassName = a.OtherEntity.Name, OtherClassPluralName = a.OtherEntity.PluralName
                                                   }),
                       NavigableChildren = entity.NavigableChildren
                                                 .Where(a => _shouldRenderEntityForSchema(a.OtherEntity))
                                                 .Select(
                                                      a => new
                                                           {
                                                               ChildClassName = a.OtherEntity.Name, ChildCollectionPropertyName = a.Name,
                                                               ChildCollectionFieldName = "_" + a.Name.ToCamelCase(),
                                                               AggregateExtensionBagName = a.GetAggregateExtensionBagName()
                                                           }),
                       SynchronizationSupport = new
                                                {
                                                    Properties = entity.AggregateExtensionOneToOnes
                                                                       .Concat(entity.AggregateExtensionChildren)
                                                                       .Where(a => _shouldRenderEntityForSchema(a.OtherEntity))
                                                                       .Select(
                                                                            a => new
                                                                                 {
                                                                                     PropertyName = a.Name
                                                                                 }),
                                                    CollectionClasses = entity.AggregateExtensionChildren
                                                                              .Where(a => _shouldRenderEntityForSchema(a.OtherEntity))
                                                                              .Select(
                                                                                   a => new
                                                                                        {
                                                                                            ChildCollectionRoleName = a.RoleName,
                                                                                            ChildCollectionClassName = a.OtherEntity.Name,
                                                                                            ChildCollectionPropertyName = a.Name
                                                                                        })
                                                }
                   };
        }

        private IEnumerable<object> GetClasses(Aggregate aggregate, Entity entity)
        {
            var contexts = GetClassContexts(entity);

            var schemaNameMapProvider = entity.DomainModel.SchemaNameMapProvider;

            string properCaseSchemaName = schemaNameMapProvider.GetSchemaMapByPhysicalName(entity.Schema)
                                                               .ProperCaseName;

            foreach (var context in contexts)
            {
                yield return
                    new
                    {
                        NamespacePrefix = GetCommonRelativeNamespacePrefix(entity),
                        RecordNamespacePrefix = GetRecordsRelativeNamespacePrefix(entity),
                        AggregateName = aggregate.Name, ClassName = entity.Name, ReferenceDataClassName = entity.Name + "ReferenceData",
                        HasReferenceDataClass = entity.IsReferenceable() && entity.TypeHierarchyRootEntity == entity, TableName = entity.Name,
                        SchemaName = entity.Schema, entity.IsAggregateRoot, IsAbstract = entity.IsAbstractRequiringNoCompositeId(), entity.IsDerived,
                        IsDescriptor = entity.IsDescriptorEntity, context.IsConcreteEntityBaseClass, context.IsConcreteEntityChildClassForBase,
                        IsDerivedExtensionEntityOfConcreteBase =
                            entity.IsDerived && !entity.BaseEntity.IsAbstractRequiringNoCompositeId() && entity.IsExtensionEntity,
                        HasAlternateKeyValues = entity.Name == "Descriptor", // Legacy template semantics used here
                        AllowsPrimaryKeyUpdates = entity.Identifier.IsUpdatable, BaseAggregateRootRelativeNamespace = entity.IsDerived
                            ? entity.BaseEntity.GetRelativeEntityNamespace(
                                  entity.BaseEntity.SchemaProperCaseName(),
                                  isExtensionContext: !entity.BaseEntity.IsEdFiStandardEntity)
                              + (!entity.BaseEntity.IsAbstract
                                  ? "Base"
                                  : string.Empty)
                            : _notRendered,
                        Constructor = !entity.IsDescriptorEntity
                            ? new
                              {
                                  UnderlyingClassName = entity.Name, TableName = entity.Name, ContextualClassName =
                                      entity.Name + (context.IsConcreteEntityBaseClass
                                          ? "Base"
                                          : string.Empty),
                                  HasParent = entity.ParentAssociation != null, context.IsConcreteEntityBaseClass, EmbeddedObjects = entity
                                                                                                                                    .NavigableOneToOnes

                                                                                                                                     // Don't render explicit objects for associations to other schemas
                                                                                                                                    .Where(
                                                                                                                                         a => a.ThisEntity
                                                                                                                                               .Schema ==
                                                                                                                                              a.OtherEntity
                                                                                                                                               .Schema)
                                                                                                                                    .Select(
                                                                                                                                         a => new
                                                                                                                                              {
                                                                                                                                                  a.OtherEntity
                                                                                                                                                   .Name,
                                                                                                                                                  EmbeddedObjectPropertyName
                                                                                                                                                      =
                                                                                                                                                      a.OtherEntity
                                                                                                                                                       .Name +
                                                                                                                                                      SystemConventions
                                                                                                                                                         .OneToOneEntityPropertyNameSuffix
                                                                                                                                              }),
                                  Collections = entity.NavigableChildren

                                                       // Don't render explicit objects for associations to other schemas
                                                      .Where(a => a.ThisEntity.Schema == a.OtherEntity.Schema)
                                                      .Select(
                                                           a => new
                                                                {
                                                                    CollectionName = a.Name,
                                                                    ContextualCollectionItemName = a.OtherEntity.Name
                                                                                                                            + (context
                                                                                                                               .IsConcreteEntityBaseClass
                                                                                                                                ? "ForBase"
                                                                                                                                : string.Empty)
                                                                })
                              }
                            : _notRendered,
                        PrimaryKey = new
                                     {
                                         ParentReference = !entity.IsAggregateRoot
                                             ? new
                                               {
                                                   IsAggregateExtension = entity.IsAggregateExtensionTopLevelEntity, SchemaProperCaseName = entity.SchemaProperCaseName(),
                                                   ModelParentClassName = GetModelParentClassName(entity), ClassName = entity.Name,
                                                   ModelParentInterfaceNamespacePrefix = GetModelParentInterfaceNamespacePrefix(entity),
                                                   ModelParentInterfaceName = GetModelParentInterfaceName(entity),
                                                   ParentRecordInterfaceName = GetParentRecordInterfaceName(entity), ContextualSuffix =
                                                       context.IsConcreteEntityChildClassForBase
                                                           ? "Base"
                                                           : string.Empty,
                                                   RecordProperties = entity.ParentAssociation.PropertyMappings.Select(
                                                       pm => new
                                                             {
                                                                 CSharpType = pm.ThisProperty.PropertyType.ToCSharp(
                                                                     includeNullability: true),
                                                                 ClassName = entity.Name, pm.ThisProperty.PropertyName,
                                                                 ParentClassName =
                                                                     entity.ParentAssociation.OtherEntity.Name,
                                                                 ParentPropertyName = pm.OtherProperty.PropertyName
                                                             })
                                               }
                                             : _notRendered,
                                         NonParentProperties =
                                             entity
                                                .Identifier
                                                .Properties
                                                .Where(p => !p.IsFromParent)
                                                .Select(
                                                     p => new
                                                          {
                                                              entity.IsAbstract, DisplayName =
                                                                  !entity.IsAbstract && UniqueIdSpecification.IsUSI(p.PropertyName)
                                                                      ? p.PropertyName.ConvertToUniqueId()
                                                                      : _notRendered,
                                                              NeedsOverride = entity.IsDerived && !p.IsInheritedIdentifyingRenamed,
                                                              CSharpDeclaredType = p.PropertyType.ToCSharp(includeNullability: true),
                                                              CSharpBaseType = p.PropertyType.ToCSharp(),
                                                              CSharpSafePropertyName = p.PropertyName.MakeSafeForCSharpClass(entity.Name),
                                                              IsRequiredWithNonDefault = !p.PropertyType.IsNullable
                                                                                         && !p.IsServerAssigned
                                                                                         && !CSharpDefaultHasDomainMeaning(p),
                                                              ValidationReferenceName = UniqueIdSpecification.IsUSI(p.PropertyName)
                                                                  ? UniqueIdSpecification.GetUSIPersonType(p.PropertyName)
                                                                  : _notRendered,
                                                              IsDateTime = IsDateTimeProperty(p), IsString = p.PropertyType.ToCSharp() == "string",
                                                              NoWhitespaceEnforced = p.PropertyType.ToCSharp() == "string", p.PropertyType.MaxLength,
                                                              IsStandardProperty = !(p.IsLookup
                                                                                     || UniqueIdSpecification.IsUSI(p.PropertyName)
                                                                                     || IsUniqueIdPropertyOnPersonEntity(entity, p)
                                                                                     || IsNonDerivedDateProperty(entity, p)
                                                                                     || IsDateTimeProperty(p)
                                                                                     || IsDelegatedToBaseProperty(entity, p)),
                                                              PropertyAccessors = GetPropertyAccessors(entity, p)
                                                          })
                                     },
                        InheritedProperties = entity.IsDerived
                            ? entity.BaseEntity.NonIdentifyingProperties
                                    .Where(p => !p.IsAlreadyDefinedInCSharpEntityBaseClasses())
                                    .OrderBy(p => p.PropertyName)
                                    .Select(
                                         p => new
                                              {
                                                  BaseClassName = entity.BaseEntity.Name, PropertyName = p.IsLookup
                                                      ? p.GetLookupValuePropertyName()
                                                      : p.PropertyName,
                                                  CSharpType = p.IsLookup
                                                      ? "string"
                                                      : p.PropertyType.ToCSharp(includeNullability: true)
                                              })
                            : _notRendered,
                        Properties = entity
                                    .NonIdentifyingProperties
                                    .Where(p => !p.IsAlreadyDefinedInCSharpEntityBaseClasses())
                                    .OrderBy(p => p.PropertyName)
                                    .Select(
                                         p => new
                                              {
                                                  CSharpDeclaredType = p.PropertyType.ToCSharp(includeNullability: true), p.PropertyName,
                                                  CSharpSafePropertyName = p.PropertyName.MakeSafeForCSharpClass(entity.Name), Attributes =
                                                      string.Join(
                                                          ", ",
                                                          (!p.PropertyType.IsNullable && !CSharpDefaultHasDomainMeaning(p)
                                                              ? new[]
                                                                {
                                                                    "RequiredWithNonDefault"
                                                                }
                                                              : new string[0])
                                                         .Concat(
                                                              p.PropertyType.ToCSharp() == "DateTime"
                                                                  ? new[]
                                                                    {
                                                                        "SqlServerDateTimeRange"
                                                                    }
                                                                  : new string[0])
                                                         .Concat(
                                                              p.PropertyType.ToCSharp() == "string"
                                                                  ? new[]
                                                                    {
                                                                        "StringLength(" + p.PropertyType.MaxLength + ")", "NoDangerousText"
                                                                    }
                                                                  : new string[0])
                                                         .Concat(
                                                              IsUniqueIdPropertyOnPersonEntity(entity, p)
                                                                  ? new[]
                                                                    {
                                                                        "NoWhitespace"
                                                                    }
                                                                  : new string[0]
                                                          )),
                                                  RangeAttribute = PropertyHasPrecisionAndScale(p)
                                                      ? new
                                                        {
                                                            CSharpBaseType = p.PropertyType.ToCSharp(), MinimumRangeValue =
                                                                "-".PadRight(p.PropertyType.Precision - p.PropertyType.Scale + 1, '9')
                                                                + ".".PadRight(p.PropertyType.Scale + 1, '9'),
                                                            MaximumRangeValue =
                                                                "".PadRight(p.PropertyType.Precision - p.PropertyType.Scale, '9')
                                                                + ".".PadRight(p.PropertyType.Scale + 1, '9')
                                                        }
                                                      : _notRendered,
                                                  IsStandardProperty =
                                                      !(p.IsLookup
                                                        || UniqueIdSpecification.IsUSI(p.PropertyName)
                                                        || IsUniqueIdPropertyOnPersonEntity(entity, p)
                                                        || IsNonDerivedDateProperty(entity, p)
                                                        || IsDateTimeProperty(p)
                                                        || IsDelegatedToBaseProperty(entity, p)),
                                                  PropertyAccessors = GetPropertyAccessors(entity, p)
                                              }),
                        HasOneToOnes = entity.NavigableOneToOnes
                                             .Any(a => a.ThisEntity.Schema == a.OtherEntity.Schema),
                        OneToOnes = entity.NavigableOneToOnes
                                          .Where(a => a.ThisEntity.Schema == a.OtherEntity.Schema)
                                          .Select(
                                               a => new
                                                    {
                                                        AggregateNamespacePrefix = GetAggregateRelativeNamespacePrefix(entity),
                                                        EmbeddedObjectPropertyName =
                                                            a.OtherEntity.Name + SystemConventions.OneToOneEntityPropertyNameSuffix,
                                                        EmbeddedObjectPropertyNameCamelCase =
                                                            (a.OtherEntity.Name + SystemConventions.OneToOneEntityPropertyNameSuffix).ToCamelCase(),
                                                        ClassName = entity.Name, NamespacePrefix = GetCommonRelativeNamespacePrefix(entity),
                                                        OtherClassName = a.OtherEntity.Name,
                                                        OtherNamespacePrefix = GetCommonRelativeNamespacePrefix(a.OtherEntity),
                                               }),
                        RelocatedExtensionOneToOnes = entity.EdFiStandardEntityAssociation?.OtherEntity.NavigableOneToOnes
                                                            .Where(a => a.OtherEntity.Schema == entity.Schema)
                                                            .Select(
                                                                 a => new
                                                                      {
                                                                          AggregateNamespacePrefix = GetAggregateRelativeNamespacePrefix(entity),
                                                                          OtherClassName = a.OtherEntity.Name,
                                                                          OtherClassPluralName = a.OtherEntity.PluralName,
                                                                          OtherNamespacePrefix = GetCommonRelativeNamespacePrefix(a.OtherEntity),
                                                                          EdFiStandardClassName = entity.EdFiStandardEntity.Name,
                                                                          SchemaName = properCaseSchemaName
                                                                      }),
                        NavigableChildren = entity.NavigableChildren
                                                  .Where(a => a.ThisEntity.Schema == a.OtherEntity.Schema)
                                                  .Select(
                                                       a => new
                                                            {
                                                                AggregateNamespacePrefix = GetAggregateRelativeNamespacePrefix(entity),
                                                                IsRequiredCollection = a.Association.Cardinality == Cardinality.OneToOneOrMore,
                                                                ClassName = entity.Name,
                                                                ChildClassName = a.OtherEntity.Name,
                                                                ChildRelativeNamespace = GetCommonRelativeNamespacePrefix(a.OtherEntity),
                                                                ChildCollectionPropertyName = a.Name,
                                                                ChildCollectionFieldName = "_" + a.Name.ToCamelCase(),
                                                                IsChildForConcreteBase = context.IsConcreteEntityBaseClass
                                                            }),
                        RelocatedExtensionCollections = entity.EdFiStandardEntityAssociation?.OtherEntity.NavigableChildren
                                                              .Where(a => a.OtherEntity.Schema == entity.Schema)
                                                              .Select(
                                                                   a => new
                                                                        {
                                                                            IsRequiredCollection =
                                                                                a.Association.Cardinality == Cardinality.OneToOneOrMore,
                                                                            EdFiStandardClassName = entity.EdFiStandardEntity.Name,
                                                                            ChildClassName = a.OtherEntity.Name,
                                                                            ChildCollectionPropertyName = a.Name,
                                                                            ChildRelativeNamespace = GetCommonRelativeNamespacePrefix(a.OtherEntity),
                                                                            ChildCollectionFieldName = "_" + a.Name.ToCamelCase(),
                                                                            SchemaName = properCaseSchemaName
                                                                        }),
                        LookupProperties = entity.Properties
                                                 .Where(p => p.IsLookup)
                                                 .OrderBy(p => p.PropertyName)
                                                 .Select(
                                                      p => new
                                                           {
                                                               p.PropertyName, ValuePropertyName = p.GetLookupValuePropertyName(),
                                                               ValueEntityName = p.GetLookupValueEntityName()
                                                           }),
                        PrimaryKeyMap = new
                                        {
                                            ParentClassName = GetEntityParentClassName(entity), PropertyNames = entity.Identifier.Properties
                                                                                                                      .Where(p => !p.IsFromParent)
                                                                                                                      .OrderBy(p => p.PropertyName)
                                                                                                                      .Select(
                                                                                                                           p => new
                                                                                                                                {
                                                                                                                                    p.PropertyName,
                                                                                                                                    CSharpSafePropertyName
                                                                                                                                        = p
                                                                                                                                         .PropertyName
                                                                                                                                         .MakeSafeForCSharpClass(
                                                                                                                                              entity
                                                                                                                                                 .Name)
                                                                                                                                })
                                        },
                        AlternateKeyProperties = entity.Name == "Descriptor" // Added only for equivalence to legacy templates
                            ? entity.AlternateIdentifiers.FirstOrDefault()
                                    .Properties
                                    .Select(
                                         p => new
                                              {
                                                  p.PropertyName
                                              })
                            : _notRendered,
                        HasParent = entity.ParentAssociation != null, EntityParentClassName = GetEntityParentClassName(entity),
                        EntityParentClassNamespacePrefix = GetEntityParentClassNamespacePrefix(entity),
                        EntityParentClassNameCamelCase = GetEntityParentClassName(entity).ToCamelCase(), ContextualSuffix =
                            context.IsConcreteEntityChildClassForBase
                                ? "Base"
                                : string.Empty,
                        SynchronizationSupport = new
                                                 {
                                                     Properties = entity.InheritedNonIdentifyingProperties
                                                                        .Concat(entity.NonIdentifyingProperties)
                                                                        .Where(IsSynchronizedProperty)
                                                                        .Select(p => p.GetModelsInterfacePropertyName())
                                                                        .Concat(
                                                                             entity.InheritedNavigableOneToOnes
                                                                                   .Where(a => a.ThisEntity.Schema == a.OtherEntity.Schema)
                                                                                   .Select(a => a.OtherEntity.Name))
                                                                        .Concat(
                                                                             entity.NavigableOneToOnes
                                                                                   .Where(a => a.ThisEntity.Schema == a.OtherEntity.Schema)
                                                                                   .Select(a => a.OtherEntity.Name))

                                                                         // Add in aggregate extensions when the current entity is an entity extension
                                                                        .Concat(
                                                                             entity.GetEntityExtensionNavigableOneToOnes()
                                                                                   .Select(x => x.OtherEntity.Name))
                                                                        .Concat(
                                                                             entity.InheritedNavigableChildren
                                                                                   .Where(a => a.ThisEntity.Schema == a.OtherEntity.Schema)
                                                                                   .Select(a => a.Name))
                                                                        .Concat(
                                                                             entity.NavigableChildren
                                                                                   .Where(a => a.ThisEntity.Schema == a.OtherEntity.Schema)
                                                                                   .Select(a => a.Name))

                                                                         // Add in aggregate extensions when the current entity is an entity extension
                                                                        .Concat(
                                                                             entity.GetEntityExtensionNavigableChildren()
                                                                                   .Select(a => a.Name))
                                                                        .OrderBy(n => n)
                                                                        .Select(
                                                                             n => new
                                                                                  {
                                                                                      PropertyName = n, ClassName = entity.Name
                                                                                  }),
                                                     CollectionClasses = entity
                                                                        .InheritedNavigableChildren.Where(
                                                                             a => a.ThisEntity.Schema == a.OtherEntity.Schema)
                                                                        .Concat(
                                                                             entity.NavigableChildren.Where(
                                                                                 a => a.ThisEntity.Schema == a.OtherEntity.Schema))

                                                                         // Add in aggregate extensions when the current entity is an entity extension
                                                                        .Concat(entity.GetEntityExtensionNavigableChildren())
                                                                        .Select(
                                                                             a => new
                                                                                  {
                                                                                      ChildCollectionRoleName = a.RoleName,
                                                                                      ChildCollectionClassName = a.OtherEntity.Name,
                                                                                      ChildCollectionRelativeNamespace = GetCommonRelativeNamespacePrefix(a.OtherEntity),
                                                                                      ClassName = entity.Name
                                                                                  })
                                                 },
                        IsExtendable = entity.IsExtendable(), ExtendableConcreteBase = entity.IsExtendableDerivedEntityWithConcreteBase(),
                        HasDiscriminator = entity.HasDiscriminator(), AggregateReferences =
                            entity.GetAssociationsToReferenceableAggregateRoots()
                                  .OrderBy(a => a.Name)
                                  .Select(
                                       a => new
                                            {
                                                AssociationName = a.Name, InheritanceRootEntity = a.OtherEntity.TypeHierarchyRootEntity, a.OtherEntity
                                            })
                                  .Select(
                                       x =>
                                           new
                                           {
                                               ReferenceAggregateRelativeNamespace =
                                                   x.InheritanceRootEntity.GetRelativeAggregateNamespace(
                                                       x.InheritanceRootEntity.SchemaProperCaseName()),
                                               ReferenceDataClassName = x.InheritanceRootEntity + "ReferenceData",
                                               ReferenceDataPropertyName = x.AssociationName + "ReferenceData",
                                               ReferenceAssociationName = x.AssociationName,
                                               MappedReferenceDataHasDiscriminator = x.OtherEntity.HasDiscriminator()
                                           })
                    };
            }
        }

        private static bool PropertyHasPrecisionAndScale(EntityProperty p)
        {
            return p.PropertyType.Precision != 0 && p.PropertyType.Scale != 0;
        }

        private static bool IsSynchronizedProperty(EntityProperty property)
        {
            return property.PropertyName != "Id"
                   && property.PropertyName != "CreateDate"
                   && property.PropertyName != "LastModifiedDate";
        }

        private static string GetEntityParentClassName(Entity entity)
        {
            if (entity.IsAggregateRoot)
            {
                return null;
            }

            return $"{entity.Parent.Name}";
        }

        private static string GetModelParentClassName(Entity entity)
        {
            if (entity.IsAggregateRoot)
            {
                return null;
            }

            if (entity.IsEdFiStandardEntity)
            {
                return $"{entity.Parent.Name}";
            }

            if (entity.IsAggregateExtensionTopLevelEntity)
            {
                return $"{entity.Parent.GetExtensionClassName()}";
            }

            return $"{entity.Parent.Name}";
        }

        private static string GetCommonRelativeNamespacePrefix(Entity entity)
        {
            return $"{Namespaces.Entities.Common.RelativeNamespace}.{entity.SchemaProperCaseName()}.";
        }

        private static string GetRecordsRelativeNamespacePrefix(Entity entity)
        {
            return $"{Namespaces.Entities.Records.RelativeNamespace}.{entity.SchemaProperCaseName()}.";
        }

        private static string GetAggregateRelativeNamespacePrefix(Entity entity)
        {
            return $"{Namespaces.Entities.NHibernate.RelativeNamespace}.{entity.Aggregate.Name}Aggregate.{entity.SchemaProperCaseName()}.";
        }

        private static string GetModelParentInterfaceNamespacePrefix(Entity entity)
        {
            return
                $"{Namespaces.Entities.Common.RelativeNamespace}.{entity.EdFiStandardEntityAssociation?.OtherEntity.SchemaProperCaseName() ?? entity.SchemaProperCaseName()}.";
        }

        private static string GetEntityParentClassNamespacePrefix(Entity entity)
        {
            return entity.IsEntityExtension || entity.IsAggregateExtensionTopLevelEntity
                ? $"{EdFiConventions.ProperCaseName}."
                : null;
        }

        private static object GetPropertyAccessors(Entity entity, EntityProperty p)
        {
            return new
                   {
                       LookupProperty = p.IsLookup
                           ? new
                             {
                                 LookupValuePropertyName = p.GetLookupValuePropertyName(), LookupEntityName = p.LookupEntity.Name,
                                 p.PropertyType.IsNullable, IdFieldName = "_" + p.PropertyName.ToCamelCase(), ValueFieldName =
                                     "_" + p.GetLookupValuePropertyName()
                                            .ToCamelCase(),
                                 CSharpDeclaredType = p.PropertyType.ToCSharp(includeNullability: true),
                                 NeedsOverride = entity.IsDerived && p.IsIdentifying && !p.IsInheritedIdentifyingRenamed
                             }
                           : _notRendered,
                       UsiProperty = UniqueIdSpecification.IsUSI(p.PropertyName)
                           ? new
                             {
                                 CSharpDeclaredType = p.PropertyType.ToCSharp(includeNullability: true),
                                 UsiFieldName = "_" + p.PropertyName.ToCamelCase(), p.PropertyType.IsNullable,
                                 PersonType = UniqueIdSpecification.GetUSIPersonType(p.PropertyName),
                                 UniqueIdPropertyName = p.PropertyName.ReplaceSuffix("USI", "UniqueId"), UniqueIdFieldName =
                                     "_" + p.PropertyName.ReplaceSuffix("USI", "UniqueId")
                                            .ToCamelCase(),
                                 IsPersonEntity = entity.IsPersonEntity()
                             }
                           : _notRendered,
                       UniqueIdProperty = IsUniqueIdPropertyOnPersonEntity(entity, p)
                           ? new
                             {
                                 UniqueIdFieldName = "_" + p.PropertyName.ToCamelCase(),
                                 UsiPropertyName = p.PropertyName.ReplaceSuffix("UniqueId", "USI"), UsiFieldName =
                                     "_" + p.PropertyName.ReplaceSuffix("UniqueId", "USI")
                                            .ToCamelCase(),
                                 PersonType = UniqueIdSpecification.GetUniqueIdPersonType(p.PropertyName)
                             }
                           : _notRendered,
                       DateOnlyProperty = IsNonDerivedDateProperty(entity, p)
                           ? new
                             {
                                 CSharpDeclaredType = p.PropertyType.ToCSharp(includeNullability: true), p.PropertyType.IsNullable,
                                 FieldName = "_" + p.PropertyName.ToCamelCase()
                             }
                           : _notRendered,
                       DateTimeProperty = IsDateTimeProperty(p)
                           ? new
                             {
                                 CSharpDeclaredType = p.PropertyType.ToCSharp(includeNullability: true), p.PropertyType.IsNullable,
                                 FieldName = "_" + p.PropertyName.ToCamelCase()
                             }
                           : _notRendered,
                       DelegatedProperty = IsDelegatedToBaseProperty(entity, p)
                           ? new
                             {
                                 BasePropertyName = GetBasePropertyName(entity, p)
                             }
                           : _notRendered
                   };
        }

        private static bool CSharpDefaultHasDomainMeaning(EntityProperty property)
        {
            switch (property.PropertyType.ToCSharp())
            {
                case "string":
                case "DateTime":
                    return false;

                case "TimeSpan":

                    if (property.PropertyName.StartsWith("Start", StringComparison.InvariantCultureIgnoreCase)
                        || property.PropertyName.StartsWith("Begin", StringComparison.InvariantCultureIgnoreCase)
                        || property.PropertyName.StartsWith("End", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return false;
                    }

                    break;

                case "short":
                case "int":

                    if (property.PropertyName.EndsWith("Year", StringComparison.InvariantCultureIgnoreCase)
                        || property.PropertyName.Equals("Version", StringComparison.InvariantCultureIgnoreCase)
                        || property.PropertyName.Contains("Sequence")
                        || property.PropertyName.EndsWith("Number", StringComparison.InvariantCultureIgnoreCase)
                        || property.PropertyName.EndsWith("Id", StringComparison.InvariantCultureIgnoreCase)
                        || property.PropertyName.EndsWith("USI", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return false;
                    }

                    break;

                default:
                    return true;
            }

            return true;
        }

        private static bool IsDelegatedToBaseProperty(Entity entity, EntityProperty p)
        {
            return entity.IsDerived && p.IsIdentifying && p.PropertyName != GetBasePropertyName(entity, p);
        }

        private static bool IsNonDerivedDateProperty(Entity entity, EntityProperty p)
        {
            return p.PropertyType.DbType == DbType.Date && (!p.IsIdentifying || !entity.IsDerived);
        }

        private static bool IsDateTimeProperty(EntityProperty p)
        {
            return p.PropertyType.DbType == DbType.DateTime2;
        }

        private static bool IsUniqueIdPropertyOnPersonEntity(Entity entity, EntityProperty p)
        {
            return UniqueIdSpecification.IsUniqueId(p.PropertyName)
                   && entity.Name == UniqueIdSpecification.GetUniqueIdPersonType(p.PropertyName);
        }

        private static string GetBasePropertyName(Entity entity, EntityProperty property)
        {
            return entity.IsDerived && property.IsIdentifying
                ? property.Entity.BaseAssociation.PropertyMappingByThisName[property.PropertyName]
                          .OtherProperty.PropertyName
                : null;
        }

        private static IEnumerable<ClassContext> GetClassContexts(Entity entity)
        {
            yield return new ClassContext();

            if (!entity.IsAbstract && entity.IsBase)
            {
                yield return
                    new ClassContext
                    {
                        IsConcreteEntityBaseClass = true, IsConcreteEntityChildClassForBase = false
                    };
            }
            else if (!entity.IsAggregateRoot
                     && !entity.Aggregate.AggregateRoot.IsAbstract
                     && entity.Aggregate.AggregateRoot.IsBase)
            {
                yield return
                    new ClassContext
                    {
                        IsConcreteEntityBaseClass = false, IsConcreteEntityChildClassForBase = true
                    };
            }
        }

        private static string GetModelParentInterfaceName(Entity entity)
        {
            if (entity.IsAggregateRoot)
            {
                return null;
            }

            if (entity.IsEdFiStandardEntity)
            {
                return $"I{entity.Parent.Name}";
            }

            if (entity.IsAggregateExtensionTopLevelEntity)
            {
                return
                    $"I{entity.Parent.GetExtensionClassName()}"; // NOTE: Can't rely on explicit "Extension" class being present in domain model
            }

            if (entity.IsEntityExtension)
            {
                return $"I{entity.Parent.Name}";
            }

            return $"I{entity.Parent.Name}";
        }

        private string GetParentRecordInterfaceName(Entity entity)
        {
            var properCaseName = entity.Parent.IsExtensionEntity
                ? TemplateContext.SchemaProperCaseName
                : EdFiConventions.ProperCaseName;

            var namespaceSegment =
                EdFiConventions.BuildNamespace(
                    Namespaces.Entities.Records.RelativeNamespace,
                    properCaseName);

            string otherEntityName = entity.ParentAssociation.OtherEntity.Name;

            return $"{namespaceSegment}.I{otherEntityName}Record";
        }

        /// <summary>
        /// Holds contextual information for the generation of the current NHibernate class mapping.
        /// </summary>
        /// <remarks>Due to how the mappings need to be generated to handle certain special scenarios 
        /// (e.g. concrete base classes and their children), multiple mappings are sometimes generated for
        /// the same tables (entities).  This context class captures the details pertinent to the variations
        /// required for the specific mapping being generated so that a single template and template driver 
        /// class can be used.</remarks>
        private class ClassContext
        {
            /// <summary>
            /// Indicates whether the current class mapping being generated is the "base class" version for
            /// an entity that is a concrete base entity (a base type that is not also abstract).
            /// </summary>
            public bool IsConcreteEntityBaseClass { get; set; }

            /// <summary>
            /// Indicates whether the current class mapping being generated is for one of the child collection
            /// classes for the specialized "base class" mapping.
            /// </summary>
            public bool IsConcreteEntityChildClassForBase { get; set; }
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Text;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.CodeGen.Generators
{
    public class EntityInterfaces : GeneratorBase
    {
        protected override object Build()
        {
            var resourceClassesToRender = ResourceModelProvider.GetResourceModel()
                .GetAllResources()
                .SelectMany(
                    r => r.AllContainedItemTypesOrSelf.Where(
                        i => TemplateContext.ShouldRenderResourceClass(i)

                             // Don't render artifacts for base class children in the context of derived resources
                             && !i.IsInheritedChildItem()))
                .OrderBy(r => r.Name)
                .ToList();

            var entityInterfacesModel = new
            {
                EntitiesBaseNamespace =
                    EdFiConventions.BuildNamespace(
                        Namespaces.Entities.Common.BaseNamespace,
                        TemplateContext.SchemaProperCaseName),
                Interfaces = resourceClassesToRender
                    .Where(TemplateContext.ShouldRenderResourceClass)
                    .Select(
                        r => new
                        {
                            r.FullName.Schema,
                            r.Name,
                            AggregateName = r.Name,
                            ImplementedInterfaces = GetImplementedInterfaceString(r),
                            ParentInterfaceName = GetParentInterfaceName(r),
                            ParentClassName = GetParentClassName(r),
                            IdentifyingProperties = r
                                .IdentifyingProperties

                                // Exclude inherited identifying properties where the property has not been renamed
                                .Where(
                                    p => !(
                                        p.EntityProperty
                                            ?.IsInheritedIdentifying ==
                                        true
                                        && !p
                                            .EntityProperty
                                            ?.IsInheritedIdentifyingRenamed ==
                                        true))
                                .OrderBy(
                                    p => p
                                        .PropertyName)
                                .Select(
                                    p =>
                                        new
                                        {
                                            p.IsServerAssigned,
                                            IsUniqueId
                                                = UniqueIdSpecification
                                                      .IsUniqueId(
                                                          p.PropertyName)
                                                  &&
                                                  PersonEntitySpecification
                                                      .IsPersonEntity(
                                                          r.Name),
                                            p.IsLookup,
                                            CSharpType
                                                = p
                                                    .PropertyType
                                                    .ToCSharp(
                                                        false),
                                            Name
                                                = p
                                                    .PropertyName,
                                            CSharpSafePropertyName
                                                = p
                                                    .PropertyName
                                                    .MakeSafeForCSharpClass(
                                                        r.Name),
                                            LookupName
                                                = p
                                                    .PropertyName
                                        })
                                .ToList(),
                            r.IsDerived,
                            InheritedNonIdentifyingProperties = r.IsDerived
                                ? r.AllProperties
                                    .Where(p => p.IsInherited && !p.IsIdentifying)
                                    .OrderBy(p => p.PropertyName)
                                    .Where(IsModelInterfaceProperty)
                                    .Select(
                                        p =>
                                            new
                                            {
                                                p.IsLookup,
                                                CSharpType = p.PropertyType.ToCSharp(true),
                                                Name = p.PropertyName,
                                                LookupName = p.PropertyName.TrimSuffix("Id")
                                            })
                                    .ToList()
                                : null,
                            NonIdentifyingProperties = r.NonIdentifyingProperties
                                .Where(p => !p.IsInherited)
                                .OrderBy(p => p.PropertyName)
                                .Where(IsModelInterfaceProperty)
                                .Select(
                                    p =>
                                        new
                                        {
                                            p.IsLookup,
                                            CSharpType =
                                                p.PropertyType.ToCSharp(true),
                                            Name = p.PropertyName,
                                            CSharpSafePropertyName =
                                                p.PropertyName
                                                    .MakeSafeForCSharpClass(r.Name),
                                            LookupName =
                                                p.PropertyName.TrimSuffix("Id")
                                        })
                                .ToList(),
                            HasNavigableOneToOnes = r.EmbeddedObjects.Any(),
                            NavigableOneToOnes = r
                                .EmbeddedObjects
                                .Where(eo => !eo.IsInherited)
                                .OrderBy(
                                    eo
                                        => eo
                                            .PropertyName)
                                .Select(
                                    eo
                                        => new
                                        {
                                            Name
                                                = eo
                                                    .PropertyName
                                        })
                                .ToList(),
                            InheritedLists = r.IsDerived
                                ? r.Collections
                                    .Where(c => c.IsInherited)
                                    .OrderBy(c => c.PropertyName)
                                    .Select(
                                        c => new
                                        {
                                            c.ItemType.Name,
                                            PluralName = c.PropertyName
                                        })
                                    .ToList()
                                : null,
                            Lists = r.Collections
                                .Where(c => !c.IsInherited)
                                .OrderBy(c => c.PropertyName)
                                .Select(
                                    c => new
                                    {
                                        c.ItemType.Name,
                                        PluralName = c.PropertyName
                                    })
                                .ToList(),
                            HasDiscriminator = r.HasDiscriminator(),
                            AggregateReferences =
                                r.Entity?.GetAssociationsToReferenceableAggregateRoots()
                                    .OrderBy(a => a.Name)
                                    .Select(
                                        a => new
                                        {
                                            AggregateReferenceName = a.Name,
                                            MappedReferenceDataHasDiscriminator =
                                                a.OtherEntity.HasDiscriminator()
                                        })
                                    .ToList()
                        })
                    .ToList()
            };

            return entityInterfacesModel;
        }

        private static string GetParentClassName(ResourceClassBase resourceClass)
        {
            return (resourceClass as ResourceChildItem)?.Parent.Name;
        }

        private static string GetParentInterfaceName(ResourceClassBase resourceClass)
        {
            string parentClassName = GetParentClassName(resourceClass);

            if (parentClassName == null)
            {
                return null;
            }

            var resourceChildItem = (ResourceChildItem) resourceClass;

            // If this resource class represents an "Entity Extension"
            if (resourceChildItem.Parent.Extensions.Any(
                x => ModelComparers.Resource.Equals(resourceChildItem, x.ObjectType)))
            {
                return $"{EdFiConventions.ProperCaseName}.I{parentClassName}";
            }

            return $"I{parentClassName}";
        }

        private string GetImplementedInterfaceString(ResourceClassBase resourceClass)
        {
            var interfaceStringBuilder = new StringBuilder();

            if (resourceClass.Entity?.IsDerived == true)
            {
                AddInterface(
                    $"{resourceClass.Entity.BaseEntity.SchemaProperCaseName()}.I{resourceClass.Entity.BaseEntity.Name}",
                    interfaceStringBuilder);
            }

            if (resourceClass.Entity?.IsAbstractRequiringNoCompositeId() != true)
            {
                AddInterface("ISynchronizable", interfaceStringBuilder);
                AddInterface("IMappable", interfaceStringBuilder);
            }

            // We want to exclude base concrete classes, descriptors and types from extensions.
            if (resourceClass.IsExtendable())
            {
                AddInterface("IHasExtensions", interfaceStringBuilder);
            }

            if (resourceClass is Resource)
            {
                AddInterface("IHasIdentifier", interfaceStringBuilder);
            }

            if (resourceClass.Properties.Where(p => p.IsIdentifying)
                .Any(p => UniqueIdSpecification.IsUniqueId(p.PropertyName) && p.IsLocallyDefined))
            {
                AddInterface("IIdentifiablePerson", interfaceStringBuilder);
            }

            AddInterface("IGetByExample", interfaceStringBuilder);

            return interfaceStringBuilder.ToString();
        }

        private void AddInterface(string interfaceName, StringBuilder interfaceStringBuilder)
        {
            if (interfaceStringBuilder.Length > 0)
            {
                interfaceStringBuilder.Append(", " + interfaceName);
            }
            else
            {
                interfaceStringBuilder.Append(" : " + interfaceName);
            }
        }

        private bool IsModelInterfaceProperty(ResourceProperty p)
        {
            return !new[]
            {
                "Id",
                "LastModifiedDate",
                "CreateDate"
            }.Contains(p.PropertyName);
        }
    }
}

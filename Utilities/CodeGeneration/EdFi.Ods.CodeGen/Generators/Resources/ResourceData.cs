// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Generators.Resources
{
    public class ResourceProfileData
    {
        /// <summary>
        /// Gets the version of the resource guaranteed not to have any filters applied.
        /// </summary>
        /// <remarks>When generating a non-profile constrained resource, this will be the same as the <see cref="Resource" />.</remarks>
        public Resource UnfilteredResource { get; set; }

        public string ProfileName { get; set; }

        /// <summary>
        /// Gets the combined context of readable/writable and any concrete resource (for generating namespaces for inherited base child classes).
        /// </summary>
        /// <seealso cref="ConcreteResourceContext"/>
        /// <seealso cref="ReadableWritableContext"/>
        public string Context { private get; set; }

        /// <summary>
        /// Indicates that the resource model representation is a "base" resource from which other resources are derived.
        /// </summary>
        public bool IsBaseResource { get; set; }

        /// <summary>
        /// Gets the supplied resource class.
        /// </summary>
        public Resource Resource { get; set; }

        public string ResourceName
        {
            get { return ContextualRootResource.Name; }
        }

        public bool IsDerived
        {
            get { return ContextualRootResource.IsDerived; }
        }

        public bool IsAbstract
        {
            get { return ContextualRootResource.IsAbstract(); }
        }

        //TODO: JSM - Embedded convention -converting profile name to a C# namespace segment
        public string ProfileNamespaceName => ProfileName?.Replace("-", "_");

        public string ProfileNamespaceSegment
        {
            get
            {
                if (ProfileName == null)
                {
                    return null;
                }

                return "." + ProfileNamespaceName + Context;
            }
        }

        public string ProfilePropertyNamespaceSection
        {
            get
            {
                if (ProfileName == null)
                {
                    return null;
                }

                //TODO: JSM - Embedded convention -converting profile name to a C# property with namespace
                return (ProfileNamespaceSegment + "." + Resource.Name + ".").TrimStart('.');
            }
        }

        /// <summary>
        /// Gets the contextual root resource, which may be the <see cref="Resource" /> or its base resource class (if applicable, and depending on the code generation context).
        /// </summary>
        /// <returns>The contextual root resource, to be used only for evaluating whether to generate a class for the root.</returns>
        public Resource ContextualRootResource { get; set; }

        /// <summary>
        /// Gets the readable/writable context (if applicable) for Profile-based namespaces (in the form of "_Readable" or "_Writable").
        /// </summary>
        public string ReadableWritableContext { get; set; }

        /// <summary>
        /// Gets the concrete resource context (e.g. "School") for use in constructing the namespace for the child classes of a base resource.
        /// </summary>
        public string ConcreteResourceContext { get; set; }

        public bool HasFilteredCollection()
        {
            return Resource.Collections
                .Select(x => x)
                .Concat(
                    Resource.Collections
                        .SelectMany(x => x.ItemType.Collections))
                .Any(x => x.ValueFilters.Any());
        }

        public bool IsIncluded(ResourceClassBase resource, ResourceProperty property)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (IsBaseResource && Resource.IsDerived && resource.Entity.IsBase)
            {
                return true;
            }

            if (resource.Name == Resource.Name)
            {
                return Resource.AllProperties
                    .Contains(property, ModelComparers.ResourceProperty);
            }

            // if the resource is excluded we ignore all properties
            if (!IsIncluded(resource))
            {
                return false;
            }

            var filteredResource = GetContainedResource(resource);

            if (filteredResource != null
                && filteredResource.AllProperties
                    .Contains(property, ModelComparers.ResourcePropertyNameOnly))
            {
                return true;
            }

            if (Resource.Extensions.SelectMany(
                    e => e.ObjectType.AllProperties)
                .Contains(
                    property,
                    ModelComparers.ResourceProperty))
            {
                return true;
            }

            return false;
        }

        public bool IsIncluded(ResourceClassBase resource, Reference reference)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (reference == null)
            {
                throw new ArgumentNullException(nameof(reference));
            }

            //need to render a reference if the pk is inherited
            if (reference.IsExclusiveForIdentifyingColumns())
            {
                return true;
            }

            // Is this reference included outright?
            if (IsIncluded(resource, reference as ResourceMemberBase))
            {
                return true;
            }

            return false;
        }
        
        public bool IsIncluded(ResourceClassBase resource, Reference reference, out bool implicitOnly)
        {
            implicitOnly = false;

            if (IsIncluded(resource, reference))
            {
                return true;
            }
            
            // Does this un-included reference have unified key properties (properties shared with another included reference)?
            var unifiedKeyProperties = reference.Properties.Where(p => p.IsUnified()).ToArray();
            
            if (unifiedKeyProperties.Any())
            {
                bool isSubsetOfAnotherIncludedReference = 
                    // All references (except the current reference)
                    resource.References.Except(new[] { reference })

                    // Inspect other included references
                    .Where(r => IsIncluded(resource, r))

                    // Exclude the current reference
                    

                    // Determine if all of the current reference's unified key properties are found in the unified key properties of the other included reference
                    .Any(
                        r => unifiedKeyProperties.All(
                                ukp => r.Properties.Where(p => p.IsUnified())
                                    .Contains(ukp, ModelComparers.ResourcePropertyNameOnly)));

                if (isSubsetOfAnotherIncludedReference)
                {
                    implicitOnly = true;
                }
            }

            return false;
        }

        public bool IsIncluded(ResourceClassBase resource, Collection collection)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (IsBaseResource && Resource.IsDerived)
            {
                return true;
            }

            return IsIncluded(resource, collection as ResourceMemberBase);
        }

        public bool IsFilteredCollection(ResourceClassBase resource, Collection collection)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            var filteredCollection = GetFilteredCollection(resource, collection);

            if (filteredCollection == null || !IsIncluded(resource, collection))
            {
                return false;
            }

            return filteredCollection.ValueFilters.Any();
        }

        public ResourceChildItem GetContainedResource(ResourceClassBase resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            return Resource != null
                ? Resource.AllContainedItemTypes.SingleOrDefault(
                    x => ModelComparers.Resource.Equals(x, resource))
                : null;
        }

        public bool HasNavigableChildren(ResourceClassBase resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (IsBaseResource)
            {
                return resource.Entity.NavigableChildren.Any();
            }

            if (resource.Name == Resource.Name)
            {
                return Resource.Collections.Any();
            }

            return resource.Collections.Any() || resource.HasBackReferences();
        }

        public Collection GetFilteredCollection(ResourceClassBase resource, Collection collection)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            var filteredResource = GetContainedResource(resource) ?? resource;
            return filteredResource.Collections.FirstOrDefault(x => ModelComparers.Collection.Equals(x, collection));
        }

        public ResourceClassBase GetProfileActiveResource(ResourceClassBase resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            return Resource.Name == resource.Name
                ? UnfilteredResource
                : resource;
        }

        public string GetProfileNamespace(ResourceClassBase resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            return resource.Name == Resource.Name
                ? ProfilePropertyNamespaceSection
                : null;
        }

        private bool IsIncluded(ResourceClassBase resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            // We include the parent resource as included   
            // OR   check to see if any Extensions's ObjectTypes match the input resource.Name
            if (Resource.Name == resource.Name
                || Resource.Extensions.Select(x => x.ObjectType.Name)
                    .Any(x => x == resource.Name))
            {
                return true;
            }

            // we are looking if the resource is the parent resource, and if any of its children are referenced in the profile.
            if (IsBaseResource && (resource as ResourceChildItem)?.Parent == null)
            {
                return Resource.AllContainedItemTypes
                    .Select(x => x.Entity)
                    .Contains(resource.Entity, ModelComparers.Entity);
            }

            return Resource.AllContainedItemTypes
                .Select(x => x.Entity)
                .Contains(resource.Entity, ModelComparers.Entity);
        }

        private bool IsIncluded(ResourceClassBase resource, ResourceMemberBase resourceMember)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (resourceMember == null)
            {
                throw new ArgumentNullException(nameof(resourceMember));
            }
            if (!IsIncluded(resource))
            {
                return false;
            }

            if (resource.Name == Resource.Name)
            {
                return Resource.AllMembers.Any(x => x.PropertyName == resourceMember.PropertyName);
            }

            var filteredResource = GetContainedResource(resource);

            return filteredResource != null
                   && filteredResource.AllMembers.Any(x => x.PropertyName == resourceMember.PropertyName);
        }

        public override string ToString()
        {
            return $"{ResourceName} ({ProfileName}";
        }
    }
}

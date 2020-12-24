// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Resource
{
    // Resource (non-top-level) only
    public class ResourceChildItem : ResourceClassBase, IHasParent
    {
        private readonly ResourceMemberBase _containingMember;

        private Lazy<bool> _isInheritedChild;
        
        internal ResourceChildItem(IResourceModel resourceModel, Entity entity, FilterContext childContext, ResourceClassBase parentResource)
            : base(resourceModel, entity, childContext)
        {
            Parent = parentResource;

            _isInheritedChild = InitializeIsInheritedChild();
        }

        internal ResourceChildItem(
            ResourceMemberBase containingMember,
            IResourceModel resourceModel,
            Entity entity,
            FilterContext childContext,
            ResourceClassBase parentResource,
            Func<IEnumerable<AssociationView>> collectionAssociations,
            Func<IEnumerable<AssociationView>> embeddedObjectAssociations)
            : base(resourceModel, entity, childContext, collectionAssociations, embeddedObjectAssociations)
        {
            _containingMember = containingMember;
            
            Parent = parentResource;

            _isInheritedChild = InitializeIsInheritedChild();
        }

        internal ResourceChildItem(ResourceChildItem[] resourceChildItems, ResourceClassBase parentResource)
            : base(
                resourceChildItems.Cast<ResourceClassBase>()
                                  .ToArray())
        {
            Parent = parentResource;
            
            _isInheritedChild = InitializeIsInheritedChild();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceChildItem" /> class using the specified name and parent resource.
        /// </summary>
        /// <param name="name">The name to be given to the resource class.</param>
        /// <param name="parentResource">The containing (parent) resource for the new child item.</param>
        /// <remarks>This constructor was introduced for use in building Composite resources.</remarks>
        public ResourceChildItem(string name, ResourceClassBase parentResource)
            : base(name)
        {
            Parent = parentResource;
            
            _isInheritedChild = InitializeIsInheritedChild();
        }

        public ResourceChildItem(
            ResourceMemberBase containingMember,
            IResourceModel resourceModel,
            FullName fullName,
            ResourceClassBase parentResource,
            Func<IEnumerable<AssociationView>> collectionAssociations,
            Func<IEnumerable<AssociationView>> embeddedObjectAssociations,
            FilterContext filterContext)
            : base(resourceModel, fullName, collectionAssociations, embeddedObjectAssociations, filterContext)
        {
            _containingMember = containingMember;
            
            Parent = parentResource;
            
            _isInheritedChild = InitializeIsInheritedChild();
        }

        private Lazy<bool> InitializeIsInheritedChild()
        {
            return new Lazy<bool>(() =>
            {
                // TODO: Simple API - Consider the following line as an alternative implementation
                // return (resourceClass.Entity.Aggregate.AggregateRoot != resourceClass.ResourceRoot.Entity)
                
                // Get the lineage from bottom to top, leaving out the root resource class
                var lineage = GetLineage()
                    .Skip(1)
                    .Reverse()
                    .Cast<ResourceChildItem>();

                // Iterate up the lineage looking for evidence of divergence in the reported "Parent" names (between the underlying Entities and Resource classes)
                foreach (var resourceClass in lineage)
                {
                    // Quit looking if this is a child of an entity extension
                    if (resourceClass.Parent.IsResourceExtensionClass)
                    {
                        break;
                    }

                    // Are the parents' names different between the resource and the underlying entity? This is the indication that this is a child from a base resource.
                    if (resourceClass.Entity != null && resourceClass.Parent.FullName != resourceClass.Entity.Parent.FullName)
                    {
                        return true;
                    }
                }

                return false;
            });
        }
        
        public ResourceMemberBase ContainingMember
        {
            get => _containingMember;
        }
        
        /// <summary>
        /// Gets the root <see cref="Resource" /> class for the current resource.
        /// </summary>
        public override Resource ResourceRoot => GetLineage()
                                                .Cast<Resource>()
                                                .First();

        public override string JsonPath
        {
            get
            {
                if (_containingMember == null)
                {
                    throw new NullReferenceException($"The containing member for ResourceChildItem '{FullName}' has not been initialized.");
                }
                
                return _containingMember.JsonPath;
            }
        }

        /// <summary>
        /// Indicates whether the resource class is part of an extension to an Ed-Fi standard resource (i.e. a "resource extension" as opposed to being part of a new "extension resource").
        /// </summary>
        public override bool IsResourceExtension
        {
            get
            {
                return GetLineage()
                   .Any(r => r.IsResourceExtensionClass);
            }
        }

        /// <summary>
        /// Indicates whether the resource class is the "Extension" class artifact for a resource extension, containing all the 
        /// extension <see cref="ResourceProperty" />, <see cref="Reference" />, <see cref="Collection" />, and <see cref="EmbeddedObject" /> instances.
        /// </summary>
        public override bool IsResourceExtensionClass
        {
            get
            {
                if (Entity != null)
                {
                    return Entity.IsEntityExtension;
                }

                if (FullName.Schema != EdFiConventions.PhysicalSchemaName)
                {
                    // Is this an implicitly created Extension class?
                    if (Name == ExtensionsConventions.GetExtensionClassName(Parent.Name))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Indicates whether this resource child item was inherited from a base resource class.
        /// </summary>
        public bool IsInheritedChildItem
        {
            get => _isInheritedChild.Value;
        }

        public ResourceClassBase Parent { get; }

        /// <summary>
        /// Gets the lineage of resource classes (inclusive) from the root down to the current resource class.
        /// </summary>
        /// <returns>The lineage of the current resource class in the resource.</returns>
        public IEnumerable<ResourceClassBase> GetLineage()
        {
            // Return the parent resource child item's lineage
            if (Parent is IHasParent)
            {
                return (Parent as IHasParent)
                      .GetLineage()
                      .Concat(
                           new[]
                           {
                               this
                           });
            }

            // Just return the parent resource
            return new[]
                   {
                       Parent, this
                   };
        }
    }
}

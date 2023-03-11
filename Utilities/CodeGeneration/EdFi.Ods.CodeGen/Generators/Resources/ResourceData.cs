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
    public class ResourceData
    {
        public ResourceData(Resource resource)
        {
            Resource = resource;
        }
        
        /// <summary>
        /// Indicates that the resource model representation is a "base" resource from which other resources are derived.
        /// </summary>
        public bool IsBaseResource { get; set; }

        /// <summary>
        /// Gets the supplied resource class.
        /// </summary>
        public Resource Resource { get; }

        public string ResourceName
        {
            get { return Resource.Name; }
        }

        public bool IsDerived
        {
            get { return Resource.IsDerived; }
        }

        public bool IsAbstract
        {
            get { return Resource.IsAbstract(); }
        }

        public ResourceChildItem GetContainedResource(ResourceClassBase resourceClass)
        {
            if (resourceClass == null)
            {
                throw new ArgumentNullException(nameof(resourceClass));
            }

            return Resource?.AllContainedItemTypes.SingleOrDefault(
                x => ModelComparers.Resource.Equals(x, resourceClass));
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

        public override string ToString()
        {
            return ResourceName;
        }
    }
}

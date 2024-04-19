// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Validation;

namespace EdFi.Ods.Common.Models.Resource
{
    /// <summary>
    /// Provides access to the readable and writable versions of a Resource for a Profile.
    /// </summary>
    public class ProfileResourceContentTypes
    {
        private readonly ConcurrentDictionary<FullName, bool> _isCreatableByResourceClassName = new();
        private readonly IProfileValidationReporter _profileValidationReporter;

        private readonly Lazy<Resource> _readableResource;
        private readonly Resource _sourceResource;
        private readonly Lazy<Resource> _writableResource;
        private readonly string _profileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileResourceContentTypes"/> class using the
        /// supplied Resource and Profile-specific resource definition.
        /// </summary>
        /// <param name="sourceResource">The source (underlying) resource.</param>
        /// <param name="resourceDefinition">The profile's definition for the resource.</param>
        public ProfileResourceContentTypes(
            Resource sourceResource,
            XElement resourceDefinition,
            IProfileValidationReporter profileValidationReporter)
        {
            _profileName = resourceDefinition.Parent.AttributeValue("name");

            _sourceResource = sourceResource;
            _profileValidationReporter = profileValidationReporter;

            _readableResource = new Lazy<Resource>(
                () => GetResourceForContentType(sourceResource, resourceDefinition, "ReadContentType"));

            _writableResource = new Lazy<Resource>(
                () => GetResourceForContentType(sourceResource, resourceDefinition, "WriteContentType"));
        }

        /// <summary>
        /// Gets the readable version of the Resource.
        /// </summary>
        public Resource Readable
        {
            get { return _readableResource.Value; }
        }

        /// <summary>
        /// Gets the writable version of the Resource.
        /// </summary>
        public Resource Writable
        {
            get { return _writableResource.Value; }
        }

        public bool CanCreateResourceClass(FullName resourceClassName)
        {
            if (_writableResource == null)
            {
                return false;
            }

            return _isCreatableByResourceClassName.GetOrAdd(
                resourceClassName,
                fn =>
                {
                    // Find the resource class in both representations (writable content type, and original)
                    var sourceResourceClass =
                        _sourceResource.AllContainedItemTypesOrSelf.SingleOrDefault(t => t.FullName == resourceClassName);

                    if (sourceResourceClass == null)
                    {
                        throw new InternalServerErrorException(
                            "scenario41.",
                            $"The resource class '{fn}' was not found in resource '{_sourceResource.FullName}' while attempting to determine if it is creatable with Profile '{_profileName}'.");
                    }

                    var writableResourceClass =
                        Writable.AllContainedItemTypesOrSelf.SingleOrDefault(t => t.FullName == resourceClassName);

                    if (writableResourceClass == null)
                    {
                        return false;
                    }

                    return IsCreatable(sourceResourceClass, writableResourceClass);
                });
        }

        private bool IsCreatable(ResourceClassBase sourceResourceClass, ResourceClassBase writableResourceClass)
        {
            // Need to check for any members that are required for creation have not been included in the Profile resource

            // Check for missing required properties
            var requiredPropertyNames = sourceResourceClass.Properties.Where(p => !p.PropertyType.IsNullable)
                .Select(p => p.PropertyName);

            if (requiredPropertyNames.Any(rn => !writableResourceClass.PropertyByName.ContainsKey(rn)))
            {
                return false;
            }

            // Check for missing required references
            var requiredReferenceNames = sourceResourceClass.References.Where(r => r.IsRequired).Select(r => r.PropertyName);

            if (requiredReferenceNames.Any(rn => !writableResourceClass.ReferenceByName.ContainsKey(rn)))
            {
                return false;
            }

            // Check for missing required collections
            var requiredCollections = sourceResourceClass.Collections.Where(c => c.Association.IsRequiredCollection);

            if (requiredCollections.Any(c => !writableResourceClass.CollectionByName.ContainsKey(c.PropertyName)))
            {
                return false;
            }

            // Recursively check the resource class contained by the required collections
            var requiredCollectionItemTypes = requiredCollections.Select(
                rc => new
                {
                    SourceItemType = rc.ItemType,
                    WritableItemType = writableResourceClass.CollectionByName[rc.PropertyName].ItemType
                });

            if (requiredCollectionItemTypes.Any(x => !IsCreatable(x.SourceItemType, x.WritableItemType)))
            {
                return false;
            }

            // Check for missing embedded objects
            var requiredEmbeddedObjects = sourceResourceClass.EmbeddedObjects.Where(e => e.Association.IsRequiredEmbeddedObject);

            if (requiredEmbeddedObjects.Any(eo => !writableResourceClass.EmbeddedObjectByName.ContainsKey(eo.PropertyName)))
            {
                return false;
            }

            // Recursively check the resource class contained by the required embedded object
            var requiredEmbeddedObjectTypes = requiredEmbeddedObjects.Select(
                rc => new
                {
                    SourceItemType = rc.ObjectType,
                    WritableItemType = writableResourceClass.EmbeddedObjectByName[rc.PropertyName].ObjectType
                });

            if (requiredEmbeddedObjectTypes.Any(x => !IsCreatable(x.SourceItemType, x.WritableItemType)))
            {
                return false;
            }

            // If we're still here. It's creatable
            return true;
        }

        private Resource GetResourceForContentType(
            Resource sourceResource,
            XElement resourceDefinition,
            string contentTypeElementName)
        {
            var contentTypeElt = resourceDefinition.Element(contentTypeElementName);

            if (contentTypeElt == null)
            {
                return null;
            }

            var filterContext = new FilterContext(
                new ProfileResourceMembersFilterProvider(_profileValidationReporter),
                contentTypeElt,
                sourceResource);

            return new Resource(sourceResource.ResourceModel, sourceResource.Entity, filterContext);
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Xml.Linq;

namespace EdFi.Ods.Common.Models.Resource
{
    /// <summary>
    /// Provides access to the readable and writable versions of a Resource for a Profile.
    /// </summary>
    public class ProfileResourceContentTypes
    {
        private readonly Lazy<Resource> _readableResource;
        private readonly Lazy<Resource> _writableResource;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileResourceContentTypes"/> class using the
        /// supplied Resource and Profile-specific resource definition.
        /// </summary>
        /// <param name="sourceResource">The source (underlying) resource.</param>
        /// <param name="resourceDefinition">The profile's definition for the resource.</param>
        public ProfileResourceContentTypes(Resource sourceResource, XElement resourceDefinition)
        {
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

        private static Resource GetResourceForContentType(
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
                new ProfileResourceMembersFilterProvider(),
                contentTypeElt,
                sourceResource);

            return new Resource(sourceResource.ResourceModel, sourceResource.Entity, filterContext);
        }
    }
}

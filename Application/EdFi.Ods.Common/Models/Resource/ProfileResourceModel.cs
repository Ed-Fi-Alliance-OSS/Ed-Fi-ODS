// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Ods.Common.Models.Resource
{
    /// <summary>
    /// Provides access to all of a Profile's resources (both readable and writable versions).
    /// </summary>
    public class ProfileResourceModel
    {
        private readonly XElement _profileDefinition;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileResourceModel"/> class based on
        /// the provided profile definition obtaining resources from the provided <see cref="ResourceModel"/>.
        /// </summary>
        /// <param name="resourceModel">The backing <see cref="ResourceModel"/> for the Profile-constrained model.</param>
        /// <param name="profileDefinition">The Profile definition which is to be used to constraint the Resource model.</param>
        public ProfileResourceModel(ResourceModel resourceModel, XElement profileDefinition)
        {
            ResourceModel = resourceModel;

            _profileDefinition = profileDefinition;
            ProfileName = _profileDefinition.AttributeValue("name");

            // Removed the lazy reference so that the tests will pass
            ResourceByName = new ReadOnlyDictionary<FullName, ProfileResourceContentTypes>(
                CreateResourceByName(
                    resourceModel, 
                    r => r.FullName));
            
            ResourceByApiCollectionName = new ReadOnlyDictionary<FullName, ProfileResourceContentTypes>(
                CreateResourceByName(
                    resourceModel, 
                    r => new FullName(r.SchemaUriSegment(), r.PluralName.ToCamelCase())));
        }

        public string ProfileName { get; }

        public IReadOnlyDictionary<FullName, ProfileResourceContentTypes> ResourceByName { get; }
        
        internal IReadOnlyDictionary<FullName, ProfileResourceContentTypes> ResourceByApiCollectionName { get; }

        public IReadOnlyList<ProfileResourceContentTypes> Resources => ResourceByName.Values.ToList();

        internal ResourceModel ResourceModel { get; }

        public Resource GetResourceByName(FullName resourceName)
        {
            ProfileResourceContentTypes types =
                ResourceByName.FirstOrDefault(
                                   resourceEntry => resourceEntry.Key == resourceName)
                              .Value;

            return types.Readable ?? types.Writable;
        }

        public bool ResourceIsReadable(FullName resourceName) => ResourceByName.Any(
            resourceEntry => resourceEntry.Key == resourceName
                             && resourceEntry.Value.Readable != null);

        public bool ResourceIsWritable(FullName resourceName) => ResourceByName.Any(
            resourceEntry => resourceEntry.Key == resourceName
                             && resourceEntry.Value.Writable != null);

        /// <summary>
        /// Creates the resources by name for the model.
        /// </summary>
        /// <param name="resourceModel"></param>
        /// <returns></returns>
        private Dictionary<FullName, ProfileResourceContentTypes> CreateResourceByName(ResourceModel resourceModel, Func<Resource, FullName> createKey)
        {
            var resourceElts = _profileDefinition.Elements("Resource");

            var resources = new Dictionary<FullName, ProfileResourceContentTypes>();

            resourceElts.ForEach(
                resourceElt =>
                {
                    string resourceName = resourceElt.AttributeValue("name");

                    string logicalName = resourceElt.Attributes()
                                                    .SingleOrDefault(x => x.Name == "logicalSchema")
                                                   ?.Value ?? EdFiConventions.LogicalName;

                    var physicalName = resourceModel.SchemaNameMapProvider
                                                   ?.GetSchemaMapByLogicalName(logicalName)
                                                    .PhysicalName
                                       ?? EdFiConventions.PhysicalSchemaName;

                    // Use the direct/default resource selector on the resource model because we need the main resource, not the contextual one
                    var fullName = new FullName(physicalName, resourceName);
                    var sourceResource = ResourceModel.DefaultResourceSelector.GetByName(fullName);

                    resources[createKey(sourceResource)] = new ProfileResourceContentTypes(sourceResource, resourceElt);
                });

            return resources;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Utils.Profiles;

namespace EdFi.Ods.Common.Models.Resource
{
    // NOTE: This should be used as a transient object, or the Lazy implementation of the _underlyingResourceModel assignment will need to be reworked.
    public class ProfilesAppliedResourceModel : IResourceModel
    {
        private readonly ProfilesAppliedResourceSelector _resourceSelector;

        public ProfilesAppliedResourceModel(
            ContentTypeUsage usage,
            ProfileResourceModel[] profileResourceModels)
        {
            if (profileResourceModels == null || profileResourceModels.Length == 0)
            {
                throw new ArgumentException("Argument must be non-null, and non-empty.", nameof(profileResourceModels));
            }

            if (profileResourceModels.Select(x => x.ResourceModel)
                                     .Distinct()
                                     .Count() > 1)
            {
                throw new ArgumentException("Supplied profile resource models do not have the same underlying resource model.");
            }

            _resourceSelector = new ProfilesAppliedResourceSelector(profileResourceModels, usage);

            var resourceModel = profileResourceModels.First()
                                                     .ResourceModel;

            SchemaNameMapProvider = resourceModel.SchemaNameMapProvider;

            // Assign the current selector as the contextual selector
            _resourceSelector.UnderlyingResourceSelector = ((IHasContextualResourceSelector) resourceModel)
               .SetContextualResourceSelector(_resourceSelector);
        }

        /// <summary>
        /// Gets the Resource using the specified name.
        /// </summary>
        /// <param name="resourceName">The name of the resource to be retrieved.</param>
        /// <returns>The matching resource.</returns>
        public Resource GetResourceByFullName(FullName resourceName)
        {
            return _resourceSelector.GetByName(resourceName);
        }

        /// <summary>
        /// Get a read-only of all the resources available in the model.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Resource> GetAllResources()
        {
            return _resourceSelector.GetAll();
        }

        /// <summary>
        /// Gets a provider capable of mapping schema names between logical, physical, proper case name and URI segment representations.
        /// </summary>
        public ISchemaNameMapProvider SchemaNameMapProvider { get; }

        private class ProfilesAppliedResourceSelector : IResourceSelector
        {
            private readonly ProfileResourceModel[] _profileResourceModels;
            private readonly ContentTypeUsage _usage;

            public ProfilesAppliedResourceSelector(ProfileResourceModel[] profileResourceModels, ContentTypeUsage usage)
            {
                _profileResourceModels = profileResourceModels;
                _usage = usage;
            }

            public IResourceSelector UnderlyingResourceSelector { get; internal set; }

            public IReadOnlyList<Resource> GetAll()
            {
                return _profileResourceModels.SelectMany(m => m.Resources)
                                             .Select(
                                                  r => _usage == ContentTypeUsage.Readable
                                                      ? r.Readable
                                                      : r.Writable)
                                             .Where(r => r != null)
                                             .ToList();
            }

            public Resource GetByName(FullName fullName)
            {
                var allProfileResources =
                    (from m in _profileResourceModels
                     let ct = m.ResourceByName.GetValueOrDefault(fullName)
                     where ct != null
                     select _usage == ContentTypeUsage.Readable
                         ? ct.Readable
                         : ct.Writable)
                   .ToArray();

                // If we have any Profiles that apply to the requested resource
                if (allProfileResources.Any())
                {
                    // If none of the Profiles that apply to the requested resource have the appropriate ContentType (Read/Write)
                    // then we can't continue because the resource is inaccessible.
                    if (allProfileResources.All(x => x == null))
                    {
                        throw new ProfileContentTypeException(
                            string.Format(
                                "There is no {0} content type available to the caller for the requested resource.",
                                _usage));
                    }

                    // Return all the profile-filtered versions of the resource
                    return new Resource(
                        allProfileResources.Where(x => x != null)
                                           .ToArray());
                }

                // No resources means there's no Profile in play so we should return the main ResourceModel's resource
                return UnderlyingResourceSelector.GetByName(fullName);
            }
        }
    }
}

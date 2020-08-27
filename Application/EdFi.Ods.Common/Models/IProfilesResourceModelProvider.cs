// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Models
{
    /// <summary>
    /// Defines a method for obtaining a Profile-based version of the <see cref="ResourceModel"/>.
    /// </summary>
    public interface IProfileResourceModelProvider
    {
        /// <summary>
        /// Get a Profile-based version of the <see cref="ResourceModel"/> for the Profile specified by name.
        /// </summary>
        /// <param name="profileName">The name of the profile for which a model should be created.</param>
        /// <returns>The <see cref="ProfileResourceModel"/> for the specified profile.</returns>
        ProfileResourceModel GetProfileResourceModel(string profileName);
    }

    public class ProfileResourceModelProvider : IProfileResourceModelProvider
    {
        private readonly ConcurrentDictionary<string, ProfileResourceModel> _modelByProfileName
            = new ConcurrentDictionary<string, ProfileResourceModel>(StringComparer.InvariantCultureIgnoreCase);
        private readonly IProfileMetadataProvider _profileMetadataProvider;

        private readonly Lazy<ResourceModel> _resourceModel;

        public ProfileResourceModelProvider(
            IResourceModelProvider resourceModelProvider,
            IProfileMetadataProvider profileMetadataProvider)
        {
            _profileMetadataProvider = profileMetadataProvider;

            _resourceModel = new Lazy<ResourceModel>(resourceModelProvider.GetResourceModel);
        }

        public ProfileResourceModel GetProfileResourceModel(string profileName)
        {
            return _modelByProfileName.GetOrAdd(
                profileName,
                pn =>
                    new ProfileResourceModel(
                        _resourceModel.Value,
                        _profileMetadataProvider.GetProfileDefinition(profileName)));
        }
    }

    public class ProfilePassthroughResourceModelProvider : IProfileResourceModelProvider
    {
        public ProfileResourceModel GetProfileResourceModel(string profileName)
        {
            // Force a bad request if a profile claim exists and profiles are disabled.
            throw new BadRequestException($"Profiles are not enabled for profile {profileName}.");
        }
    }
}

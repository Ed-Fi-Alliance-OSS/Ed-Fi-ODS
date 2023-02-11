// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Extensions;
using log4net;

namespace EdFi.Ods.Common.Metadata.Profiles
{
    public class ProfileMetadataProvider : IProfileMetadataProvider
    {
        private readonly IProfileDefinitionsProvider[] _profileDefinitionsProviders;

        private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileMetadataProvider));

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileMetadataProvider"/> class.
        /// </summary>
        public ProfileMetadataProvider(IProfileDefinitionsProvider[] profileDefinitionsProviders)
        {
            _profileDefinitionsProviders = profileDefinitionsProviders;
        }

        // <summary>
        /// Indicates that the instance has profile metadata data.
        /// </summary>
        public bool HasProfileData
        {
            get { return ProfileDefinitionsByName.Any(); }
        }

        /// <summary>
        /// Collection of valid profile definitions, organized by name.
        /// </summary>
        public IReadOnlyDictionary<string, XElement> ProfileDefinitionsByName =>
                _profileDefinitionsProviders.SelectMany(x => x.GetProfileDefinitions()).ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Indicates whether the specified Profile definition exists.
        /// </summary>
        bool IProfileMetadataProvider.ContainsProfileDefinition(string profileName)
        {
            return ProfileDefinitionsByName.ContainsKey(profileName);
        }

        /// <summary>
        /// Gets the specified Profile definition by name.
        /// </summary>
        XElement IProfileMetadataProvider.GetProfileDefinition(string profileName)
        {
            return ProfileDefinitionsByName.GetValueOrThrow(profileName, "Unable to find profile '{0}'.");
        }

        /// <inheritdoc cref="IProfileMetadataProvider.GetValidationResults" />
        public MetadataValidationResult[] GetValidationResults()
            => _profileDefinitionsProviders.SelectMany(x => x.ValidationResultsByMetadataStream)
                .Select(kvp => new MetadataValidationResult(kvp.Key.name, kvp.Key.source, kvp.Value))
                .ToArray();
    }
}

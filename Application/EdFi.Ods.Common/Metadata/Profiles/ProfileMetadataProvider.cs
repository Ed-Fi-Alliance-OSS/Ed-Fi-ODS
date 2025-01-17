// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Autofac.Extras.DynamicProxy;
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

        /// <summary>
        /// Collection of valid profile definitions, organized by name.
        /// </summary>
        public IReadOnlyDictionary<string, XElement> GetProfileDefinitionsByName()
        {
            var profileDefinitions = _profileDefinitionsProviders.SelectMany(x => x.GetProfileDefinitions()).ToArray();

            var profilesWithDuplicateDefinitions = profileDefinitions
                .GroupBy(x => x.Key, StringComparer.OrdinalIgnoreCase)
                .Where(x => x.Count() > 1)
                .SelectMany(x => profileDefinitions.Where(y => y.Key.Equals(x.Key, StringComparison.OrdinalIgnoreCase)))
                .ToArray();

            if (profilesWithDuplicateDefinitions.Any())
            {
                var duplicateProfileNames = string.Join(", ", profilesWithDuplicateDefinitions.Select(x => x.Key).Distinct());

                _logger.Error(
                    $"The following profile names were not loaded because multiple XML definitions were provided: {duplicateProfileNames}");
            }

            return profileDefinitions.Except(profilesWithDuplicateDefinitions).ToDictionary(
                x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        }

        /// <inheritdoc cref="IProfileMetadataProvider.GetValidationResults" />
        public MetadataValidationResult[] GetValidationResults()
            => _profileDefinitionsProviders.SelectMany(x => x.ValidationResultsByMetadataStream)
                .Select(kvp => new MetadataValidationResult(kvp.Key.name, kvp.Key.source, kvp.Value))
                .ToArray();
    }
}

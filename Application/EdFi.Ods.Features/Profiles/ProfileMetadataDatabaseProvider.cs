// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Common;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Metadata.Profiles;
using FluentValidation.Results;
using log4net;

namespace EdFi.Ods.Features.Profiles
{
    public class ProfileMetadataDatabaseProvider : IProfileMetadataProvider, IProfileResourceNamesProvider
    {
        private const string DefinitionsCacheKeyPrefix = "Profile.Definitions";
        private const string ResourcesCacheKeyPrefix = "Profile.Resources";
        private const string ValidationsCacheKeyPrefix = "Profile.Definitions";
        private const string CacheActiveKey = "ProfileCache.Active";

        private readonly IUsersContextFactory _usersContextFactory;
        private readonly ICacheProvider _cacheProvider;
        private readonly IProfileMetadataValidator _profileMetadataValidator;

        private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileMetadataDatabaseProvider));

        public ProfileMetadataDatabaseProvider(
            IUsersContextFactory usersContextFactory,
            ICacheProvider cacheProvider,
            IProfileMetadataValidator profileMetadataValidator)
        {
            _usersContextFactory = Preconditions.ThrowIfNull(usersContextFactory, nameof(usersContextFactory));
            _cacheProvider = Preconditions.ThrowIfNull(cacheProvider, nameof(cacheProvider));
            _profileMetadataValidator = Preconditions.ThrowIfNull(profileMetadataValidator, nameof(profileMetadataValidator));
        }

        bool IProfileMetadataProvider.ContainsProfileDefinition(string profileName)
        {
            EnsureProfileDefinitionsCacheIsRefreshedFromDatabase();

            return _cacheProvider.TryGetCachedObject($"{DefinitionsCacheKeyPrefix}.{profileName.ToLowerInvariant()}", out object _);
        }

        XElement IProfileMetadataProvider.GetProfileDefinition(string profileName)
        {
            EnsureProfileDefinitionsCacheIsRefreshedFromDatabase();

            if (!_cacheProvider.TryGetCachedObject($"{DefinitionsCacheKeyPrefix}.{profileName.ToLowerInvariant()}", out XElement profileDefinition))
            {
                return null;
            }

            return profileDefinition;
        }

        MetadataValidationResult[] IProfileMetadataProvider.GetValidationResults()
        {
            if (!_cacheProvider.TryGetCachedObject($"{ValidationsCacheKeyPrefix}", out IDictionary<(string name, string source), ValidationResult> validationResults))
            {
                return new MetadataValidationResult[] { };
            }

            return validationResults
                .Select(kvp => new MetadataValidationResult(kvp.Key.name, kvp.Key.source, kvp.Value))
                .ToArray();
        }

        List<ProfileAndResourceNames> IProfileResourceNamesProvider.GetProfileResourceNames()
        {
            EnsureProfileDefinitionsCacheIsRefreshedFromDatabase();

            if (!_cacheProvider.TryGetCachedObject($"{ResourcesCacheKeyPrefix}", out List<ProfileAndResourceNames> profileResouces))
            {
                return new();
            }

            return profileResouces;
        }

        private void EnsureProfileDefinitionsCacheIsRefreshedFromDatabase()
        {
            if (!HasCacheExpired)
            {
                return;
            }

            // Add Active key to cache
            _cacheProvider.SetCachedObject(CacheActiveKey, true);

            List<Profile> profiles;
            using (var usersContext = _usersContextFactory.CreateContext())
            {
                profiles = usersContext.Profiles.ToList();
            }

            List<ProfileAndResourceNames> profileAndResourceNames = new();
            ConcurrentDictionary<(string name, string source), ValidationResult> validationResultsByProfile = new();

            foreach (var profile in profiles)
            {
                if (string.IsNullOrEmpty(profile.ProfileDefinition))
                {
                    var validationResult = new ValidationResult
                    {
                        Errors = new List<ValidationFailure>()
                        {
                            new ValidationFailure("root", "Profile Definition is empty")
                        }
                    };

                    validationResultsByProfile.AddOrUpdate(
                        (profile.ProfileName, "Database"),
                        validationResult,
                        (key, existingResult) => validationResult);

                    continue;
                }

                try
                {
                    var profileDefinition = XDocument.Parse(profile.ProfileDefinition);

                    // TODO: Profiles in xml are not valid; ignoring validation until fixed
                    var validationResult = _profileMetadataValidator.Validate(profileDefinition);

                    if (!validationResult.IsValid)
                    {
                        _logger.Error($"Profiles schema validation failed: {validationResult}");

                        validationResultsByProfile.AddOrUpdate(
                            (profile.ProfileName, "Database"),
                            validationResult,
                            (key, existingResult) => validationResult);

                        continue;
                    }

                    _cacheProvider.SetCachedObject($"{DefinitionsCacheKeyPrefix}.{profile.ProfileName.ToLowerInvariant()}", profileDefinition.Root.FirstNode);
                    profileAndResourceNames.AddRange(GetProfileResources(profile));
                }
                catch (XmlException)
                {
                    var validationResult = new ValidationResult
                    {
                        Errors = new List<ValidationFailure>()
                        {
                            new ValidationFailure("root", "Profile Definition is not in valid XML format")
                        }
                    };

                    validationResultsByProfile.AddOrUpdate(
                        (profile.ProfileName, "Database"),
                        validationResult,
                        (key, existingResult) => validationResult);
                }
            }

            // Add Profile and resources to cache
            _cacheProvider.SetCachedObject($"{ResourcesCacheKeyPrefix}", profileAndResourceNames);

            // Add Validation results to cache
            _cacheProvider.SetCachedObject($"{ValidationsCacheKeyPrefix}", validationResultsByProfile);
        }

        private bool HasCacheExpired
        {
            get
            {
                return !_cacheProvider.TryGetCachedObject(CacheActiveKey, out object _);
            }
        }

        private IEnumerable<ProfileAndResourceNames> GetProfileResources(Profile profile)
        {
            var profileDefinition = XElement.Parse(profile.ProfileDefinition);
            return from r in profileDefinition.Descendants("Resource")
                   select new ProfileAndResourceNames
                   {
                       ProfileName = profile.ProfileName,
                       ResourceName = (string)r.Attribute("name")
                   };
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
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
using StackExchange.Redis;

namespace EdFi.Ods.Features.Profiles
{
    public class AdminDatabaseProfileDefinitionsProvider : IProfileDefinitionsProvider
    {
        private const string DefinitionsCacheKeyPrefix = "profile.definitions";
        private const string CacheActiveKey = "profile.cache-active";

        private readonly IUsersContextFactory _usersContextFactory;
        private readonly ICacheProvider _cacheProvider;
        private readonly IProfileMetadataValidator _profileMetadataValidator;
        private readonly ConcurrentDictionary<(string name, string source), ValidationResult> _validationResultsByProfile = new();

        private readonly ILog _logger = LogManager.GetLogger(typeof(AdminDatabaseProfileDefinitionsProvider));

        public AdminDatabaseProfileDefinitionsProvider(
            IUsersContextFactory usersContextFactory,
            ICacheProvider cacheProvider,
            IProfileMetadataValidator profileMetadataValidator)
        {
            _usersContextFactory = Preconditions.ThrowIfNull(usersContextFactory, nameof(usersContextFactory));
            _cacheProvider = Preconditions.ThrowIfNull(cacheProvider, nameof(cacheProvider));
            _profileMetadataValidator = Preconditions.ThrowIfNull(profileMetadataValidator, nameof(profileMetadataValidator));
        }

        ConcurrentDictionary<(string name, string source), ValidationResult> IProfileDefinitionsProvider.ValidationResultsByMetadataStream =>
                    _validationResultsByProfile;

        IDictionary<string, XElement> IProfileDefinitionsProvider.GetProfileDefinitions()
        {
            EnsureProfileDefinitionsCacheIsRefreshedFromDatabase();

            if (!_cacheProvider.TryGetCachedObject($"{DefinitionsCacheKeyPrefix}", out IDictionary<string, XElement> profileDefinitions))
            {
                return new Dictionary<string, XElement>();
            }

            return profileDefinitions;
        }

        private void EnsureProfileDefinitionsCacheIsRefreshedFromDatabase()
        {
            if (!HasCacheExpired)
            {
                return;
            }

            // Add Active key to cache
            _cacheProvider.SetCachedObject(CacheActiveKey, true);

            var profiles = LoadProfilesFromDatabase();

            var profileDefinitions = new Dictionary<string, XElement>(StringComparer.OrdinalIgnoreCase);
            foreach (var profile in profiles)
            {
                if (string.IsNullOrEmpty(profile.ProfileDefinition))
                {
                    RegisterValidationResult(profile.ProfileName, "root", "Profile Definition is empty");

                    continue;
                }

                try
                {
                    var profileDefinition = XDocument.Parse(profile.ProfileDefinition);

                    var validationResult = _profileMetadataValidator.Validate(profileDefinition);

                    if (!validationResult.IsValid)
                    {
                        _logger.Error($"Profiles schema validation failed: {validationResult}");

                        _validationResultsByProfile.AddOrUpdate(
                            (profile.ProfileName, "Database"),
                            validationResult,
                            (key, existingResult) => validationResult);

                        continue;
                    }

                    profileDefinitions.Add(profile.ProfileName, (XElement)profileDefinition.Root.FirstNode);
                }
                catch (XmlException)
                {
                    RegisterValidationResult(profile.ProfileName, "root", "Profile Definition is not in valid XML format");
                }
            }

            // Add profile definitions to cache
            _cacheProvider.SetCachedObject($"{DefinitionsCacheKeyPrefix}", profileDefinitions);
        }

        private bool HasCacheExpired
        {
            get
            {
                return !_cacheProvider.TryGetCachedObject(CacheActiveKey, out object _);
            }
        }

        private void RegisterValidationResult(string profileName, string propertyName, string errorMessage)
        {
            var validationResult = new ValidationResult
            {
                Errors = new List<ValidationFailure>()
                        {
                            new ValidationFailure(propertyName, errorMessage)
                        }
            };

            _validationResultsByProfile.AddOrUpdate(
                (profileName, "Database"),
                validationResult,
                (key, existingResult) => validationResult);
        }

        private List<Profile> LoadProfilesFromDatabase()
        {
            using (var usersContext = _usersContextFactory.CreateContext())
            {
                return usersContext.Profiles.ToList();
            }
        }
    }
}

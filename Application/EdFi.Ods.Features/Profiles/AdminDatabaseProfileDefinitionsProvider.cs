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
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata.Profiles;
using FluentValidation.Results;
using log4net;

namespace EdFi.Ods.Features.Profiles
{
    public class AdminDatabaseProfileDefinitionsProvider : IProfileDefinitionsProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(AdminDatabaseProfileDefinitionsProvider));
        private readonly IProfileMetadataValidator _profileMetadataValidator;
        private readonly IUsersContextFactory _usersContextFactory;
        private readonly ConcurrentDictionary<(string name, string source), ValidationResult> _validationResultsByProfile = new();

        public AdminDatabaseProfileDefinitionsProvider(
            IUsersContextFactory usersContextFactory,
            IProfileMetadataValidator profileMetadataValidator)
        {
            _usersContextFactory = Preconditions.ThrowIfNull(usersContextFactory, nameof(usersContextFactory));
            _profileMetadataValidator = Preconditions.ThrowIfNull(profileMetadataValidator, nameof(profileMetadataValidator));
        }

        ConcurrentDictionary<(string name, string source), ValidationResult> 
            IProfileDefinitionsProvider.ValidationResultsByMetadataStream
            => _validationResultsByProfile;

        IDictionary<string, XElement> IProfileDefinitionsProvider.GetProfileDefinitions()
        {
            var profiles = LoadProfilesFromDatabase();

            var profileDefinitionByName = new Dictionary<string, XElement>(StringComparer.OrdinalIgnoreCase);

            foreach (var profile in profiles)
            {
                // Empty Profile definitions are expected in the Admin database for definitions that are sourced elsewhere
                // The empty entries allow them to be presented in the Admin UI, but they should be ignored here.
                if (string.IsNullOrEmpty(profile.ProfileDefinition))
                {
                    continue;
                }

                try
                {
                    var profileDefinition = XElement.Parse(profile.ProfileDefinition);

                    // Wrap the profile definition element in a Profiles document for validation
                    var profilesElement = XElement.Parse("<Profiles/>");
                    profilesElement.Add(profileDefinition);
                    var validationDoc = new XDocument(profilesElement);
                    
                    var validationResult = _profileMetadataValidator.Validate(validationDoc);

                    if (!validationResult.IsValid)
                    {
                        _logger.Error($"Profiles schema validation failed: {validationResult}");

                        _validationResultsByProfile.AddOrUpdate(
                            (profile.ProfileName, "Database"),
                            validationResult,
                            (key, existingResult) => validationResult);

                        continue;
                    }

                    profileDefinitionByName.Add(profileDefinition.AttributeValue("name"), profileDefinition);
                }
                catch (XmlException)
                {
                    RegisterValidationResult(profile.ProfileName, "root", "Profile Definition is not in valid XML format");
                }
            }

            return profileDefinitionByName;
        }

        private void RegisterValidationResult(string profileName, string propertyName, string errorMessage)
        {
            var validationResult = new ValidationResult
            {
                Errors = new List<ValidationFailure>() { new ValidationFailure(propertyName, errorMessage) }
            };

            _validationResultsByProfile.AddOrUpdate(
                (profileName, "Database"),
                validationResult,
                (key, existingResult) => validationResult);
        }

        private List<Profile> LoadProfilesFromDatabase()
        {
            using var usersContext = _usersContextFactory.CreateContext();

            return usersContext.Profiles.Where(p => p.ProfileDefinition != null).ToList();
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata.StreamProviders.Profiles;
using FluentValidation.Results;
using log4net;

namespace EdFi.Ods.Common.Metadata.Profiles
{
    public class ProfileMetadataProvider : IProfileMetadataProvider, IProfileResourceNamesProvider
    {
        private readonly Lazy<IReadOnlyList<XDocument>> _allDocs;
        private readonly IProfileMetadataValidator _profileMetadataValidator;
        private readonly IProfilesMetadataStreamsProvider[] _metadataStreamsProviders;
        private readonly Lazy<IDictionary<string, XElement>> _profileDefinitionByName;
        private readonly Lazy<List<ProfileAndResourceNames>> _profileResources;

        private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileMetadataProvider));
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileMetadataProvider"/> class.
        /// </summary>
        public ProfileMetadataProvider(
            IProfileMetadataValidator profileMetadataValidator,
            IProfilesMetadataStreamsProvider[] metadataStreamsProviders)
        {
            _profileMetadataValidator = profileMetadataValidator;
            _metadataStreamsProviders = metadataStreamsProviders;

            if (metadataStreamsProviders.Length == 0)
            {
                throw new Exception("No profiles metadata stream providers have been registered.");
            }
            
            _allDocs = new Lazy<IReadOnlyList<XDocument>>(LazyInitializeXDocuments);
            _profileDefinitionByName = new Lazy<IDictionary<string, XElement>>(LazyInitializeProfileDefinitions);
            _profileResources = new Lazy<List<ProfileAndResourceNames>>(LazyInitializeProfileResources);
        }

        /// <summary>
        /// Indicates that the instance has profile metadata data.
        /// </summary>
        public bool HasProfileData
        {
            get { return _profileDefinitionByName.Value.Any(); }
        }

        /// <summary>
        /// Gets the specified Profile definition by name.
        /// </summary>
        XElement IProfileMetadataProvider.GetProfileDefinition(string profileName)
        {
            return _profileDefinitionByName.Value.GetValueOrThrow(profileName, "Unable to find profile '{0}'.");
        }

        /// <inheritdoc cref="IProfileMetadataProvider.GetValidationResults" />
        public MetadataValidationResult[] GetValidationResults()
            => _validationResultsByMetadataStream
                .Select(kvp => new MetadataValidationResult(kvp.Key.name, kvp.Key.source, kvp.Value))
                .ToArray();

        /// <summary>
        /// Gets a list of tuples containing the names of associated Profiles and Resources.
        /// </summary>
        /// <returns>A list of tuples containing associated Profile and Resource names.</returns>
        List<ProfileAndResourceNames> IProfileResourceNamesProvider.GetProfileResourceNames()
        {
            return _profileResources.Value;
        }

        private readonly ConcurrentDictionary<(string name, string source), ValidationResult> _validationResultsByMetadataStream = new();

        private XDocument[] LazyInitializeXDocuments()
        {
            return _metadataStreamsProviders
                .SelectMany(p => p.GetStreams())
                .Select(
                    s =>
                    {
                        using var reader = new StreamReader(s.Stream);
                        var profilesDocument = XDocument.Load(reader);

                        var validationResult = _profileMetadataValidator.Validate(profilesDocument);

                        _validationResultsByMetadataStream.AddOrUpdate(
                            (s.Name, s.Source),
                            validationResult,
                            (key, existingResult) => validationResult); 
                            
                        if (validationResult.IsValid)
                        {
                            return profilesDocument;
                        }
                        
                        _logger.Error($"Profiles schema validation failed: {validationResult}");
                    
                        return null;
                    })
                .Where(d => d != null)
                .ToArray();
        }

        private IDictionary<string, XElement> LazyInitializeProfileDefinitions()
        {
            return _allDocs.Value.SelectMany(x => x.Descendants("Profile"))
                .ToDictionary(x => x.AttributeValue("name"), x => x, StringComparer.InvariantCultureIgnoreCase);
        }

        private List<ProfileAndResourceNames> LazyInitializeProfileResources()
        {
            return _profileDefinitionByName.Value.Values.SelectMany(GetProfileResources).ToList();
        }

        private IEnumerable<ProfileAndResourceNames> GetProfileResources(XElement profileElt)
        {
            return from r in profileElt.Descendants("Resource")
                select new ProfileAndResourceNames
                {
                    ProfileName = profileElt.AttributeValue("name"),
                    ResourceName = (string)r.Attribute("name")
                };
        }
    }
}

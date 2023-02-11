// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata.StreamProviders.Profiles;
using FluentValidation.Results;
using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace EdFi.Ods.Common.Metadata.Profiles
{
    public class EmbeddedResourceProfileDefinitionsProvider : IProfileDefinitionsProvider
    {
        private readonly IProfileMetadataValidator _profileMetadataValidator;
        private readonly IProfilesMetadataStreamsProvider[] _metadataStreamsProviders;
        private readonly Lazy<IReadOnlyList<XDocument>> _allDocs;
        private readonly Lazy<IDictionary<string, XElement>> _profileDefinitionByName;
        public readonly ConcurrentDictionary<(string name, string source), ValidationResult> _validationResultsByMetadataStream = new();

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmbeddedResourceProfileDefinitionsProvider));

        public EmbeddedResourceProfileDefinitionsProvider(
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
        }

        IDictionary<string, XElement> IProfileDefinitionsProvider.GetProfileDefinitions() 
            => _profileDefinitionByName.Value;

        ConcurrentDictionary<(string name, string source), ValidationResult> IProfileDefinitionsProvider.ValidationResultsByMetadataStream =>
            _validationResultsByMetadataStream;

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
    }
}

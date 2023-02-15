// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EdFi.Ods.CodeGen.Providers.Impl;
using EdFi.Ods.Common.Metadata.Profiles;
using EdFi.Ods.Common.Metadata.StreamProviders.Common;
using EdFi.Ods.Common.Metadata.StreamProviders.Profiles;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.Profiles;

namespace EdFi.Ods.CodeGen.Metadata
{
    public static class MetadataHelper
    {
        private static readonly MetadataFolderProvider _metadataFolderProvider;

        /// <summary>
        ///  NOTE: This is legacy code and it needs to be refactored
        /// </summary>
        static MetadataHelper()
        {
            var codeRepository = new DeveloperCodeRepositoryProvider();
            _metadataFolderProvider = new MetadataFolderProvider(codeRepository);
        }

        private static IProfilesMetadataStreamsProvider GetStreamsProvider(string projectPath)
        {
            string profilesFileName = Path.Combine(projectPath, "Profiles.xml");

            if (File.Exists(profilesFileName))
            {
                return new SingleFileMetadataStreamsProvider(profilesFileName);
            }

            return new NullFileMetadatStreamsProvider();
        }

        private class NullFileMetadatStreamsProvider : IProfilesMetadataStreamsProvider
        {
            public IEnumerable<MetadataStream> GetStreams() => Array.Empty<MetadataStream>();
        }
        
        private class SingleFileMetadataStreamsProvider : IProfilesMetadataStreamsProvider
        {
            private readonly string _fileName;

            public SingleFileMetadataStreamsProvider(string fileName)
            {
                _fileName = fileName;
            }

            public IEnumerable<MetadataStream> GetStreams()
            {
                yield return new MetadataStream(Path.GetFileName(_fileName), _fileName, GetMemoryStream());
            }

            private Stream GetMemoryStream()
            {
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(_fileName)));

                return ms;
            }
        }
        
        public static ProfileMetadataProvider GetProfileMetadataProvider(IResourceModelProvider resourceModelProvider, string projectPath)
        {
            IProfilesMetadataStreamsProvider[] streamProviders =
            {
                GetStreamsProvider(projectPath)
            };

            IProfileDefinitionsProvider[] definitionsProviders =
            {
                new EmbeddedResourceProfileDefinitionsProvider(new ProfileMetadataValidator(resourceModelProvider), streamProviders)
            };

            var profileMetadataProvider = new ProfileMetadataProvider(definitionsProviders);

            var failedValidationResults = profileMetadataProvider.GetValidationResults()
                .Where(r => !r.ValidationResult.IsValid)
                .ToArray();

            if (failedValidationResults.Any())
            {
                var result = failedValidationResults.First();

                throw new Exception($"Profile validation failed for '{result.Name}' (from '{result.Source}'): {result.ValidationResult}");
            }

            return profileMetadataProvider;
        }

        public static ProfileResourceNamesProvider GetProfileResourceNamesProvider(IResourceModelProvider resourceModelProvider, string projectPath)
        {
            var profileResourceNamesProvider = new ProfileResourceNamesProvider(GetProfileMetadataProvider(resourceModelProvider, projectPath));

            return profileResourceNamesProvider;
        }
    }
}
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.CodeGen.Metadata;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Metadata.Schemas;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class ValidatingProfileMetadataProvider : IProfileMetadataProvider, IProfileResourceNamesProvider
    {
        private readonly Lazy<Profile[]> _codeGenProfiles;
        private readonly Lazy<IDictionary<string, XElement>> _profileDefinitionByName;
        private readonly Lazy<List<ProfileAndResourceNames>> _profileResources;
        private readonly Lazy<XDocument> _profileXDoc;
        private readonly ResourceModel _resourceModel;

        public ValidatingProfileMetadataProvider(string profilePath, IResourceModelProvider resourceModelProvider)
        {
            if (profilePath == null)
            {
                throw new ArgumentNullException(nameof(profilePath));
            }

            if (!Directory.Exists(profilePath))
            {
                throw new DirectoryNotFoundException($"{profilePath} not found");
            }

            if (resourceModelProvider == null)
            {
                throw new ArgumentNullException(nameof(resourceModelProvider));
            }

            _resourceModel = resourceModelProvider.GetResourceModel();
            _profileDefinitionByName = new Lazy<IDictionary<string, XElement>>(LazyInitializeProfileDefinitions);
            _profileXDoc = new Lazy<XDocument>(() => MetadataHelper.GetProfilesXDocument(profilePath));
            _profileResources = new Lazy<List<ProfileAndResourceNames>>(LazyInitializeProfileResources);

            _codeGenProfiles = new Lazy<Profile[]>(
                () => MetadataHelper.GetProfiles(ProfileXDocument)
                    .Profile);
        }

        /// <summary>
        /// Get the Profile elements from the deserialized XML profile for use in CodeGen
        /// specific applications that use them.
        /// </summary>
        /// <returns></returns>
        private Profile[] CodeGenProfiles => _codeGenProfiles.Value;

        /// <summary>
        /// Gets the underlying XDocument that represents the Profile.
        /// </summary>
        private XDocument ProfileXDocument => _profileXDoc.Value;

        /// <summary>
        /// Indicates that the instance has profile metadata data.
        /// </summary>
        public bool HasProfileData
            => ProfileXDocument.Nodes()
                .Any();

        /// <summary>
        /// Gets the specified Profile definition by name.
        /// </summary>
        public XElement GetProfileDefinition(string profileName)
        {
            if (profileName == null)
            {
                throw new ArgumentException("Null profile name provided.");
            }

            return _profileDefinitionByName.Value.GetValueOrThrow(
                profileName,
                "Unable to find profile '{0}'.");
        }

        List<ProfileAndResourceNames> IProfileResourceNamesProvider.GetProfileResourceNames() => _profileResources.Value;

        private IDictionary<string, XElement> LazyInitializeProfileDefinitions()
        {
            if (!HasProfileData)
            {
                throw new ArgumentException("Profile does not exist.");
            }

            ValidateMetadata();

            return ProfileXDocument
                .Descendants("Profile")
                .ToDictionary(
                    x => x.AttributeValue("name"),
                    x => x,
                    StringComparer
                        .InvariantCultureIgnoreCase);
        }

        private List<ProfileAndResourceNames> LazyInitializeProfileResources()
            => _profileDefinitionByName.Value.Values
                .SelectMany(GetProfileResources)
                .ToList();

        private IEnumerable<ProfileAndResourceNames> GetProfileResources(XElement profileElt)
            => from r in profileElt.Descendants("Resource")
                select new ProfileAndResourceNames
                {
                    ProfileName = profileElt.AttributeValue(
                        "name"),
                    ResourceName = (string) r.Attribute(
                        "name")
                };

        private void ValidateMetadata()
        {
            MetadataHelper.ValidateProfileXml(ProfileXDocument.ToString());

            new ProfileMetadataValidator(_resourceModel, CodeGenProfiles, ProfileXDocument)
                .ValidateMetadata();
        }
    }
}

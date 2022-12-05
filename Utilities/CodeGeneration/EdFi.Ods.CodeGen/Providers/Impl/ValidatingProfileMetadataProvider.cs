// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using EdFi.Ods.CodeGen.Metadata;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Metadata.Schemas;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Models.Validation;
using EdFi.Ods.Common.Utils.Profiles;
using log4net;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class ValidatingProfileMetadataProvider : IProfileMetadataProvider, IProfileResourceNamesProvider
    {
        private readonly IProfileValidationReporter _profileValidationReporter;
        private readonly Lazy<Profile[]> _codeGenProfiles;
        private readonly Lazy<IDictionary<string, XElement>> _profileDefinitionByName;
        private readonly Lazy<List<ProfileAndResourceNames>> _profileResourceNames;
        private readonly Lazy<XDocument> _profileXDoc;
        private readonly ResourceModel _resourceModel;
        private Lazy<ProfilesAppliedResourceModel> _readableProfileResourceModel;
        private Lazy<ProfilesAppliedResourceModel> _writableProfileResourceModel;

        private readonly ILog _logger = LogManager.GetLogger(typeof(ValidatingProfileMetadataProvider));

        public ValidatingProfileMetadataProvider(
            string profilePath,
            IResourceModelProvider resourceModelProvider,
            IProfileValidationReporter profileValidationReporter)
        {
            if (profilePath == null)
            {
                throw new ArgumentNullException(nameof(profilePath));
            }

            _profileValidationReporter = profileValidationReporter;

            if (!Directory.Exists(profilePath))
            {
                throw new DirectoryNotFoundException($"{profilePath} not found");
            }

            if (resourceModelProvider == null)
            {
                throw new ArgumentNullException(nameof(resourceModelProvider));
            }

            _resourceModel = resourceModelProvider.GetResourceModel();

            _profileDefinitionByName = new Lazy<IDictionary<string, XElement>>(LazyInitializeProfileDefinitionByName);
            _profileXDoc = new Lazy<XDocument>(() => MetadataHelper.GetProfilesXDocument(profilePath));

            _profileResourceNames = new Lazy<List<ProfileAndResourceNames>>(LazyInitializeProfileResourceNames);

            _readableProfileResourceModel = new Lazy<ProfilesAppliedResourceModel>(
                () => new ProfilesAppliedResourceModel(
                    ContentTypeUsage.Readable,
                    _profileXDoc.Value.XPathSelectElements("//Profile[Resource/ReadContentType]")
                        .Select(p => new ProfileResourceModel(_resourceModel, p, _profileValidationReporter))
                        .ToArray()));

            _writableProfileResourceModel = new Lazy<ProfilesAppliedResourceModel>(
                () => new ProfilesAppliedResourceModel(
                    ContentTypeUsage.Writable,
                    _profileXDoc.Value.XPathSelectElements("//Profile[Resource/WriteContentType]")
                        .Select(p => new ProfileResourceModel(_resourceModel, p, _profileValidationReporter))
                        .ToArray()));
        }

        /// <summary>
        /// Indicates that the instance has profile metadata data.
        /// </summary>
        public bool HasProfileData 
        {
            get => _profileXDoc.Value.Nodes().Any();
        }
        
        /// <summary>
        /// Gets the specified Profile definition by name.
        /// </summary>
        XElement IProfileMetadataProvider.GetProfileDefinition(string profileName)
        {
            if (profileName == null)
            {
                throw new ArgumentNullException(nameof(profileName));
            }

            return _profileDefinitionByName.Value.GetValueOrThrow(
                profileName,
                "Unable to find profile '{0}'.");
        }

        List<ProfileAndResourceNames> IProfileResourceNamesProvider.GetProfileResourceNames() => _profileResourceNames.Value;

        private IDictionary<string, XElement> LazyInitializeProfileDefinitionByName()
        {
            if (!HasProfileData)
            {
                throw new ("Profile document does not have any profile definitions.");
            }

            ValidateMetadata();

            return _profileXDoc.Value
                .Descendants("Profile")
                .ToDictionary(
                    x => x.AttributeValue("name"),
                    x => x,
                    StringComparer
                        .InvariantCultureIgnoreCase);
        }

        private List<ProfileAndResourceNames> LazyInitializeProfileResourceNames()
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
            MetadataHelper.ValidateProfileXml(_profileXDoc.Value.ToString());
            
            // Force creation of resource model
            using var readable = _readableProfileResourceModel.Value;

            // Force full iteration of the read content type
            var allReadableMembers = readable.GetAllResources()
                .SelectMany(r => r.AllContainedItemTypesOrSelf)
                .SelectMany(
                    rcb => rcb.Properties.Cast<ResourceMemberBase>()
                        .Concat(rcb.Collections)
                        .Concat(rcb.Extensions)
                        .Concat(rcb.References)
                        .Concat(rcb.EmbeddedObjects))
                .ToArray();

            using var writable = _writableProfileResourceModel.Value;

            // Force full iteration of the write content type
            var allWritableMembers = writable.GetAllResources()
                .SelectMany(r => r.AllContainedItemTypesOrSelf)
                .SelectMany(
                    rcb => rcb.Properties.Cast<ResourceMemberBase>()
                        .Concat(rcb.Collections)
                        .Concat(rcb.Extensions)
                        .Concat(rcb.References)
                        .Concat(rcb.EmbeddedObjects))
                .ToArray();

            if (_profileValidationReporter.ValidationFailures.Any())
            {
                var warnings = _profileValidationReporter.ValidationFailures
                    .Where(e => e.Severity == ProfileValidationSeverity.Warning)
                    .ToArray();

                if (warnings.Any())
                {
                    _logger.Warn(
                        $"Profile validation warnings occurred:{Environment.NewLine}{string.Join(Environment.NewLine, warnings.Select(e => e.Message))}");
                }

                var errors = _profileValidationReporter.ValidationFailures
                    .Where(e => e.Severity == ProfileValidationSeverity.Error)
                    .ToArray();

                if (errors.Any())
                {
                    _logger.Error(
                        $"Profile validation errors occurred:{Environment.NewLine}{string.Join(Environment.NewLine, errors.Select(e => e.Message))}");

                    throw new Exception("Profile validation errors occured.");
                }
            }
        }
    }
}

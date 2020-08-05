// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Metadata
{
    public class ProfileResourceNamesProvider
        : MetadataDocumentProviderBase,
          IProfileResourceNamesProvider,
          IProfileMetadataProvider
    {
        private readonly Lazy<IDictionary<string, XElement>> _profileDefinitionByName;
        private readonly Lazy<List<ProfileAndResourceNames>> _profileResources;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileResourceNamesProvider"/> class.
        /// </summary>
        public ProfileResourceNamesProvider()
        {
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
            return _profileDefinitionByName.Value.GetValueOrThrow(
                profileName,
                "Unable to find profile '{0}'.");
        }

        /// <summary>
        /// Gets a list of tuples containing the names of associated Profiles and Resources.
        /// </summary>
        /// <returns>A list of tuples containing associated Profile and Resource names.</returns>
        List<ProfileAndResourceNames> IProfileResourceNamesProvider.GetProfileResourceNames()
        {
            return _profileResources.Value;
        }

        private IDictionary<string, XElement> LazyInitializeProfileDefinitions()
        {
            return GetAllMetadataDocumentsInAppDomain(IsProfilesAssembly, "Profiles.xml")
                  .SelectMany(x => x.Descendants("Profile"))
                  .ToDictionary(
                       x => x.AttributeValue("name"),
                       x => x,
                       StringComparer.InvariantCultureIgnoreCase);
        }

        private static bool IsProfilesAssembly(Assembly assembly)
        {
            return EdFiConventions.IsProfileAssembly(assembly);
        }

        private List<ProfileAndResourceNames> LazyInitializeProfileResources()
        {
            return
                _profileDefinitionByName.Value.Values
                                        .SelectMany(GetProfileResources)
                                        .ToList();
        }

        private IEnumerable<ProfileAndResourceNames> GetProfileResources(XElement profileElt)
        {
            return
                from r in profileElt.Descendants("Resource")
                select new ProfileAndResourceNames
                       {
                           ProfileName = profileElt.AttributeValue("name"), ResourceName = (string) r.Attribute("name")
                       };
        }
    }
}

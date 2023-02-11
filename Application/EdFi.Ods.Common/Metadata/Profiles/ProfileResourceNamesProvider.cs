// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata.Profiles;

namespace EdFi.Ods.Features.Profiles
{
    public class ProfileResourceNamesProvider : IProfileResourceNamesProvider
    {
        private readonly IProfileMetadataProvider _profileMetadataProvider;
        private readonly Lazy<List<ProfileAndResourceNames>> _profileResources;

        public ProfileResourceNamesProvider(
            IProfileMetadataProvider profileMetadataProvider)
        {
            _profileMetadataProvider = profileMetadataProvider;

            _profileResources = new Lazy<List<ProfileAndResourceNames>>(LazyInitializeProfileResources);
        }

        /// <summary>
        /// Gets a list of tuples containing the names of associated Profiles and Resources.
        /// </summary>
        /// <returns>A list of tuples containing associated Profile and Resource names.</returns>
        List<ProfileAndResourceNames> IProfileResourceNamesProvider.GetProfileResourceNames()
        {
            return _profileResources.Value;
        }

        private List<ProfileAndResourceNames> LazyInitializeProfileResources()
        {
            return _profileMetadataProvider.ProfileDefinitionsByName.Values
                        .SelectMany(GetProfileResources).ToList();
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

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Extensions;
using log4net;

namespace EdFi.Ods.Common.Metadata.Profiles
{
    public class ProfileResourceNamesProvider : IProfileResourceNamesProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileResourceNamesProvider));
        private readonly IProfileMetadataProvider _profileMetadataProvider;

        public ProfileResourceNamesProvider(IProfileMetadataProvider profileMetadataProvider)
        {
            _profileMetadataProvider = profileMetadataProvider;
        }

        /// <inheritdoc cref="IProfileResourceNamesProvider.GetProfileResourceNames" />
        public List<ProfileAndResourceNames> GetProfileResourceNames()
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug("Initializing Profile and resource names...");
            }

            return _profileMetadataProvider.ProfileDefinitionsByName.Values.SelectMany(CreateNameTuples).ToList();

            IEnumerable<ProfileAndResourceNames> CreateNameTuples(XElement profileElt)
            {
                return profileElt.Descendants("Resource")
                    .Select(
                        r => new ProfileAndResourceNames
                        {
                            ProfileName = profileElt.AttributeValue("name"),
                            ResourceName = (string)r.Attribute("name")
                        });
            }
        }
    }
}

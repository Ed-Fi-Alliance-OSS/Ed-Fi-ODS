// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Xml.Linq;

namespace EdFi.Ods.Common.Metadata
{
    /// <summary>
    /// Implements an <see cref="IProfileMetadataProvider" /> that is registered as the "default" registration for the dependency
    /// needed by the EnforceAssignedProfileUsageFilter filter that is used by the action methods on the DataManagementControllerBase
    /// class. This provider is used to satisfy the dependency when the Profiles feature is not enabled.
    /// </summary>
    public class NullProfileMetadataProvider : IProfileMetadataProvider
    {
        public bool HasProfileData
        {
            get => false;
        }

        public XElement GetProfileDefinition(string profileName)
        {
            return null;
        }

        public IReadOnlyDictionary<string, XElement> ProfileDefinitionsByName { get; } = new Dictionary<string, XElement>();
    }
}

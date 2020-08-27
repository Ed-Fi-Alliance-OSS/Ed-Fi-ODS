// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Xml.Linq;

namespace EdFi.Ods.Common.Metadata
{
    public interface IProfileMetadataProvider
    {
        /// <summary>
        /// Indicates that the instance has profile metadata data.
        /// </summary>
        bool HasProfileData { get; }

        /// <summary>
        /// Gets the specified Profile definition by name.
        /// </summary>
        XElement GetProfileDefinition(string profileName);
    }
}

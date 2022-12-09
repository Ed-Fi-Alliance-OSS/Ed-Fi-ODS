// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Metadata.StreamProviders.Common;

namespace EdFi.Ods.Common.Metadata.StreamProviders.Profiles;

/// <summary>
/// Provides access to all profiles metadata streams available from embedded resources in Assemblies in the AppDomain. 
/// </summary>
public class AppDomainEmbeddedResourcesProfilesMetadataStreamsProvider
    : AppDomainEmbeddedResourceStreamsProviderBase, IProfilesMetadataStreamsProvider
{
    public IEnumerable<MetadataStream> GetStreams()
    {
        return base.GetStreams("Profiles.xml", EdFiConventions.IsProfileAssembly);
    }
}

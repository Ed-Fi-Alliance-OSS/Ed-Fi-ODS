using System.Collections.Generic;
using System.IO;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Metadata.Profiles;
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
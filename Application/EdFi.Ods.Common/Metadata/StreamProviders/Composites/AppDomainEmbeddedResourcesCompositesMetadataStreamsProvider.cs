using System.Collections.Generic;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Metadata.StreamProviders.Common;

namespace EdFi.Ods.Common.Metadata.StreamProviders.Composites;

/// <summary>
/// Provides access to all composite metadata streams available from embedded resources in Assemblies in the AppDomain. 
/// </summary>
public class AppDomainEmbeddedResourcesCompositesMetadataStreamsProvider
    : AppDomainEmbeddedResourceStreamsProviderBase, ICompositesMetadataStreamsProvider
{
    public IEnumerable<MetadataStream> GetStreams()
    {
        return base.GetStreams("Composites.xml", EdFiConventions.IsCompositesAssembly);
    }
}

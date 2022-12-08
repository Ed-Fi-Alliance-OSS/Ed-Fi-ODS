using System.Collections.Generic;
using System.IO;
using EdFi.Ods.Common.Metadata.StreamProviders.Common;
using EdFi.Ods.Common.Metadata.StreamProviders.Profiles;

namespace EdFi.Ods.Common.Metadata.StreamProviders.Composites;

/// <summary>
/// Defines a method for obtaining all available streams of Composites metadata.
/// </summary>
public interface ICompositesMetadataStreamsProvider
{
    /// <summary>
    /// Gets all available streams of Composites metadata.
    /// </summary>
    /// <returns>An enumerable of open streams.</returns>
    IEnumerable<MetadataStream> GetStreams();
};
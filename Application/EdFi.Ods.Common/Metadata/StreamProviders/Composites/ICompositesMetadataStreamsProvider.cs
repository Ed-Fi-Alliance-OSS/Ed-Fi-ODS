using System.Collections.Generic;
using EdFi.Ods.Common.Metadata.StreamProviders.Common;

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
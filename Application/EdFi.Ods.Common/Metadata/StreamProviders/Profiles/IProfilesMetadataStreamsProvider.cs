using System.Collections.Generic;
using EdFi.Ods.Common.Metadata.StreamProviders.Common;

namespace EdFi.Ods.Common.Metadata.StreamProviders.Profiles;

/// <summary>
/// Defines a method for obtaining all available streams of Profiles metadata.
/// </summary>
public interface IProfilesMetadataStreamsProvider
{
    /// <summary>
    /// Gets all available streams of Profiles metadata.
    /// </summary>
    /// <returns>An enumerable of open streams.</returns>
    IEnumerable<MetadataStream> GetStreams();
};
using System.IO;

namespace EdFi.Ods.Common.Metadata.StreamProviders.Common;

/// <summary>
/// Contains identifying information associated with an open <see cref="Stream" /> containing profiles or composite metadata.
/// </summary>
public class MetadataStream
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MetadataStream"/> class.
    /// </summary>
    /// <param name="name">The name of the stream (e.g. a file name or short description).</param>
    /// <param name="source">A description of the source of the stream (e.g. an assembly filename, a physical file path, a database name, etc.).</param>
    /// <param name="stream">The open stream containing the metadata.</param>
    public MetadataStream(string name, string source, Stream stream)
    {
        Name = name;
        Source = source;
        Stream = stream;
    }
    
    /// <summary>
    /// Gets the name of the stream (e.g. a file name or short description).
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Gets a description of the source of the stream (e.g. an assembly filename, a physical file path, a database name, etc.).
    /// </summary>
    public string Source { get; }

    /// <summary>
    /// Gets the open stream containing the metadata.
    /// </summary>
    public Stream Stream { get; }
}
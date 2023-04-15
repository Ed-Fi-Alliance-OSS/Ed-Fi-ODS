namespace EdFi.Ods.Api.Configuration;

/// <summary>
/// Implements a hash generator that returns the OdsInstanceId as a 64-bit value.
/// </summary>
public class OdsInstanceHashIdGenerator : IOdsInstanceHashIdGenerator
{
    /// <summary>
    /// Gets the supplied OdsInstanceId value as a 64-bit value.
    /// </summary>
    /// <param name="odsInstanceId">The tenant-specific identifier for the ODS instance.</param>
    /// <returns>The hash value.</returns>
    /// <remarks>This implementation is only appropriate for single-tenant deployments.</remarks>
    public ulong GenerateHashId(int odsInstanceId) => (ulong) odsInstanceId;
}
namespace EdFi.Ods.Api.Configuration;

/// <summary>
/// Defines a method for generating a 64-bit hash value for uniquely identifying an ODS instance.
/// </summary>
public interface IOdsInstanceHashIdGenerator
{
    /// <summary>
    /// Generates a unique hash value for an ODS instance.
    /// </summary>
    /// <param name="odsInstanceId">The tenant-specific identifier for the ODS instance.</param>
    /// <returns>The hash value.</returns>
    ulong GenerateHashId(int odsInstanceId);
}
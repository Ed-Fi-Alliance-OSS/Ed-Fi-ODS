using EdFi.Common;

namespace EdFi.Ods.Common.Configuration;

/// <summary>
/// Contains entries for the supported types of "derivative" ODS database instances.
/// </summary>
public class DerivativeType : Enumeration<DerivativeType>
{
    private DerivativeType(int value, string displayName)
        : base(value, displayName) { }

    /// <summary>
    /// A read-replica of the primary ODS database that is continuously kept up-to-date.
    /// </summary>
    public static readonly DerivativeType ReadReplica = new DerivativeType(2, "ReadReplica");
    
    /// <summary>
    /// A read-only, point-in-time snapshot or clone of the primary ODS instance.
    /// </summary>
    public static readonly DerivativeType Snapshot = new DerivativeType(1, "Snapshot");
}
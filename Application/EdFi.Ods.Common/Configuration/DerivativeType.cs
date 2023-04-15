using EdFi.Common;

namespace EdFi.Ods.Common.Configuration;

public class DerivativeType : Enumeration<DerivativeType>
{
    private DerivativeType(int value, string displayName)
        : base(value, displayName) { }

    public static readonly DerivativeType ReadWrite = new DerivativeType(1, "ReadWrite");

    public static readonly DerivativeType ReadReplica = new DerivativeType(2, "ReadReplica");
}
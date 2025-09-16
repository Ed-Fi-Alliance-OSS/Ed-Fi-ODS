using System;
using System.Reflection;

namespace EdFi.Ods.Common.Caching.CacheKeyProviders;

public class MethodSignatureCacheKeyProvider : IMethodSignatureCacheKeyProvider
{
    public ulong GetKey(MethodInfo method, object[] arguments)
    {
        switch (arguments.Length)
        {
            case 0:
                return XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name);

            case 1:
                return XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name, arguments[0]);

            case 2:
                return XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name, arguments[0], arguments[1]);

            case 3:
                return XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name, arguments[0], arguments[1], arguments[2]);

            default:
                throw new NotImplementedException(
                    "Support for generating cache keys for more than 3 arguments has not been implemented.");
        }
    }
}
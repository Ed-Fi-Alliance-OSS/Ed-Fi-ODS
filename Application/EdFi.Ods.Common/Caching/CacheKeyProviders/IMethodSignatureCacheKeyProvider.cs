using System.Reflection;

namespace EdFi.Ods.Common.Caching.CacheKeyProviders;

public interface IMethodSignatureCacheKeyProvider
{
    ulong GetKey(MethodInfo method, object[] args);
}
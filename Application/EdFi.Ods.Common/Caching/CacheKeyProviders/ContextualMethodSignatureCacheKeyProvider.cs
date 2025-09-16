using System;
using System.Reflection;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Caching.CacheKeyProviders;

public class ContextualMethodSignatureCacheKeyProvider<TContext>(IContextProvider<TContext> _contextProvider)
    : IMethodSignatureCacheKeyProvider
    where TContext : IContextHashBytesSource
{
    public ulong GetKey(MethodInfo method, object[] arguments)
    {
        var context = _contextProvider.Get();

        // Without context, we cannot generate a key here
        if (context == null)
        {
            throw new InvalidOperationException($"No context has been set for value of type '{typeof(TContext).Name}'.");
        }

        switch (arguments.Length)
        {
            case 0:
                return XxHash3Code.Combine(context.HashBytes, method.DeclaringType!.FullName, method.Name);

            case 1:
                return XxHash3Code.Combine(context.HashBytes, method.DeclaringType!.FullName, method.Name, arguments[0]);

            case 2:
                return XxHash3Code.Combine(
                    context.HashBytes,
                    method.DeclaringType!.FullName,
                    method.Name,
                    arguments[0],
                    arguments[1]);

            case 3:
                return XxHash3Code.Combine(
                    context.HashBytes,
                    method.DeclaringType!.FullName,
                    method.Name,
                    arguments[0],
                    arguments[1],
                    arguments[2]);

            default:
                throw new NotImplementedException(
                    "Support for generating contextual cache keys with more than 3 arguments has not been implemented.");
        }
    }
}